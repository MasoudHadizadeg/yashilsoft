/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 10/29/2019 9:54:08 PM
 ************************************************************/
 
 
ALTER PROCEDURE INSERT_AppEntity
AS
-- DROP TABLE IF EXISTS #t
SELECT t.name             Title,
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
       )                  TitleColumn,
       CAST(1 AS BIT)  AS IsLargTable
 INTO   #t
FROM   sys.tables AS t
WHERE  t.[type] = 'U'


INSERT INTO base.AppEntity 
  (
    Title,
    ObjectId,
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
                           
DELETE FROM base.AppEntity WHERE Title NOT IN (SELECT Title
											  FROM   #t) 