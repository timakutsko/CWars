CREATE TABLE `int_mindbox`.`products_lib` (
  `id_lib` INT NOT NULL AUTO_INCREMENT,
  `id_product` INT NOT NULL,
  `id_category` INT NULL,
  PRIMARY KEY (`id_lib`));
  
ALTER TABLE `int_mindbox`.`products_lib` 
ADD INDEX `fk_prod_idx` (`id_product` ASC) VISIBLE,
ADD INDEX `fk_cat_idx` (`id_category` ASC) VISIBLE;
;
ALTER TABLE `int_mindbox`.`products_lib` 
ADD CONSTRAINT `fk_prod`
  FOREIGN KEY (`id_product`)
  REFERENCES `int_mindbox`.`products` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_cat`
  FOREIGN KEY (`id_category`)
  REFERENCES `int_mindbox`.`product_categories` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
    
USE `int_mindbox`;

SELECT * FROM products_lib;
INSERT INTO products_lib(id_product, id_category) VALUES (1, 1);
INSERT INTO products_lib(id_product, id_category) VALUES (1, 5);
INSERT INTO products_lib(id_product) VALUES (6);
INSERT INTO products_lib(id_product, id_category) VALUES (2, 1);
INSERT INTO products_lib(id_product, id_category) VALUES (2, 6);
INSERT INTO products_lib(id_product, id_category) VALUES (3, 2);
INSERT INTO products_lib(id_product) VALUES (5);

SELECT products.name, product_categories.name FROM products_lib
	INNER JOIN products ON products_lib.id_product = products.id
    LEFT JOIN  product_categories ON products_lib.id_category = product_categories.id;