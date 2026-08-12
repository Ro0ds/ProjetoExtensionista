# InovarJunto — Sistema de Gestão de Estoque

Sistema web para pequenas empresas gerenciarem estoque, produtos e custos de forma simples e centralizada. Desenvolvido como projeto acadêmico (Trabalho de Extensão Universitária) e evoluído para uma arquitetura profissional em camadas, com API REST documentada, autenticação JWT e frontend server-side em Razor Pages.

## Problema resolvido

Pequenas empresas e comerciantes muitas vezes controlam estoque em planilhas, o que dificulta o rastreamento de custos reais, quantidade disponível e produtos com estoque crítico. Este sistema centraliza esse controle em uma aplicação web simples, permitindo cadastro de empresa/usuário, gestão de produtos e visão consolidada de custos.

## Funcionalidades

- Cadastro de empresa e usuário com autenticação
- Adicionar, editar e remover produtos
- Adicionar quantidade ao estoque existente
- Visualização do total de itens em estoque
- Alerta de volume crítico (baixo estoque) por produto
- Visualização do custo bruto total do estoque

## Demonstração

O sistema permite autenticar usuários, cadastrar produtos, controlar quantidades e acompanhar o custo total e os níveis críticos do estoque.

![Demonstração do sistema](docs/images/sistema_apr.gif)

## Arquitetura

O projeto é dividido em três módulos principais:

- **Api**: Web API em .NET Core responsável pelas regras de negócio, persistência de dados e autenticação.
- **WebApp**: Frontend em Razor Pages que consome a API.
- **Common**: Camada compartilhada com modelos e utilitários usados pelos dois módulos.

## Tecnologias

- .NET Core 9.0 (Web API + Razor Pages)
- Entity Framework Core
- MySQL
- Autenticação via JWT
- Documentação de API com Swagger
- Newtonsoft.Json
- Font Awesome (ícones do frontend)

## Como executar localmente

### Pré-requisitos

- .NET Core 9.0 SDK
- MySQL instalado e em execução

### Configuração

1. Clone o repositório.
2. Crie o banco de dados MySQL que será utilizado pela aplicação.
3. No `appsettings.json` do projeto **Api**, configure:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=db_inovarjunto;User Id=<seu_usuario>;Password=<sua_senha>;"
  },
  "JwtSettings": {
    "Issuer": "InovarJuntoAPI",
    "Audience": "InovarJuntoFrontend",
    "Secret": "<uma_chave_secreta_forte_de_sua_escolha>"
  }
}
```

4. No `appsettings.json` do projeto **WebApp**, configure a URL da API:

```json
{
  "ApiSettings": {
    "BaseUrl": "http://localhost:5205"
  }
}
```

5. Defina as variáveis de ambiente do sistema para criação do usuário administrador padrão:

```
DEFAULT_ADMIN_EMAIL=<email_do_admin>
DEFAULT_ADMIN_PASSWORD=<senha_do_admin>
```

6. Execute as migrations do Entity Framework Core para criar as tabelas no banco.
7. Inicie o projeto **Api** e, em seguida, o projeto **WebApp**.

### Como confirmar que está funcionando

Após iniciar ambos os projetos, acesse a URL configurada do WebApp no navegador. A tela de login deve carregar corretamente, e o login com o usuário administrador definido nas variáveis de ambiente deve dar acesso ao painel de gestão de estoque. A documentação interativa da API fica disponível via Swagger na porta configurada da Api.

## Decisões técnicas

- Autenticação via **JWT** foi escolhida para permitir que a API seja consumida futuramente por outros clientes além do WebApp (por exemplo, um app mobile).
- Nenhuma credencial ou segredo é versionado no código: toda configuração sensível é lida de `appsettings.json` (ignorado pelo Git) ou de variáveis de ambiente.
- A separação em camadas (`Api`, `WebApp`, `Common`) facilita manutenção e permite reaproveitar modelos entre frontend e backend.

## Próximas melhorias

- Publicar uma demonstração online (deploy gratuito) para testes sem necessidade de configuração local.
- Adicionar testes automatizados para as regras de negócio da API.
- Implementar relatórios exportáveis (CSV/PDF) de estoque e custos.
- Adicionar paginação e filtros na listagem de produtos.

## Sobre o autor

Desenvolvedor backend com experiência em C#, .NET, integrações com bancos de dados relacionais (Firebird, MySQL, SQL Server) e geração de XML/documentos fiscais. Disponível para projetos freelance de pequeno e médio porte envolvendo APIs, sistemas administrativos e integrações.

[LinkedIn](https://www.linkedin.com/in/rodrigogms/)

Contato profissional no email: rodgabrielsilva@icloud.com
