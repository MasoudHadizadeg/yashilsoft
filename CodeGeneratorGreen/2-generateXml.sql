/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 3/3/2020 11:15:58 AM
 ************************************************************/

EXEC INSERT_AppEntity


SELECT s.name                       AS '@schema',
       t.name                       AS '@name',
       t.object_id                  AS '@id',
       ae.GenerateTabForDescColumn  AS '@generateTabForDescColumn',
       ae.HasAttachmenet            AS '@hasAttachmenet',
       dbo.getTableDesc(t.[object_id]) AS '@tableDesc',
       (
           SELECT c.name         AS '@name',
                  c.column_id    AS '@id',
                  IIF(ic.object_id IS NOT NULL, 1, 0) AS '@isPrimaryKey',
                  CASE 
                       WHEN fkc.constraint_column_id IS NULL THEN 0
                       ELSE 1
                  END            AS '@isForeignKey',
                  (
                      SELECT c2.name
                      FROM   sys.[columns] AS c2
                      WHERE  c2.column_id = fkc.referenced_column_id
                             AND c2.[object_id] = fkc.referenced_object_id
                  )              AS '@referencedColumnName',
                  CASE 
                       WHEN fkc.constraint_column_id IS NOT NULL THEN (
                                SELECT td.TitlePropertyName
                                FROM   base.AppEntity td
                                WHERE  td.Title = (
                                           SELECT t.name
                                           FROM   sys.tables AS t
                                           WHERE  t.[object_id] = fkc.referenced_object_id
                                       )
                            )
                  END            AS '@referencedObjectTitleColumn',
                  CASE 
                       WHEN fkc.constraint_column_id IS NOT NULL THEN (
                                SELECT td.IsLarge
                                FROM   base.AppEntity td
                                WHERE  td.Title = (
                                           SELECT t.name
                                           FROM   sys.tables AS t
                                           WHERE  t.[object_id] = fkc.referenced_object_id
                                       )
                            )
                  END            AS '@referencedObjectIsLarge',
                  (
                      SELECT c2.name
                      FROM   sys.[columns] AS c2
                      WHERE  c2.column_id = fkc.constraint_column_id
                             AND c2.[object_id] = fkc.constraint_object_id
                  )              AS '@constraintColumnName',
                  (
                      SELECT t1.name
                      FROM   sys.tables AS t1
                      WHERE  t1.[object_id] = fkc.referenced_object_id
                  )              AS '@referencedObject',
                  fkc.referenced_object_id AS '@columnReferencesTableId',
                  fkc.referenced_column_id AS '@columnReferencesTableColumnId',
                  dbo.getColDesc(c.[object_id], c.column_id) AS '@colDesc',
                  c.is_identity  AS '@isIdentity',
                  c.is_nullable  AS '@isNullable',
                  c.is_computed  AS '@isComputed',
                  c.max_length   AS '@maxLength',
                  c.scale        AS '@scale',
                  ty.name        AS '@colType'
           FROM   sys.columns    AS c
                  LEFT JOIN sys.types ty
                       ON  c.user_type_id = ty.user_type_id
                  LEFT OUTER JOIN sys.index_columns AS ic
                       ON  c.object_id = ic.object_id
                       AND c.column_id = ic.column_id
                       AND ic.index_id = 1
                  LEFT OUTER JOIN sys.foreign_key_columns AS fkc
                       ON  c.object_id = fkc.parent_object_id
                       AND c.column_id = fkc.parent_column_id
           WHERE  c.object_id = t.object_id
                  FOR XML PATH('Column'),TYPE
       )
FROM   sys.schemas                  AS s
       INNER JOIN sys.tables        AS t
            ON  s.schema_id = t.schema_id
            AND t.name NOT IN ('sysdiagrams', 'TableDesc')
            AND s.name = 'tms'
       INNER JOIN base.AppEntity    AS ae
            ON  t.[object_id] = ae.SystemId
                FOR XML PATH('Table'),
       ROOT('Tables')
       
     
       