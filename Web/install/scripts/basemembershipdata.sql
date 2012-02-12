DELETE FROM dbo.[aspnet_UsersInRoles]
GO
DELETE FROM dbo.[aspnet_Roles]
GO
DELETE FROM dbo.[aspnet_Membership]
GO
DELETE FROM dbo.[aspnet_Users]
GO
DELETE FROM dbo.[aspnet_Applications]
GO
DELETE FROM dbo.[aspnet_SchemaVersions]
GO

INSERT INTO  dbo.[aspnet_SchemaVersions] ([Feature],[CompatibleSchemaVersion],[IsCurrentVersion]) VALUES('common', '1', 1)
INSERT INTO  dbo.[aspnet_SchemaVersions] ([Feature],[CompatibleSchemaVersion],[IsCurrentVersion]) VALUES('health monitoring', '1', 1)
INSERT INTO  dbo.[aspnet_SchemaVersions] ([Feature],[CompatibleSchemaVersion],[IsCurrentVersion]) VALUES('membership', '1', 1)
INSERT INTO  dbo.[aspnet_SchemaVersions] ([Feature],[CompatibleSchemaVersion],[IsCurrentVersion]) VALUES('personalization', '1', 1)
INSERT INTO  dbo.[aspnet_SchemaVersions] ([Feature],[CompatibleSchemaVersion],[IsCurrentVersion]) VALUES('profile', '1', 1)
INSERT INTO  dbo.[aspnet_SchemaVersions] ([Feature],[CompatibleSchemaVersion],[IsCurrentVersion]) VALUES('role manager', '1', 1)
INSERT INTO  dbo.[aspnet_Applications] ([ApplicationName],[LoweredApplicationName],[ApplicationId],[Description]) VALUES('dashCommerce', 'dashcommerce', '83c1c3f6-c539-41d7-815d-143fbd40e41f', 'dashCommerce')
INSERT INTO  dbo.[aspnet_Roles] ([ApplicationId],[RoleId],[RoleName],[LoweredRoleName],[Description]) VALUES('83c1c3f6-c539-41d7-815d-143fbd40e41f', 'a177e260-575a-4cf1-b12e-caf43d63621e', 'Administrator', 'administrator', NULL)
INSERT INTO  dbo.[aspnet_Roles] ([ApplicationId],[RoleId],[RoleName],[LoweredRoleName],[Description]) VALUES('83c1c3f6-c539-41d7-815d-143fbd40e41f', 'ba6e6b1f-03b9-43c0-b01f-c6c22a14060f', 'Registered User', 'registered user', NULL)