--<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<DATABASE FOR MINI_PROJECT>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>--

-->1... Train Details <--
use RR_system
Create Table Traindetail (Train_id numeric(5)  not null primary key , 
Train_name varchar(70) not null , 
City_of_Departure varchar(80) not null ,
City_of_Arrival varchar(90) not null,
Status_of_Train bit not null default 1)
Insert into Traindetail values
(12341,'GORAKHPUR EXP','DELHI JN.', 'GORAKHPUR JN.',1),
(22334,'KANPUR SHATABDI EXP','DELHI JN.','KANPUR JN.',1),
(22436,'VANDE BHARAT EXP','NEW DELHI','KANPUR CENTRAL',0),	
(10112,'Mailani Non-Stop','BAHRAICH','GONDA',1),
select * from Traindetail


----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>

--->2.. ADMIN <---
create table Admindetails(Admin_id int  primary key not null,
Admin_name varchar(25) not null,
UPDATE Admindetails
SET Admin_password = 'infinite'
WHERE Admin_name = 'sharad';
select * from Admindetails


----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>



--->3.. USER DETAILS <---
create table Userdetails(S_no int identity ,userID varchar(10) primary key not null, 
userPassword varchar(16) not null , 
userEmail varchar(50) not null)
select * from Userdetails


----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>


--->4.. TICKET CONFIRMATION <----
Create Table Ticket_Booking (Train_id numeric(5) foreign key references Traindetail(Train_id),
userID varchar(10) foreign key references Userdetails (userID),
Ticket_no numeric(4) Primary key not null, 
Class varchar(7) not null)
select * from Ticket_Booking
alter table Ticket_booking drop column Train_name



----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>



--->5..TICKET CANCELLATION <----
Create Table Ticket_Cancellation(Cancellation_Id numeric(5) Primary key not null,
Ticket_no numeric(4) foreign key references Ticket_Booking(Ticket_no) not null,
_status varchar(20),
Train_id  numeric (5) foreign key references Traindetail(Train_ID) not null,
refundAmt int )
select * from Ticket_Cancellation
select * from Ticket_Booking



----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>


--->6..SEAT AVAILABILITY <---
create table Seat_available (serial_num int  identity not null,
Train_Id  numeric(5) foreign key references  Traindetail (Train_id) not null,
[1AC] numeric(5) not null,
[2AC] numeric(5) not null,
SL numeric(5) not null)
select * from Seat_available
insert into Seat_available values 
(12341,50,80,150),
(22334,50,80,150),
(22436,50,80,150)


----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>


--->7..CLASS PRICES<---
create table Class_price (serial_num int identity not null,
Train_no numeric(5) foreign key references  Traindetail (Train_id) not null,
 [1AC] numeric(5) not null,
 [2AC] numeric(5) not null,
 SL numeric(5) not null)
 insert into Class_price values( 12341, 4000,2700,1200),
 (22334,4000,2500,800),
 (22436,4000,2400,1000)

 select * from Class_price
 
 ----------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>

---> creating Stored Procedure for ticket Booking.....
Create or alter proc
SeatAvl(@trainid int, @class varchar(20))
as
begin

if @class='1Ac'
update Seat_available set [1AC] =[1AC]-1 where Train_id=@trainid

else if @class ='2Ac'
update Seat_available set [2AC] =[2AC]-1 where Train_id=@trainid

else if @class ='SL'
update Seat_available set [SL] =[SL]-1 where Train_id=@trainid
end


------------------------------------------------------------------------------------------>>>>>>>>>>>>>>>>>>>>>>


---> creating Stored Procedure for ticket Booking.....
Create or alter proc
Seatcancelled(@trainid int, @class varchar(20))
as
begin

if @class='1Ac'
update Seat_available set [1AC] =[1AC]-1 where Train_id=@trainid

else if @class ='2Ac'
update Seat_available set [2AC] =[2AC]-1 where Train_id=@trainid

else if @class ='SL'
update Seat_available set [SL] =[SL]-1 where Train_id=@trainid
end

--------------------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>

--procedure for seat availability

CREATE or alter PROCEDURE AddclassSeats( 
@TrainID NUMERIC(5),
@firstAcSeats int,
@SecAcSeats int,
@SLSeats int
)
AS
insert into 
Seat_available(Train_Id,[1AC],[2AC],[SL])
values
(@TrainID,@firstAcSeats,@SecAcSeats,@SLSeats)


----------------------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 
-- proceudure to add fair of 1ac,2ac and SL class

CREATE or alter PROCEDURE AddclassFair( 
@TrainNo NUMERIC(5),
@firstAcSeatsfare int,
@SecAcSeatsfare int,
@SLSeatsfare int
)
as
insert into
Class_price(Train_no,[1AC],[2AC],[SL]) 
values
(@TrainNo,@firstAcSeatsfare,@SecAcSeatsfare,@SLSeatsfare)

----------------------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>





