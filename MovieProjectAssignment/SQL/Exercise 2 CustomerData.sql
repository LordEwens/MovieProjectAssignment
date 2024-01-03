

insert into Customers
(Firstname, Lastname, BillingAddress, BillingZip, BillingCity, DeliveryAddress, DeliveryZip, DeliveryCity, EmailAddress, PhoneNo)
values ('Jonas', 'Gray', '23 Green Corner Street', '56743', 'Birmingham',
'23 Green Comer Street', '56743', 'Birmingham', 'jonas.gray@hotmail.com', '0708123456')

insert into Customers
values ('Jane', 'Harolds', '10 West Street', '43213', 'London', '10 West Street',
'43213', 'London', 'jane_h77@gmail.com', '0701245512')

insert into Customers
values ('Peter', 'Birro', '12 Fox Street', '45681', 'New York', '89 Moose Plaza',
'45321', 'Seattle', 'peter_the_great@hotmail.com', '0739484322')

select * from dbo.Customers
