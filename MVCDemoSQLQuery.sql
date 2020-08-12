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

drop table tblEmployee

Create table tblEmployee
(
 Id int Primary Key Identity(1,1),
 Name nvarchar(50),
 Gender nvarchar(10),
 City nvarchar(50),
 DateOfBirth DateTime
)

Insert into tblEmployee values('Mark','Male','London','01/05/1979')
Insert into tblEmployee values('John','Male','Chennai','03/07/1981')
Insert into tblEmployee values('Mary','Female','New York','02/04/1978')
Insert into tblEmployee values('Mike','Male','Sydeny','02/03/1974')
Insert into tblEmployee values('Scott','Male','London','04/06/1972')

Create procedure spGetAllEmployees
as
Begin
 Select Id, Name, Gender, City, DateOfBirth
 from tblEmployee
End

-- To insert employee data into tblEmployee table
Create procedure spAddEmployee  
@Name nvarchar(50),  
@Gender nvarchar (10),  
@City nvarchar (50),  
@DateOfBirth DateTime  
as  
Begin  
 Insert into tblEmployee (Name, Gender, City, DateOfBirth)  
 Values (@Name, @Gender, @City, @DateOfBirth)  
End

-- Run the application and navigate to the following URL.http://localhost/MVCDemo/EmployeeUsingBusinessLayer/Create
-- Submit the page without entering any data. You will now get a different error stating - Procedure or function 'spAddEmployee' expects 
-- parameter '@Name', which was not supplied.This is because, the following parameters of stored procedure "spAddEmployee" are all required.
--@Name
--@Gender
--@City
--@DateOfBirth
--To make all these parameters optional, modify the stored procedure
Alter procedure spAddEmployee    
@Name nvarchar(50) = null,    
@Gender nvarchar(10) = null,     
@City nvarchar (50) = null,     
@DateOfBirth DateTime  = null  
as    
Begin    
 Insert into tblEmployee (Name, Gender, City, DateOfBirth)    
 Values (@Name, @Gender, @City, @DateOfBirth)    
End

-- Create a stored procedure to update employee data.
Create procedure spSaveEmployee      
@Id int,
@Name nvarchar(50),      
@Gender nvarchar (10),      
@City nvarchar (50),      
@DateOfBirth DateTime 
as      
Begin      
 Update tblEmployee Set
 Name = @Name,
 Gender = @Gender,
 City = @City,
 DateOfBirth = @DateOfBirth
 Where Id = @Id 
End

-- Create a stored procedure to delete employee data by "ID"
Create procedure spDeleteEmployee
@Id int
as
Begin
 Delete from tblEmployee 
 where Id = @Id
End

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
