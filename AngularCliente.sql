--crear base de datos
create database [Nombre de tu base de datos]
----crear tablas
create table Cliente(
	[id] [int] NOT NULL PRIMARY KEY,
	[nombre] [varchar](150) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[rfc] [char](13) NULL,
	[correo] [varchar](150) UNIQUE NULL,
	[telefono] [varchar](15) NULL,
);

create table usuario(
	id int not null primary key identity(1,1),
	Usuario varchar(150) not null unique,
	nombre varchar(150) not null,
	email varchar(150) not null unique,
	pwd varchar(150) not null,
	telefono varchar(150),
	[admin] char(1) check([admin]='s' or [admin] = 'n'),
	activo char(1) check(activo='s' or activo = 'n')

)

create table pedido(
	idPedido int not null identity(1001,1),
	idCliente int not null references Cliente(id) on delete no action on update no action,
	NombrePedido varchar(150),
	Observaciones varchar(2000)
	primary key(idPedido,IdCliente)

)

alter table pedido alter column precio numeric(12,2) check(precio > 0)


select * from pedido
--insertar datos a la tabla
insert into cliente values(0,' ',' ',' ',' ',' ');
insert into cliente values(1,'Jose','Alamos','331314544','jose1@hotmail.com','99584394646');
insert into cliente values(2,'fernando','jaramillo','sasad122','fernando@hotmail.com','6345444646');
insert into cliente values(3,'juan alberto','canteras','2333114s','jAlberto@hotmail.com','66114444646');
insert into cliente values(4,'pedro vazques','veracruz','xxxxxxxxxxx','pVazques@hotmail.com','777444545');
insert into cliente values(5,'valentil elizalde','paris','zzzzzzzzz','vElizald@hotmail.com','545455121');
insert into cliente values(6,'hector herrera','las vegas','ssssssssss','HH@hotmail.com','33232246461');




--crear procedimiento almacenado

alter proc spConsultar(@id int)
as
begin
	if not exists(select * from cliente where id = @id)begin
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

alter proc spDeleteClient(@id int)
as
begin
	
	delete from pedido where idCliente = @id
	
end


--triggers



alter trigger dbo.deleteCliente on dbo.pedido
after delete
as
begin
	declare @idPedido int,
			@idCliente int,
			@nombrePedido varchar(150),
			@precio numeric(12,2),
			@Observaciones varchar(2000)

	declare MiCursor cursor for select * from deleted
	open Micursor
	fetch next from miCursor into @idPedido,@idCliente,@nombrePedido, @Observaciones,@precio
	while(@@FETCH_STATUS = 0)begin
		if not exists(select * from pedido where idCliente = @idCliente)begin
			delete from cliente where id = @idCliente
		end
		fetch next from miCursor into @idPedido,@idCliente,@nombrePedido, @Observaciones,@precio
	end
	close MiCursor
	deallocate miCursor
	
end