DELETE um.ResourceAppAction

INSERT INTO um.ResourceAppAction
(
	-- Id -- this column value is auto-generated
	AppActionId,
	ResourceId,
	CreateBy,
	CreationDate
)
	SELECT 
	a.Id action_id,
	r.Id resource_id,
	7,
	getdate()
	 FROM um.Resource AS r
	CROSS JOIN um.[AppAction] AS a

INSERT INTO um.RoleResourceAction
(
	-- Id -- this column value is auto-generated
	ResourceActionId,
	RoleId,
	CreateBy,
	CreationDate
)
SELECT ra.id,1,7,getdate() FROM um.ResourceAppAction AS ra