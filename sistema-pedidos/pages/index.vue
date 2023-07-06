<template>
  <div>
    <v-card class="pa-md-4 mx-lg-auto" max-width="800" variant="outlined">
      <v-card-item>
        <div>
          <div class="text-overline mb-1">
            SISTEMA DE CADASTRO DE PEDIDOS AO FORNECEDOR
          </div>
          <div class="text-h6 mb-1">
            Seja Bem-Vindo(a)!
          </div>
          <div>Esse projeto tem o objetivo de resolver o desafio proposto pela ZDZCode, referente a
            vaga de Desenvolvedor(a). Abaixo um roteiro de como navegar por ele.</div>
        </div>
      </v-card-item>
    </v-card>
    <v-card class="pa-md-4 mx-lg-auto" max-width="800">
      <v-list>
        <v-list-item-group>
          <template v-for="(item, index) in items">
            <v-divider v-if="item.type === 'divider'"></v-divider>
            <v-subheader v-else-if="item.type === 'subheader'">{{ item.title }}</v-subheader>
            <v-list-item v-else :key="item.value">
              <v-list-item-content>
                <v-list-item-title class="text-wrap">{{ item.title }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </template>
        </v-list-item-group>
      </v-list>
    </v-card>
    <v-card class="pa-md-4 mx-lg-auto" max-width="800" variant="outlined">
      <v-card-item>
        <div>
          <div class="text-caption">Independente do resultado, obrigada pela oportunidade.</div>
        </div>
      </v-card-item>
    </v-card>
  </div>
</template>

<script>
export default {
  data: () => ({
    items: [
      { type: 'subheader', title: 'Manual' },
      {
        title: '1. Os cadastros devem começar pelas despesas e seguir a sequencia: fornecedores, tributação, produtos e pedidos.',
        value: 1,
      },
      {
        title: '2. Em todas as páginas o mesmo layout e ações são iguais para fins de entrega dentro do prazo.',
        value: 2,
      },
      {
        title: '3. A função salvar verifica se está sendo feito um novo lançamento ou atualizando uma dado selecionado da tabela.',
        value: 3,
      },
      {
        title: '4. O botão editar acionado após selecionar uma linha replica os dados para os campos de preenchimento logo acima, também feito dessa forma para entrega dentro do prazo do desafio.',
        value: 4,
      },
      {
        title: '5. O botão excluir também necessita que uma linha da tabela seja selecionada.',
        value: 5,
      },
      {
        title: '6. Por questões de prazo também optei por Pedidos só vincular 1 produto.',
        value: 5,
      },
      { type: 'divider' },
    ],
  }),
};
</script>