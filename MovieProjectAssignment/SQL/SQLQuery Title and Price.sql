select Id from Orders where CustomerId = 1

select Movies.Title, OrderRows.Price, Orders.Id from OrderRows
left join Orders on OrderId=Orders.Id
left join Movies on MovieId=Movies.Id


