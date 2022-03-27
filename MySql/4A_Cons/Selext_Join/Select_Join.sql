USE 4a_schema;
SELECT * FROM t1
	INNER JOIN t2 on t1.id = t2.id;

SELECT * FROM t1
	INNER JOIN t2 on t1.id = t2.id
    	WHERE t2.id IS NOT NULL;
        
SELECT t1.* FROM t1
	LEFT JOIN t2 on t1.id = t2.id
  	WHERE t2.id IS NULL;