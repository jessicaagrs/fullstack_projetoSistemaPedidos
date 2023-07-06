<template>
    <div>
        <v-alert v-if="errorMessage" type="error" dismissible>
            {{ errorMessage }}
        </v-alert>

        <v-toolbar>
            <v-toolbar-title class="text-center">
                Cadastro de Tributos
            </v-toolbar-title>
        </v-toolbar>

        <v-form v-model="valid">
            <v-container>
                <v-row class="d-flex justify-sparce-between align-center">
                    <v-col cols="12" md="4">
                        <v-text-field v-model="tributacoes.ncm" :rules="[v => !!v || 'Obrigatório']" label="NCM:"
                            required></v-text-field>
                    </v-col>

                    <v-col cols="12" md="4">
                        <v-text-field v-model="tributacoes.aliquotaImposto" :rules="[v => !!v || 'Obrigatório']"
                            label="Alíquota Imposto:" required></v-text-field>
                    </v-col>

                    <v-col cols="12" md="4">
                        <v-text-field v-model="tributacoes.descricao" :rules="[v => !!v || 'Obrigatório']" label="Descrição:"
                            required></v-text-field>
                    </v-col>

                    <v-col cols="12" md="4">
                        <v-btn color="primary" @click="salvarTributacao">
                            Salvar
                        </v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>

        <v-data-table v-model="selected" :headers="headers" :items="tributacoes" show-select return-object
            class="elevation-1">

        </v-data-table>

        <v-container class="d-flex justify-start mb-6 bg-surface-variant">
            <v-btn class="ma-2 pa-2" color="error" @click="deleteTributacao">
                Excluir
            </v-btn>
            <v-btn class="ma-2 pa-2" color="primary" @click="editarTributacao">
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
            tributacao: {
                ncm: "",
                aliquotaImposto: 0.00,
                descricao: "",
            },
            headers: [
                {
                    text: 'NCM',
                    align: 'start',
                    sortable: false,
                    value: 'ncm',
                },
                { text: 'Alíquota Imposto', align: 'start', value: 'aliquotaImposto' },
                { text: 'Descricao', align: 'start', value: 'descricao' },
            ],
            tributacoes: [],
            selected: [],
            idEdicao: 0,
            errorMessage: "",
        };
    },
    mounted() {
        this.getTributacao();
    },
    methods: {
        async editarTributacao() {
            try {
                if (this.selected.length == 1) {
                    const selectedTributacao = this.selected[0];
                    this.tributacoes.ncm = selectedTributacao.ncm;
                    this.tributacoes.aliquotaImposto = selectedTributacao.aliquotaImposto;
                    this.tributacoes.descricao = selectedTributacao.descricao;
                    this.idEdicao = selectedTributacao.id;
                    this.selected = [];
                } else {
                    this.errorMessage = "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async salvarTributacao() {
            try {
                if (this.tributacoes.ncm != null || this.tributacoes.aliquotaImposto != null || this.tributacoes.descricao != null) {
                    let contemElemento = this.tributacoes.some(item => item.id === this.idEdicao);
                    if (contemElemento) {
                        this.putTributacao();
                        this.idEdicao = 0;
                    } else {
                        this.postTributacao();
                    }
                } else {
                    this.errorMessage = "Os campos descrição, alíquota e grupo são obrigatórios.";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async putTributacao() {
            try {
                const aliquotaImpostoConvertido = parseFloat(this.tributacoes.aliquotaImposto.replace(',', '.'));
                const data = {
                    id: this.idEdicao,
                    ncm: this.tributacoes.ncm,
                    aliquotaImposto: aliquotaImpostoConvertido,
                    descricao: this.tributacoes.descricao,
                };
                await this.$axios.put('https://localhost:7054/Tributacao', data);
                await this.getTributacao();
                this.tributacoes.ncm = "";
                this.tributacoes.aliquotaImposto = "";
                this.tributacoes.descricao = "";
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async postTributacao() {
            try {
                const aliquotaImpostoConvertido = parseFloat(this.tributacoes.aliquotaImposto.replace(',', '.'));
                const data = {
                    ncm: this.tributacoes.ncm,
                    aliquotaImposto: aliquotaImpostoConvertido,
                    descricao: this.tributacoes.descricao,
                };
                await this.$axios.post('https://localhost:7054/Tributacao', data);
                await this.getTributacao();
                this.tributacoes.ncm = "";
                this.tributacoes.aliquotaImposto = "";
                this.tributacoes.descricao = "";
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async getTributacao() {
            try {
                const response = await this.$axios.get('https://localhost:7054/Tributacao');
                this.tributacoes = response.data;
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async deleteTributacao() {
            try {
                if (this.selected.length == 1) {
                    if (this.selected[0].id) {
                        const id = this.selected[0].id;
                        await this.$axios.delete(`https://localhost:7054/Tributacao/${id}`);
                        await this.getTributacao();
                    }
                } else {
                    this.errorMessage = "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },

    },
};
</script>


