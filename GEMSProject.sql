create database GEMS
use GEMS



CREATE TABLE Admin(
Admin_Id int primary key,
Admin_Phone_Number varchar(20) not null,
Admin_mail varchar(50) not null,
Admin_pass varchar(50) not null);

create table Employee(
Employee_Id int identity(1,1) primary key,
First_Name varchar(50) not null,
Last_Name varchar(50) not null,
Date_of_Birth date not null,
NID varchar(20) not null,
Address varchar(50) not null,
phone_Number varchar(20) not null,
Gender varchar(15) not null,
Mobile_Banking_Account varchar(20) null,
Banking_Account varchar(20) null,
);

create table Salary(
Employee_Id int not null foreign key references Employee(Employee_Id),
Transaction_Id int identity(1,1) primary key,
Salary_Grade varchar(50) not null,
Transaction_Date date not null,
SalaryYear varchar(10) not null,
SalaryMonth varchar(10) not null,
Basic_salary decimal(10,2) not null,
Total_salary decimal(10,2) not null,
Addition decimal(10,2) null,
Deduction decimal(10,2) null,
Payment_Status varchar(50) not null,
);

create table Job_History(
Previous_Company varchar(50) not null,
Joining_Date date not null,
Ending_Date date not null,
Designation varchar(50) not null,
Employee_Id int not null foreign key references Employee(Employee_Id),
Job_History_Id int identity(1,1) primary key,
);

create table Attendance(
Entry_date date not null,
Entry_Month varchar(10) not null,
Entry_Year varchar(10) not null,
Entry_Time time null,
Exit_Time time null,
Employee_Id int not null foreign key references Employee(Employee_Id),
Over_Time int null,
);

create table Allowence(
Department_Id int not null,
House_rent decimal not null,
Medical_allowence decimal not null,
Transportation_fee decimal not null
);


create table Leave(
Leave_Id int identity(1,1) primary key,
Leave_Status varchar(50) not null,
Leave_From datetime null,
Leave_To datetime null,
Employee_Id int not null foreign key references Employee(Employee_Id),
Leave_Reason varchar(100) null,
);

create table Department(
Department_Id int not null,
Designation varchar(50) not null,
Title varchar(50) not null,
Employee_Id int not null foreign key references Employee(Employee_Id),
);

create table Salary_Grade(
Department_Id int not null,
Grade varchar(10) not null,
Basic_Salary decimal(10,2) not null)


select * from admin
select * from Employee
select * from Salary
select * from Allowence
select * from Attendance
select * from Department
select * from Salary_Grade
select * from Job_History
select * from Leave

insert into Salary values(1,'A','2023-02-15','2023','February',15000,20000,0,0,'p');
insert into Admin 
			values(1,'01614370880','ahmed@12','456789');


select COUNT(Entry_date), SUM(over_time) 
from Attendance join salary 
on Attendance.Employee_Id=2
where Attendance.Entry_Year='2023' and Attendance.Entry_Month='February'



select SUM(over_time) from Attendance join salary 
on Attendance.Employee_Id=Salary.Employee_Id

SELECT
  Employee_id,
  DATEDIFF(second, Entry_Time, Exit_Time) AS difference
FROM Attendance where Employee_Id=1 ;

select * from Salary_Grade join Department 
on Department.Department_Id=Salary_Grade.Department_Id 
join Allowence on Allowence.department_id = Department.Department_Id
where Department.Employee_Id=2

select * from Allowence 
join Department on Department.Department_Id=Allowence.Department_Id 
where Department.Employee_Id=1

select * from Salary_Grade join Department on Department.Department_Id=Salary_Grade.Department_Id


update Attendance set Over_Time=2 where Employee_Id=1 and Entry_date='2023-02-17';
select * from Attendance
insert into Attendance values('2022-02-11','07:30:00','15:30:00',1,4)


