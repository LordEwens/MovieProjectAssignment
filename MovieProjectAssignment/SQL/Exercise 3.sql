
-- Orders - Id (auto inc), OrderDate, CustomerId

-- Exercise 3 A
insert into Orders
values ('2015-01-01', (select Id from Customers where Firstname = 'Jonas'))

insert into OrderRows values ((select top 1 Id from Orders order by Id desc), 4, 49) -- Pulp fiction
insert into OrderRows values ((select top 1 Id from Orders order by Id desc), 1, 179) -- Interstellar

-- Exercise 3 B
insert into Orders
values ('2015-01-15', (select Id from Customers where Firstname = 'Peter'))
insert into OrderRows values ((select top 1 Id from Orders order by Id desc), (select Id from Movies where Title = 'The Wolf of Wall Street'), (select Price from Movies where Title = 'The Wolf of Wall Street'))
insert into OrderRows values ((select top 1 Id from Orders order by Id desc), (select Id from Movies where Title = 'The Wolf of Wall Street'), (select Price from Movies where Title = 'The Wolf of Wall Street'))

-- Exercie 3 C
insert into Orders
values ('2014-12-20', (select Id from Customers where Firstname = 'Jonas'))
insert into OrderRows values ((select top 1 Id from Orders order by Id desc), (select Id from Movies where Title = 'The Wolf of Wall Street'), (select Price from Movies where Title = 'The Wolf of Wall Street'))

select * from OrderRows
select * from Orders
select * from Movies
select * from Customers
