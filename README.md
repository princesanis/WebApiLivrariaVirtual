# WebApiLivrariaVirtual
 
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
  
  - GET /livraria-virtual/v{apiversion}/autores
  - GET /livraria-virtual/v{apiversion}/autores/{autorId}
  - POST /livraria-virtual/v{apiversion}/autores
  - PUT /livraria-virtual/v{apiversion}/autores/{autorId}
  - DELETE /livraria-virtual/v{apiversion}/autores/{autorId}
  
### Editora

  - GET /livraria-virtual/v{apiversion}/editoras
  - GET /livraria-virtual/v{apiversion}/editoras/{editoraId}
  - GET /livraria-virtual/v{apiversion}/editoras/{editoraId}/livros  
  - GET /livraria-virtual/v{apiversion}/editoras/{editoraId}/livros/{livroId}
  - POST /livraria-virtual/v{apiversion}/editoras
  - PUT /livraria-virtual/v{apiversion}/editoras/{editoraId}
  - DELETE /livraria-virtual/v{apiversion}/editoras/{editoraId}
  
### Livro

  - GET /livraria-virtual/v{apiversion}/livros
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/autores  
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/autores/{autorId}
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/comentarios
  - GET /livraria-virtual/v{apiversion}/livros/{livroId}/comentarios/{comentarioId}
  - POST /livraria-virtual/v{apiversion}/livros
  - PUT /livraria-virtual/v{apiversion}/livros/{livroId}
  - DELETE /livraria-virtual/v{apiversion}/livros/{livroId}
  
### Carrinho de Compras

  - GET /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}
  - PUT /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}/livros/{livroId}
  - DELETE /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}
  - DELETE /livraria-virtual/v{apiversion}/carrinhos/{carrinhoId}/livros/{livroId}
  
### Pedidos

  - GET /livraria-virtual/v{apiversion}/pedidos
  - GET /livraria-virtual/v{apiversion}/pedidos/{pedidoId}
  - POST /livraria-virtual/v{apiversion}/pedidos
