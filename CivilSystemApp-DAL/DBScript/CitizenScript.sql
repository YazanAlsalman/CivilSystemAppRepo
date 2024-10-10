
create table citizens
(
    Id int primary key identity(1,1),
	----------------
    Name nvarchar(100) not null,  
	Nationality nvarchar(100) not null,     
    Birthdate datetime not null,         
    Gender int not null,  
	IsDeleted bit,
	---------------
    Attachmentdata varbinary(max), 
	AttachmentType int ,
	---------------
	CreatedDate datetime not null,         
    ModifiedDate datetime null,         
    DeletedDate datetime null       

);

--drop table citizens

insert into citizens (Name, Nationality, Birthdate, Gender, IsDeleted, Attachmentdata, AttachmentType, CreatedDate, ModifiedDate, DeletedDate)
values 
('Anas Omar', 'Egyptian', '1985-07-22', 1, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Fatima Zeinab', 'Lebanese', '1992-09-10', 2, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Khaled Abdullah', 'Saudi', '1980-12-02', 1, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Sarah Hussein', 'Moroccan', '1995-11-11', 2, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Yasmeen Omar', 'Palestinian', '1993-03-27', 2, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Ali Ibrahim', 'Syrian', '1988-08-18', 1, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Zeinab Mohammed', 'Iraqi', '1997-01-05', 2, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Maryam Ahmed', 'Kuwaiti', '2000-04-12', 2, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Hassan Yousef', 'Emirati', '1991-06-30', 1, 0, NULL, NULL, GETDATE(), NULL, NULL),
('Yazan Omar', 'Jordanian', '1998-11-03', 1, 0, NULL, NULL, GETDATE(), NULL, NULL)

select * from citizens