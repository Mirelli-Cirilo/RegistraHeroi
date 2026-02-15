# RegistraHeroi

## Projeto desenvolvido para processo seletivo.

## Sobre a aplicação
- Optei por desenvolver o backend utilizando .NET, organizando os controllers, services e DTOs de forma clara para manter o código mais fácil de entender e dar manutenção.
  
- Usei Entity Framework Core conectado ao banco em memória para facilitar os testes iniciais do projeto e popular os dados de exemplo rapidamente.
  
- No frontend com Angular, utilizei Html e Csd para criar interfaces simples e limpas, e organizei os componentes de forma modular para facilitar futuras melhorias.
  
- Implementei telas de listagem, criação, edição e exclusão de heróis, garantindo que o fluxo básico da aplicação estivesse completo.
  
- Para manter o código mais robusto, organizei os DTOs e serviços de forma consistente e padronizada, facilitando testes e futuras alterações.

## Tecnologias

Backend: .NET 8, Entity Framework Core, REST API, C#, InMemory Database

Frontend: Angular 18, HTML, CSS 

Outros: Git, GitHub, Visual Studio / VS Code

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

   
