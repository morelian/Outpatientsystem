\set ON_ERROR_STOP 1
\set ECHO all
\i 01_CREATE_DATABASE.sql;
\c EduBaseDemo;
\i 05_CREATE_TABLE_INSERT.sql;