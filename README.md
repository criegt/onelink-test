# OneLink BPO - Test

Esta prueba esta desarrollada utilizando: 
- `.NET Core 3.1`
- `SQL Server`
- `Angular`

## Web API

Para corre la aplicación se deben seguir los siguientes pasos:

- Clonar proyecto
```
cd onelink-test
```

- Aplicar migraciones
```
dotnet ef database update --project .\src\OneLinkTest.Infrastructure\ --startup-project .\src\OneLinkTest.WebApi\
```

- Iniciar aplicación
```
dotnet run -p .\src\OneLinkTest.WebApi\
```

- Iniciar cliente
```
cd .\src\onelink-test-client\
ng serve
```

### Comandos adicionales

- Crear migración inicial
```
dotnet ef migrations add "InitialCreate" -o "DataAccess/Migrations" --project .\src\OneLinkTest.Infrastructure\ --startup-project .\src\OneLinkTest.WebApi\
```

- Eliminar migraciones
```
dotnet ef migrations remove --project .\src\OneLinkTest.Infrastructure\ --startup-project .\src\OneLinkTest.WebApi\
```