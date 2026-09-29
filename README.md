# BlackBook — домашняя библиотека

Веб-приложение для ведения домашней библиотеки. Данные о книгах лежат в PostgreSQL, файлы книг (PDF) — в облачном хранилище MEGA, оглавления — в XML-поле, редактируются через WYSIWYG-редактор.

## Что умеет

- список книг с поиском по названию, автору и оглавлению
- карточка книги: данные, оглавление, чтение PDF прямо в браузере
- добавление и редактирование книг; оглавление набирается в редакторе (Summernote) и сохраняется в БД как XML
- прогресс чтения и оценка каждой книги
- REST API со Swagger

## Стек

ASP.NET Core 6 (Razor Pages), EF Core 6 + Npgsql, PostgreSQL 16, Summernote, Swashbuckle.

## Запуск через Docker

```
docker compose up -d --build
```

- приложение: http://localhost:8080 (корень редиректит на список книг)
- Swagger: http://localhost:8080/swagger
- PostgreSQL поднимается рядом, снаружи доступен на 5433 — чтобы не конфликтовать с локальным, если он уже есть

При первом старте контейнера БД сама создаёт таблицы и хранимые процедуры: скрипты из `Sql/docker-init` выполняются через `docker-entrypoint-initdb.d`. Строка подключения передаётся приложению переменной окружения `ConnectionStrings__DefaultConnection`.

Если Docker Hub не отдает образы, postgres можно стянуть через зеркало:

```
docker pull mirror.gcr.io/library/postgres:16-alpine
docker tag mirror.gcr.io/library/postgres:16-alpine postgres:16-alpine
```

Данные БД живут в volume `pgdata`. Полный снос вместе с данными: `docker compose down -v`.

## Запуск без Docker

1. Поднять PostgreSQL, создать базу. Строка подключения — в `Src/BlackBook.Api/appsettings.json` (или в переменной окружения `ConnectionStrings__DefaultConnection`).
2. При первом запуске EF Core создаст таблицы сам (`EnsureCreated`).
3. Выполнить `Sql/02_stored_procs.sql` — создаёт процедуры и функции. Если база старая, без колонок года и оглавления, — сначала `Sql/01_alter_books.sql`.
4. `dotnet run --project Src/BlackBook.Api`

## Как устроено

Трёхзвенная архитектура, репозитории → сервисы → UI/API:

| Проект | Что в нём |
|---|---|
| `BlackBook.Data` | модели, контекст EF Core, репозитории |
| `BookStorageService`, `RatingService`, `UserBookProgressService` | бизнес-логика |
| `Mega.Client`, `MegaService` | обёртка над облачным хранилищем MEGA |
| `BlackBook.Api` | Razor Pages + REST API |

Вся работа с книгами в БД идёт через хранимые процедуры и функции PostgreSQL (скрипт — `Sql/02_stored_procs.sql`):

- `sp_books_insert` / `sp_books_update` / `sp_books_delete` — DML, вызываются через `CALL`; insert возвращает id новой записи через INOUT-параметр
- `fn_books_select` / `fn_books_get_by_id` / `fn_books_search` — выборки. Выборки сделаны функциями, а не процедурами, потому что в PostgreSQL процедуру нельзя использовать в `FROM`

Поиск по оглавлению — приведение XML к тексту: `"Toc"::text ILIKE '%запрос%'`.

Оглавление хранится так: HTML из редактора сам по себе не валидный XML (незакрытые теги и прочее), поэтому он оборачивается в CDATA-секцию — `<toc><html><![CDATA[ ... ]]></html></toc>`. XML в базе остаётся валидным, а содержимое доступно и для показа, и для поиска. Логика — `BlackBook.Data/Utils/TocXml.cs`.

## Известные нюансы

- чтобы приложить к книге PDF, нужно подключиться к MEGA (страница MegaLogin); без подключения книга спокойно создаётся, просто без файла
- при удалении книги файл из MEGA пока не удаляется (TODO в `Library.cshtml.cs`)
- миграций EF нет, таблицы создаёт `EnsureCreated`; для существующей базы — `Sql/01_alter_books.sql`
