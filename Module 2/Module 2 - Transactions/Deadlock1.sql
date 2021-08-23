BEGIN TRANSACTION

UPDATE dbo.Person
set Income = 1000
where Name = 'Bill'

UPDATE dbo.Country
set Capital = 'Timisoara'
where Name = 'Romania'

ROLLBACK TRANSACTION