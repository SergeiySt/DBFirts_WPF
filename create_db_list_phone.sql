create database db_list_phone;


use db_list_phone;
go


create table Country
(	
	id_country int not null identity(1,1) primary key,
	CName nvarchar(70) check (CName <> '') not null
);
go

create table ListPhone
(	
	id_listphone int not null identity(1,1) primary key,
	LSurname nvarchar(50) check (LSurname <> '') not null,
	LName nvarchar(50) check (LName  <> '') not null,
	LPobatkovi nvarchar(50) check (LPobatkovi  <> '') not null,
	LEmail nvarchar(50) check (LEmail  <> '') not null,
	id_country int not null,
	foreign key (id_country) references Country(id_country),
	LPhone int not null,
	LDateBrith date not null,
	LAddDate date not null
);
go

insert into Country  values
('Україна'),
('Польша'),
('США'),
('Франція'),
('Канада');
go

insert into ListPhone values
('Кириленко', 'Жора', 'Олександрович', '1234@gmail.com', 1, 0995545687, '1996-02-05', '2023-04-15'),
('Сидоренко', 'Світлана', 'Олександрівна', '3454@gmail.com', 2, 0899999987, '1990-06-05', '2023-04-21');
go