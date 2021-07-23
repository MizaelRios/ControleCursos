# ControleCursos

## Projeto de uma Web API desenvolvida em .Net Core, utilizando a linguagem C#, na arquitetura MVC, que realiza as operações CRUD (criar, recuperar/consultar, editar e excluir)    para o controle de Cursos de formação.

Publicação (método principal): https://apicontrolecursos.herokuapp.com/api/curso

Documentação Swagger: https://apicontrolecursos.herokuapp.com/swagger/index.html

Regras de validação:
 - Não será permitida a inclusão de cursos dentro do mesmo período.
   O sistema vai identificar tal situação e retornar um código de erro e a mensagem:
  "Existe(m) curso(s) planejados(s) dentro do período informado."
 - Não será permitida a inclusão de cursos com a data de início menor que a data 
   atual.

# Informações adicionais sobre o projeto.

O projeto foi desenvolvido utilizando:
- ASP.NET Core: Framework Open Source da Microsoft para o desenvolvimento de aplicações.
- Git e GitHub: utilizados para versionamento e hospedagem do código-fonte.
- Swagger: Documentação técnica da API.
- Heroku: Plataforma em nuvem onde o serviço foi hospedado.
- BuildPack: Pacote utilizado para permitir o suporte do .NET Core pelo Heroku, 
  que ainda não suporta nativamente o deploy com este framework. (https://github.com/jincod/dotnetcore-buildpack). 
- HerokuData: Plataforma em nuvem onde o banco de dados em PostgreSQL foi hospedado.
- Heroku Deploy: Serviço de integração contínua do Heroku, onde assim que um commit for realizado na 
  branch configurada será realizado deploy automático com as mudanças inseridas.

Utilizada arquitetura MVC (Model-View-Controller):
- Models: Camada que contem todas as entidades do projeto.
- Controllers: Camada que contem os Controllers do projeto, responsáveis por lidar com entradas de solicitações HTTP e enviar a resposta de volta ao requisitante.
- Views: não se aplica a este projeto.

Design Patterns:
- Um Design Pattern que poderia ser aplicado neste projeto por exemplo seria o "Repository Pattern", que permite
   o encapsulamento da lógica do acesso a dados, fazendo uso da     injeção de dependencia (DI) para tal.
