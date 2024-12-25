Use Hotel
Go

-- V�lj alla kolumner och alla rader fr�n tabellen Customer
SELECT * 
FROM Customer;

-- Denna fr�ga h�mtar all information (alla kolumner) f�r alla rum i rumtabellen.
SELECT * 
FROM Room;

-- Denna fr�ga h�mtar f�rnamn och efternamn f�r alla kunder vars f�rnamn b�rjar med bokstaven 'J'.
-- '%' anv�nds som en jokertecken som representerar vilken sekvens av tecken som helst efter 'J'.
SELECT FirstName, LastName 
FROM Customer
WHERE FirstName LIKE 'J%';

-- V�lj alla kolumner fr�n tabellen Room d�r priset per natt �r st�rre �n 190
SELECT *
FROM Room
WHERE PricePerNight > 190;

-- V�lj alla kolumner fr�n tabellen Room och sortera resultaten efter pris per natt i fallande ordning
SELECT * 
FROM Room
ORDER BY PricePerNight DESC;

-- V�lj alla kolumner fr�n tabellen Room d�r rummet �r av typen 'Double'
SELECT * 
FROM Room
WHERE RoomType = 'Double'
ORDER BY RoomType ASC;
