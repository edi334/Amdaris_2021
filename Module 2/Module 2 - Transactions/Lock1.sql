BEGIN TRANSACTION

select * from dbo.Person

ROLLBACK TRANSACTION

BEGIN TRANSACTION

UPDATE dbo.Person
set Income = 7500
where Name = 'Bill';

COMMIT TRANSACTION