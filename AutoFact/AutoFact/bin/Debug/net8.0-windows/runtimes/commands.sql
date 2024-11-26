SELECT * FROM Clients INNER JOIN Particuliers ON Particuliers.id = Clients.id;

SELECT Contrats.reference, SUM(ServicesClients.quantité * ServicesClients.prix) AS Total
FROM Contrats
INNER JOIN Clients ON Clients.id = Contrats.client
INNER JOIN StatutsContrats ON StatutsContrats.reference = Contrats.reference
INNER JOIN ServicesClients ON ServicesClients.reference = Contrats.reference
WHERE Contrats.client = 2 AND StatutsContrats.etat = 5
GROUP BY Contrats.reference;

INSERT INTO ServicesClients(id, reference, quantité, prix) VALUES(1, 'C004', 899.99, 1);
INSERT INTO Contrats(reference, id, client) VALUES('C004', 1, 2);
INSERT INTO StatutsContrats(reference, etat, dateAction) VALUES('C004', 5, '2024-11-20');