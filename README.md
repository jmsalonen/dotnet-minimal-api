# Description

Dotnet Minimal API template with Sqlite and EF migrations.

```bash
dotnet dotnet-ef ef migrations add InitialMigration \
  --context DeviceDBContext \
  --output-dir Services/DeviceService/Infrastructure/Migrations

dotnet ef migrations add InitialMigration \
  --context UserDbContext \
  --output-dir Services/UserService/Infrastructure/Migrations
```
