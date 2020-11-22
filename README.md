# API.NET-MongoDB
exemplo Api .Net com banco de dados Atlas MongoDB

Exemplos MongoDB

 ### Insert
```
for(var i=0;i<=25;i++) db.contador.insert({x:i})

db.products.insert({ProductName:"Caixa",Price:20})

db.products.insertMany([
	{ ProductName: "Lapis",stock: 10, Price: 20, status: "A" },
	{ ProductName: "Tesoura",stock: 10, Price: 20, status: "B" },
	{ ProductName: "Borracha",stock: 10, Price: 20, status: "A" },
])
```

### Find
I) SELECT * FROM contador
```
db.contador.find().pretty()
```

II) SELECT * FROM products WHERE status = "A"
db.products.find({ status:"A" })

III) SELECT * FROM products WHERE status in ("A", "B")
db.products.find({ status: { $in: ["A","B"] } })

- mongo atlas - https://www.mongodb.com/cloud/atlas/register
Criar cluster no atlas MongoDb, em database acess criar usuario
Connect your aplicattion -> copiar a connect string 

### Criar projeto .Net

#### dotnet new api -n Api

appsettings.json adicionar para poder conectar no banco
```
 },
  "AllowedHosts": "*",
  "ConnectionString": "",
  "NomeBanco": "coronavirus"
}
```
https://docs.mongodb.com/ecosystem/drivers/csharp/
Documentacao MongoDb C# driver -> instalar GeoJson2DGeographicCoordinates para geolocalizacao, adicione no api.csproj
```
	<PackageReference Include="MongoDB.Driver" Version="2.10.2" />
  </ItemGroup>
```
#### dotnet add package MongoDB.Driver

figuras legais para respostas da conexao site:
- http.cat - http.cat

debugar e fazer testes com POSTMAN
Para teste:
https://localhost:5001/infectado

POST no body do Postman:
obs:Av Paulista
```
{
	"dataNascimento": "1990-03-01",
	"sexo": "M",
	"latitude": -23.5630994,
	"longitude": -46.6565712
}
```

build:
#### dotnet run 
