--- Configurar a string de conexão para máquina que deseja executar o projeto,
o sistema está preparado para criar o banco, gerar migrations e popular registros de forma automática porém
isso somente será possível se configurar o server da string de conexão. ---

Endpoints
A API segue o padrão REST e possui os seguintes endpoints:

Obter todos os fornecedores
Método: GET
URL: /api/Fornecedores
Descrição: Retorna uma lista de todos os fornecedores cadastrados.

Obter um fornecedor pelo ID
Método: GET
URL: /api/Fornecedores/{id}
Descrição: Retorna os detalhes de um fornecedor específico.

Inserir um novo fornecedor
Método: POST
URL: /api/Fornecedores
Descrição: Insere um novo fornecedor na base de dados.

Atualizar um fornecedor existente
Método: PUT
URL: /api/Fornecedores/{id}
Descrição: Atualiza os dados de um fornecedor existente.

Deletar um fornecedor
Método: DELETE
URL: /api/Fornecedores/{id}
Descrição: Remove um fornecedor da base de dados.
