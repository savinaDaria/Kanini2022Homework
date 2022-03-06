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

create table tblWords(
wordId int primary key,
word char(4))


-- register-create user
alter proc proc_createUser(@uname nvarchar(20),@uage int,@uid int out)
as
begin
if(select count(*) from  tblUsers)!=0
		set @uid = (select max(userId) from tblUsers)+1;
else 
		set @uid = 101;	
declare @upassword nvarchar(30)
set @upassword=@uname+CAST(@uage AS VARCHAR)
insert into tblUSers(userId,userName,userAge,userPassword) values
(@uid ,@uname ,@uage , @upassword)
end
select * from tblUsers
select * from tblWords

--login user-check

create proc proc_checkUser(@uid int, @upassword nvarchar(30),@username nvarchar(30) out)
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

--get count all users
create proc proc_GetAllUsersCount
as
begin
	select count(*) from tblUsers
end;
--add word
alter proc proc_AddWord(@Word varchar(20), @Id int out)
as
begin
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










