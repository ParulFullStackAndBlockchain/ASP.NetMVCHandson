create database sample

create table tblEmployee
(
     EmployeeID int primary key,
     Name nvarchar(50),
     Gender nvarchar(50),
     City nvarchar(50)
)

Insert into tblEmployee values (101, 'John', 'Male', 'London')
Insert into tblEmployee values (102, 'John1', 'Male', 'London1')
Insert into tblEmployee values (103, 'John2', 'Male', 'London2')
Insert into tblEmployee values (104, 'John3', 'Male', 'London3')

select * from tblEmployee

Create table tblDepartment
(
 Id int primary key identity,
 Name nvarchar(50)
)

Insert into tblDepartment values('IT')
Insert into tblDepartment values('HR')
Insert into tblDepartment values('Payroll')

select * from tblDepartment

delete tblEmployee
drop table tblEmployee

Create table tblEmployee
(
 EmployeeId int Primary Key Identity(1,1),
 Name nvarchar(50),
 Gender nvarchar(10),
 City nvarchar(50),
 DepartmentId int
)

Alter table tblEmployee
add foreign key (DepartmentId)
references tblDepartment(Id)

Insert into tblEmployee values('Mark','Male','London',1)
Insert into tblEmployee values('John','Male','Chennai',3)
Insert into tblEmployee values('Mary','Female','New York',3)
Insert into tblEmployee values('Mike','Male','Sydeny',2)
Insert into tblEmployee values('Scott','Male','London',1)
Insert into tblEmployee values('Pam','Female','Falls Church',2)
Insert into tblEmployee values('Todd','Male','Sydney',1)
Insert into tblEmployee values('Ben','Male','New Delhi',2)
Insert into tblEmployee values('Sara','Female','London',1)
