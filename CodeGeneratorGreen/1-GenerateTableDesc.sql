/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 3/3/2020 11:14:54 AM
 ************************************************************/

ALTER PROCEDURE INSERT_AppEntity
AS
	-- DROP TABLE IF EXISTS #t
	/************************************************************
	* Code formatted by SoftTree SQL Assistant © v9.1.276
	* Time: 3/3/2020 7:40:19 AM
	************************************************************/
	
	SELECT t.name     Title,
	       t.[object_id],
	       (
	           SELECT TOP(1) c.name
	           FROM   sys.[columns] AS c
	           WHERE  c.[object_id] = t.[object_id]
	                  AND (
	                          c.name LIKE '%Title%'
	                          OR c.name LIKE '%PersianName%'
	                          OR c.name LIKE '%Name%'
	                      )
	           ORDER BY
	                  (
	                      CASE c.name
	                           WHEN '%Title%' THEN 0
	                           WHEN 'Name' THEN 1
	                           WHEN 'PersinaName' THEN 2
	                           ELSE 3
	                      END
	                  )
	       )          TitleColumn,
	       CASE 
	            WHEN t.name = 'AccessLevel' OR t.name = 'AppAction' OR t.name = 'APPLICATION' OR t.name = 'DocType' OR 
	                 t.name 
	                 = 'DocFormat' OR t.name = 'YashilConnectionString' THEN CAST(0 AS BIT)
	            ELSE CAST(1 AS BIT)
	       END     AS IsLargTable
	INTO   #t
	FROM   sys.tables AS t
	WHERE  t.[type] = 'U'
	
	
	INSERT INTO base.AppEntity
	  (
	    Title,
	    SystemId,
	    TitlePropertyName,
	    IsLarge,
	    CreateBy,
	    CreationDate
	  )
	SELECT title,
	       [object_id],
	       TitleColumn,
	       IsLargTable,
	       1,
	       GETDATE()
	FROM   #t t
	WHERE  t.title NOT IN (SELECT title
	                       FROM   base.AppEntity)
	
	DELETE 
	FROM   base.AppEntity
	WHERE  Title NOT IN (SELECT Title
	                     FROM   #t)
	
	UPDATE base.AppEntity
	SET    IsLarge      = #t.IsLargTable,
	       SystemId     = #t.[object_id]
	FROM   base.AppEntity
	       INNER JOIN #t
	            ON  #t.Title = base.AppEntity.Title
	                     
	                     
	                   