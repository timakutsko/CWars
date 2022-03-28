CREATE TABLE `4a_schema`.`bank_acc` (
  `id` INT NOT NULL,
  `money` DECIMAL(10,2) NOT NULL,
  `user_name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`));

INSERT INTO `4a_schema`.`bank_acc` (`id`, `money`, `user_name`) VALUES (1, 75, "Me");
INSERT INTO `4a_schema`.`bank_acc` (`id`, `money`, `user_name`) VALUES (2, 0, "Con");

SELECT * FROM 4a_schema.bank_acc;

START TRANSACTION;
	UPDATE `4a_schema`.`bank_acc` set `money` = `money` - 50 WHERE `id` = 1;
	UPDATE `4a_schema`.`bank_acc` set `money` = `money` + 50 WHERE `id` = 2;
COMMIT;