create database AssetManagement;

use AssetManagement;

create table UserType(
UserTypeId int identity(1,1) primary key,
UserType varchar(100)
)
INSERT INTO UserType (UserType)
VALUES 
('Admin'),
('Purchase Manager');

create table Logins(
LId int identity(1,1) primary key,
UserName varchar(100),
Password varchar(100),
UserTypeId int,
Foreign Key(UserTypeId) references UserType(UserTypeId)
)

INSERT INTO Logins (UserName, Password, UserTypeId)
VALUES
('admin', 'admin123', 1),
('ram', 'ram123', 2),
('sara', 'sara123', 2);

create table Users(
UserId int identity(1,1) primary key,
FirstName varchar(100),
LastName varchar(100),
Age int ,
Gender varchar(10),
Address varchar(200),
PhoneNumber int,
LId  int ,
Constraint ForeignKey Foreign key(LId) references Logins(LId)
);

INSERT INTO Users (FirstName, LastName, Age, Gender, Address, PhoneNumber, LId)
VALUES
('Rama', 'Lingam', 28, 'Male', 'Trivandrum', 987654321, 2),
('Sara', 'Joseph', 26, 'Female', 'Kochi', 876543210, 3);

create table AssetType(
AssetTypeId int identity(1,1) primary key ,
AssetName varchar(100)
)

INSERT INTO AssetType (AssetName)
VALUES
('Mobile'),
('Thermal Printer'),
('Sensor'),
('Gateway'),
('Laptop'),
('Boom Barrier');

create table AssetDefinition(
AssetDId int identity(1,1) primary key,
AssetDName varchar(100),
AssetTypeId int,
Constraint foreginKeyAssetType foreign key(AssetTypeId)references AssetType(AssetTypeId),
AssetDClass varchar(100)
)
INSERT INTO AssetDefinition (AssetDName, AssetTypeId, AssetDClass)
VALUES
('Geo Magnetic Sensor - Ground', 3, 'HW'),
('LoRaGateway - Tata', 4, 'HW'),
('Mobile Phone', 1, 'HW'),
('Laser Printer - Colour', 2, 'HW'),
('Laptop', 5, 'HW'),
('Desktop', 5, 'HW'),
('Mobile Charger', 1, 'HW'),
('Printer Charger', 2, 'HW'),
('Thermal Printer', 2, 'HW'),
('Lora Gateway - ICFOSS', 4, 'HW');

create table Vendor(
VendorId int identity(1,1) primary key,
VendorName varchar(100),
VendorType Varchar(40),
AssetTypeId int,
Constraint foreginKeyVAssetType foreign key(AssetTypeId)references AssetType(AssetTypeId),
Vendor_From Date,
Vendor_To Date,
VendorAddress varchar(200)
);
INSERT INTO Vendor (VendorName, VendorType, AssetTypeId, Vendor_From, Vendor_To, VendorAddress)
VALUES
('Samsung', 'Supplier', 1, '2019-06-15', '2099-12-31', 'India'),
('MI', 'Supplier', 1, '2019-06-15', '2099-12-31', 'India'),
('Vivo', 'Supplier', 1, '2019-06-15', '2099-12-31', 'India'),
('Softland India', 'Supplier', 4, '2019-06-15', '2099-12-31', 'India'),
('Mobio', 'Supplier', 1, '2019-06-15', '2099-12-31', 'India'),
('ICFOSS', 'Supplier', 3, '2019-06-15', '2099-12-31', 'India'),
('WIFI Solutions', 'Supplier', 4, '2019-06-15', '2099-12-31', 'India'),
('Talent Services', 'Supplier', 5, '2019-06-15', '2099-12-31', 'India');

create table PurchaseOrder(
PurchaseId int identity(1,1) primary key,
OrderNo varchar(10),
AssetDId int,
Constraint ForeignKeyAssetD Foreign Key(AssetDId) references AssetDefinition(AssetDId),
AssetTypeId int,
Constraint ForeignKeyAssetType Foreign Key(AssetTypeId) references AssetType(AssetTypeId),
Quantity  int,
VendorId int,
Constraint ForeignKeyVendor Foreign Key(VendorId) references Vendor(VendorId),
Purchase_Date date,
Purchase_Status varchar(100)
)
INSERT INTO PurchaseOrder 
(OrderNo, AssetDId, AssetTypeId, Quantity, VendorId, Purchase_Date, Purchase_Status)
VALUES
('PO101', 3, 1, 10, 1, '2024-01-10', 'PO - Raised with Supplier'),

('PO102', 9, 2, 5, 8, '2024-02-12', 'Awaiting Delivery by Supplier'),

('PO103', 1, 3, 8, 6, '2024-03-05', 'Consignment Received'),

('PO104', 2, 4, 4, 7, '2024-03-18', 'Asset Details registered internally'),

('PO105', 5, 5, 6, 4, '2024-04-02', 'Asset Allocated to Resources'),

('PO106', 7, 1, 12, 2, '2024-04-15', 'Identified Faulty'),

('PO107', 4, 2, 3, 5, '2024-05-01', 'Replaced - Repaired');

create table AssetMaster(
AssetMId int identity(1,1)primary key,
AssetTypeId int,
Constraint ForeignKeyMAssetType Foreign Key(AssetTypeId) references AssetType(AssetTypeId),
VendorId int,
Constraint ForeignKeyMVendor Foreign Key(VendorId) references Vendor(VendorId),
AssetDId int,
Constraint ForeignKeyMAssetD Foreign Key(AssetDId) references AssetDefinition(AssetDId),
Model varchar(40),
SNumber varchar(20),
Years varchar(10),
Updates Date,
warranty varchar(1),
AMfrom date,
AMto date
)
