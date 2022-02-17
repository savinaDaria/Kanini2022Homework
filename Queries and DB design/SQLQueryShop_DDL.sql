create database dbShop

use dbShop

create table tblCodes
(zip_code char(3) constraint pk_zipcode primary key,
area varchar(10) not null,
city varchar(10) ,
state varchar(20))


create table tblProduct
(id char(4) constraint pk_productid primary key,
name varchar(50) not null,
price_per_unit float constraint chk_Prod_price check(price_per_unit>0) ,
stockavailable int)

drop table tblProduct

sp_help tblCodes

sp_help tblProduct

create table tblSupplier
(supplier_id char(3) constraint pk_sid primary key,
name Varchar(20) Not null,
phone Varchar(12) Not null,
email varchar(50),
address varchar(30),
zip char(3) not null constraint fk_zip foreign key references  tblCodes(zip_code))

sp_help tblSupplier

create table tblProductSupplier (
  po_number int,
  product_id char(4)constraint fk_prodid foreign key references tblProduct(id),
  supplier_id char(3) references tblSupplier(supplier_id),
  date date not null,
  quantity int not null,
  constraint pl_productsupplier primary key (po_number, product_id, supplier_id)
)

sp_help tblProductSupplier