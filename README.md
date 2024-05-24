# MerceariaAPI
# Escopo do Projeto
## Tópicos a serem abordados na documentação do escopo de um projeto fullstack de TI usando arquitetura MVT com repository:

### 1. Visão Geral do Sistema

    Visão geral do projeto: consiste no desenvolvimento de uma API Restful para o gerenciamento de produtos e usuários, especificamente 
    voltada para o contexto de uma mercearia ou minimercado. 
    
    A API será desenvolvida utilizando a arquitetura Model-View-Template (MVT) em conjunto com o padrão  Repository, assegurando uma 
    separação clara entre as camadas de lógica de negócios, apresentação e persistência de dados. Isso garantirá uma estrutura de código 
    limpa, de fácil manutenção e altamente testável.
    
    Objetivos e propósito do sistema: Facilitar o cadastro, consulta, alteração e exclusão de produtos e usuários.
    
    Benefícios esperados do projeto: Automação do gerenciamento de produtos e usuários, aumento da  eficiência operacional e melhoria na 
    organização de dados.
    
### 2. Requisitos funcionais e não funcionais:

     Funcionais: Cadastro, consulta, alteração e exclusão de produtos; autenticação e registro de usuários.
     Não funcionais: Segurança, desempenho, escalabilidade e manutenibilidade.

### 3. Arquitetura do Sistema

    Arquitetura MVT (Model-View-Template):
        Model: Representa a estrutura dos dados.
        View: Controla a lógica de negócios e a interação com o usuário.
        Template: Define a apresentação dos dados.
        
    Papel de cada componente:
        Model: Gerencia os dados e a lógica de negócios associada.
        View: Recebe as solicitações HTTP, processa os dados do modelo e retorna a resposta HTTP.
        Template: Renderiza a resposta em um formato específico, como HTML.
        
    Uso do padrão Repository para acesso a dados: Abstração da lógica de acesso a dados, facilitando a manutenção e a 
    testabilidade do código.

### 4. Requisitos Funcionais

    Lista detalhada de funcionalidades do sistema:
        Cadastro, consulta, alteração e exclusão de produtos.
        Registro e autenticação de usuários.
    Casos de uso principais:
        Administrador cadastra um novo produto.
        Usuário consulta detalhes de um produto específico.
    Fluxos de trabalho do usuário:
        Login -> Consultar Produtos -> Alterar Produto -> Logout

### 5. Requisitos Não Funcionais

    Desempenho esperado do sistema: Resposta em tempo real com latência mínima.
    Segurança e autenticação: Uso de JWT para autenticação de usuários.
    Escalabilidade e manutenibilidade: Estrutura modular para facilitar a escalabilidade e manutenção.

### 6. Tecnologias Utilizadas

    Linguagens de programação: C#
    Frameworks: ASP.NET Core, EntityFramework
    Bancos de dados: SQLite
    Ferramentas de desenvolvimento: VSCode

### 7. Modelo de Dados

    Estrutura do banco de dados: Tabelas para produtos e usuários.
    Relacionamentos entre entidades: Relacionamentos de herança entre tipos de produtos.
    Esquema de armazenamento: Tabelas e colunas específicas para cada tipo de produto.

### 8. Interfaces do Usuário

    Layout e design das interfaces: APIs RESTful sem interface gráfica.
    Funcionalidades específicas de cada tela: Não aplicável.
    Fluxos de interação do usuário: Interações via chamadas API.

### 9. Arquitetura de Implementação

    Organização do código-fonte: Separação em camadas (Controllers (Views), Models, Repositories, Services).
    Divisão em módulos e componentes: Módulos para produtos, usuários e autenticação.
    Dependências entre os componentes: Controllers dependem de Services que dependem de Repositories.

### 10. Planejamento de Implantação

    Ambientes de implantação: Desenvolvimento, teste e produção.
    Migração de dados, se necessário: Frameworks de ORM para migração de banco de dados.

### 11. Gestão de Configuração e Controle de Versão

    Políticas de controle de versão: Uso de Git com branches específicas para desenvolvimento, 
    teste e produção. Ramificação do código-fonte: Feature branches, release branches e hotfix branches.
    Uso de ferramentas de controle de versão: Git

### 12. Gestão de Projetos

    Cronograma de desenvolvimento: Planejamento iterativo e incremental.
    Atribuição de tarefas e responsabilidades: Projeto individual.
    Monitoramento do progresso do projeto: Não se aplica.

### 13. Considerações de Segurança

    Mecanismos de autenticação e autorização: Autenticação JWT, autorização baseada em roles.
    Proteção contra vulnerabilidades conhecidas: Implementação de práticas de segurança recomendadas (OWASP).
    Auditoria e registro de atividades sensíveis: Logs de acesso e alterações.

===========================================================================

Este projeto faz parte dos requisitos para aprovação na disciplina de Desenvolvimento Web II 
do curso de Análise e Desenvolvimento de Sistemas no Senai Gaspar Ricardo Júnior - Sorocaba/SP.

Curso ministrado pelo Prof. Me. André Cassulino. 

===========================================================================

Desenvolvimento: Rafael Rodrigues
- Aluno 3º Semestre de ADS/ 2024
- Contato: rafael.rodrigues44@senaisp.edu.br

--------------------------------------------------------------------------------------------   
