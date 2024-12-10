# LibraryManager 📚🚀

Bem-vindo ao **LibraryManager**, um sistema de gerenciamento de bibliotecas desenvolvido em ASP.NET Core, utilizando padrões de arquitetura avançados para fornecer uma solução robusta para empréstimos e gerenciamento de livros.

## Funcionalidades Implementadas

- **CRUD completo de Livros**: Cadastro, edição, consulta, remoção, arquivamento e disponibilização de livros.
- **Empréstimos de Livros**: Realização de empréstimos, com alteração do status do livro para "alugado", impossibilitando novos empréstimos até a devolução.
- **Devolução de Livros**: Devolução com cálculo de dias de atraso e re-disponibilização do livro para novos empréstimos.
- **Listagem de Empréstimos**: Exibição de empréstimos realizados, com filtros por ID e por usuário.
- **CRUD completo de Usuários**: Gerenciamento eficiente de usuários da biblioteca.

## Tecnologias Utilizadas

- **.NET 9**
- **ASP.NET Core**  
- **Blazor WebAssembly**: Interface moderna para consumir a API.  
- **CQRS (Command Query Responsibility Segregation)**: Separação de comandos (escrita) e consultas (leitura).  
- **Fluent Validation**: Validação fluente para entradas de dados (usuários e livros).  
- **Entity Framework Core**: ORM para comunicação com o banco de dados.  

## Estrutura do Projeto

O projeto segue a Arquitetura Limpa e implementa o padrão CQRS para melhorar a organização e escalabilidade. A seguir, algumas camadas principais:

- **Application Layer**: Contém os casos de uso, incluindo comandos e consultas.
- **Domain Layer**: Modelos de domínio e regras de negócios.
- **Infrastructure Layer**: Acesso a dados e implementação de repositórios.

## Pré-requisitos

Antes de começar, você vai precisar ter instalado:

- [.NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [JetBrains Rider](https://www.jetbrains.com/rider/) (ou outra IDE de sua preferência)
- Banco de dados: SQL Server

## Imagens do Frontend (Blazor)

### Tela de Listagem dos Cards dos Livros
![Tela de Listagem de Livros](/images/Site/books-card.png)

### Tela de Listagem de Livros  
![Tela de Listagem de Livros](/images/Site/book-list.png)

### Tela de Cadastro/Edição de Livros  
![Tela de Cadastro de Livros](/images/Site/book-edit.png)

### Tela de Detalhes do Livro
![Tela de Listagem de Empréstimos](/images/Site/book-detail.png)
  
## Como rodar o projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/LibraryManager.git

## Exemplos de Uso da API

### 1. CRUD de Livros
- **GET** `/api/books` - Lista todos os livros.
- **GET** `/api/books/{id}` - Obtem um livro pelo seu id.
- **POST** `/api/books` - Adiciona um novo livro.
- **POST** `/api/books/{id}/archive` - Atualiza o status do livro para arquivado.
- **POST** `/api/books/{id}/available` - Atualiza o status do livro para disponivel.
- **PUT** `/api/books/{id}` - Atualiza as informações de um livro.
- **DELETE** `/api/books/{id}` - Remove um livro.

### 2. Empréstimos de Livros
- **GET** `/api/loans` - Lista todos os empréstimos.
- **GET** `/api/loans/{id}` - Obtem um empréstimo pelo seu id.
- **GET** `/api/loans/by-user/{id}` - Obtem um empréstimo pelo id de um usuário.
- **POST** `/api/loans` - Realiza um novo empréstimo.
- **PUT** `/api/loans/{id}/return-book` - Devolve o livro e calcula dias de atraso (se houver).

### 3. CRUD de Usuários
- **GET** `/api/users` - Lista todos os usuários.
- **GET** `/api/users/{id}` - OPbtem um usuário pelo seu id.
- **POST** `/api/users` - Adiciona um novo usuário.
- **PUT** `/api/users/{id}` - Atualiza as informações de um usuário.
- **DELETE** `/api/users/{id}` - Deleta um usuário.

---

## Próximos Passos

- Implementação de autenticação e autorização.
- Testes unitários e de integração.
- Melhorias na interface

---

## Agradecimentos

Este projeto faz parte da minha jornada de aprendizado em ASP.NET Core, .NET 9 e Blazor. Um agradecimento especial ao professor Luis Felipe e à equipe da **Next Wave Education** pela mentoria.

