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