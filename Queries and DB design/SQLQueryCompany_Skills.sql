create database dbCompany

use dbCompany

create table tblSkills
(skillname varchar(20),
skill_description varchar(50))

sp_help tblSkills

alter table tblSkills
alter column skillname varchar(20) not null

alter table tblSkills
add constraint pk_skill primary key(skillname)

drop table tblSkills

create table tblSkills
(skillname varchar(20) constraint pk_skill primary key,
skill_description varchar(50))

--comments

alter table tblSkills
add industryRating int not null

alter table tblSkills
drop column industryRating

create table tblArea
(area_location varchar(10) constraint pk_location primary key,
zip_code char(4) not null)

sp_help tblArea

create table tblEmployee
(id char(4)constraint pk_employeeid primary key,
name varchar(20) not null,
location varchar(10) constraint fk_location foreign key references tblArea(area_location),
phone varchar(12),
salary float,
remarks varchar(1000))

sp_help tblEmployee

alter table tblEmployee
alter column phone  varchar(12) not null

create table tblEmployeeSkills
(Employee_Id char(4) references tblEmployee(id),
Skill_Name varchar(20) constraint fk_skill foreign key references tblSkills(skillname),
skill_level int,
constraint pk_emp_skill primary key(Employee_id,skill_name))

sp_help tblEmployeeSkills