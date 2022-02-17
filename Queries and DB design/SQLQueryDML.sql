use dbCompany

--ctrl+K+C -c comment
select *from tblArea

insert into tblArea values('XXX','1234')
insert into tblArea(area_location, zip_code) values('YYY','4321')
insert into tblArea( zip_code, area_location) values('4334','III')
insert into tblArea( zip_code, area_location) values('4354','KKK'),('0000','PPP')

select *from tblEmployee
insert into tblEmployee values('E001','ABC','XXX','9876543210',234566,'NOthing to say')
insert into tblEmployee values('E002','EFG','KKK','7654321098',876654,'Very Good')
insert into tblEmployee values('E003','HIJ','PPP','6677889900',8906654,'')
insert into tblEmployee values('E004','LMN','XXX','5544332211',876877,null)

select *from tblSkills
insert into tblSkills values('C#','PL'),('SQL','RDBMS'),('GIT','SCM'),('Java','Web')

select *from tblEmployeeSkills
insert into tblEmployeeSkills values('E001','C#',7),('E001','SQL',8),('E001','Git',7)
insert into tblEmployeeSkills values('E002','Git',7),('E002','SQL',8),('E002','Java',7)


update tblEmployeeSkills set skill_level=5 where Employee_Id='E001' and Skill_Name= 'C#'

update tblEmployeeSkills set skill_level = 9 where Employee_Id='E002' 

delete from tblEmployeeSkills where Employee_Id='E002' and Skill_Name='Java'