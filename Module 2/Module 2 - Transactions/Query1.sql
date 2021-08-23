select * from dbo.Person;

select @@TRANCOUNT;

BEGIN TRANSACTION

INSERT INTO dbo.Person VALUES ('John', 10000, '1330121457270');

BEGIN TRANSACTION
	INSERT INTO dbo.Person VALUES ('George', 6500, '1480323439720');
	select @@TRANCOUNT;
	select *from dbo.Person;
commit transaction

select XACT_STATE();
select @@TRANCOUNT;

select * from dbo.Person;

rollback transaction

select * from dbo.Person;


