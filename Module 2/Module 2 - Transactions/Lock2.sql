BEGIN TRANSACTION

UPDATE dbo.Person
set Income = 5500
where Name = 'Bill';

COMMIT TRANSACTION
