use dbGame
--create tblUsers and tblWords
--register-create user (tblUsers)
--login user-check for existing (tblUsers)
--add word (tblWords)
--remove word (tblWords)
--get all words (tblWords)

-----creating tables------

create table tblUsers(
userId int primary key,
userName varchar(20),
userAge int,
userPassword varchar(30))

-- get a length of words and then create tblWords
create proc proc_createTableForWords(@wordlen int)
as
begin
create table tblWords(
wordId int primary key,
word char(@wordlen))
end

--exec proc_createTableForWords 4

-- register-create user
create proc proc_createUser(@uname nvarchar(20),@uage int, @upassword nvarchar(30))
as
begin
declare 
@uid int
if(select count(*) from  users)!=0
		set @uid = (select max(userId) from users)+1;
else 
		set @uid	=101;	
insert into tblUSers(userId,userName,userAge,userPassword) values
(@uid ,@uname ,@uage , @upassword)
end

--login user-check

create proc proc_checkUserRole(@uid int, @upassword nvarchar(30),@username nvarchar(30) out)
as
begin
set @username =(select tb.userName
from tblUsers tb
where tb.userId=@uid and tb.userPassword=@upassword )
end

declare
@username nvarchar(30)
 
begin
exec proc_checkUserRole 101, 'oleg28', @username out
print @username
end

--add word
create proc proc_AddWord(@Word varchar(20))
as
begin
    declare
	@Id int;
	if(select count(*) from tblWords)!=0
		set @Id = (select max(wordId) from tblWords)+1;
	else 
		set @Id	=1;	
	insert into tblWords values (@Id, @Word);
end;

--remove word
create proc proc_RemoveWord(@Id int)
as
begin
	delete from tblWords where wordId=@Id
end;

--get all words
create proc proc_GetAllWords
as
begin
	select * from tblWords
end;





