
-- Exercise 5

-- A
select Firstname, Lastname, PhoneNo, EmailAddress from Customers

-- B
select * from Movies
order by ReleaseYear desc

-- C
select Title from Movies
order by Price asc

-- D
select distinct Customers.Firstname, Customers.Lastname, Customers.DeliveryAddress, Customers.DeliveryZip, Customers.DeliveryCity from
Customers, Orders, OrderRows, Movies where Customers.Id = Orders.CustomerId and Orders.Id = OrderRows.OrderId and OrderRows.MovieId = (select Id from Movies where Title = 'The Wolf of Wall Street');

--select Firstname, Lastname, DeliveryAddress, DeliveryZip, DeliveryCity from Customers

--select Customers.Firstname, Customers.Lastname, Customers.DeliveryAddress, Customers.DeliveryZip, Customers.DeliveryCity, Orders.OrderDate from Customers, Orders where Orders.CustomerId = Customers.Id

--select distinct Customers.Firstname, Customers.Lastname, Customers.DeliveryAddress, Customers.DeliveryZip, Customers.DeliveryCity from
--Customers, Orders, OrderRows, Movies where Customers.Id = Orders.CustomerId and Orders.Id = OrderRows.OrderId and OrderRows.MovieId = 3;

--select Customers.Firstname, Customers.Lastname, Customers.DeliveryAddress, Customers.DeliveryZip, Customers.DeliveryCity from
--Customers, Movies

-- E

select Orders.Id, Orders.OrderDate, Customers.Firstname, Customers.Lastname, SUM(Price) as 'Price'  from OrderRows
left join Orders on OrderId=Orders.Id
left join Customers on Orders.CustomerId=Customers.Id
group by Orders.Id, Orders.OrderDate, Customers.Firstname, Customers.Lastname

-- Get Id, Date, Customer (Firstname, Lastname) and total cost of every individual order.

--select Orders.Id, Orders.OrderDate, Customers.Firstname, Customers.Lastname from Orders, Customers where Orders.CustomerId = Customers.Id

--select  SUM(Price) as 'Price', OrderId
--from OrderRows
--group by OrderId

--select Orders.Id , Orders.OrderDate
--from Orders
--left join OrderRows on Id = OrderRows.OrderId

--select * from OrderRows
--left join Orders on OrderId=Orders.Id
--left join Customers on Orders.CustomerId=Customers.Id

--select Orders.Id, Orders.OrderDate, Customers.Firstname, Customers.Lastname, Price  from OrderRows
--left join Orders on OrderId=Orders.Id
--left join Customers on Orders.CustomerId=Customers.Id




