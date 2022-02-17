create database dbDepartmentSales

use dbDepartmentSales

create table tblEMP(
empno int constraint pk_empno primary key check(empno>0),
empname varchar(50) not null,
salary float constraint chk_salary check(salary>0),
bossno int constraint fk_bossno foreign key references tblEMP(empno))

create table tblDEPARTMENT(
deptname varchar(50) constraint pk_deptname primary key,
floor int not null,
phone char(2),
empno int constraint fk_empno foreign key references tblEMP(empno) check(empno>0) not null
)

Alter table tblEMP
add deptname varchar(50) constraint fk_deptname foreign key references tblDEPARTMENT(deptname)

create table tblSALES(
salesno int constraint pk_salesno primary key check(salesno>0),
saleqty int check(saleqty>0),
itemname varchar(100) constraint fk_itemname foreign key references tblITEM(itemname) not null,
deptname varchar(50) constraint fk_salesdeptname foreign key references tblDEPARTMENT(deptname) not null,
)
sp_help tblEMP
create table tblITEM(
itemname varchar(100) constraint pk_itemname primary key ,
itemtype char(1) not null,
itemcolor varchar(50))

--DML

select * from tblEMP

insert into tblEMP(empno,empname,salary,deptname,bossno) values
('1'	,	'Alice'		,	'75000'		,	null,	null),
('2'	,	'Ned'		,	'45000'		,	null,	'1'),
('3'	,	'Andrew'	,	'25000'		,	null,	'2'),
('4'	,	'Clare'		,	'22000'		,	null,	'2'),
('5'	,	'Todd'		,	'38000'		,	null,	'1'),
('6'	,	'Nancy'		,	'22000'		,	null,	'5'),
('7'	,	'Brier'		,	'43000'		,	null,	'1'),
('8'	,	'Sarah'		,	'56000'		,	null,	'7'),
('9'	,	'Sophile'	,	'35000'		,	null,	'1'),
('10'	,	'Sanjay'	,	'15000'		,	null,	'3'),
('11'	,	'Rita'		,	'15000'		,	null,	'4'),
('12'	,	'Gigi'		,	'16000'		,	null,	'4'),
('13'	,	'Maggie'	,	'11000'		,	null,	'4'),
('14'	,	'Paul'		,	'15000'		,	null,	'3'),
('15'	,	'James'		,	'15000'		,	null,	'3'),
('16'	,	'Pat'		,	'15000'		,	null,	'3'),
('17'	,	'Mark'		,	'15000'		,	null,	'3')

select * from tblDEPARTMENT

insert into tblDEPARTMENT values
('Management',	'5'	,	'34'	,		'1'),
('Books'		,	'1'	,	'81'	,		'4'),
('Clothes'	,	'2'	,	'24'	,		'4'),
('Equipment'	,	'3'	,	'57'	,		'3'),
('Furniture'	,	'4'	,	'14'	,		'3'),
('Navigation',	'1'	,	'41'	,		'3'),
('Recreation',	'2'	,	'29'	,		'4'),
('Accounting',	'5'	,	'35'	,		'5'),
('Purchasing',	'5'	,	'36'	,		'7'),
('Personnel'	,	'5'	,	'37'	,		'9'),
('Marketing'	,	'5'	,	'38'	,		'2')

update tblEMP set deptname='Management' where empno=1
update tblEMP set deptname='Marketing' where empno in (2,3,4)
update tblEMP set deptname='Accounting' where empno in (5,6)
update tblEMP set deptname='Purchasing' where empno in (7,8)
update tblEMP set deptname='Personnel' where empno=9
update tblEMP set deptname='Navigation' where empno=10
update tblEMP set deptname='Books' where empno=11
update tblEMP set deptname='Clothes' where empno in (12,13)
update tblEMP set deptname='Equipment' where empno in (14,15)
update tblEMP set deptname='Furniture' where empno=16
update tblEMP set deptname='Recreation' where empno=17

select * from tblITEM

insert into tblITEM values
('Pocket Knife-Nile'	,		'E'	,		'Brown'),
('Pocket Knife-Avon',			'E'		,	'Brown'),
('Compass'	,			'N'		,	null),
('Geo positioning system'	,		'N'	,		null),
('Elephant Polo stick'		,	'R'		,	'Bamboo'),
('Camel Saddle'		,		'R'	,		'Brown'),
('Sextant'				,	'N'		,	null),
('Map Measure'			,	'N'		,null),
('Boots-snake proof'	,		'C'		,	'Green'),
('Pith Helmet'			,	'C'		,	'Khaki'),
('Hat-polar Explorer'		,	'C'	,		'White'),
('Exploring in 10 Easy Lessons'	,	'B'		,	null),
('Hammock'		,		'F'	,		'Khaki'),
('How to win Foreign Friends'	,	'B'	,		null),
('Map case'			,	'E'		,	'Brown'),
('Safari Chair'		,		'F'		,	'Khaki'),
('Safari cooking kit'	,		'F'	,		'Khaki'),
('Stetson'			,		'C'		,	'Black'),
('Tent - 2 person'	,			'F'	,		'Khaki'),
('Tent -8	 person'	,			'F'	,		'Khaki')

select * from tblSALES

insert into tblSALES values
('101'	,	'2'	,	'Boots-snake proof'	,	'Clothes'),
('102'	,	'1'	,	'Pith Helmet'		,	'Clothes')	,
('103'	,	'1'	,	'Sextant'		,		'Navigation'),
('104'	,	'3'	,	'Hat-polar Explorer',	'Clothes'),
('105'	,	'5'	,	'Pith Helmet'		,	'Equipment'),
('106'	,	'2'	,	'Pocket Knife-Nile'	,	'Clothes'),
('107'	,	'3'	,	'Pocket Knife-Nile'	,	'Recreation'),	
('108'	,	'1'	,	'Compass'		,	'Navigation')	,
('109'	,	'2'	,	'Geo positioning system'	,	'Navigation'),
('110'	,	'5'	,	'Map Measure'		,	'Navigation'),
('111'	,	'1'	,	'Geo positioning system'	,	'Books'),
('112'	,	'1'	,	'Sextant'		,		'Books'),
('113'	,	'3'	,	'Pocket Knife-Nile'	 , 	'Books'),
('114'	,	'1'	,	'Pocket Knife-Nile'	,	'Navigation'),	
('115'	,	'1'	,	'Pocket Knife-Nile'	,	'Equipment'),	
('116'	,	'1'	,	'Sextant'		,		'Clothes'),
('117'	,	'1'	,	'Sextant'		,		'Equipment'),
('118'	,	'1'	,	'Sextant'		,		'Recreation'),
('119'	,	'1'	,	'Sextant'		,		'Furniture'),
('120'	,	'1'	,	'Pocket Knife-Nile'	,	'Furniture'),
('121'	,	'1'	,	'Exploring in 10 easy lessons'	,'Books'),
('122'	,	'1'	,	'How to win foreign friends',	'Books'),
('123'	,	'1'	,	'Compass'		,	'Books'),
('124'	,	'1'	,	'Pith Helmet'	,		'Books'),
('125'	,	'1'	,	'Elephant Polo stick',		'Recreation'),
('126'	,	'1'	,	'Camel Saddle'		,	'Recreation')
