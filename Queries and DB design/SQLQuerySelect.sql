use Northwind

select * from Products

--alias
select ProductName Product,QuantityPerUnit from Products

--products that are available in stock
select * from Products where UnitsInStock>0

select* from Products where UnitPrice<=20

select* from Products where Discontinued=1

select * from Products where UnitPrice >=20 and UnitPrice <= 40
select * from Products where UnitPrice between 25 and  34

select * from Orders
select * from Orders where Freight>50
select * from Orders where ShippedDate> '1996-07-11 00:00:00.000'
select * from Orders where EmployeeID=3

select * from Orders where ShipRegion is not null

select * from Orders where ShipName = 'Hanari Carnes'
select * from Orders where ShipName !='Rattlesnake Canyon Grocery'

-- % - 0 or any number
-- _ - one char
select * from Products where ProductName like 'T%'
select * from Products where ProductName like '_h%'

select ProductName from Products where ProductName like '%e%' and UnitPrice>15

select sum(UnitsOnOrder) 'Total units in hand' from Products

select avg(unitprice) 'Average price' from Products where CategoryID=2

select sum(UnitsInStock) from Products where Discontinued=1

select* from Products where SOUNDEX(ProductName)=Soundex('Chaai')

select SupplierID,count(ProductID) 'Number of supplied products' from Products 
group by SupplierID

select CategoryID,avg(unitprice) 'Average price' from Products
group by CategoryID


select CustomerID,count(OrderID) 'Number of orders' from Orders 
group by CustomerID

select ShipName,sum(Freight) 'Total freight'from Orders 
group by ShipName

select CustomerID,min(OrderDate) 'First Order Date'from Orders 
group by CustomerID

select * from Orders 

select ShipName,sum(Freight) 'Total freight'from Orders 
where ShipName like '%a%'
group by ShipName 
having sum(Freight)>100
order by 2 desc

select ProductName,UnitPrice from Products order by ProductName,UnitPrice 

--sub queries

select * from Categories
select * from Products
select* from Customers

select * from Products where CategoryID in
(select CategoryID  from Categories where CategoryName like 'C%')

select * from Orders where CustomerID in
(select CustomerID from Customers where Country='Mexico')

select distinct ShipName from Orders