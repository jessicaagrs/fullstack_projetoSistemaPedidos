<template>
    <div>
        <v-alert v-if="errorMessage" type="error" dismissible>
            {{ errorMessage }}
        </v-alert>

        <v-toolbar>
            <v-toolbar-title class="text-center">
                Cadastro de Fornecedores
            </v-toolbar-title>
        </v-toolbar>

        <v-form v-model="valid">
            <v-container>
                <v-row class="d-flex justify-sparce-between align-center">
                    <v-col cols="12" md="4">
                        <v-text-field v-model="fornecedores.razaoSocial" label="Razão Social:" required></v-text-field>
                    </v-col>

                    <v-col cols="12" md="4">
                        <v-text-field v-model="fornecedores.cnpj" label="CNPJ:" required></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-select :items="despesas" density="compact" label="Despesa" item-text="descricao" item-value="id"
                            v-model="selectedTipoDespesa"></v-select>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-btn color="primary" @click="salvarFornecedor">
                            Salvar
                        </v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>

        <v-data-table v-model="selected" :headers="headers" :items="fornecedores" show-select return-object
            class="elevation-1">

        </v-data-table>

        <v-container class="d-flex justify-start mb-6 bg-surface-variant">
            <v-btn class="ma-2 pa-2" color="error" @click="deleteFornecedor">
                Excluir
            </v-btn>
            <v-btn class="ma-2 pa-2" color="primary" @click="editarFornecedor">
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
            fornecedor: {
                razaoSocial: "",
                cnpj: "",
                tipoDespesaId: 0,
            },
            headers: [
                {
                    text: 'Nome Fantasia',
                    align: 'start',
                    sortable: false,
                    value: 'razaoSocial',
                },
                { text: 'CNPJ', align: 'start', value: 'cnpj' },
                { text: 'Código Despesa', align: 'start', value: 'tipoDespesaId' },
                { text: 'Descrição Despesa', align: 'start', value: 'despesa.descricao' },
                { text: 'Grupo Despesa', align: 'start', value: 'despesa.grupo' },
            ],
            fornecedores: [],
            selected: [],
            idEdicao: 0,
            errorMessage: "",
            despesas: [],
            selectedTipoDespesa: null,
        };
    },
    mounted() {
        this.getTipoDespesas();
        this.getFornecedores();
    },
    methods: {
        async editarFornecedor() {
            try {
                if (this.selected.length == 1) {
                    const selectedFornecedor = this.selected[0];
                    this.fornecedores.razaoSocial = selectedFornecedor.razaoSocial;
                    this.fornecedores.cnpj = selectedFornecedor.cnpj;
                    this.selectedTipoDespesa = selectedFornecedor.tipoDespesaId;
                    this.idEdicao = selectedFornecedor.id;
                    this.selected = [];
                } else {
                    this.errorMessage = "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async salvarFornecedor() {
            try {
                if (this.fornecedores.razaoSocial != "" && this.fornecedores.cnpj != "" && this.selectedTipoDespesa != null) {
                    let contemElemento = this.fornecedores.some(item => item.id === this.idEdicao);
                    if (contemElemento) {
                        this.putFornecedor();
                        this.idEdicao = 0;
                        this.selectedTipoDespesa = null;
                    } else {
                        this.postFornecedor();
                        this.selectedTipoDespesa = null;
                    }
                } else {
                    this.errorMessage = "Os campos razão social, CNPJ e tipo da despesa são obrigatórios.";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async putFornecedor() {
            try {
                const data = {
                    id: this.idEdicao,
                    razaoSocial: this.fornecedores.razaoSocial,
                    cnpj: this.fornecedores.cnpj,
                    tipoDespesaId: this.selectedTipoDespesa,
                };
                await this.$axios.put('https://localhost:7054/Fornecedor', data);
                await this.getFornecedores();
                this.fornecedores.razaoSocial = "";
                this.fornecedores.cnpj = "";
            } catch (error) {
                this.errorMessage = error.response.data;
            }
        },
        async postFornecedor() {
            try {
                const data = {
                    razaoSocial: this.fornecedores.razaoSocial,
                    cnpj: this.fornecedores.cnpj,
                    tipoDespesaId: this.selectedTipoDespesa,
                };
                await this.$axios.post('https://localhost:7054/Fornecedor', data);
                await this.getFornecedores();
                this.fornecedores.razaoSocial = "";
                this.fornecedores.cnpj = "";
            } catch (error) {
                this.errorMessage = error.response.data;
            }
        },
        async getTipoDespesas() {
            try {
                const response = await this.$axios.get('https://localhost:7054/TipoDespesa');
                this.despesas = response.data;
            } catch (error) {
                this.errorMessage = error.response.data;
            }
        },
        async getFornecedores() {
            try {
                const response = await this.$axios.get('https://localhost:7054/Fornecedor');
                this.fornecedores = response.data;
            } catch (error) {
                this.errorMessage = error.response.data;
            }
        },
        async deleteFornecedor() {
            try {
                if (this.selected.length == 1) {
                    if (this.selected[0].id) {
                        const id = this.selected[0].id;
                        await this.$axios.delete(`https://localhost:7054/Fornecedor/${id}`);
                        await this.getFornecedores();
                    }
                } else {
                    this.errorMessage = "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
                }
            } catch (error) {
                this.errorMessage = error.response.data;
            }
        },

    },
};
</script>


