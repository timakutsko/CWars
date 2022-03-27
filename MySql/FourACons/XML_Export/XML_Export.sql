USE 4a_schema;
SELECT
	CONCAT('<?xml version="1.0" encoding="UTF-8"?>')
UNION
SELECT
	CONCAT(
        '<Row>',
			GROUP_CONCAT('\n\t<Id>', id, '</Id>'),
			GROUP_CONCAT('\n\t<Code>', Code, '</Code>'),
            GROUP_CONCAT('\n\t<Name>', Name, '</Name>'),
			GROUP_CONCAT('\n\t<StatusId s_id=', '"', StatusId, '"','>', StatusId, '</StatusId>'),            
		'\n</Row>') AS XMLDOC
FROM t3 GROUP BY id INTO OUTFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/name.xml';