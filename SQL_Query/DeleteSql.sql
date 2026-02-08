BEGIN;

DELETE FROM "Restaurants"
WHERE "Id" IN (99904, 99905, 99906, 9994999, 9995000, 9995001, 9995002, 9995003);

COMMIT;

-- Optional: check the table after deletion
SELECT * FROM "Restaurants" ORDER BY "Id";