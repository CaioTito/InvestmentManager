# API de Compra, venda e gerenciamento de produtos de investimentos;

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/CaioTito/InvestmentManager/blob/master/LICENSE.txt)

Este é um projeto em C#, consiste em uma API de Compra, venda e gerenciamento de produtos de investimentos. A API utiliza o framework ASP.NET Core e o banco de dados Microsoft SQL Server, utilizando Entity Framework como ORM.

A API conta com as seguintes **funcionalidades**:

**Gestão dos produtos**
  
  Realizado a criação de endpoints utilizando padrão CQRS, de maneira a qual o Backoffice possa criar, editar, consultar e deletar produtos.
  
**Disparo de e-mail diário para notificar os administradores a respeito dos produtos com vencimento próximo.**
  
  Criado utilizando a biblioteca Quartz, roda um job em background todo dia as 08:00, onde é feita uma consulta e retornado todos produtos que estejam a menos de 03 meses dos vencimento e são encaminhados para os e-mails configurados, para notificação e atualização dos produtos. 
  
**Criar um serviço que permita o cliente comprar, vender e consultar seus investimentos.**

  Realizado a criação de endpoints utilizando padrão CQRS, de maneira a qual o cliente possa realizar a compra e venda, além de consultar o saldo dos produtos comprados e saldo em conta, além de consulta do historico de transações.

**Autorização e autenticação**

  Feito utilizando através de token JWT, existem duas roles a de Administrador e a de Cliente, contando com os endpoints de cadastro e login disponiveis, para possibilitar a criação do acesso.

**Validação de dados**

  Feito a validação de e-mail e requisitos de senha para o endpoint de criação de usuários

# Endpoints

![Endpoints1](https://live.staticflickr.com/65535/53555781990_e2986c24f2_k.jpg)
![Endpoints2](https://live.staticflickr.com/65535/53555672314_5a6525da15_k.jpg)

## Como executar o projeto
Para executar o projeto, siga as seguintes etapas:

1. Clone este repositório em sua máquina local usando o comando git clone `https://github.com/CaioTito/InvestmentManager.git`
2. Abra o projeto no Visual Studio ou em outra IDE de sua preferência.
3. Configure a string de conexão do banco de dados no arquivo `appsettings.Development.json`.
4. No Console do Gerenciador de Pacotes, execute o comando `Update-Database` para criar o banco de dados e suas tabelas.
5. Utilize um cliente SQL de sua preferencia e faça a conexão ao seu banco de dados local.
6. Abra o script de nome "Script Inicial Banco de dados" disponivel na pasta raiz do projeto, e execute-o para criação de dados básicos.
7. Compile o projeto e execute a aplicação.
8. Use o Swagger ou outra ferramenta similar para testar os endpoints da API.

## Como utilizar a aplicação
Para executar o projeto, siga as seguintes etapas:

**Criando um usuário**

O primeiro passo da aplicação é realizar a criação do usuário você deve usar o endpoint abaixo com as seguintes informações
