select* from Products

select* from Categories
select* from Customers
select* from Orders
select* from Employees
select* from Suppliers
select* from Products where CategoryID=
(select CategoryID from Categories where CategoryName='Confections')

--joins

select ProductName,CategoryName 
from Products join Categories 
on Products.CategoryID = Categories.CategoryID

select ContactName,OrderDate
from Customers join Orders 
on Orders.CustomerID = Customers.CustomerID

select FirstName,OrderDate
from Orders join Employees
on Orders.EmployeeID= Employees.EmployeeID


select* from Employees where EmployeeID not in(
select distinct EmployeeID from Orders)

select distinct ProductId from [Order Details]

select* from Customers where CustomerID not in
(select distinct CustomerID from Orders)

select ContactName,OrderDate
from Orders right outer join Customers 
on Orders.CustomerID = Customers.CustomerID

select OrderDate, CompanyName, ContactName
  from Orders left outer join Customers on Orders.CustomerID = Customers.CustomerID

  select OrderDate, CompanyName, ContactName
  from Orders right outer join Customers on Orders.CustomerID = Customers.CustomerID


  select ProductName,OrderDate,Quantity,od.UnitPrice,(Quantity*od.UnitPrice) 'Total Price'
  from 
  (Orders o join [Order Details] od
   on o.OrderID =od.OrderID) 
  join Products p on od.ProductID=p.ProductID

  select ProductName,CategoryName,ContactName
  from (Products p join Categories c
   on p.CategoryID =c.CategoryID) 
  join Suppliers s on p.SupplierID=s.SupplierID

  select ProductName,ContactName,OrderDate
  from Customers c 
  join Orders o on c.CustomerID =o.CustomerID
  join [Order Details] od on o.OrderID=od.OrderID
  join Products p on od.ProductID=p.ProductID
  where c.Country ='Mexico'

  select CompanyName, count(o.OrderID) 'Number of orders'
  from Customers c 
  join Orders o on c.CustomerID =o.CustomerID
  --where c.Country ='Mexico'
  group by CompanyName
  having count(o.orderid) >2
  order by count(o.orderid)

  select * from Employees
   
  select concat(emp.FirstName,'', emp.LastName) 'Employee Name',concat(manager.FirstName,'', manager.LastName) 'Manager Name'
  from Employees manager  join Employees emp on manager.EmployeeID=emp.ReportsTo

  select* from Employees cross join Products

  