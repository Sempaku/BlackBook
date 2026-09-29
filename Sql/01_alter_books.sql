-- 01_alter_books.sql
-- Добавляет в существующую таблицу "Books" год издания ("Year")
-- и оглавление ("Toc", тип xml).
-- Для новой БД скрипт не нужен: колонки создаст EF Core по модели.

ALTER TABLE public."Books"
    ADD COLUMN IF NOT EXISTS "Year" integer NOT NULL DEFAULT 0,
    ADD COLUMN IF NOT EXISTS "Toc" xml NULL;
