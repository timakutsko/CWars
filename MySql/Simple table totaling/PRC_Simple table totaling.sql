CREATE PROCEDURE creator (IN num INT, IN nameVar VARCHAR(45), IN clanVar VARCHAR(45))
  BEGIN
	  DECLARE i INT DEFAULT 0;
	  DECLARE var TINYTEXT DEFAULT '';
	  WHILE i < num DO
		SET i = i + 1;
		SET var = CONCAT(nameVar, i);
		insert into people(name, points, clan) values(var, 30, clanVar);
	  END WHILE;
	END
