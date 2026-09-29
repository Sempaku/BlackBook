-- ============================================================
-- 02_stored_procs.sql
-- Хранимые процедуры и функции PostgreSQL для таблицы "Books".
--
-- DML (INSERT/UPDATE/DELETE) — настоящие хранимые процедуры
-- (CREATE PROCEDURE, вызываются через CALL).
-- Выборки (SELECT) — хранимые функции (CREATE FUNCTION),
-- потому что в PostgreSQL процедуру нельзя использовать в FROM,
-- а функции можно: SELECT * FROM fn_books_select().
-- ============================================================

-- INSERT: добавляет книгу, возвращает Id новой записи (INOUT)
CREATE OR REPLACE PROCEDURE public.sp_books_insert(
    p_title text,
    p_author text,
    p_genre text,
    p_year integer,
    p_pages integer,
    p_toc xml,
    INOUT p_new_id integer)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO public."Books" ("Title", "Author", "Genre", "Year", "Pages", "Toc")
    VALUES (p_title, p_author, p_genre, p_year, p_pages, p_toc)
    RETURNING "Id" INTO p_new_id;
END;
$$;

-- UPDATE: обновляет данные книги по Id
CREATE OR REPLACE PROCEDURE public.sp_books_update(
    p_id integer,
    p_title text,
    p_author text,
    p_genre text,
    p_year integer,
    p_pages integer,
    p_toc xml)
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE public."Books"
    SET "Title" = p_title,
        "Author" = p_author,
        "Genre"  = p_genre,
        "Year"   = p_year,
        "Pages"  = p_pages,
        "Toc"    = p_toc
    WHERE "Id" = p_id;
END;
$$;

-- DELETE: удаляет книгу по Id
-- (связанные BookFile/UserBookProgress/Rating удаляются каскадом)
CREATE OR REPLACE PROCEDURE public.sp_books_delete(p_id integer)
LANGUAGE plpgsql
AS $$
BEGIN
    DELETE FROM public."Books" WHERE "Id" = p_id;
END;
$$;

-- SELECT: все книги
CREATE OR REPLACE FUNCTION public.fn_books_select()
RETURNS TABLE (
    "Id"    integer,
    "Title" text,
    "Author" text,
    "Genre" text,
    "Year"  integer,
    "Pages" integer,
    "Toc"   xml)
LANGUAGE sql
STABLE
AS $$
    SELECT b."Id", b."Title", b."Author", b."Genre", b."Year", b."Pages", b."Toc"
    FROM public."Books" b
    ORDER BY b."Id";
$$;

-- SELECT: книга по Id
CREATE OR REPLACE FUNCTION public.fn_books_get_by_id(p_id integer)
RETURNS TABLE (
    "Id"    integer,
    "Title" text,
    "Author" text,
    "Genre" text,
    "Year"  integer,
    "Pages" integer,
    "Toc"   xml)
LANGUAGE sql
STABLE
AS $$
    SELECT b."Id", b."Title", b."Author", b."Genre", b."Year", b."Pages", b."Toc"
    FROM public."Books" b
    WHERE b."Id" = p_id;
$$;

-- Поиск по названию, автору и оглавлению (без учета регистра).
-- Поиск по XML-оглавлению: "Toc"::text ILIKE — ищет по текстовому
-- содержимому XML (заголовки глав внутри CDATA).
CREATE OR REPLACE FUNCTION public.fn_books_search(p_query text)
RETURNS TABLE (
    "Id"    integer,
    "Title" text,
    "Author" text,
    "Genre" text,
    "Year"  integer,
    "Pages" integer,
    "Toc"   xml)
LANGUAGE sql
STABLE
AS $$
    SELECT b."Id", b."Title", b."Author", b."Genre", b."Year", b."Pages", b."Toc"
    FROM public."Books" b
    WHERE b."Title"  ILIKE '%' || p_query || '%'
       OR b."Author" ILIKE '%' || p_query || '%'
       OR b."Toc"::text ILIKE '%' || p_query || '%'
    ORDER BY b."Id";
$$;
