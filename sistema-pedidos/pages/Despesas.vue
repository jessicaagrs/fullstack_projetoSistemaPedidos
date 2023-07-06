<template>
    <div>
        <v-alert v-if="errorMessage" type="error" dismissible>
            {{ errorMessage }}
        </v-alert>

        <v-toolbar>
            <v-toolbar-title class="text-center">
                Cadastro de Despesas
            </v-toolbar-title>
        </v-toolbar>

        <v-form v-model="valid">
            <v-container>
                <v-row class="d-flex justify-center align-center">
                    <v-col cols="12" md="4">
                        <v-text-field v-model="tipoDespesa.descricao" :rules="[v => !!v || 'Obrigatório']"
                            label="Descrição:" required></v-text-field>
                    </v-col>

                    <v-col cols="12" md="4">
                        <v-text-field v-model="tipoDespesa.grupo" :rules="[v => !!v || 'Obrigatório']" label="Grupo:"
                            required></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-btn color="primary" @click="salvarTipoDespesa">
                            Salvar
                        </v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>

        <v-data-table v-model="selected" :headers="headers" :items="tipoDespesas" show-select return-object
            class="elevation-1">

        </v-data-table>

        <v-container class="d-flex justify-start mb-6 bg-surface-variant">
            <v-btn class="ma-2 pa-2" color="error" @click="deleteTipoDespesa">
                Excluir
            </v-btn>
            <v-btn class="ma-2 pa-2" color="primary" @click="editarTipoDespesa">
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
            tipoDespesa: {
                descricao: "",
                grupo: "",
            },
            headers: [
                {
                    text: 'Descricao',
                    align: 'start',
                    sortable: false,
                    value: 'descricao',
                },
                { text: 'Grupo', align: 'start', value: 'grupo' },
            ],
            tipoDespesas: [],
            selected: [],
            idEdicao: 0,
            errorMessage: "",
        };
    },
    mounted() {
        this.getTipoDespesas();
    },
    methods: {
        async editarTipoDespesa() {
            try {
                if (this.selected.length == 1) {
                    const selectedDespesa = this.selected[0];
                    this.tipoDespesa.descricao = selectedDespesa.descricao;
                    this.tipoDespesa.grupo = selectedDespesa.grupo;
                    this.idEdicao = selectedDespesa.id;
                    this.selected = [];
                    console.log(this.idEdicao);
                } else {
                    this.errorMessage = "Nenhum item foi selecionado ou mais de uma linha. Nesse caso selecione apenas um.";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async salvarTipoDespesa() {
            try {
                if (this.tipoDespesa.descricao != "" || this.tipoDespesa.grupo != "") {
                    let contemElemento = this.tipoDespesas.some(item => item.id === this.idEdicao);
                    if (contemElemento) {
                        this.putTipoDespesa();
                        this.idEdicao = 0;
                    } else {
                        this.postTipoDespesa();
                    }
                } else {
                    this.errorMessage = "Os campos descrição e grupo são obrigatórios;";
                }
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async putTipoDespesa() {
            try {
                const data = {
                    id: this.idEdicao,
                    descricao: this.tipoDespesa.descricao,
                    grupo: this.tipoDespesa.grupo,
                };
                await this.$axios.put('https://localhost:7054/TipoDespesa', data);
                await this.getTipoDespesas();
                this.tipoDespesa.descricao = "";
                this.tipoDespesa.grupo = "";
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async postTipoDespesa() {
            try {
                const data = {
                    descricao: this.tipoDespesa.descricao,
                    grupo: this.tipoDespesa.grupo,
                };
                await this.$axios.post('https://localhost:7054/TipoDespesa', data);
                await this.getTipoDespesas();
                this.tipoDespesa.descricao = "";
                this.tipoDespesa.grupo = "";
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async getTipoDespesas() {
            try {
                const response = await this.$axios.get('https://localhost:7054/TipoDespesa');
                this.tipoDespesas = response.data;
            } catch (error) {
                this.errorMessage = error;
            }
        },
        async deleteTipoDespesa() {
            try {
                if (this.selected.length == 1) {
                    if (this.selected[0].id) {
                        const id = this.selected[0].id;
                        await this.$axios.delete(`https://localhost:7054/TipoDespesa/${id}`);
                        await this.getTipoDespesas();
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


