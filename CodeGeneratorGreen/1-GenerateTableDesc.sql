/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 10/29/2019 9:54:08 PM
 ************************************************************/
CREATE PROCEDURE INSERT_TableDesc
AS

SELECT t.name             TableName,
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


INSERT INTO TableDesc
  (
    TableName,
    [object_id],
    TitleColumn,
    IsLargTable
  )
SELECT TableName,
       [object_id],
       TitleColumn,
       IsLargTable
FROM   #t t
WHERE  t.TableName NOT IN (SELECT TableName
                           FROM   TableDesc)
                           
DELETE FROM TableDesc WHERE TableName NOT IN (SELECT TableName
											  FROM   #t) 