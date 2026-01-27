# FinanceApp

## 🧾 Descrição do Projeto

O FinanceApp é uma aplicação backend em .NET 10 para controle de finanças pessoais, permitindo que os usuários registrem contas, categorias e transações financeiras de forma segura e organizada.
O projeto utiliza Entity Framework Core com SQL Server, autenticação via JWT, seguindo boas práticas de arquitetura com camadas Domain, Application e Infrastructure.

## 🚀 Funcionalidades

- Cadastro de usuários com hash de senha seguro.
- Login com autenticação JWT.
- Estrutura escalável em camadas (Domain, Application, Infrastructure).
- Configuração pronta para testes via Swagger.

Em desenvolvimento:
- CRUD de categorias financeiras.
- CRUD de transações vinculadas a categorias e usuários.
- Validação de entrada de dados e segurança.


## 🛠 Tecnologias

- Backend: .NET 10, C#
- Banco de dados: SQL Server
- ORM: Entity Framework Core
- Autenticação: JWT
- Segurança: Hash de senhas com SHA256/BCrypt
- Documentação: Swagger
- Controle de versão: Git e GitHub

## 📁 Estrutura do Projeto
FinanceApp/
- ├── FinanceApp.API/              -> Camada de API (Controllers, Program.cs)
- ├── FinanceApp.Application/      -> Serviços, DTOs e lógica de negócio
- ├── FinanceApp.Domain/           -> Entidades do domínio
- ├── FinanceApp.Infrastructure/   -> Repositórios, DbContext e migrações

## ⚙️ Pré-requisitos
- .NET 10 SDK
- SQL Server Express
- Ferramenta de testes de API: Postman ou navegador para Swagger
- Git

## 🛠 Instalação e Setup
Configure a connection string no appsettings.Development.json:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=FinanceAppDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```
Crie e atualize o banco de dados:
```
cd FinanceApp.Infrastructure
dotnet ef database update --startup-project ../FinanceApp.API
```
Execute a API:
```
cd ../FinanceApp.API
dotnet run
```
Acesse a documentação Swagger:
```
http://localhost:5110/swagger
```
## 🧑‍💻 Testando os Endpoints
Register: 
```
POST /api/auth/register
{
  "name": "Nome",
  "email": "nome@gmail.com",
  "password": "senha123"
}
```
Login:
```
POST /api/auth/login
{
  "email": "nome@gmail.com",
  "password": "senha123"
}

Response:
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```
O login retorna um JWT, que deve ser usado no header ```Authorization: Bearer <token>``` para acessar endpoints protegidos como categorias e transações.

## 🔒 Segurança

- Senhas armazenadas como hash seguro (SHA256/BCrypt).
- Autenticação via JWT com expiração configurável.
- Endpoints protegidos por ```[Authorize]```.

## 📌 Próximos Passos

- Implementar CRUD completo de categorias e transações.
- Adicionar filtros e relatórios financeiros.
- Implementar testes automatizados (unitários e integração).
