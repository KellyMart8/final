create database Contador;

use Contador


create table EstadoResultado(
IngresosActividades varchar (7) not null,
DescuentosBonificaciones varchar (7) not null,
IngresosOperativosNetos char (7) not null,
CostoBienesVendidos char (7) not null,
ResultadoBruto varchar (7) not null,
GastosVentas char (7) not null,
GastosAdministración char (7) not null,
ResultadoOperacionesOrdinarias char (7) not null,
IngresosFinancieros char (7) not null,
GastosFinancieros char (7) not null,
IngresosExtraordinarios char (7) not null,
GastosExtraordinarios char (7) not null,
IngresosEjerciciosAnteriores char (7) not null,
GastosIngresosAnteriores char (7) not null,
ResultadoANTESImpuesto char (7) not null,
ImpuestoGanancias char (7) not null,
ResultadoNeto char (7) not null
)

select * from EstadoResultado


go
create proc InsertarEstadoResultado
@IngA char(7),@DB char(7),@ION char(7),
@CBV char(7),@RB char(7),@GV char(7),
@GA char(7),@ROO char(7),@IngF char(7),
@GF char(7),@IngE char(7),@GasE char(7),@IEA char(7),
@GIA char(7),@RAI char(7),@IG char(7),@RN char(7)
as
   insert into BalanceGeneral (IngresosActividades,DescuentosBonificaciones,
IngresosOperativosNetos,CostoBienesVendidos,ResultadoBruto,
GastosVentas,GastosAdministración,ResultadoOperacionesOrdinarias,
IngresosFinancieros,IngresosExtraordinarios,GastosExtraordinarios
,IngresosEjerciciosAnteriores,GastosIngresosAnteriores,
ResultadoANTESImpuesto,ImpuestoGanancias,ResultadoNeto) values (@IngA,@DB,
@ION,@CBV,@RB,@GV,@GA,@ROO,@IngF,@GF,@IngE,@GasE,@IEA,
@GIA,@RAI,@IG,@RN
) 
go
select * from EstadoResultado

create table Activos(
Activo varchar(max) not null,
Monto varchar(max),
)

create procedure Nactivos
@Activo varchar(max),
@Monto varchar(max)
as
insert into Activos values (@Activo, @Monto)

select * from Activos

create table Pasivos(
Pasivo varchar(max) not null,
Monto varchar(max),
)

create procedure Npasivos
@Pasivo varchar(max),
@Monto varchar(max)
as
insert into Activos values (@Pasivo, @Monto)

select * from Activos