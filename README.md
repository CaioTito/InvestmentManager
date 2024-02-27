# API de Compra, venda e gerenciamento de produtos de investimentos;

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/ezequiel-lima/gestao-de-cursos/blob/master/LICENSE.txt)

Este é um projeto em C#, consiste em uma API de Compra, venda e gerenciamento de produtos de investimentos. A API utiliza o framework ASP.NET Core e o banco de dados Microsoft SQL Server, utilizando Entity Framework como ORM.

A API conta com as seguintes funcionalidades:

Gestão dos produtos financeiros
Disparo de e-mail diário para notificar os administradores a respeito dos produtos com vencimento próximo
Criar um serviço que permita o cliente comprar, vender e consultar seus investimentos.
Funcionalidades:

Negociar produto financeiro (Compra e Venda)
Extrato do produto

## Demonstração 

Endpoints

![Endpoints1](https://live.staticflickr.com/65535/53555781990_e2986c24f2_k.jpg)
![Endpoints2](https://live.staticflickr.com/65535/53555672314_5a6525da15_k.jpg)

## Como executar o projeto
Para executar o projeto, siga as seguintes etapas:

1. Clone este repositório em sua máquina local usando o comando git clone `https://github.com/CaioTito/InvestmentManager.git`
2. Abra o projeto no Visual Studio ou em outra IDE de sua preferência.
3. Configure a string de conexão do banco de dados no arquivo `appsettings.Development.json`.
4. No Console do Gerenciador de Pacotes, execute o comando `Update-Database` para criar o banco de dados e suas tabelas.
5. Rode o Script Inicial em seu cliente SQL, para criação de dados básicos.
6. Compile o projeto e execute a aplicação.
7. Use o Swagger ou outra ferramenta similar para testar os endpoints da API.
