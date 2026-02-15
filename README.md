# RegistraHeroi

## Projeto desenvolvido para um processo seletivo.

Sistema de registro de heróis, com backend em .NET 8 e frontend em Angular 18 (standalone components), seguindo boas práticas e separação de responsabilidades.

## Tecnologias

Backend: .NET 8, Entity Framework Core, REST API, C#, InMemory Database

Frontend: Angular 17, HTML, CSS 

Outros: Git, GitHub, Visual Studio / VS Code

## Funcionalidades

### Cadastro de Heróis

 - Inserção de heróis com nome real, nome de herói, data de nascimento, altura, peso e superpoderes.
  
 - Validação de dados obrigatórios e restrições, incluindo impedir datas de nascimento futuras.
  
 - Mensagens de erro exibidas no formulário e via alert quando necessário.

### Listagem de Heróis

 - Exibição de lista de heróis cadastrados com ações de Info, Editar e Excluir.
  
 - Atualização automática da lista após exclusão.

### Detalhes do Herói

 - Tela de informações completas do herói.

### Edição de Heróis

 - Atualização dos dados do herói existente, com validações.

### Exclusão com Modal

 - Confirmação de exclusão via modal customizado (não mais via alert).

# Como Rodar o Projeto

## Backend (.NET)
### 1. Abra a pasta RegisterHeroApi/ no Visual Studio.
### 2. Abra o Terminal dentro da pasta do projeto e rode o comando - > "dotnet run"
  - A API estará disponível em disponível em http://localhost:5159.
### 3. Banco de dados: usa InMemory, não precisa de SQL Server ou configuração adicional.

## Frontend (Angular)

### 1. Abra o terminal na pasta register-hero-front/.
### 2. Rode o comando -> "ng serve"
### 3. Acesse http://localhost:4200 no navegador.

## Observações: como o backend é InMemory, todos os dados são temporários. Ao reiniciar a aplicação, o cadastro de heróis será resetado.

   
