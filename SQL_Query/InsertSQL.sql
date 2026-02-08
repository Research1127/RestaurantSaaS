BEGIN;

-- Get the first user's Id
DO $$
    DECLARE
user_id uuid;
BEGIN
SELECT "Id" INTO user_id FROM "AspNetUsers" LIMIT 1;

INSERT INTO "Restaurants"
("Id", "Name", "Description", "Category", "HasDelivery", "ContactEmail", "ContactNumber", "Address_City", "Address_Street", "Address_PostalCode", "OwnerId")
VALUES
    (99904, 'Reichel Group', 'The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the odness of 100% Natural Ingredients', 'French', TRUE, 'Esmeralda_Gleichner@hotmail.com', '922-291-1167', 'West Wardfurt', '940 Rodrick Manor', '26883-2337', user_id),
    (99905, 'Lockman Inc', 'Ernomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support', 'Vegetarian', FALSE, 'Stan.Ruecker@hotmail.com', '(644) 920-6179 x0153', 'Port Gardnertown', '2775 Royal Heights', '09282-4591', user_id),
    (99906, 'Schowalter and Sons', 'Boston''s most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles', 'Italian', TRUE, 'Rafaela_Schmeler5@yahoo.com', '(438) 922-7115', 'Herminiostad', '0297 Frederique Place', '52445', user_id),
    (9994999, 'Becker, Howell and Morissette', 'New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016', 'Steakhouse', FALSE, 'Brandt79@gmail.com', '1-331-793-1148', 'New Casandrabury', '3244 Florence Cliff', '62491-2896', user_id),
    (9995000, 'Johns, Lueilwitz and D''Amore', 'New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart', 'American', TRUE, 'Cheyanne50@yahoo.com', '1-355-593-7533', 'New Dollyshire', '8045 Casper Mill', '82973', user_id),
    (9995001, 'Rempel and Sons', 'The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the odness of 100% Natural Ingredients', 'Mexican', TRUE, 'Krystina4@gmail.com', '1-842-652-8742', 'Garrisonville', '68556 Moses Mission', '17350', user_id),
    (9995002, 'Kemmer - Cassin', 'The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality', 'American', FALSE, 'Armand.Hackett@yahoo.com', '694.468.0768', 'Lake Sabrinafort', '609 Fleta Mission', '84042', user_id),
    (9995003, 'Streich - Quigley', 'The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality', 'Japanese', FALSE, 'Emile_Jacobs@yahoo.com', '666.496.7983', 'North Monteshire', '486 Raynor Hill', '12227-5673', user_id);

END $$;

-- Verify insertion
SELECT * FROM "Restaurants";

COMMIT;