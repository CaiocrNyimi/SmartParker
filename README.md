# SmartParker API

API para gerenciamento de motos, desenvolvida em .NET com integração ao banco de dados Oracle por meio de EF Core.

## Membros

2TDSPX:
- Caio Cesar - rm556331
- Guilherme Grizão – rm557958

2TDSPY:
- Pietro – rm555839

## Rotas

- `GET /api/moto` — Lista todas as motos
- `GET /api/moto/{id}` — Busca moto por ID
- `GET /api/moto/search?nome=Pop 100` — Busca motos pelo nome
- `POST /api/moto` — Cria uma nova moto
- `PUT /api/moto/{id}` — Atualiza uma moto existente
- `DELETE /api/moto/{id}` — Remove uma moto

## Instalação

1. Clone o repositório:
-----------------------------------------------------------
    git clone https://github.com/CaiocrNyimi/SmartParker.git
-----------------------------------------------------------

2. Configure a string de conexão Oracle no `appsettings.json` (já configurado).

3. Execute as migrations:
--------------------------------------------------------------
    dotnet ef database update --startup-project ..\SmartParker.API
--------------------------------------------------------------

4. Rode a aplicação:
----------------------------------------
    dotnet run --project SmartParker.API
----------------------------------------

5. Acesse o Swagger para testes em:

http://localhost:[porta]/swagger/index.html

## Tecnologias
- ASP.NET Core
- Entity Framework Core
- Banco de dados Oracle
- Documentação no Swagger

