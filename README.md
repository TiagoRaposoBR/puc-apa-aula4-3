# puc-apa-aula4-3
Exercício 3 da aula 4 da matéria Análise, Projeto e Avaliação Arquitetural do curso de pós-graduação da PUC

Template de DDD:
https://github.com/marco-mendes/.net-core/blob/master/NET%20Core/Programa%C3%A7%C3%A3o%20Orientada%20a%20Objeto/Laboratorio/DDD01.md


## Como usar

O projeto já vem com um banco de dados configurado, e com alguns dados de exemplo (SQLite, pasta Application.app.db).

Lista os correntistas e seus dados
[GET] _/api/correntista/ListarCorrentistas_

Insere um novo correntista
[POST] _/api/correntista/NovoCorrentista_
[BODY]
{
    "Id": 3,
    "Nome": "Medio",
    "Cpf": "193656",
    "Telefone": "(71)1A23B",
    "Endereco": "1A23B 45"
}

Pega as constas associadas ao correntista
[GET] _/api/correntista/GetContasDoCorrentista/{id}_

Pega a conta por id
[GET] _/api/contacorrente/GetConta/{id}_

Insere uma nova conta
[POST] _/api/contacorrente/NovaConta_
[BODY]
{
    "Id": 4,
    "Saldo": 903510,
    "LimiteCredito": 3,
    "CorrentistaId": 1
}

Efetua uma transação (valor pode ser positivo ou negativo)
[PUT] _/api/contacorrente/FazerTransacao_
[BODY]
{
    "Id": 4,
    "Valor": 77000
}
