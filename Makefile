init:
	@dotnet ef migrations add InitialDbMigration -c CustomerManagementDbContext -o Migrations

add:
	@dotnet ef migrations add -c CustomerManagementDbContext -o ./Migrations $$name

rollback:
	@./efbundle --connection $${ConnectionStrings__ConnectionString} $$previousmigname

update:
	@echo "$${ConnectionStrings__DatabaseConnection}"
	@./efbundle --connection "$${ConnectionStrings__ConnectionString}"
