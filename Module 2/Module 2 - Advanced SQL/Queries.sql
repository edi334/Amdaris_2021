select * from dbo.Country;
select * from dbo.City;

select substring(Name,1,1) as CityThatStartsWith, AVG(Population) as Average from dbo.City
group by SUBSTRING(Name,1,1);

select Region, AVG(Population) as Average from dbo.Country
group by Region
having AVG(Population) > 20000;

insert into dbo.WesternCountry(Id, Name, Population)
select Id, Name, Population from dbo.Country
where Region = 'West';

select * from dbo.WesternCountry;

truncate table dbo.WesternCountry;

select * from dbo.WesternCountry;

delete dbo.Country
from dbo.Country inner join dbo.City on dbo.Country.Id = dbo.City.CountryId
where dbo.City.Name like 'P%';

select * from dbo.Country;

update dbo.City
set Population += 500
from dbo.Country inner join dbo.City on dbo.Country.Id = dbo.City.CountryId
where dbo.Country.Region = 'East';

select * from dbo.City;

insert into dbo.Country values (3, 'Spain', 50000, 'West');
insert into dbo.City values (3, 'Madrid', 3, 2000);
insert into dbo.City values (4, 'Barcelona', 3, 3000);

select Name, 
	(select SUM(Population) from dbo.City where dbo.City.CountryId = dbo.Country.Id) as CityPopulation
from dbo.Country;

select Name
from dbo.Country
where 2000 < (select SUM(Population) from dbo.City where dbo.City.CountryId = dbo.Country.Id);

select Region
from dbo.Country as C
group by Region
having 5000 < (select SUM(dbo.City.Population) from dbo.City left join dbo.Country on dbo.City.CountryId = dbo.Country.Id where dbo.Country.Region = C.Region);

select Name, Population
from dbo.City
where CountryId in (select Id from dbo.WesternCountry);

select dbo.City.Name, dbo.City.Population
from dbo.City left join dbo.Country on dbo.City.CountryId = dbo.Country.Id
where dbo.Country.Name not in ('Spain', 'Romania');

insert into dbo.Country values (4, 'Serbia', 15000, 'East');

select Name, Population
from dbo.Country as C
where exists (select CountryId from dbo.City where CountryId = C.Id);

select Name,
	case Region
	when 'West' then Population + 5000
	when 'East' then Population + 10000
	else Population
	end as NewPopulation
from dbo.Country