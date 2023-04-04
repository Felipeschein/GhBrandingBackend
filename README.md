# GhBranding Repository

Esta Api foi criada para gerenciar as atividades realizadas diariamente, bem como, mensurar o tempo investido nelas.

>### GET - listar-registros
Este endpoint lista todos os apontamentos realizados, com suas atividades, data/hora de início e fim, e a quantidade de horas totais gasta em cada atividade.

>### GET - listar-registros/{id}
Este endpoint possuí a mesma funcionalidade de listagem do anterior, porém, o mesmo exigi um parâmetro, neste caso o id, para uma busca mais ágil e focada.

>### POST - cadastrar-registros
Este endpoint realiza o cadastro dos registros, seu parâmentros são:
- Descrição: Campo destinado para registrar a atividade realizada;
- RegistroInicial: Lançamento de dia/hora do início da atividade;
- RegistroFinal: Lançamento de dia/hora do fim da atividade;

**Importante:**
Este endpoint conta com uma validação de horas, não podendo ser lançada mais de 8h45min de atividade diária.

>### DELETE - excluir-registros/{id}
Endpoint destinado a exclusão do registro, em caso de lançamento equivocado. O parâmetro para exclusão é o id do registro.
