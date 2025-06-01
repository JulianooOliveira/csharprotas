## Sistema de Gerenciamento de Atendimento Médico

### 1. Objetivo do Projeto
 - O objetivo deste projeto é desenvolver uma API RESTful voltada à gestão de pacientes, médicos e especialidades dentro de um sistema de saúde. A aplicação foi concebida para permitir o cadastro, consulta, atualização e exclusão de dados relacionados a essas entidades.

### 2. Estrutura da Solução

2.1 Modelagem de Dados - A modelagem do sistema foi dividida em três entidades principais:

 - Paciente: contendo dados como nome, CPF, data de nascimento, email, telefone e endereço.

 - Médico: contendo nome, CRM, CRM-UF, data de nascimento, especialidade principal e telefone profissional.

 - Especialidade: representando a área de atuação de um médico, contendo nome, descrição e nível de complexidade, com relação direta a um médico.

Essas entidades foram implementadas com classes C# e integradas ao banco de dados via Entity Framework Core, utilizando SQLite como repositório principal.

### 2.2 Integração da API com a Solução
A API foi organizada de forma modular, com rotas separadas por operação (GET, POST, PUT, DELETE). O modelo minimalista do .NET 8 foi adotado para construir as rotas de forma direta e expressiva, permitindo testes e interações fáceis com ferramentas como Postman.

#### 3. Endpoints da API

| Método  | Rota                         | Descrição                            |
|---------|------------------------------|----------------------------------------|
| GET     | /api/pacientes               | Lista todos os pacientes              |
| GET     | /api/pacientes/{id}          | Busca um paciente pelo ID             |
| POST    | /api/pacientes               | Cadastra um novo paciente             |
| PUT     | /api/pacientes/{id}          | Atualiza um paciente existente        |
| DELETE  | /api/pacientes/{id}          | Remove um paciente                    |
| GET     | /api/medicos                 | Lista todos os médicos                |
| GET     | /api/medicos/{id}            | Busca um médico pelo ID               |
| POST    | /api/medicos                 | Cadastra um novo médico               |
| PUT     | /api/medicos/{id}            | Atualiza um médico existente          |
| DELETE  | /api/medicos/{id}            | Remove um médico                      |
| GET     | /api/especialidades          | Lista todas as especialidades         |
| GET     | /api/especialidades/{id}     | Busca uma especialidade pelo ID       |
| POST    | /api/especialidades          | Cadastra uma nova especialidade       |
| PUT     | /api/especialidades/{id}     | Atualiza uma especialidade existente  |
| DELETE  | /api/especialidades/{id}     | Remove uma especialidade              |

### 4. Organização do Código - O código está dividido de forma clara entre responsabilidades:

 - Models/: Contém as classes de Paciente, Médico e Especialidade.

 - Context/Modelo/: Define o contexto SistemaSaudeContext com configuração do EF Core.

 - Rotas/Rota_GET.cs, Rota_POST.cs, Rota_PUT.cs, Rota_DELETE.cs: Implementação separada das operações HTTP.

 - Program.cs: Configura o pipeline da aplicação e registra as rotas, contexto e CORS.

### 5. Justificativa Técnica
O uso de SQLite foi escolhido por ser leve e adequado para protótipos e ambientes locais. A separação das rotas por operação permite manutenção simples e clara. O uso do .NET 8 e do EF Core 9.0 garante compatibilidade com as tecnologias mais recentes do ecossistema Microsoft.
