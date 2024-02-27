# API de Compra, venda e gerenciamento de produtos de investimentos

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/CaioTito/InvestmentManager/blob/master/LICENSE.txt)

Este é um projeto em C#, consiste em uma API de Compra, venda e gerenciamento de produtos de investimentos. A API utiliza o framework ASP.NET Core 8 e o banco de dados Microsoft SQL Server, utilizando Entity Framework como ORM.

A API conta com as seguintes **funcionalidades**:

**Gestão dos produtos**
  
  Realizado a criação de endpoints utilizando padrão CQRS, de maneira a qual o Backoffice possa criar, editar, consultar e deletar produtos.
  
**Disparo de e-mail diário para notificar os administradores a respeito dos produtos com vencimento próximo.**
  
  Criado utilizando a biblioteca Quartz, roda um job em background todo dia as 08:00, onde é feita uma consulta e retornado todos produtos que estejam a menos de 03 meses do vencimento e são encaminhados para os e-mails configurados, para notificação e atualização dos produtos. 
  
**Criar um serviço que permita o cliente comprar, vender e consultar seus investimentos.**

  Realizado a criação de endpoints utilizando padrão CQRS, de maneira a qual o cliente possa realizar a compra e venda, além de consultar o saldo dos produtos comprados e saldo em conta, além de consulta do historico de transações.

**Autorização e autenticação**

  Feito através de token JWT, existem duas roles a de Administrador e a de Cliente, contando com os endpoints de cadastro e login disponiveis, para possibilitar a criação do acesso.

**Validação de dados**

  Feito a validação de e-mail e requisitos de senha para o endpoint de criação de usuários

# Endpoints

![Endpoint1](https://github.com/CaioTito/InvestmentManager/assets/47333681/688658fa-5145-4ec8-ba83-f3f7d05f6327)
![Endpoint2](https://github.com/CaioTito/InvestmentManager/assets/47333681/9368c610-c21d-4b6c-b070-8b836b3731d2)
![Endpoint3](https://github.com/CaioTito/InvestmentManager/assets/47333681/ee5c1750-a4cb-4331-9481-61e0e0553651)

## Como executar o projeto
Para executar o projeto, siga as seguintes etapas:

1. Clone este repositório em sua máquina local usando o comando git clone `https://github.com/CaioTito/InvestmentManager.git`
2. Abra o projeto no Visual Studio ou em outra IDE de sua preferência.
3. Configure a string de conexão do banco de dados no arquivo `appsettings.Development.json`.
4. No Console do Gerenciador de Pacotes, execute o comando `Update-Database` para criar o banco de dados e suas tabelas.
5. Utilize um cliente SQL de sua preferencia e faça a conexão ao seu banco de dados local.
6. Abra o script de nome "Script Inicial Banco de dados" disponivel na pasta raiz do projeto, e execute-o para criação de dados básicos.
7. Compile o projeto e execute a aplicação.
8. Ao executar o  Swagger se abrirá automaticamente para que você possa testar os endpoints da API.

## Como utilizar a aplicação - Customer
Para executar o projeto, siga as seguintes etapas:

**Criando um usuário**

O primeiro passo da aplicação é realizar a criação do usuário você deve usar o endpoint abaixo com as seguintes informações:

![PostUser](https://github.com/CaioTito/InvestmentManager/assets/47333681/7d85c07a-a02e-4e23-94c6-b3906668512f)

Respeitando as seguintes validações:

![ValidationUser](https://github.com/CaioTito/InvestmentManager/assets/47333681/85b8c277-087d-42ad-b3f1-b943dd0d98d5)

Em seguida você deve utilizar o seu email e senha para ser validado no Login:

![Login](https://github.com/CaioTito/InvestmentManager/assets/47333681/c9873188-f313-478e-af80-d50e57c8b3d2)

Por fim pegar o Token gerado na resposta e fazer a autorização no Swagger.

![Token](https://github.com/CaioTito/InvestmentManager/assets/47333681/ea58ebc2-1e32-41c0-9b10-87d586139209)
![AuthorizationSwagger](https://github.com/CaioTito/InvestmentManager/assets/47333681/a96ad9df-9cbe-4968-8e12-2193576bc163)
![Bearer](https://github.com/CaioTito/InvestmentManager/assets/47333681/241e9a16-e10e-4ff3-aea1-7c46ffe3d070)

Nesse momento você está validado como Customer e tem acesso aos seguintes endpoints:
 - (GET) api/transactions/statement (Consulta de extrato)
 - (GET) api/transactions/checkBalance (Consulta de saldo de produtos e conta)
 - (POST) api/transactions/buy (Compra de produtos)
 - (POST) api/transactions/sell (Venda de produtos)
 - (GET) api/categories (Consulta todas as categorias, futuramente utilizado para preencher uma lista de seleção)
 - (GET) api/operationTypes (Consulta todas as categorias, futuramente utilizado para preencher uma lista de seleção)
 - (GET) api/products (Consulta todas as categorias, futuramente utilizado para preencher uma lista de seleção)

**Fazendo uma compra**

Para fazer uma compra é necessário passar o ProductId e do OperationTypeId, para consultar você pode usar os endpoints de consulta de cada um deles (GET) api/products e (GET) api/operationTypes

![Product](https://github.com/CaioTito/InvestmentManager/assets/47333681/ea5095d1-5d5a-4492-bdae-d118cafa9cdb)
![OperationType](https://github.com/CaioTito/InvestmentManager/assets/47333681/6e23c7fd-a5bb-4c7e-837c-d3723837ec75)

Lembrando de usar o tipo correto de operação. Nesse caso deve-se usar o id da compra

Por fim basta seguir ao endpoint de compra e preencher com o valor e ids que acabou de consultar.

![Buy](https://github.com/CaioTito/InvestmentManager/assets/47333681/b23c091c-f087-46db-a3ad-3f6eab076bbb)

**Fazendo uma Venda**

Para fazer uma venda também é necessário passar o ProductId e do OperationTypeId, para consultar você deve seguir os mesmos passos da compra

![Product](https://github.com/CaioTito/InvestmentManager/assets/47333681/ea5095d1-5d5a-4492-bdae-d118cafa9cdb)
![image](https://github.com/CaioTito/InvestmentManager/assets/47333681/ce7b8033-df92-4a81-b7ba-527b90707065)

Lembrando de usar o tipo correto de operação. Nesse caso deve-se usar o id da venda

Por fim basta seguir ao endpoint de venda e preencher com o valor e ids que acabou de consultar.

![Sell](https://github.com/CaioTito/InvestmentManager/assets/47333681/2b4bdfaa-861a-4449-92f2-399f25a06646)

**Fazendo as consultas**

As Consultas são bem simples sendo os endpoints de (GET) api/transactions/statement, que traz um retorno com todas as vendas e compras que fez de cada produto e (GET) api/transactions/checkBalance, que traz um consolidado de saldo que você tem de cada produto e do seu saldo disponivel para comprar mais produtos, não é necessário a passagem de nenhum parametro pois o Id do usuario é recuperado através do token.

## Como utilizar a aplicação - Administrator

Como um administrador você tem acesso aos demais endpoints, porém perde acesso aos de Customer, pois são exclusivos para Customer.

A primeira coisa que deve fazer é utilizar o endpoint de atualização de usuario e atualizar sua role para 1, o que seria o valor referente a role de Administrador.

![PutUser](https://github.com/CaioTito/InvestmentManager/assets/47333681/f9d65e71-fa6a-4839-bd02-bbedcb2f3ad3)

Após isso você terá que repetir o passo de autorização, gerando um novo token no endpoint de login e atualizando na autenticação do Swagger

Após esse procedimento você terá acesso a todos os demais endpoints que irão te possibilitar a criação de novos produtos, categorias e tipos de operações, lembrando que o produto está diretamente ligado a categoria, portanto ao criar um novo produto deve se atentar ao código de categoria, se existe na tabela de categorias.

Por fim caso queira voltar para Customer, para utilizar novamente as outras funcionalidade basta repetir o processo de atualização de usuario, porém passando o valor **"2"** em Role.


## Próximos passos - To Do's

- Elaboração de testes unitários;
- Implementação de validação de dados de entradas para os demais endpoints alem do Create User;
- Tratamento de exceções e criação de exceções personalizadas;
- Implementação de Paginação para consultas com resultados maiores;
- Ajuste de parametros de serviço de e-mail e job de verificação para o AppSettings;
- Refatoração das handlers de compra e venda para reduzir complexidade.
