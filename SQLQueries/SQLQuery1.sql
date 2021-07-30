Alter Table [dbo].[Students]
Add ID Int Identity(1, 1)
Go

Alter Table [dbo].[Students] Drop Column StudentId
Go

Exec sp_rename 'Students.ID', 'StudentId', 'Column'