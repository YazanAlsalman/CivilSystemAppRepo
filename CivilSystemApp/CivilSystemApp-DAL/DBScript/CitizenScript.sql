
create table citizens
(
    Id int primary key identity(1,1),
	----------------
    Name nvarchar(100) not null,     
    Birthdate date not null,         
    Gender int not null,  
	IsDeleted bit,
	---------------
    Attachmentdata varbinary(max), 
	AttachmentType int    
);

--drop table citizens
select * from citizens