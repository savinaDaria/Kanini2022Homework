--1
select CategoryName, Description from Categories
order by CategoryName

--2
select ContactName,CompanyName,ContactTitle,Phone from Customers
order by Phone

--3
select FirstName,LastName,HireDate from Employees
order by HireDate desc

--4
select OrderID,OrderDate,ShippedDate,CustomerID,Freight from Orders
order by Freight desc

--5
select CompanyName,Fax,Phone,HomePage,Country from Suppliers
order by Country desc, CompanyName

--6
select CompanyName,ContactName from Customers
where City='Buenos Aires'

--7
select ProductName,UnitPrice,QuantityPerUnit from Products
where UnitsInStock=0

--8
select OrderDate,ShippedDate,CustomerID,Freight from Orders
where OrderDate='1997-19-05 00:00:00.000'

--9
select FirstName,LastName,Country from Employees
where Country!='USA'

--10
select EmployeeID,OrderID,CustomerID,RequiredDate,ShippedDate from Orders
where ShippedDate>RequiredDate

--11
select city,CompanyName,ContactName from Customers
where City like 'A%' or City like'B%'

--12
select * from orders 
where Freight>500.00

--13
select ProductName,UnitsInStock,UnitsOnOrder,ReorderLevel from Products
where ReorderLevel>0

--14
select CompanyName,ContactName,Fax from Customers
where Fax is not Null

--15
select FirstName,LastName from Employees
where ReportsTo is null

--16
select CompanyName,ContactName,Fax from Customers
where Fax is not Null
order by CompanyName

--17
select city,CompanyName,ContactName from Customers
where City like 'A%' or City like'B%'
order by ContactName desc

--18
select FirstName,LastName,BirthDate from Employees
where BirthDate between '1950' and '1960'

--19
select SupplierID,ProductName from Products
where SupplierID in
	(select SupplierID  from Suppliers
	where CompanyName in('Exotic Liquids','Grandma Kelly'+CHAR(39)+'s Homestead','Tokyo Traders'))

--20
select ShipPostalCode,OrderID,OrderDate from orders
where ShipPostalCode like '02389%'

--21
select ContactName,ContactTitle,CompanyName from Customers
where ContactTitle not like '%Sales%'

--22
select FirstName,LastName,City from Employees
where city !='Seattle'

--23
select city,country,ContactTitle,CompanyName from Customers
where country='Mexico' or country='Spain' and city!='Madrid'

--24
select concat(FirstName,' ',LastName,' can be reached at x',Extension) 'ContactInfo' from Employees

--25
select UnitsInStock,UnitPrice,UnitPrice*UnitsInStock 'price value of all units in stock',
Floor(UnitPrice*UnitsInStock)'price value of all units in stock rounded down',
Ceiling(UnitPrice*UnitsInStock)'price value of all units in stock rounded up' from Products
order by 'price value of all units in stock'

--26
SELECT (CONVERT(int,CONVERT(char(8),HireDate,112))-CONVERT(char(8),BirthDate,112))/10000.0 'HireAgeAccurate',
Round((CONVERT(int,CONVERT(char(8),HireDate,112))-CONVERT(char(8),BirthDate,112))/10000.0,0) 'HireAgeInAccurate' from Employees

--27
select FirstName,LastName,Format(BirthDate,'MMMM') 'Birth month' from Employees
where Format(BirthDate,'MMMM')=Format(GETDATE(),'MMMM')

--28
select Lower(ContactTitle) from Customers

--29  ???

--30
select ProductName from products p join Categories c
on p.CategoryID=c.CategoryID
where c.CategoryName='Seafood'

--31
select distinct companyname from Suppliers s join Products p
on s.SupplierID=p.SupplierID
where p.CategoryID=8

--32
select distinct companyname from Suppliers s join Products p
on s.SupplierID=p.SupplierID join Categories c
on p.CategoryID=c.CategoryID
where c.CategoryName='Seafood'

--33
select OrderID,FirstName,LastName from orders ord join Employees emp
on ord.EmployeeID=emp.EmployeeID
where ShippedDate>RequiredDate
order by LastName

--34
select ProductName,sum(Quantity) 'TotalUnits'  from [Order Details] ord_det join Products pr
on ord_det.ProductID= pr.ProductID join orders ord 
on ord_det.OrderID=ord.OrderID
group by ord_det.ProductID,ProductName
having sum(Quantity) <200

--35
select CompanyName, count(OrderID) 'Total number of orders' from orders o join Customers c
on o.CustomerID=c.CustomerID
where OrderDate>'1996-31-12 00:00:00.000'
group by CompanyName 
having count(OrderID)>15

--36
select CompanyName,o.OrderID,ord.UnitPrice*ord.Quantity-ord.UnitPrice*ord.Quantity*ord.Discount 'Total'  
from orders o join [Order Details] ord on o.OrderID=ord.OrderID 
join Products p on ord.ProductID=p.ProductID 
join Customers c on o.CustomerID=c.CustomerID
where ord.UnitPrice*ord.Quantity-ord.UnitPrice*ord.Quantity*ord.Discount>10000.0
order by 'Total' desc

