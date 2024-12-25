Use Hotel
Go

-- Välj alla kolumner och alla rader från tabellen Customer
SELECT * 
FROM Customer;

-- Denna fråga hämtar all information (alla kolumner) för alla rum i rumtabellen.
SELECT * 
FROM Room;

-- Denna fråga hämtar förnamn och efternamn för alla kunder vars förnamn börjar med bokstaven 'J'.
-- '%' används som en jokertecken som representerar vilken sekvens av tecken som helst efter 'J'.
SELECT FirstName, LastName 
FROM Customer
WHERE FirstName LIKE 'J%';

-- Välj alla kolumner från tabellen Room där priset per natt är större än 190
SELECT *
FROM Room
WHERE PricePerNight > 190;

-- Välj alla kolumner från tabellen Room och sortera resultaten efter pris per natt i fallande ordning
SELECT * 
FROM Room
ORDER BY PricePerNight DESC;

-- Välj alla kolumner från tabellen Room där rummet är av typen 'Double'
SELECT * 
FROM Room
WHERE RoomType = 'Double'
ORDER BY RoomType ASC;
