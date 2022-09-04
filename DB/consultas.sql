
use Encuestas;

INSERT INTO Cuenta(usuario, password)
VALUES('rm','123');

select * from cuenta;

insert into ENCUESTA(nombre,descripcion)
values ('enc1','desc');

insert into TIPO_CAMPO(nombre) values ('texto');

insert into CAMPO(nombre,titulo,es_requerido,id_encuesta,id_tipo_campo)
values('campo1','Campo1',1,1,1);