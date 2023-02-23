-- Table: public.Notice

-- DROP TABLE IF EXISTS public."Notice";

CREATE TABLE IF NOT EXISTS public."Notice"
(
    "No" smallint NOT NULL,
    "Title" text COLLATE pg_catalog."default",
    "Concent" text COLLATE pg_catalog."default",
    CONSTRAINT "Notice_pkey" PRIMARY KEY ("No")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Notice"
    OWNER to postgres;

	INSERT INTO 'Notice'
	("No",)
	VALUES
	('3210707001',DECODE(MD5('7001'),'HEX'),TRUE);