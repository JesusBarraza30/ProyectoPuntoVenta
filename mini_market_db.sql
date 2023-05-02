CREATE database mini_market_db;

use mini_market_db; 

-- drop database mini_market_db;
 
CREATE TABLE clientes (
  id_cliente INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(40) NOT NULL,
  ap_pat VARCHAR(20) NOT NULL,
  ap_mat VARCHAR(20) NOT NULL,
  email VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  PRIMARY KEY (id_cliente)
);

CREATE TABLE vendedores (
  id_vendedor INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(50) NOT NULL,
  ap_pat VARCHAR(20) NOT NULL,
  ap_mat VARCHAR(20) NOT NULL,
  email VARCHAR(50) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  comision INT NOT NULL,
  sueldo_base DECIMAL NOT NULL,
  PRIMARY KEY (id_vendedor)
);

CREATE TABLE productos (
  id_producto INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(80) NOT NULL,
  precio DECIMAL(30,2) NOT NULL,
  existencia INT NOT NULL,
  PRIMARY KEY (id_producto)
);

CREATE TABLE ventas (
  id_venta INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  id_cliente INT,
  id_vendedor INT,
  id_producto INT,
  fecha_venta DATE,
  cantidad_producto INT,
  subtotal DECIMAL(30,2) NOT NULL,
  total DECIMAL(30,2) NOT NULL,
  FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
  FOREIGN KEY (id_vendedor) REFERENCES vendedores(id_vendedor),
  FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);

CREATE TABLE detalle_ventas(
	id_producto INT,
    id_venta INT,
	cantidad INT,
    FOREIGN KEY (id_producto) REFERENCES productos(id_producto),
    FOREIGN KEY (id_venta) REFERENCES ventas(id_venta)
);


INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('1', 'Vasos De Plástico', '200.98', '12');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('2', 'Papel Higiénico De 4 Capas Rollo A Granel', '505.24', '34');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('3', 'Salmas Sanissimo De Maíz Blanco', '190', '49');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('4', 'Del Valle Pulpy sabor Mango de 400 mililitros. Paquete de 6', '83.68', '53');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('5', 'Sabritas Botana Fritos Sal 170g', '35', '34');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('6', 'Sabritas Botana Rancheritos 225 g', '53', '43');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('7', 'Sabritas Papas Ruffles Queso 290g', '149', '23');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('8', 'Cacahuates Kacang Flamin Hot 185gr', '40.38', '26');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('9', 'Oreo Galleta Cubierta Dark fudge Chocolate Display de 166.4 gr', '40', '35');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('10', 'Emperador Galletas de Chocolate 382 g', '40.30', '34');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('11', 'Zucarmex Zulka Azúcar Morena Empacada, 1 kg', '22', '40');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('12', 'Dolores Atun Agua 295 gr', '37', '53');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('13', 'McCormick Mayonesa con Limón 725 g', '66.67', '64');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('14', 'Aceite de Soya Nutrioli Tripack 946 ml', '151.05', '12');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('15', 'La Moderna, Fideo 0, Pasta Para Sopa, 220 Gramos', '9.80', '65');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('16', 'Pétalo Ultra Jumbo Papel Higiénico, 16 Rollos con 234 Hojas Dobles', '70.67', '3');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('17', 'Ace Detergente en Polvo Limpieza Completa 5 kg', '153.64', '4');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('18', 'Coca-Cola Original, 12 Pack - 355 ml', '165.60', '32');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('19', 'Powerade Ion4, 6 Pack Bebida Para Deportistas Sabor Moras Botella 1 Lt', '118.80', '14');
INSERT INTO productos (id_producto, nombre, precio, existencia) VALUES ('20', 'La Costeña Chile Jalapeño Rajas', '14', '44');

SELECT * FROM ventas;

INSERT INTO vendedores VALUES
('1', 'jesus', 'barraza', 'castro', 'asfas@gmail.com', '6674153728', 5, 2000);

INSERT INTO clientes VALUES
('1', 'Maria', 'Velazquez', 'Alvarez', 'marveal@gmail.com', '6674153728'),
('2', 'Jose', 'García', 'Beltran', 'josgabel@gmail.com', '6674523416'),
('3', 'Manuel', 'Campos', 'Meza', 'macam@gmail.com', '6673425612');