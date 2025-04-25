# Entrega PetShopCSharp

## 1. String de conexão
No `appsettings.json` usei:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS01;Database=PetShopDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

Comandos executados

dotnet build
dotnet tool run dotnet-ef database update --project PetShopCSharp.csproj
dotnet run --project PetShopCSharp.csproj

URL de teste
Swagger UI em: http://localhost:5000/swagger/index.html