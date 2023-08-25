<template>
  <div>
    <v-alert v-if="errorMessage" type="error" dismissible>
      {{ errorMessage }}
    </v-alert>

    <v-toolbar>
      <v-toolbar-title class="text-center">
        Cadastro de Produtos
      </v-toolbar-title>
    </v-toolbar>

    <v-form v-model="valid">
      <v-container>
        <v-row class="d-flex justify-sparce-between align-center">
          <v-col cols="12" md="4">
            <v-text-field v-model="produtos.descricao" label="Descrição:" required></v-text-field>
          </v-col>

          <v-col cols="12" md="4">
            <v-select :items="fornecedores" density="compact" label="Fornecedor" item-text="razaoSocial" item-value="id"
              v-model="selectedFornecedor"></v-select>
          </v-col>
          <v-col cols="12" md="4">
            <v-select :items="tributacoes" density="compact" label="Despesa" item-text="descricao" item-value="id"
              v-model="selectedTributacao"></v-select>
          </v-col>
          <v-col cols="12" md="4">
            <v-btn color="primary" @click="salvarProduto"> Salvar </v-btn>
          </v-col>
        </v-row>
      </v-container>
    </v-form>

    <v-data-table v-model="selected" :headers="headers" :items="produtos" show-select return-object class="elevation-1">
      <template v-slot:item.tributacoes.aliquotaImposto="{ item }">
        {{ formatCurrency(item.tributacoes.aliquotaImposto) }}
      </template>
    </v-data-table>

    <v-container class="d-flex justify-left mb-6 bg-surface-variant">
      <v-btn class="ma-2 pa-2" color="error" @click="deleteProduto">
        Excluir
      </v-btn>
      <v-btn class="ma-2 pa-2" color="primary" @click="editarProduto">
        Editar
      </v-btn>
    </v-container>
  </div>
</template>

<script>
export default {
  data() {
    return {
      valid: false,
      produto: {
        descricao: "",
        fornecedorId: 0,
        tributacaoId: 0,
      },
      headers: [
        {
          text: "Descrição",
          align: "left",
          sortable: false,
          value: "descricao",
        },
        { text: "Código Fornecedor", align: "left", value: "fornecedorId" },
        {
          text: "Nome Fornecedor",
          align: "left",
          value: "fornecedores.razaoSocial",
        },
        { text: "CNPJ Fornecedor", align: "left", value: "fornecedores.cnpj" },
        {
          text: "Código Despesa",
          align: "left",
          value: "fornecedores.despesa.id",
        },
        {
          text: "Descrição Despesa",
          align: "left",
          value: "fornecedores.despesa.descricao",
        },
        {
          text: "Grupo Despesa",
          align: "left",
          value: "fornecedores.despesa.grupo",
        },
        { text: "Código Tributação", align: "left", value: "tributacaoId" },
        { text: "NCM Tributação", align: "left", value: "tributacoes.ncm" },
        {
          text: "NCM Descrição",
          align: "left",
          value: "tributacoes.descricao",
        },
        {
          text: "Impostos",
          align: "left",
          value: "tributacoes.aliquotaImposto",
        },
      ],
      produtos: [],
      selected: [],
      idEdicao: 0,
      errorMessage: "",
      fornecedores: [],
      tributacoes: [],
      selectedFornecedor: null,
      selectedTributacao: null,
    };
  },
  mounted() {
    this.getFornecedores();
    this.getTributacoes();
    this.getProdutos();
  },
  methods: {
    formatCurrency(value) {
      const numberFormat = new Intl.NumberFormat("pt-BR");
      return numberFormat.format(value);
    },
    async editarProduto() {
      try {
        if (this.selected.length == 1) {
          const selectedProduto = this.selected[0];
          this.produtos.descricao = selectedProduto.descricao;
          this.selectedFornecedor = selectedProduto.fornecedorId;
          this.selectedTributacao = selectedProduto.tributacaoId;
          this.idEdicao = selectedProduto.id;
          this.selected = [];
        } else {
          this.errorMessage =
            "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
        }
      } catch (error) {
        this.errorMessage = error;
      }
    },
    async salvarProduto() {
      try {
        if (
          this.produtos.descricao != "" &&
          this.selectedFornecedor != null &&
          this.selectedTributacao != null
        ) {
          let contemElemento = this.produtos.some(
            (item) => item.id === this.idEdicao
          );
          if (contemElemento) {
            this.putProduto();
            this.idEdicao = 0;
          } else {
            this.postProduto();
          }
        } else {
          this.errorMessage =
            "Os campos descrição, fornecedor e despesa são obrigatórios.";
        }
      } catch (error) {
        this.errorMessage = error;
      }
    },
    async putProduto() {
      try {
        const data = {
          id: this.idEdicao,
          descricao: this.produtos.descricao,
          fornecedorId: this.selectedFornecedor,
          tributacaoId: this.selectedTributacao,
        };
        await this.$axios.put("https://localhost:7054/Produto", data);
        await this.getProdutos();
        this.produtos.descricao = "";
      } catch (error) {
        this.errorMessage = "Erro ao fazer solicitação, revise os dados.";
      }
    },
    async postProduto() {
      try {
        const data = {
          descricao: this.produtos.descricao,
          fornecedorId: this.selectedFornecedor,
          tributacaoId: this.selectedTributacao,
        };
        await this.$axios.post("https://localhost:7054/Produto", data);
        await this.getProdutos();
        this.produtos.descricao = "";
      } catch (error) {
        this.errorMessage = "Erro ao fazer solicitação, revise os dados.";
      }
    },
    async getFornecedores() {
      try {
        const response = await this.$axios.get(
          "https://localhost:7054/Fornecedor"
        );
        this.fornecedores = response.data;
      } catch (error) {
        this.errorMessage = "Erro ao fazer solicitação, revise os dados.";
      }
    },
    async getTributacoes() {
      try {
        const response = await this.$axios.get(
          "https://localhost:7054/Tributacao"
        );
        this.tributacoes = response.data;
      } catch (error) {
        this.errorMessage = "Erro ao fazer solicitação, revise os dados.";
      }
    },
    async getProdutos() {
      try {
        const response = await this.$axios.get(
          "https://localhost:7054/Produto"
        );
        this.produtos = response.data;
      } catch (error) {
        this.errorMessage = "Erro ao fazer solicitação, revise os dados.";
      }
    },
    async deleteProduto() {
      try {
        if (this.selected.length == 1) {
          if (this.selected[0].id) {
            const id = this.selected[0].id;
            await this.$axios.delete(`https://localhost:7054/Produto/${id}`);
            await this.getFornecedores();
          }
        } else {
          this.errorMessage =
            "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
        }
      } catch (error) {
        this.errorMessage = "Erro ao fazer solicitação, revise os dados.";
      }
    },
  },
};
</script>
