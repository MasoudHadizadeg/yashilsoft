/************************************************************
 * Code formatted by SoftTree SQL Assistant © v11.0.35
 * Time: 11/09/1398 10:20:36 ق.ظ
 ************************************************************/

UPDATE um.Menu
SET    resourceId = res2.resourceId
FROM   (
           SELECT m.Id menuId,
                  res.resourceId
           FROM   um.Menu AS m
                  INNER JOIN (
                           SELECT CASE 
                                       WHEN s.name != 'dbo' THEN '/' + s.name
                                       ELSE ''
                                  END + CAST(
                                      '/' + LOWER(LEFT(t.NAME, 1)) + SUBSTRING(t.NAME, 2, LEN(t.NAME)) + 's' AS NVARCHAR
                                  )        PATH,
                                  r.Id     resourceId
                           FROM   sys.schemas AS s
                                  INNER JOIN sys.tables AS t
                                       ON  s.schema_id = t.schema_id
                                  INNER JOIN um.Resource AS r
                                       ON  r.Title = t.name
                       ) res
                       ON  m.[Path] = res.[PATH]
       )res2
WHERE  res2.menuId = Menu.id
 
 
 

 