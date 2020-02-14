/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 2/14/2020 8:25:58 PM
 ************************************************************/


DROP TABLE 
IF EXISTS #t
    TRUNCATE TABLE um.Menu

TRUNCATE TABLE Schemas 

INSERT INTO Schemas
SELECT DISTINCT s.name           NAME,
       ''                        Title
FROM   sys.schemas            AS s
       INNER JOIN sys.tables  AS t
            ON  s.schema_id = t.schema_id
WHERE  t.name NOT IN ('sysdiagrams', 'report-backup', 'tableDesc')

INSERT INTO um.Menu
  (
    -- Id -- this column value is auto-generated
    [Path],
    Title,
    CreateBy,
    CreationDate,
    ApplicationId,
    CreatorOrganizationId
  )
SELECT '',
       s.name,
       7,
       GETDATE(),
       1,
       1
FROM   Schemas s

SELECT CASE 
            WHEN s.name != 'dbo' THEN '/' + s.name
            ELSE ''
       END + CAST(
           '/' + LOWER(LEFT(t.NAME, 1)) + SUBSTRING(t.NAME, 2, LEN(t.NAME)) + 's' AS NVARCHAR
       )              PATH,
       CAST(ISNULL(dbo.getTableDesc(t.[object_id]), '') AS NVARCHAR) title,
       'ft-users'     icon,
       7              CreateBy,
       GETDATE()      CreationDate,
       sdm.id         ParentId
INTO   #t
FROM   sys.schemas AS s
       INNER JOIN sys.tables AS t
            ON  s.schema_id = t.schema_id
       INNER JOIN Schemas sd
            ON  sd.Name = s.name
       INNER JOIN um.Menu sdm
            ON  sdm.Title = sd.name
WHERE  t.name NOT IN ('sysdiagrams', 'report-backup', 'tableDesc', 'Schemas')


UPDATE um.Menu
SET    Title = t.Title
FROM   um.Menu
       INNER JOIN #t t
            ON  um.Menu.[Path] = t.path

INSERT INTO um.Menu
  (
    -- Id -- this column value is auto-generated
    [Path],
    Title,
    Icon,
    CreateBy,
    CreationDate,
    ParentId,
    ApplicationId,
    CreatorOrganizationId
  )
SELECT [Path],
       Title,
       Icon,
       CreateBy,
       CreationDate,
       ParentId,
       1  ApplicationId,
       1  CreatorOrganizationId
FROM   #T t
