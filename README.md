# MerceariaAPI

## Visão Geral do Sistema

O projeto consiste no desenvolvimento de uma API Restful para o gerenciamento de produtos e usuários, especificamente voltada para o contexto de uma mercearia ou minimercado.

A API será desenvolvida utilizando a arquitetura Model-View-Template (MVT) em conjunto com o padrão Repository, assegurando uma separação clara entre as camadas de lógica de negócios, apresentação e persistência de dados. Isso garantirá uma estrutura de código limpa, de fácil manutenção e altamente testável.

#### Objetivos e Propósito do Sistema

Facilitar o cadastro, consulta, alteração e exclusão de produtos e usuários.

#### Benefícios Esperados do Projeto

Automação do gerenciamento de produtos e usuários, aumento da eficiência operacional e melhoria na organização de dados.

### Requisitos Funcionais e Não Funcionais

#### Funcionais

- Cadastro, consulta, alteração e exclusão de produtos.
- Autenticação e registro de usuários.

#### Não Funcionais

- Segurança, desempenho, escalabilidade e manutenibilidade.

### Arquitetura do Sistema

#### Arquitetura MVT (Model-View-Template)

- **Model:** Representa a estrutura dos dados.
- **View:** Controla a lógica de negócios e a interação com o usuário.
- **Template:** Define a apresentação dos dados.

#### Uso do Padrão Repository

Abstração da lógica de acesso a dados, facilitando a manutenção e a testabilidade do código.

### Requisitos Funcionais Detalhados

- Cadastro, consulta, alteração e exclusão de produtos.
- Registro e autenticação de usuários.

### Casos de Uso Principais

- Administrador cadastra um novo produto.
- Usuário consulta detalhes de um produto específico.

### Requisitos Não Funcionais

- Desempenho esperado do sistema: Resposta em tempo real com latência mínima.
- Segurança e autenticação: Uso de JWT para autenticação de usuários.
- Escalabilidade e manutenibilidade: Estrutura modular para facilitar a escalabilidade e manutenção.

### Tecnologias Utilizadas

- Linguagem de Programação: C#
- Frameworks: ASP.NET Core, EntityFramework
- Banco de Dados: SQLite
- Ferramentas de Desenvolvimento: Visual Studio Code

### Modelo de Dados

#### Estrutura do Banco de Dados

- Tabelas para produtos e usuários.
- Relacionamentos entre entidades: Relacionamentos de herança entre tipos de produtos.
- Esquema de Armazenamento: Tabelas e colunas específicas para cada tipo de produto.

### Interfaces do Usuário

- APIs RESTful sem interface gráfica.
- Interações via chamadas API.

### Arquitetura de Implementação

- Organização do Código-fonte: Separação em camadas (Controllers (Views), Models, Repositories, Services).
- Divisão em Módulos e Componentes: Módulos para produtos, usuários e autenticação.
- Dependências entre os Componentes: Controllers dependem de Services que dependem de Repositories.

### Planejamento de Implantação

- Ambientes de Implantação: Desenvolvimento, teste e produção.
- Migração de Dados, se Necessário: Frameworks de ORM para migração de banco de dados.

### Gestão de Configuração e Controle de Versão

- Políticas de Controle de Versão: Uso de Git com branches específicas para desenvolvimento, teste e produção. Ramificação do código-fonte: Feature branches, release branches e hotfix branches.
- Uso de Ferramentas de Controle de Versão: Git Flow.

### Gestão de Projetos

- Cronograma de Desenvolvimento: Planejamento iterativo e incremental.
- Atribuição de Tarefas e Responsabilidades: Projeto individual.
- Monitoramento do Progresso do Projeto: Não se aplica.

### Considerações de Segurança

- Mecanismos de Autenticação e Autorização: Autenticação JWT, autorização baseada em roles.
- Proteção contra Vulnerabilidades Conhecidas: Implementação de práticas de segurança recomendadas (OWASP).
- Auditoria e Registro de Atividades Sensíveis: Logs de acesso e alterações.

## Iniciando a Aplicação

### Pré-requisitos

1. **Ambiente de Desenvolvimento**
   - Certifique-se de ter um ambiente de desenvolvimento configurado com as seguintes ferramentas:
     - **IDE:** Recomenda-se utilizar Visual Studio Code ou Visual Studio.
     - **.NET SDK:** Instale o .NET SDK mais recente disponível em [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

2. **Banco de Dados**
   - A aplicação utiliza SQLite como banco de dados padrão, o qual é incorporado e não requer instalação separada.

### Configuração e Execução

1. **Clone o Repositório**
   - Abra um terminal ou prompt de comando.
   - Execute o seguinte comando para clonar o repositório MerceariaAPI:

     ```bash
     git clone https://github.com/seu-usuario/mercearia-api.git
     ```

   - Substitua `https://github.com/seu-usuario/mercearia-api.git` pelo URL do seu repositório, se aplicável.

2. **Abra o Projeto**
   - Navegue até o diretório do projeto:

     ```bash
     cd mercearia-api
     ```

3. **Build da Aplicação**
   - Execute o comando para restaurar as dependências e compilar o projeto:

     ```bash
     dotnet build
     ```

4. **Configuração do Banco de Dados**
   - Execute as migrações para criar o banco de dados SQLite e suas tabelas:

     ```bash
     dotnet ef database update
     ```

   - Isso aplicará todas as migrações pendentes e configurará o banco de dados SQLite com base nas configurações do DbContext.

5. **Executando a Aplicação**
   - Inicie a aplicação usando o comando:

     ```bash
     dotnet run
     ```

   - A aplicação será iniciada localmente em `http://localhost:5000` (ou `https://localhost:5001` com HTTPS).

6. **Testando a Aplicação**
   - Use ferramentas como Postman, Insomnia ou um navegador para enviar requisições HTTP aos endpoints da API.

#### Observações

- Certifique-se de que todas as dependências estão instaladas corretamente antes de iniciar a aplicação.
- Para fins de desenvolvimento, você pode modificar as configurações de banco de dados no arquivo `appsettings.json` se necessário.


===========================================================================

Este projeto faz parte dos requisitos para aprovação na disciplina de Desenvolvimento Web II 
do curso de Análise e Desenvolvimento de Sistemas no Senai Gaspar Ricardo Júnior - Sorocaba/SP.

Curso ministrado pelo Prof. Me. André Cassulino. 

===========================================================================

Desenvolvimento: Rafael Rodrigues
- Aluno 3º Semestre de ADS/ 2024
- Contato: rafael.rodrigues44@senaisp.edu.br

--------------------------------------------------------------------------------------------   
