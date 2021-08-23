BEGIN TRANSACTION
UPDATE dbo.Country
set Capital = 'Cluj'
where Name = 'Romania'

BEGIN TRANSACTION
UPDATE dbo.Person
set Income = 1200
where Name = 'Bill'

ROLLBACK TRANSACTION