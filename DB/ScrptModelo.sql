CREATE DATABASE Encuestas;
USE Encuestas;

CREATE TABLE CUENTA(
	id INT IDENTITY(1,1) PRIMARY KEY,
	usuario VARCHAR(80) NOT NULL,
	password VARCHAR(90) NOT NULL
);


CREATE TABLE ENCUESTA(
	id	INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	descripcion VARCHAR(200)
);

CREATE TABLE DET_ENC (
	id INT IDENTITY(1,1) PRIMARY KEY,
	id_usuario INT NOT NULL,
	id_encuesta INT NOT NULL, 
	fecha DATE,
	CONSTRAINT fk_usuario_det_enc FOREIGN KEY(id_usuario) REFERENCES CUENTA(id),
	CONSTRAINT fk_encuesta_det_enc FOREIGN KEY(id_encuesta) REFERENCES ENCUESTA(id)

);

CREATE TABLE TIPO_CAMPO(
	 id INT IDENTITY(1,1) PRIMARY KEY,
	 nombre Varchar(10)
);

CREATE TABLE CAMPO (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	titulo VARCHAR(50) NOT NULL,
	es_requerido BIT NOT NULL, 
	id_tipo_campo INT NOT NULL,
	CONSTRAINT pk_tcampo_campo FOREIGN KEY(id_tipo_campo) REFERENCES TIPO_CAMPO(id)
);




CREATE TABLE ENC_CAMPO(
	id_encuesta  INT NOT NULL,
	id_campo INT NOT NULL,
	fecha DATE NOT NULL,
	CONSTRAINT pk_id_enc_campo PRIMARY KEY(id_encuesta, id_campo),
	CONSTRAINT fk_enc_enc_campo FOREIGN KEY(id_encuesta) REFERENCES ENCUESTA(id),
	CONSTRAINT fk_campo_enc_campo FOREIGN KEY(id_campo) REFERENCES CAMPO(id)
);
