USE 4a_schema;
SET @xml = LOAD_FILE('C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/name.xml');
SELECT CONVERT(ExtractValue(@xml, '/Row/Id[../StatusId!="3"]') USING utf8) AS Id,
	CONVERT(ExtractValue(@xml, '/Row/Code[../StatusId!="3"]') USING utf8) AS Code,
    CONVERT(ExtractValue(@xml, '/Row/Name[../StatusId!="3"]') USING utf8) AS Name,
    CONVERT(ExtractValue(@xml, '/Row/StatusId[../StatusId!="3"]') USING utf8) AS StatusId;