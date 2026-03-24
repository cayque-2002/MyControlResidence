# MyControlResidence

Sistema web para **controle financeiro residencial**, permitindo gerenciar pessoas, categorias e transações financeiras, além de gerar relatórios consolidados de receitas e despesas.

O projeto foi desenvolvido como **teste técnico** com foco em boas práticas de arquitetura, organização de código e separação de responsabilidades utilizando **DDD (Domain Driven Design)** no backend.

---

# Demonstração

O sistema permite:

- Cadastro de **Pessoas**
- Cadastro de **Categorias** (Receita / Despesa / Ambas)
- Cadastro de **Transações financeiras**
- Relatórios financeiros por:
  - Categoria
  - Pessoa
- Visualização de **saldo total**, receitas e despesas

---

# Arquitetura

O backend segue o padrão **DDD (Domain Driven Design)** para organização da aplicação.

Estrutura principal:

src
│
├── Domain
│ ├── Entities
│ ├── Enums
│
├── Application
│ ├── DTOs
│ ├── Services
│
├── Infrastructure
│ ├── Data
│ ├── Migrations
│
├── API
│ ├── Controllers


Principais conceitos aplicados:

- Separação de responsabilidades
- DTOs para transporte de dados
- Services para regras de negócio
- Controllers para exposição da API
- Entity Framework para persistência

## Padrões e Boas Práticas

- Aplicação do princípio da Inversão de Dependência (SOLID)
- Uso de interfaces para desacoplamento da camada de dados
- Injeção de dependência nativa do ASP.NET Core
- Separação em camadas (Domain, Application, Infrastructure)
- Utilização de DTOs para evitar acoplamento entre domínio e API


---

# Tecnologias Utilizadas

## Backend

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite (LocalDB)
- Arquitetura DDD

## Frontend

- React
- TypeScript
- Axios
- React Toastify
- CSS responsivo

---

# Funcionalidades

## Pessoas

Permite cadastrar pessoas responsáveis pelas transações.

Campos:

- Nome
- Idade
- Data de criação

Operações disponíveis:

- Criar
- Editar
- Excluir
- Listar

---

## Categorias

Permite cadastrar categorias financeiras.

Exemplos:

- Salário
- Alimentação
- Aluguel

Cada categoria possui uma finalidade:

- Receita
- Despesa
- Ambas

---

## Transações

Registro das movimentações financeiras do sistema.

Campos:

- Descrição
- Valor
- Tipo (Receita ou Despesa)
- Categoria
- Pessoa responsável
- Data de criação

---

# Relatórios

O sistema possui dois relatórios principais:

## Relatório por Categoria

Apresenta:

- Total de receitas
- Total de despesas
- Saldo por categoria

Exemplo:

| Categoria | Receita | Despesa | Saldo |
|----------|--------|--------|--------|
| Salário | 3800 | 0 | 3800 |
| Alimentação | 0 | 500 | -500 |
| Aluguel | 0 | 1100 | -1100 |

---

## Relatório por Pessoa

Mostra o consolidado financeiro de cada pessoa cadastrada no sistema.

Campos exibidos:

- Pessoa
- Receita total
- Despesas totais
- Saldo

---

## Regras de Negócio

- Menores de idade (menos de 18 anos) só podem possuir transações do tipo despesa
- Não é permitido associar uma transação a uma categoria incompatível com seu tipo (receita/despesa)
- Ao excluir uma pessoa, todas as suas transações são removidas automaticamente (cascade delete)
- Valores de transação devem ser positivos

# Estrutura do Frontend

src
│
├── components
│ ├── FormModal
│ ├── Input
│ ├── Navbar
│ ├── Table
│
├── pages
│ ├── PessoaPage
│ ├── CategoriaPage
│ ├── TransacaoPage
│ ├── ReportPage
│
├── services
│ ├── pessoaService
│ ├── categoriaService
│ ├── transacaoService
│ ├── relatorioService
│
├── types


---

# Como Executar o Projeto

## 1️⃣ Clonar o repositório

```bash
git clone https://github.com/cayque-2002/MyControlResidence.git
```

# Backend

Entrar na pasta da API:

```bash
cd backend
```

Instalar dependências e rodar migrations.

Rodar a aplicação:

```bash
dotnet run
```

API disponível em:

http://localhost:5050


# Frontend

Entrar na pasta do frontend:

```bash
cd frontend
```

Instalar dependências:

```bash
npm install
```

Executar projeto:

```bash
npm run dev
```

Aplicação disponível em:

http://localhost:5173

## Melhorias Futuras

Autenticação de usuários

Filtros avançados nos relatórios

Dashboard com gráficos

Paginação nas tabelas

Validações adicionais no frontend

Testes automatizados


# Autor

Desenvolvido por Cayque Guilherme

Desenvolvedor Backend focado em:

APIs REST

Arquitetura de software

Banco de dados relacionais

Boas práticas de desenvolvimento
