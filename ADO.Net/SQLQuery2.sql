--get products 
alter procedure proc_getProducts
as
begin
select ProductName,QuantityPerUnit,UnitPrice,UnitsInStock from Products
end

exec proc_getProducts


--check
select*from tblUSer

alter proc proc_checkUserRole(@uname nvarchar(30), @upassword nvarchar(30),@urole nvarchar(30) out)
as
begin
set @urole =(select role 
from tblUser tb
where tb.username=@uname and tb.password=@upassword )
if (@urole is null)
	set @urole='invalid'
end

declare
@role nvarchar(30)
 
 begin
 exec proc_checkUserRole 'Oleg', 'oleg28', @role out
 print @role
 end

-- register-create user
alter proc proc_createUser(@uname nvarchar(30), @upassword nvarchar(30),@urole nvarchar(30))
as
begin
insert into tblUSer(username,password,role,age) values
(@uname, @upassword,@urole ,@uid )
end

exec proc_createUser 'Oleg', 'oleg28', 'admin', 28

select* from tblUSer