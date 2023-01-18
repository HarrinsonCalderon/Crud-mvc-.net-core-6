drop database Pub;
create database Pub;
use Pub;
create table Beer(
Beerld int identity(1,1) primary key,
NameB varchar(20),
FkBrandld int
);
create table Brand(
Brandld int identity(1,1) primary key,
NameB varchar(20)
);
alter table Beer add constraint fkbran foreign key(FkBrandld) references Brand(Brandld);


select * from Brand
insert into Brand values('Minerva');
insert into Brand values('Erdinger');
insert into Brand values('Modern Times');

select * from Beer
insert into Beer values('Beer Minerva',1);
insert into Beer values('Beer Erdinger',2);
insert into Beer values('Beer Modern Times',3);

select * from Brand inner join Beer
on Brand.Brandld=Beer.Beerld