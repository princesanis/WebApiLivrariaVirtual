# API da Livraria Virtual
 
 Lista de funcionalidades da livraria virtual:

  - **Cadastro de novos livros**
  - **Cadastro de autores**
  - **Cadastro de editoras**
  - **Pesquisa de livros por critérios diversos**
  - **Postar comentários para livros**
  - **Manipular um carrinho de compras**
  - **Realizar pedidos**
  - **Acompanhamento do status das entregas realizadas**

### Autor
  
  **Buscar todos os autores**
  - GET /livraria-virtual/v{apiversion}/autores

  **Buscar autor pelo seu Id**
  - GET /livraria-virtual/v{apiversion}/autores/{autorId}

  **Adicionar um novo autor**
  - POST /livraria-virtual/v{apiversion}/autores

  **Atualizar um autor cadastrado**
  - PUT /livraria-virtual/v{apiversion}/autores/{autorId}

  **Excluir um autor cadastrado**
  - DELETE /livraria-virtual/v{apiversion}/autores/{autorId}
  
### Editora

  **Buscar todas as editoras**  
  - GET /livraria-virtual/v{apiversion}/editoras

  **Buscar editora pelo seu Id**
  - GET /livraria-virtual/v{apiversion}/editoras/{editoraId}

  **Buscar todos os livros de uma editora**
  - GET /livraria-virtual/v{apiversion}/editoras/{editoraId}/livros

  **Buscar um livro pelo seu Id na respectiva editora**  
  - GET /livraria-virtual/v{apiversion}/editoras/{editoraId}/livros/{livroId}

  **Incluir uma nova editora**
  - POST /livraria-virtual/v{apiversion}/editoras

  **Atualizar uma editora cadastrada**
  - PUT /livraria-virtual/v{apiversion}/editoras/{editoraId}

  **Excluir uma editora cadastrada**
  - DELETE /livraria-virtual/v{apiversion}/editoras/{editoraId}
  
### Livro

  **Buscar todas os livros**
  - GET /livraria-virtual/v{apiversion}/livros

  **Buscar livro pelo seu Id**
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}

  **Buscar todos os autores de um livro**
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/autores 

  **Buscar um autor de um respectivo livro** 
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/autores/{autorId}

  **Buscar todos os comentários de um livro**
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/comentarios

  **Buscar um comentário em específico de um livro**
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/comentarios/{comentarioId}

  **Incluir um novo livro**
  - POST /livraria-virtual/v{apiversion}/livros

  **Atualizar um livro cadastrado**
  - PUT /livraria-virtual/v{apiversion}/livros/{livroId}

  **Excluir um livro cadastrado**
  - DELETE /livraria-virtual/v{apiversion}/livros/{livroId}
  
### Carrinho de Compras

  **Buscar um carrinho de compras pelo Id**
  - GET /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}

  **Incluir um livro num respectivo carrinho de compras**
  - PUT /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}/livros/{livroId}

  **Excluir um carrinho de compras pelo Id**
  - DELETE /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}

  **Buscar um livro do seu respectivo carrinho compras pelo Id**
  - DELETE /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}/livros/{livroId}
  
### Pedidos

  **Buscar todos os pedidos realizados**
  - GET /livraria-virtual/v{apiversion}/pedidos

  **Buscar um pedido pelo seu Id**
  - GET /livraria-virtual/v{apiversion}/pedidos/{pedidoId}

  **Incluri um novo pedido**
  - POST /livraria-virtual/v{apiversion}/pedidos
