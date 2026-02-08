-- Start transaction
BEGIN;

-- 1️⃣ Delete all rows with Id >= 10000
DELETE FROM "Restaurants"
WHERE "Id" >= 10000;

-- 2️⃣ Reset the sequence so next Id starts from 10000
-- Replace Restaurants_Id_seq with your actual sequence name
SELECT setval(
               pg_get_serial_sequence('"Restaurants"', 'Id'),
               9999,  -- the sequence will start from 10000 next
               false  -- false means the next nextval() will return 10000
       );

-- 3️⃣ Optional: check table
SELECT * FROM "Restaurants" ORDER BY "Id";

-- Commit changes
COMMIT;