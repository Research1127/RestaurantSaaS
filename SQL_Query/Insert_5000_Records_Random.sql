BEGIN;

DO $$
DECLARE
user_id uuid;
    i integer;
    restaurant_name text;
    restaurant_type text[];
    surname text[];
    category text[];
    description text[];
    city text[];
    street text[];
    postal_code text;
    has_delivery boolean;
    email text;
    phone text;
BEGIN
    -- Get first user Id
SELECT "Id" INTO user_id FROM "AspNetUsers" LIMIT 1;

-- Arrays for generating random data
restaurant_type := ARRAY['Bistro','Cafe','Grill','Group','Kitchen'];
    surname := ARRAY['Reichel','Lockman','Schowalter','Becker','Johns','Rempel','Kemmer','Streich','Muller','Smith','Brown','Taylor','Wilson'];
    category := ARRAY['French','Italian','Vegetarian','American','Japanese','Mexican','Steakhouse'];
    description := ARRAY[
        'Famous for its delicious dishes and cozy atmosphere.',
        'Known for fresh ingredients and friendly service.',
        'Offering a wide variety of traditional and modern dishes.',
        'A perfect place for family dinners and casual outings.',
        'Exquisite flavors with a modern twist on classic recipes.'
    ];
    city := ARRAY['West Wardfurt','Port Gardnertown','Herminiostad','New Casandrabury','New Dollyshire','Garrisonville','Lake Sabrinafort','North Monteshire'];
    street := ARRAY['940 Rodrick Manor','2775 Royal Heights','0297 Frederique Place','3244 Florence Cliff','8045 Casper Mill','68556 Moses Mission','609 Fleta Mission','486 Raynor Hill'];

    -- Loop to insert 5000 restaurants starting at Id = 10000
FOR i IN 10000..14999 LOOP
        restaurant_name := surname[1 + floor(random()*array_length(surname,1))] || ' ' || restaurant_type[1 + floor(random()*array_length(restaurant_type,1))];
        postal_code := lpad((floor(random()*90000 + 10000))::text, 5, '0') || '-' || lpad((floor(random()*9000 + 1000))::text,4,'0');
        has_delivery := (random() > 0.5);
        email := lower(replace(restaurant_name,' ','') || '@example.com');
        phone := (floor(random()*900+100))::text || '-' || (floor(random()*900+100))::text || '-' || (floor(random()*9000+1000))::text;

INSERT INTO "Restaurants"
("Id","Name","Description","Category","HasDelivery","ContactEmail","ContactNumber","Address_City","Address_Street","Address_PostalCode","OwnerId")
VALUES
    (i, restaurant_name, description[1 + floor(random()*array_length(description,1))],
     category[1 + floor(random()*array_length(category,1))],
     has_delivery, email, phone,
     city[1 + floor(random()*array_length(city,1))],
     street[1 + floor(random()*array_length(street,1))],
     postal_code, user_id);
END LOOP;
END $$;

COMMIT;