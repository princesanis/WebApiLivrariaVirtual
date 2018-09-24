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
  
  - GET v1/livraria-virtual/autores
  - GET v1/livraria-virtual/autores/{autorId}
  - GET v1/livraria-virtual/autores/{autorId}/livros
  - GET v1/livraria-virtual/autores/{autorId}/livros/{livroId}
  - POST v1/livraria-virtual/autores
  - PUT v1/livraria-virtual/autores/{autorId}
  - DELETE v1/livraria-virtual/autores/{autorId}
  
### Editora

  - GET v1/livraria-virtual/editoras
  - GET v1/livraria-virtual/editoras/{editoraId}
  - GET v1/livraria-virtual/editoras/{editoraId}/livros  
  - GET v1/livraria-virtual/editoras/{editoraId}/livros/{livroId}
  - POST v1/livraria-virtual/editoras
  - PUT v1/livraria-virtual/editoras/{editoraId}
  - DELETE v1/livraria-virtual/editoras/{editoraId}
  
### Livro

  - GET v1/livraria-virtual/livros
  - GET v1/livraria-virtual/livros/{livroId}
  - GET v1/livraria-virtual/livros/{livroId}/autores  
  - GET v1/livraria-virtual/livros/{livroId}/autores/{autorId}
  - GET v1/livraria-virtual/livros/{livroId}/comentarios
  - GET v1/livraria-virtual/livros/{livroId}/comentarios/{comentarioId}
  - POST v1/livraria-virtual/livros
  - PUT v1/livraria-virtual/livros/{livroId}
  - DELETE v1/livraria-virtual/livros/{livroId}
  
### Carrinho de Compras

  - GET v1/livraria-virtual/carrinhos/{carrinhoId}
  - POST v1/livraria-virtual/carrinhos/{carrinhoId}/livros/{livroId}
  - DELETE v1/livraria-virtual/carrinhos/{carrinhoId}
  - DELETE v1/livraria-virtual/carrinhos/{carrinhoId}/livros/{livroId}
  
