create table tblUSer
(username varchar(20) primary key,
password varchar(20),
role varchar(20),
age int)

select * from tblUSer

create procedure proc_getProducts
as
begin
select*from Products
end

exec proc_getProducts

create proc proc_getProductsByCateg(@cid int)
as
begin
select*from Products
where CategoryID=@cid
end
exec proc_getProductsByCateg 3



ALTER proc proc_getCategName(@cname nvarchar(30))
as
begin
select * from Products p join Categories c on 
p.CategoryID=c.CategoryID
where c.CategoryName=@cname
end

exec proc_getCategName 'Seafood'

select * from Categories
select*from Products  p join Categories c on 
p.CategoryID=c.CategoryID
where c.CategoryName='Seafood'

create proc proc_ProductCategName(@cid int)
as
begin
select p.ProductName,c.CategoryName from Products p join Categories c on 
p.CategoryID=c.CategoryID
where c.CategoryID=@cid
end

exec proc_ProductCategName 8


create proc proc_createUser(@uname nvarchar(30), @upassword nvarchar(30),@urole nvarchar(30),@uid int)
as
begin
insert into tblUSer(username,password,role,age) values
(@uname, @upassword,@urole ,@uid )
end

exec proc_createUser 'Oleg', 'oleg28', 'admin', 28

select * from tblUSer

alter proc proc_getCname(@cname varchar(20) out)
as
begin
set @cname=(select Categories.CategoryName from Categories where Categories.CategoryID=4)
end

declare
@cnameget varchar(20)
 
 begin
 exec proc_getCname @cnameget out
 print @cnameget
 end

 --
 select*from customers
alter proc proc_getOrderNumbers(@cname varchar(20) ,@ordercount int out)
as
begin
set @ordercount =(select count(o.OrderID) 
from Orders o 
where o.CustomerID=(select CustomerID from Customers where ContactName=@cname )
)
end

declare
@orders int
 
 begin
 exec proc_getOrderNumbers 'Ana Trujillo',@orders out
 print @orders
 end


 select count(o.OrderID) 
from Orders o 
where o.CustomerID=(select CustomerID from Customers where ContactName='Ana Trujillo')