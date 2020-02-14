


INSERT INTO um.RoleResourceAction
(
	-- Id -- this column value is auto-generated
	ResourceActionId,
	RoleId,
	CreateBy,
	ModifyBy,
	CreationDate,
	ModificationDate,
	[Deleted]
)
SELECT raa.Id,1,1,1,GETDATE(),GETDATE(),0 FROM um.ResourceAppAction AS raa

