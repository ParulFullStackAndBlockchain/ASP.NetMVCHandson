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

select tblDepartment.Name, COUNT(*) as Total
from tblEmployee
Join tblDepartment
on tblDepartment.Id = tblEmployee.DepartmentId
group by tblDepartment.Name
order by Total

ALTER TABLE tblDepartment
ADD IsSelected BIT

--If you want HR department to be selected by default when the dropdownlist is loaded, set "IsSelected=1" for the "HR" department row.
Update tblDepartment Set IsSelected = 1 Where Id = 2

--If you now want "IT" department to be selected, instead of "HR", set "IsSelected=1" for "IT" department and "IsSelected=0" 
--for "HR" department.
Update tblDepartment Set IsSelected = 1 Where Id = 1
Update tblDepartment Set IsSelected = 0 Where Id = 2


CREATE TABLE tblCity
(
 ID INT IDENTITY PRIMARY KEY,
 Name NVARCHAR(100) NOT NULL,
 IsSelected BIT NOT NULL
)

Insert into tblCity values ('London', 0)
Insert into tblCity values ('New York', 0)
Insert into tblCity values ('Sydney', 1)
Insert into tblCity values ('Mumbai', 0)
Insert into tblCity values ('Cambridge', 0)

select * from tblCity

-- For Topic "Using displayname, displayformat, scaffoldcolumn attributes in asp.net mvc application"
drop table tblEmployee

drop table tblCity

drop table tblDepartment

Create table tblEmployee
(
 Id int primary key identity,
 FullName nvarchar(100),
 Gender nvarchar(10),
 Age int,
 HireDate DateTime,
 EmailAddress nvarchar(100),
 Salary int,
 PersonalWebSite nvarchar(100)
)

Insert into tblEmployee values
('John Smith', 'Male', 35, '2007-01-02 17:53:46.833', 'JohnSmith@pragimtech.com', 45000, 'https://in.yahoo.com/?p=us')
Insert into tblEmployee values
('Mary Jane', NULL, 30, '2009-05-02 19:43:25.965', 'MaryJane@pragimtech.com', 35000, 'https://in.yahoo.com/?p=us')

Alter table tblEmployee Add Photo nvarchar(100), AlternateText nvarchar(100)

Update tblEmployee set Photo='~/Photos/JohnSmith.png', AlternateText = 'John Smith Photo' where Id = 1

Update tblEmployee set Photo='~/Photos/MaryJane.png', AlternateText = 'Mary Jane Photo' where Id = 2





