--crear base de datos
create database WebServiceDesarrolloWebII
----crear tabla
create table Cliente2(
	[id] [int] NOT NULL PRIMARY KEY,
	[nombre] [varchar](150) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[rfc] [char](13) NULL,
	[correo] [varchar](150) UNIQUE NULL,
	[telefono] [varchar](15) NULL,
);
--insertar datos a la tabla
insert into cliente values(0,' ',' ',' ',' ',' ');
insert into cliente values(1,'Jose','Alamos','331314544','jose1@hotmail.com','99584394646');
insert into cliente values(2,'fernando','jaramillo','sasad122','fernando@hotmail.com','6345444646');
insert into cliente values(3,'juan alberto','canteras','2333114s','jAlberto@hotmail.com','66114444646');
insert into cliente values(4,'pedro vazques','veracruz','xxxxxxxxxxx','pVazques@hotmail.com','777444545');
insert into cliente values(5,'valentil elizalde','paris','zzzzzzzzz','vElizald@hotmail.com','545455121');
insert into cliente values(6,'hector herrera','las vegas','ssssssssss','HH@hotmail.com','33232246461');

--crear procedimiento almacenado

create proc spConsultar(@id int)
as
begin
	if(@id = 0)begin
		set @id = ((select max(id) from cliente)+1)
		select id=@id,nombre,direccion,rfc, correo ,telefono from cliente where id = 0
		return
	end
	select * from cliente where id = @id
end

alter proc spAddClient(@id int,@nombre varchar(150),@direccion varchar(150),@rfc char(13),@correo varchar(150),@telefono varchar(20))
as
begin
	if not exists(select id from cliente where id = @id)begin
			insert into cliente(id,nombre,direccion,rfc,correo,telefono)
			values(@id,@nombre,@direccion,@rfc,@correo,@telefono);
		end
	update cliente set nombre = @nombre,direccion = @direccion, rfc = @rfc,correo = @correo,telefono = @telefono
	where id = @id
end 

alter proc spConsultarClientes(@cadena varchar(150))
as
begin
	if(@cadena = '0')begin
			select*from cliente
		end
		else begin
			declare @cadena varchar(150)
			set @cadena = 'j'
			select * from cliente where nombre like '%' + @cadena +  '%' 
		end 
end
select * from cliente

spAddClient 7,'manuel','mochis','31334544','manuel21@hotmail.com','945394646'


spConsultarClientes 'fer'

spConsultar 0