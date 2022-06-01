CREATE TABLE patients (
    patientId int NOT NULL,
    fname varchar(50),
	lname varchar(50),
	sex varchar(10),
	age int,
	dob date,
    PRIMARY KEY (patientId),
    
);
CREATE TABLE doctor (
    doctorId int NOT NULL,
    fname varchar(50),
	lname varchar(50),
	sex varchar(10),
	specialization varchar(50),
	TFrom Time,
	Tto Time,
	PRIMARY KEY (doctorId)   );

create table appointments(
	 appId int Not Null,
	 patientId int,
	 doctorId int,
	 specializationRequired varchar(55),
	 visit date,
	 appointmentTime time,
    PRIMARY KEY (appId),
    FOREIGN KEY (doctorId) REFERENCES doctor(doctorId),
    FOREIGN KEY (patientId) REFERENCES patients(patientId)

);
Create table Users(
UserName varchar(33) Not Null ,
Fname varchar(55),
Lname varchar(55),
password varchar(50)
primary key(Username)
);


insert into dbo.Users values('YAYANAM','Yaswanth','Y','ok@fine123')
insert into dbo.Users values('yaswanthyayan','Yaswanth','Y','ok@fine12345')
