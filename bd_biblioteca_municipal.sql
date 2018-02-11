/*
SQLyog Ultimate v10.00 Beta1
MySQL - 5.1.41 : Database - bd_biblioteca_municipal
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bd_biblioteca_municipal` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bd_biblioteca_municipal`;

/*Table structure for table `tbl_autores` */

DROP TABLE IF EXISTS `tbl_autores`;

CREATE TABLE `tbl_autores` (
  `Clv_autor` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`Clv_autor`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_autores` */

insert  into `tbl_autores`(`Clv_autor`,`Nombre`) values (1,'MIGUEL DE CERVANTES'),(3,'Francisco minera'),(4,'MAQUIAVELO'),(5,'HENRY KISSINGER'),(6,'Richard beer'),(7,'Manuel torres Ramen'),(8,'Brian albers');

/*Table structure for table `tbl_clasificacion` */

DROP TABLE IF EXISTS `tbl_clasificacion`;

CREATE TABLE `tbl_clasificacion` (
  `Clv_clasificacion` int(11) NOT NULL AUTO_INCREMENT,
  `clasificacion` varchar(50) NOT NULL,
  PRIMARY KEY (`Clv_clasificacion`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_clasificacion` */

insert  into `tbl_clasificacion`(`Clv_clasificacion`,`clasificacion`) values (1,'NOVELA'),(2,'AVENTURA'),(3,'informatica'),(5,'HISTORIA');

/*Table structure for table `tbl_cliente` */

DROP TABLE IF EXISTS `tbl_cliente`;

CREATE TABLE `tbl_cliente` (
  `Clv_cliente` int(11) NOT NULL,
  `Clv_usuario` int(11) NOT NULL,
  PRIMARY KEY (`Clv_cliente`),
  KEY `Clv_usuario` (`Clv_usuario`),
  CONSTRAINT `tbl_cliente_ibfk_1` FOREIGN KEY (`Clv_usuario`) REFERENCES `tbl_usuario` (`Clv_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AVG_ROW_LENGTH=1 DELAY_KEY_WRITE=1;

/*Data for the table `tbl_cliente` */

insert  into `tbl_cliente`(`Clv_cliente`,`Clv_usuario`) values (48,24);

/*Table structure for table `tbl_devolucion` */

DROP TABLE IF EXISTS `tbl_devolucion`;

CREATE TABLE `tbl_devolucion` (
  `Clv_devolucion` int(11) NOT NULL,
  `Fecha_devolucion` varchar(30) NOT NULL,
  `Clv_prestamo` int(11) NOT NULL,
  PRIMARY KEY (`Clv_devolucion`),
  KEY `Clv_prestamo` (`Clv_prestamo`),
  CONSTRAINT `tbl_devolucion_ibfk_2` FOREIGN KEY (`Clv_prestamo`) REFERENCES `tbl_prestamo` (`Clv_prestamo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_devolucion` */

insert  into `tbl_devolucion`(`Clv_devolucion`,`Fecha_devolucion`,`Clv_prestamo`) values (1,'29/07/2014',1),(2,'23/32/3232',3),(3,'23/23/2323',2),(4,'22/12/12',10);

/*Table structure for table `tbl_devolucion_detalle` */

DROP TABLE IF EXISTS `tbl_devolucion_detalle`;

CREATE TABLE `tbl_devolucion_detalle` (
  `clv_devolucion_detalle` int(11) NOT NULL AUTO_INCREMENT,
  `clv_devolucion` int(11) NOT NULL,
  `clv_libro` int(11) NOT NULL,
  `Observacion` varchar(100) NOT NULL,
  PRIMARY KEY (`clv_devolucion_detalle`),
  KEY `clv_libro` (`clv_libro`),
  KEY `clv_devolucion` (`clv_devolucion`),
  CONSTRAINT `tbl_devolucion_detalle_ibfk_1` FOREIGN KEY (`clv_libro`) REFERENCES `tbl_libros` (`clv_libro`),
  CONSTRAINT `tbl_devolucion_detalle_ibfk_3` FOREIGN KEY (`clv_devolucion`) REFERENCES `tbl_devolucion` (`Clv_devolucion`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_devolucion_detalle` */

insert  into `tbl_devolucion_detalle`(`clv_devolucion_detalle`,`clv_devolucion`,`clv_libro`,`Observacion`) values (1,1,2,'este es una prueba'),(2,2,1,'sjdjsdgjsdb'),(3,3,1,'sdjhksjdhksdh'),(4,4,4,'kjgjzdsd');

/*Table structure for table `tbl_domicilio` */

DROP TABLE IF EXISTS `tbl_domicilio`;

CREATE TABLE `tbl_domicilio` (
  `clv_domi` int(11) NOT NULL AUTO_INCREMENT,
  `domicilio` varchar(50) NOT NULL,
  PRIMARY KEY (`clv_domi`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_domicilio` */

insert  into `tbl_domicilio`(`clv_domi`,`domicilio`) values (1,'TLANCHINOL'),(2,'ATLAPEXCO'),(3,'HUEJUTLA'),(4,'ALAMO'),(5,'PANUCHO'),(6,'SAN FELIPE'),(7,'PLATON SANCHEZ');

/*Table structure for table `tbl_editorial` */

DROP TABLE IF EXISTS `tbl_editorial`;

CREATE TABLE `tbl_editorial` (
  `Clv_editorial` int(11) NOT NULL AUTO_INCREMENT,
  `Editorial` varchar(50) NOT NULL,
  PRIMARY KEY (`Clv_editorial`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_editorial` */

insert  into `tbl_editorial`(`Clv_editorial`,`Editorial`) values (1,'ANAYA'),(2,'macro'),(3,'on web'),(4,'adobe');

/*Table structure for table `tbl_empleados` */

DROP TABLE IF EXISTS `tbl_empleados`;

CREATE TABLE `tbl_empleados` (
  `clv_empleado` int(11) NOT NULL,
  `Clv_usuario` int(11) NOT NULL,
  `Clv_puesto` int(11) NOT NULL,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`clv_empleado`),
  KEY `Clv_usuario` (`Clv_usuario`),
  KEY `Clv_puesto` (`Clv_puesto`),
  CONSTRAINT `tbl_empleados_ibfk_1` FOREIGN KEY (`Clv_usuario`) REFERENCES `tbl_usuario` (`Clv_usuario`),
  CONSTRAINT `tbl_empleados_ibfk_2` FOREIGN KEY (`Clv_puesto`) REFERENCES `tbl_puestos` (`Clv_puesto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_empleados` */

insert  into `tbl_empleados`(`clv_empleado`,`Clv_usuario`,`Clv_puesto`,`password`) values (1,6,1,'PEPITO'),(6,6,4,'admin');

/*Table structure for table `tbl_libro_detalle` */

DROP TABLE IF EXISTS `tbl_libro_detalle`;

CREATE TABLE `tbl_libro_detalle` (
  `clave` int(11) NOT NULL,
  `clv_libro` int(11) NOT NULL,
  `Existencia` int(11) NOT NULL,
  PRIMARY KEY (`clave`),
  KEY `clv_libro` (`clv_libro`),
  CONSTRAINT `tbl_libro_detalle_ibfk_1` FOREIGN KEY (`clv_libro`) REFERENCES `tbl_libros` (`clv_libro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_libro_detalle` */

/*Table structure for table `tbl_libros` */

DROP TABLE IF EXISTS `tbl_libros`;

CREATE TABLE `tbl_libros` (
  `clv_libro` int(11) NOT NULL,
  `nombre_libro` varchar(100) NOT NULL,
  `Fecha_edicion` varchar(20) NOT NULL,
  `numero_paginas` int(11) NOT NULL,
  `Clv_clasificacion` int(11) NOT NULL,
  `Clv_editorial` int(11) NOT NULL,
  `Clv_autor` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  PRIMARY KEY (`clv_libro`),
  KEY `Clv_autor` (`Clv_autor`),
  KEY `Clv_clasificacion` (`Clv_clasificacion`),
  KEY `Clv_editorial` (`Clv_editorial`),
  CONSTRAINT `tbl_libros_ibfk_1` FOREIGN KEY (`Clv_autor`) REFERENCES `tbl_autores` (`Clv_autor`),
  CONSTRAINT `tbl_libros_ibfk_2` FOREIGN KEY (`Clv_clasificacion`) REFERENCES `tbl_clasificacion` (`Clv_clasificacion`),
  CONSTRAINT `tbl_libros_ibfk_3` FOREIGN KEY (`Clv_editorial`) REFERENCES `tbl_editorial` (`Clv_editorial`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_libros` */

insert  into `tbl_libros`(`clv_libro`,`nombre_libro`,`Fecha_edicion`,`numero_paginas`,`Clv_clasificacion`,`Clv_editorial`,`Clv_autor`,`cantidad`) values (1,'Dreamweaver css','23/05/2010',678,3,4,6,4),(2,'php y MySQL','02/09/2013',234,5,1,5,2),(3,'visual basic','20/12/2012',678,2,1,1,2),(4,'C la biblia del programador','08/02/2001',789,5,1,1,1),(5,'NetBeans IDE','23/05/2012',567,3,2,8,2),(6,'Pro HTML5 Programming','23/05/2012',567,3,4,8,2),(7,'AJAX web2','23/05/2010',456,3,1,3,5),(8,'SQL server 2012','23/05/2013',456,3,1,3,5),(9,'C# la biblia','23/05/2013',987,3,1,6,0);

/*Table structure for table `tbl_multas` */

DROP TABLE IF EXISTS `tbl_multas`;

CREATE TABLE `tbl_multas` (
  `Clv_multa` int(11) NOT NULL,
  `Fecha_multa` varchar(50) NOT NULL,
  `Clv_prestamo` int(11) NOT NULL,
  `Observacion` varchar(30) NOT NULL,
  `Monto` double NOT NULL,
  PRIMARY KEY (`Clv_multa`),
  KEY `Clv_prestamo` (`Clv_prestamo`),
  CONSTRAINT `tbl_multas_ibfk_1` FOREIGN KEY (`Clv_prestamo`) REFERENCES `tbl_prestamo` (`Clv_prestamo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_multas` */

/*Table structure for table `tbl_prestamo` */

DROP TABLE IF EXISTS `tbl_prestamo`;

CREATE TABLE `tbl_prestamo` (
  `Clv_prestamo` int(11) NOT NULL,
  `Fecha_prestamo` varchar(50) NOT NULL,
  `Fecha_limite` varchar(50) NOT NULL,
  `Clv_cliente` int(11) NOT NULL,
  `clv_empleado` int(11) NOT NULL,
  PRIMARY KEY (`Clv_prestamo`),
  KEY `Clv_cliente` (`Clv_cliente`),
  KEY `clv_empleado` (`clv_empleado`),
  CONSTRAINT `tbl_prestamo_ibfk_2` FOREIGN KEY (`Clv_cliente`) REFERENCES `tbl_cliente` (`Clv_cliente`),
  CONSTRAINT `tbl_prestamo_ibfk_3` FOREIGN KEY (`clv_empleado`) REFERENCES `tbl_empleados` (`clv_empleado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_prestamo` */

insert  into `tbl_prestamo`(`Clv_prestamo`,`Fecha_prestamo`,`Fecha_limite`,`Clv_cliente`,`clv_empleado`) values (0,'33/43/4343','34/34/3434',48,1),(1,'23/23/2013','23/23/2013',48,1),(2,'23/23/232','23/23/2323',48,1),(3,'34/34/3434','34/34/3434',48,1),(4,'23/23/2323','23/23/2323',48,1),(8,'34/34/3434','34/34/3434',48,1),(9,'21/20/2014','19/23/2323',48,6),(10,'21/20/2014','19/23/2323',48,1);

/*Table structure for table `tbl_prestamo_detalle` */

DROP TABLE IF EXISTS `tbl_prestamo_detalle`;

CREATE TABLE `tbl_prestamo_detalle` (
  `clv_prestamo_detalle` int(11) NOT NULL AUTO_INCREMENT,
  `Clv_prestamo` int(11) NOT NULL,
  `clv_libro` int(11) NOT NULL,
  PRIMARY KEY (`clv_prestamo_detalle`),
  KEY `clv_libro` (`clv_libro`),
  KEY `Clv_prestamo` (`Clv_prestamo`),
  CONSTRAINT `tbl_prestamo_detalle_ibfk_1` FOREIGN KEY (`clv_libro`) REFERENCES `tbl_libros` (`clv_libro`),
  CONSTRAINT `tbl_prestamo_detalle_ibfk_2` FOREIGN KEY (`Clv_prestamo`) REFERENCES `tbl_prestamo` (`Clv_prestamo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_prestamo_detalle` */

insert  into `tbl_prestamo_detalle`(`clv_prestamo_detalle`,`Clv_prestamo`,`clv_libro`) values (1,1,2),(2,2,1),(3,3,1),(4,4,9),(7,0,3),(8,8,3),(9,9,4),(10,10,4);

/*Table structure for table `tbl_puestos` */

DROP TABLE IF EXISTS `tbl_puestos`;

CREATE TABLE `tbl_puestos` (
  `Clv_puesto` int(11) NOT NULL AUTO_INCREMENT,
  `Puesto` varchar(50) NOT NULL,
  PRIMARY KEY (`Clv_puesto`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `tbl_puestos` */

insert  into `tbl_puestos`(`Clv_puesto`,`Puesto`) values (1,'JERENTE'),(2,'JEFE'),(3,'LIMPIEZA'),(4,'ADMINISTRADOR');

/*Table structure for table `tbl_usuario` */

DROP TABLE IF EXISTS `tbl_usuario`;

CREATE TABLE `tbl_usuario` (
  `Clv_usuario` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `A_paterno` varchar(30) NOT NULL,
  `A_materno` varchar(30) NOT NULL,
  `clv_domi` int(11) NOT NULL,
  `Telefono` varchar(10) NOT NULL,
  `E_mail` varchar(50) NOT NULL,
  PRIMARY KEY (`Clv_usuario`),
  KEY `clv_domi` (`clv_domi`),
  CONSTRAINT `tbl_usuario_ibfk_1` FOREIGN KEY (`clv_domi`) REFERENCES `tbl_domicilio` (`clv_domi`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbl_usuario` */

insert  into `tbl_usuario`(`Clv_usuario`,`Nombre`,`A_paterno`,`A_materno`,`clv_domi`,`Telefono`,`E_mail`) values (6,'felix','hernandez','hernandez',3,'7712159542','lfhlx2013@hotmail.com'),(7,'LUISA ','HERNANDEZ','HERNANDEZ',1,'7771289879','LISA@HOTMAIL.COM'),(8,'jose','toress','jjjbjb',3,'5454545','rerer'),(17,'pedro','gonzales','pedraza',3,'7712893298','pedro@hotmail.com'),(24,'jazmin','buatista','martinez',3,'456789012','ewesdsd'),(48,'felix','hernandez','hernandez',3,'7712159542','lfhlx2013@hotmail.com');

/* Trigger structure for table `tbl_devolucion_detalle` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trg_devolucion` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `trg_devolucion` AFTER INSERT ON `tbl_devolucion_detalle` FOR EACH ROW BEGIN
        UPDATE tbl_libros SET cantidad=cantidad+1 
        WHERE clv_libro = new.clv_libro; 
    END */$$


DELIMITER ;

/* Trigger structure for table `tbl_prestamo_detalle` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `trg_prestamo` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `trg_prestamo` AFTER INSERT ON `tbl_prestamo_detalle` FOR EACH ROW BEGIN
		UPDATE tbl_libros SET cantidad = cantidad-1 WHERE clv_libro = new.clv_libro;
    END */$$


DELIMITER ;

/* Procedure structure for procedure `porcedi_autores` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_autores` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_autores`(IN op VARCHAR(10), IN clvautor INT, IN nombre VARCHAR(50))
BEGIN
   CASE op
		WHEN 'Insert' THEN
			
			INSERT INTO tbl_autores VALUES(clvautor,nombre);
		
		WHEN 'Update' THEN
		
			UPDATE tbl_autores SET Nombre=nombre 
			WHERE Clv_autor=clvautor;
		        
		WHEN 'Delete' THEN
		        DELETE FROM tbl_autores WHERE Clv_autor=clvautor;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_clasificacion` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_clasificacion` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_clasificacion`(IN op VARCHAR(10),in clvclasificacion int, IN clas VARCHAR(50))
BEGIN
   CASE op
		WHEN 'Insert' THEN
			
			INSERT INTO tbl_clasificacion VALUES(clvclasificacion,clas);
		
		WHEN 'Update' THEN
		
			update tbl_clasificacion set clasificacion=clas
			where Clv_clasificacion=clvclasificacion;
		WHEN 'Delete' THEN
		        DELETE FROM tbl_clasificacion WHERE Clv_clasificacion=clvclasificacion;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_cliente` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_cliente` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_cliente`(IN op VARCHAR(10), IN clave INT, IN nom varchar(50), IN ap VARCHAR(30), IN am VARCHAR(30), IN clvdomi INT, IN tele VARCHAR(10),IN email VARCHAR(50))
BEGIN
   CASE op
		WHEN 'Insert' THEN
		        INSERT INTO tbl_usuario VALUES(clave,nom,ap,am,clvdomi,tele,email);
			INSERT INTO tbl_cliente VALUES(clave,clave);
		WHEN 'Update' THEN
			UPDATE tbl_usuario SET Nombre=nom,A_paterno=ap,A_materno=am,clv_domi=clvdomi,Telefono=tele,E_mail=email
		        WHERE Clv_usuario=clave;
		        
		        UPDATE tbl_cliente SET Clv_usuario=clave
		        WHERE Clv_cliente=clave;
		WHEN 'delete' THEN
		        DELETE FROM tbl_cliente WHERE Clv_cliente=clave;
		        DELETE FROM tbl_usuario WHERE Clv_usuario=clave;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_devolucion` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_devolucion` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_devolucion`(IN op VARCHAR(10), IN clvdevol INT,IN fecha_devl VARCHAR(30),IN clvpres INT,in clavelibro int,in obser varchar(100))
BEGIN
   CASE op
		WHEN 'Insert' THEN
		
			INSERT INTO tbl_devolucion VALUES(clvdevol,fecha_devl,clvpres);
			insert into tbl_devolucion_detalle values(' ',clvdevol,clavelibro,obser);
			
		WHEN 'Update' THEN
		
			UPDATE tbl_devolucion SET Fecha_devolucion=fecha_devl,Clv_prestamo=clvpres
		        WHERE Clv_devolucion=clvdevol;
		        
		        update tbl_devolucion_detalle set clv_devolucion=clvdevol,clv_libro=clavelibro,Observacion=obser
		        where  clv_devolucion=clvdevol;
		        
		WHEN 'delete' THEN
		        DELETE FROM tbl_devolucion WHERE Clv_devolucion=clvdevol;
		        delete from tbl_devolucion_detalle where clv_libro=clavelibro;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_editoriales` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_editoriales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_editoriales`(IN op VARCHAR(10), IN clveditorial INT, IN editorial VARCHAR(50))
BEGIN
   CASE op
		WHEN 'Insert' THEN
			
			INSERT INTO tbl_editorial VALUES(clveditorial,editorial);
		
		WHEN 'Update' THEN
		
			UPDATE tbl_editorial SET Editorial=editorial WHERE Clv_editorial=clveditorial;
		        
		WHEN 'Delete' THEN
		        DELETE FROM tbl_editorial WHERE Clv_editorial=clveditorial;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_empleado` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_empleado` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_empleado`(IN op VARCHAR(10), IN clave INT, IN nom varchar(50), IN ap VARCHAR(30), IN am VARCHAR(30), IN clvdomi int, in tele varchar(10),in email varchar(50),
in clvpues int,in contra varchar(50))
BEGIN
   CASE op
		WHEN 'Insert' THEN
		        insert into tbl_usuario values(clave,nom,ap,am,clvdomi,tele,email);
			INSERT INTO tbl_empleados VALUES(clave,clave, clvpues,contra);
		WHEN 'Update' THEN
			UPDATE tbl_usuario SET Nombre=nom,A_paterno=ap,A_materno=am,clv_domi=clvdomi,Telefono=tele,E_mail=email
		        WHERE Clv_usuario=clave;
		        
		        UPDATE tbl_empleados SET Clv_usuario=clave,Clv_puesto=clvpues,`password`=contra
		        WHERE clv_empleado=clave;
		WHEN 'delete' THEN
		        DELETE FROM tbl_empleados WHERE clv_empleado=clave;
		        DELETE FROM tbl_usuario WHERE Clv_usuario=clave;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_libros` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_libros` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_libros`(IN op VARCHAR(10), IN clvlibro int, IN nombrelibro varchar(100), IN Fecha varchar(20), IN paginas INT,in clasi int,in editorial int,in autor int,in can int)
BEGIN
	
   CASE op
		WHEN 'Insert' THEN
			
			INSERT INTO tbl_libros VALUES(clvlibro, nombrelibro, Fecha, paginas,clasi,editorial,autor,can);
		
		WHEN 'Update' THEN
			
			UPDATE tbl_libros SET nombre_libro=nombrelibro,Fecha_edicion=Fecha,numero_paginas=paginas,Clv_clasificacion=clasi, Clv_editorial=editorial,Clv_autor=autor,cantidad=can
		        where clv_libro=clvlibro;
		when 'delete' then
		        delete from tbl_libros where clv_libro=clvlibro;
		END CASE;
   
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_multas` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_multas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_multas`(IN op VARCHAR(10), IN clvmulta INT, IN fecha VARCHAR(50), IN clvpres int, IN obser varchar(30), IN monto double)
BEGIN
   CASE op
		WHEN 'Insert' THEN
			INSERT INTO tbl_multas VALUES(clvmulta, fecha, clvpres, obser,monto);
		WHEN 'Update' THEN
			UPDATE tbl_multas SET Fecha_multa=fecha,Clv_prestamo=clvpres,Observacion=obser,Monto=monto
		        WHERE Clv_multa=clvmulta;
		WHEN 'delete' THEN
		        DELETE FROM tbl_multas WHERE Clv_multa=clvmulta;
		END CASE;
	 END */$$
DELIMITER ;

/* Procedure structure for procedure `porcedi_prestamo` */

/*!50003 DROP PROCEDURE IF EXISTS  `porcedi_prestamo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `porcedi_prestamo`(IN op VARCHAR(10),IN clvpres INT, IN fepres varchar(50), in fechalimite VARCHAR(50),in clvclien int,in clvemple int,IN claveli INT)
BEGIN
   CASE op
		WHEN 'Insert' THEN
			INSERT INTO tbl_prestamo VALUES(clvpres,fepres,fechalimite,clvclien,clvemple);
			insert into tbl_prestamo_detalle values(clvpres,clvpres,claveli);
		WHEN 'Update' THEN
			UPDATE tbl_prestamo SET Fecha_prestamo=fepres,Fecha_limite=fechalimite,Clv_cliente=clvclien,clv_empleado=clvemple
			WHERE Clv_prestamo=clvpres;
			
			update tbl_prestamo_detalle set Clv_prestamo=clvpres,clv_libro=claveli
			where Clv_prestamo=clvpres;
		WHEN 'Delete' THEN
		        DELETE FROM tbl_prestamo WHERE Clv_prestamo=clvpres;
		        delete from tbl_prestamo_detalle where  Clv_prestamo=clvpres;
		END CASE;
	 END */$$
DELIMITER ;

/*Table structure for table `reporte_cantidad_veces_prestado` */

DROP TABLE IF EXISTS `reporte_cantidad_veces_prestado`;

/*!50001 DROP VIEW IF EXISTS `reporte_cantidad_veces_prestado` */;
/*!50001 DROP TABLE IF EXISTS `reporte_cantidad_veces_prestado` */;

/*!50001 CREATE TABLE  `reporte_cantidad_veces_prestado`(
 `clave` int(11) ,
 `libro` varchar(100) ,
 `veces_prestado` bigint(21) 
)*/;

/*Table structure for table `reporte_de_clientes` */

DROP TABLE IF EXISTS `reporte_de_clientes`;

/*!50001 DROP VIEW IF EXISTS `reporte_de_clientes` */;
/*!50001 DROP TABLE IF EXISTS `reporte_de_clientes` */;

/*!50001 CREATE TABLE  `reporte_de_clientes`(
 `clv_cliente` int(11) ,
 `nombre` varchar(50) ,
 `A_paterno` varchar(30) ,
 `A_materno` varchar(30) ,
 `domicilio` varchar(50) ,
 `Telefono` varchar(10) ,
 `E_mail` varchar(50) 
)*/;

/*Table structure for table `reporte_de_empleado` */

DROP TABLE IF EXISTS `reporte_de_empleado`;

/*!50001 DROP VIEW IF EXISTS `reporte_de_empleado` */;
/*!50001 DROP TABLE IF EXISTS `reporte_de_empleado` */;

/*!50001 CREATE TABLE  `reporte_de_empleado`(
 `clv_empleado` int(11) ,
 `nombre` varchar(50) ,
 `A_paterno` varchar(30) ,
 `A_materno` varchar(30) ,
 `domicilio` varchar(50) ,
 `Telefono` varchar(10) ,
 `E_mail` varchar(50) ,
 `puesto` varchar(50) ,
 `PASSWORD` varchar(50) ,
 `clv_usuario` int(11) 
)*/;

/*Table structure for table `reporte_invertario_libros` */

DROP TABLE IF EXISTS `reporte_invertario_libros`;

/*!50001 DROP VIEW IF EXISTS `reporte_invertario_libros` */;
/*!50001 DROP TABLE IF EXISTS `reporte_invertario_libros` */;

/*!50001 CREATE TABLE  `reporte_invertario_libros`(
 `Clave` int(11) ,
 `Libro` varchar(100) ,
 `Edicion` varchar(20) ,
 `Paginas` int(11) ,
 `Clasificacion` varchar(50) ,
 `editorial` varchar(50) ,
 `autor` varchar(50) ,
 `Existencia` int(11) 
)*/;

/*Table structure for table `vie_cliente` */

DROP TABLE IF EXISTS `vie_cliente`;

/*!50001 DROP VIEW IF EXISTS `vie_cliente` */;
/*!50001 DROP TABLE IF EXISTS `vie_cliente` */;

/*!50001 CREATE TABLE  `vie_cliente`(
 `Clv_cliente` int(11) ,
 `Nombre` varchar(50) ,
 `A_Paterno` varchar(30) ,
 `A_Materno` varchar(30) ,
 `Domicilio` varchar(50) ,
 `Telefono` varchar(10) ,
 `E-mail` varchar(50) 
)*/;

/*Table structure for table `vie_empleado` */

DROP TABLE IF EXISTS `vie_empleado`;

/*!50001 DROP VIEW IF EXISTS `vie_empleado` */;
/*!50001 DROP TABLE IF EXISTS `vie_empleado` */;

/*!50001 CREATE TABLE  `vie_empleado`(
 `clv_empleado` int(11) ,
 `Nombre` varchar(50) ,
 `A_paterno` varchar(30) ,
 `A_materno` varchar(30) ,
 `Domicilio` varchar(50) ,
 `Telefono` varchar(10) ,
 `E_mail` varchar(50) ,
 `Puesto` varchar(50) ,
 `password` varchar(50) 
)*/;

/*Table structure for table `vista_devolucion` */

DROP TABLE IF EXISTS `vista_devolucion`;

/*!50001 DROP VIEW IF EXISTS `vista_devolucion` */;
/*!50001 DROP TABLE IF EXISTS `vista_devolucion` */;

/*!50001 CREATE TABLE  `vista_devolucion`(
 `clv_devolucion` int(11) ,
 `fecha_devolucion` varchar(30) ,
 `fecha_prestamo` varchar(50) ,
 `fecha_limite` varchar(50) ,
 `cliente` varchar(50) ,
 `empleado` varchar(50) 
)*/;

/*Table structure for table `vista_devolucion_detalle` */

DROP TABLE IF EXISTS `vista_devolucion_detalle`;

/*!50001 DROP VIEW IF EXISTS `vista_devolucion_detalle` */;
/*!50001 DROP TABLE IF EXISTS `vista_devolucion_detalle` */;

/*!50001 CREATE TABLE  `vista_devolucion_detalle`(
 `clv_devolucion` int(11) ,
 `fecha_devolucion` varchar(30) ,
 `fecha_prestamo` varchar(50) ,
 `fecha_limite` varchar(50) ,
 `nombre_libro` varchar(100) ,
 `cliente` varchar(50) ,
 `empleado` varchar(50) ,
 `observacion` varchar(100) ,
 `Clv_prestamo` int(11) 
)*/;

/*Table structure for table `vista_invertario` */

DROP TABLE IF EXISTS `vista_invertario`;

/*!50001 DROP VIEW IF EXISTS `vista_invertario` */;
/*!50001 DROP TABLE IF EXISTS `vista_invertario` */;

/*!50001 CREATE TABLE  `vista_invertario`(
 `Clave` int(11) ,
 `Libro` varchar(100) ,
 `Edicion` varchar(20) ,
 `Paginas` int(11) ,
 `Clasificacion` varchar(50) ,
 `editorial` varchar(50) ,
 `autor` varchar(50) ,
 `Existencia` int(11) 
)*/;

/*Table structure for table `vista_libro_detalle` */

DROP TABLE IF EXISTS `vista_libro_detalle`;

/*!50001 DROP VIEW IF EXISTS `vista_libro_detalle` */;
/*!50001 DROP TABLE IF EXISTS `vista_libro_detalle` */;

/*!50001 CREATE TABLE  `vista_libro_detalle`(
 `Clave` int(11) ,
 `libro` varchar(100) ,
 `fecha_edicion` varchar(20) ,
 `Paginas` int(11) ,
 `clasificacion` varchar(50) ,
 `Editorial` varchar(50) ,
 `Autor` varchar(50) ,
 `Existencia` int(11) 
)*/;

/*Table structure for table `vista_libros` */

DROP TABLE IF EXISTS `vista_libros`;

/*!50001 DROP VIEW IF EXISTS `vista_libros` */;
/*!50001 DROP TABLE IF EXISTS `vista_libros` */;

/*!50001 CREATE TABLE  `vista_libros`(
 `clv_libro` int(11) ,
 `nombre_libro` varchar(100) ,
 `fecha_edicion` varchar(20) ,
 `numero_paginas` int(11) ,
 `clasificacion` varchar(50) ,
 `Editorial` varchar(50) ,
 `Autor` varchar(50) ,
 `Cantidad` int(11) 
)*/;

/*Table structure for table `vista_prestamo` */

DROP TABLE IF EXISTS `vista_prestamo`;

/*!50001 DROP VIEW IF EXISTS `vista_prestamo` */;
/*!50001 DROP TABLE IF EXISTS `vista_prestamo` */;

/*!50001 CREATE TABLE  `vista_prestamo`(
 `clv_prestamo_detalle` int(11) ,
 `Libro` varchar(100) ,
 `Fecha_prestamo` varchar(50) ,
 `Fecha_limite` varchar(50) ,
 `Cliente` varchar(50) ,
 `Empleado` varchar(50) 
)*/;

/*View structure for view reporte_cantidad_veces_prestado */

/*!50001 DROP TABLE IF EXISTS `reporte_cantidad_veces_prestado` */;
/*!50001 DROP VIEW IF EXISTS `reporte_cantidad_veces_prestado` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporte_cantidad_veces_prestado` AS select `pres`.`clv_prestamo_detalle` AS `clave`,`li`.`nombre_libro` AS `libro`,count(`li`.`clv_libro`) AS `veces_prestado` from (`tbl_prestamo_detalle` `pres` join `tbl_libros` `li` on((`pres`.`clv_libro` = `li`.`clv_libro`))) group by `li`.`clv_libro` */;

/*View structure for view reporte_de_clientes */

/*!50001 DROP TABLE IF EXISTS `reporte_de_clientes` */;
/*!50001 DROP VIEW IF EXISTS `reporte_de_clientes` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporte_de_clientes` AS select `cli`.`Clv_cliente` AS `clv_cliente`,`us`.`Nombre` AS `nombre`,`us`.`A_paterno` AS `A_paterno`,`us`.`A_materno` AS `A_materno`,`domi`.`domicilio` AS `domicilio`,`us`.`Telefono` AS `Telefono`,`us`.`E_mail` AS `E_mail` from ((`tbl_cliente` `cli` join `tbl_usuario` `us` on((`cli`.`Clv_usuario` = `us`.`Clv_usuario`))) join `tbl_domicilio` `domi` on((`us`.`clv_domi` = `domi`.`clv_domi`))) order by `cli`.`Clv_cliente` */;

/*View structure for view reporte_de_empleado */

/*!50001 DROP TABLE IF EXISTS `reporte_de_empleado` */;
/*!50001 DROP VIEW IF EXISTS `reporte_de_empleado` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporte_de_empleado` AS select `em`.`clv_empleado` AS `clv_empleado`,`us`.`Nombre` AS `nombre`,`us`.`A_paterno` AS `A_paterno`,`us`.`A_materno` AS `A_materno`,`domi`.`domicilio` AS `domicilio`,`us`.`Telefono` AS `Telefono`,`us`.`E_mail` AS `E_mail`,`pu`.`Puesto` AS `puesto`,`em`.`password` AS `PASSWORD`,`us`.`Clv_usuario` AS `clv_usuario` from (((`tbl_empleados` `em` join `tbl_usuario` `us` on((`em`.`Clv_usuario` = `us`.`Clv_usuario`))) join `tbl_domicilio` `domi` on((`us`.`clv_domi` = `domi`.`clv_domi`))) join `tbl_puestos` `pu` on((`em`.`Clv_puesto` = `pu`.`Clv_puesto`))) */;

/*View structure for view reporte_invertario_libros */

/*!50001 DROP TABLE IF EXISTS `reporte_invertario_libros` */;
/*!50001 DROP VIEW IF EXISTS `reporte_invertario_libros` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporte_invertario_libros` AS select `li`.`clv_libro` AS `Clave`,`vi`.`nombre_libro` AS `Libro`,`vi`.`fecha_edicion` AS `Edicion`,`vi`.`numero_paginas` AS `Paginas`,`vi`.`clasificacion` AS `Clasificacion`,`vi`.`Editorial` AS `editorial`,`vi`.`Autor` AS `autor`,`vi`.`Cantidad` AS `Existencia` from (`tbl_libros` `li` join `vista_libros` `vi` on((`li`.`clv_libro` = `vi`.`clv_libro`))) order by `li`.`clv_libro` */;

/*View structure for view vie_cliente */

/*!50001 DROP TABLE IF EXISTS `vie_cliente` */;
/*!50001 DROP VIEW IF EXISTS `vie_cliente` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vie_cliente` AS select `cli`.`Clv_cliente` AS `Clv_cliente`,`us`.`Nombre` AS `Nombre`,`us`.`A_paterno` AS `A_Paterno`,`us`.`A_materno` AS `A_Materno`,`domi`.`domicilio` AS `Domicilio`,`us`.`Telefono` AS `Telefono`,`us`.`E_mail` AS `E-mail` from ((`tbl_cliente` `cli` join `tbl_usuario` `us` on((`cli`.`Clv_usuario` = `us`.`Clv_usuario`))) join `tbl_domicilio` `domi` on((`us`.`clv_domi` = `domi`.`clv_domi`))) order by `cli`.`Clv_cliente` */;

/*View structure for view vie_empleado */

/*!50001 DROP TABLE IF EXISTS `vie_empleado` */;
/*!50001 DROP VIEW IF EXISTS `vie_empleado` */;

/*!50001 CREATE ALGORITHM=MERGE DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vie_empleado` AS select `em`.`clv_empleado` AS `clv_empleado`,`us`.`Nombre` AS `Nombre`,`us`.`A_paterno` AS `A_paterno`,`us`.`A_materno` AS `A_materno`,`domi`.`domicilio` AS `Domicilio`,`us`.`Telefono` AS `Telefono`,`us`.`E_mail` AS `E_mail`,`pu`.`Puesto` AS `Puesto`,`em`.`password` AS `password` from (((`tbl_empleados` `em` join `tbl_usuario` `us` on((`em`.`Clv_usuario` = `us`.`Clv_usuario`))) join `tbl_domicilio` `domi` on((`us`.`clv_domi` = `domi`.`clv_domi`))) join `tbl_puestos` `pu` on((`em`.`Clv_puesto` = `pu`.`Clv_puesto`))) */;

/*View structure for view vista_devolucion */

/*!50001 DROP TABLE IF EXISTS `vista_devolucion` */;
/*!50001 DROP VIEW IF EXISTS `vista_devolucion` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_devolucion` AS select `de`.`Clv_devolucion` AS `clv_devolucion`,`de`.`Fecha_devolucion` AS `fecha_devolucion`,`pre`.`Fecha_prestamo` AS `fecha_prestamo`,`pre`.`Fecha_limite` AS `fecha_limite`,`cli`.`Nombre` AS `cliente`,`em`.`Nombre` AS `empleado` from (((`tbl_devolucion` `de` join `tbl_prestamo` `pre` on((`de`.`Clv_prestamo` = `pre`.`Clv_prestamo`))) join `vie_cliente` `cli` on((`pre`.`Clv_cliente` = `cli`.`Clv_cliente`))) join `vie_empleado` `em` on((`pre`.`clv_empleado` = `em`.`clv_empleado`))) */;

/*View structure for view vista_devolucion_detalle */

/*!50001 DROP TABLE IF EXISTS `vista_devolucion_detalle` */;
/*!50001 DROP VIEW IF EXISTS `vista_devolucion_detalle` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_devolucion_detalle` AS select `del`.`clv_devolucion_detalle` AS `clv_devolucion`,`de`.`fecha_devolucion` AS `fecha_devolucion`,`de`.`fecha_prestamo` AS `fecha_prestamo`,`de`.`fecha_limite` AS `fecha_limite`,`li`.`nombre_libro` AS `nombre_libro`,`de`.`cliente` AS `cliente`,`de`.`empleado` AS `empleado`,`del`.`Observacion` AS `observacion`,`dev`.`Clv_prestamo` AS `Clv_prestamo` from (((`tbl_devolucion_detalle` `del` join `tbl_libros` `li` on((`del`.`clv_libro` = `li`.`clv_libro`))) join `vista_devolucion` `de` on((`del`.`clv_devolucion` = `de`.`clv_devolucion`))) join `tbl_devolucion` `dev` on((`del`.`clv_devolucion` = `dev`.`Clv_devolucion`))) */;

/*View structure for view vista_invertario */

/*!50001 DROP TABLE IF EXISTS `vista_invertario` */;
/*!50001 DROP VIEW IF EXISTS `vista_invertario` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_invertario` AS select `li`.`clv_libro` AS `Clave`,`vi`.`nombre_libro` AS `Libro`,`vi`.`fecha_edicion` AS `Edicion`,`vi`.`numero_paginas` AS `Paginas`,`vi`.`clasificacion` AS `Clasificacion`,`vi`.`Editorial` AS `editorial`,`vi`.`Autor` AS `autor`,`vi`.`Cantidad` AS `Existencia` from (`tbl_libros` `li` join `vista_libros` `vi` on((`li`.`clv_libro` = `vi`.`clv_libro`))) group by `li`.`clv_libro` */;

/*View structure for view vista_libro_detalle */

/*!50001 DROP TABLE IF EXISTS `vista_libro_detalle` */;
/*!50001 DROP VIEW IF EXISTS `vista_libro_detalle` */;

/*!50001 CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_libro_detalle` AS select `li_deta`.`clave` AS `Clave`,`li`.`nombre_libro` AS `libro`,`li`.`fecha_edicion` AS `fecha_edicion`,`li`.`numero_paginas` AS `Paginas`,`li`.`clasificacion` AS `clasificacion`,`li`.`Editorial` AS `Editorial`,`li`.`Autor` AS `Autor`,`li_deta`.`Existencia` AS `Existencia` from (`tbl_libro_detalle` `li_deta` join `vista_libros` `li` on((`li_deta`.`clv_libro` = `li`.`clv_libro`))) order by `li_deta`.`clave` */;

/*View structure for view vista_libros */

/*!50001 DROP TABLE IF EXISTS `vista_libros` */;
/*!50001 DROP VIEW IF EXISTS `vista_libros` */;

/*!50001 CREATE ALGORITHM=MERGE DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_libros` AS select `tbl_libros`.`clv_libro` AS `clv_libro`,`tbl_libros`.`nombre_libro` AS `nombre_libro`,`tbl_libros`.`Fecha_edicion` AS `fecha_edicion`,`tbl_libros`.`numero_paginas` AS `numero_paginas`,`tbl_clasificacion`.`clasificacion` AS `clasificacion`,`tbl_editorial`.`Editorial` AS `Editorial`,`tbl_autores`.`Nombre` AS `Autor`,`tbl_libros`.`cantidad` AS `Cantidad` from (((`tbl_libros` join `tbl_clasificacion` on((`tbl_libros`.`Clv_clasificacion` = `tbl_clasificacion`.`Clv_clasificacion`))) join `tbl_editorial` on((`tbl_libros`.`Clv_editorial` = `tbl_editorial`.`Clv_editorial`))) join `tbl_autores` on((`tbl_libros`.`Clv_autor` = `tbl_autores`.`Clv_autor`))) order by `tbl_libros`.`clv_libro` */;

/*View structure for view vista_prestamo */

/*!50001 DROP TABLE IF EXISTS `vista_prestamo` */;
/*!50001 DROP VIEW IF EXISTS `vista_prestamo` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_prestamo` AS select `pres`.`clv_prestamo_detalle` AS `clv_prestamo_detalle`,`li`.`nombre_libro` AS `Libro`,`pre`.`Fecha_prestamo` AS `Fecha_prestamo`,`pre`.`Fecha_limite` AS `Fecha_limite`,`cli`.`Nombre` AS `Cliente`,`em`.`Nombre` AS `Empleado` from ((((`tbl_prestamo_detalle` `pres` join `tbl_libros` `li` on((`pres`.`clv_libro` = `li`.`clv_libro`))) join `tbl_prestamo` `pre` on((`pres`.`Clv_prestamo` = `pre`.`Clv_prestamo`))) join `vie_cliente` `cli` on((`pre`.`Clv_cliente` = `cli`.`Clv_cliente`))) join `vie_empleado` `em` on((`pre`.`clv_empleado` = `em`.`clv_empleado`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
