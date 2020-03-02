/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 8/20/2019 9:10:29 PM
 ************************************************************/
delete [um].[RoleResourceAction];
delete um.ResourceAppAction
delete   um.Resource 


INSERT INTO um.Resource
  (
    -- Id -- this column value is auto-generated
    Title,
    [Description],
    [Type],
	CreateBy,
	CreationDate
  )
SELECT cast(NAME AS  NVARCHAR(200)) name,
      isnull(CAST (dbo.getTableDesc(t.[object_id]) AS NVARCHAR(max)),cast(NAME AS  NVARCHAR(max)))  [Description],
       1              TYPE,
	   7,
	   GETDATE()
FROM   sys.tables  AS t
where t.name not in ('Schemas','sysdiagrams','TableDesc')