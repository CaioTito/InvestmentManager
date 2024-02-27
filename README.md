# API de Compra, venda e gerenciamento de produtos de investimentos;

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

## Como utilizar a aplicação - Customer
Para executar o projeto, siga as seguintes etapas:

**Criando um usuário**

O primeiro passo da aplicação é realizar a criação do usuário você deve usar o endpoint abaixo com as seguintes informações:

![PostUser](https://github.com/CaioTito/InvestmentManager/assets/47333681/0a38c5e2-8451-47d5-858a-a1408bbee01c)

Respeitando as seguintes validações:

![Validacoes User](https://github.com/CaioTito/InvestmentManager/assets/47333681/4b4b21f2-0b11-41fd-9f0d-34c5e6a9bb23)

Nesse momento voce está validado como Customer e tem acesso aos seguintes endpoints:
 - (GET) api/transactions/statement (Consulta de extrato)
 - (GET) api/transactions/checkBalance (Consulta de saldo de produtos e conta)
 - (POST) api/transactions/buy (Compra de produtos)
 - (POST) api/transactions/sell (Venda de produtos)
 - (GET) api/categories (Consulta todas as categorias, futuramente utilizado para preencher uma lista de seleção)
 - (GET) api/operationTypes (Consulta todas as categorias, futuramente utilizado para preencher uma lista de seleção)
 - (GET) api/products (Consulta todas as categorias, futuramente utilizado para preencher uma lista de seleção)

**Fazendo uma compra**

Para fazer uma compra é necessário passar o ProductId e do OperationTypeId, para consultar voce pode usar os endpoints de consulta de cada um deles (GET) api/products e (GET) api/operationTypes

printdoproduct

printdotype

Lembrando de usar o tipo correto de operação. Nesse caso deve-se usar o id da compra

Por fim basta seguir ao endpoint de compra e preencher com o valor e ids que acabou de consultar.

**Fazendo uma Venda**

Para fazer uma venda também é necessário passar o ProductId e do OperationTypeId, para consultar voce deve seguir os mesmos passos da compra

printdoproduct

printdotype

Lembrando de usar o tipo correto de operação. Nesse caso deve-se usar o id da venda

Por fim basta seguir ao endpoint de venda e preencher com o valor e ids que acabou de consultar.

**Fazendo as consultas**

As Consultas são bem simples sendo os endpoints de (GET) api/transactions/statement, que traz um retorno com todas as vendas e compras que fez de cada produto e (GET) api/transactions/checkBalance, que traz um consolidado de saldo que voce tem de cada produto e do seu saldo disponivel para comprar mais produtos, não é necessário a passagem de nenhum parametro pois o Id do usuario é recuperado através do token.

## Como utilizar a aplicação - Administrator

Como um administrador você tem acesso aos demais endpoints, porem perde acesso aos de Customer, pois são exclusivos para Customer.

A primeira coisa que deve fazer é utilizar o endpoint de atualização de usuario e atualizar sua role para 1, o que seria o valor referente a role de Administrador.

imagemdeputusers

Após isso você terá acesso a todos os demais endpoints que irão te possibilitar a criação de novos produtos, categorias e tipos de operações, lmebrando que o produto está diretamente ligado a categoria, portanto ao criar um novo produto deve se atentar ao código de categoria se o que de fato deseja e exista na tabela de categorias.

Por fim caso queira voltar para Customer, para utilizar novamente as outras funcionalidade basta repetir o processo de atualização de usuario, porém passando o valor **"2"** em Role.
