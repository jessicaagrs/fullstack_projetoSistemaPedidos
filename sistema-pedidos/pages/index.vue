<template>
  <v-data-table v-model:items-per-page="itemsPerPage" :headers="headers" :items="tipoDespesas"
    class="elevation-1"></v-data-table>
</template>

<script>

export default {
  data() {
    return {
      itemsPerPage: [5],
      headers: [
        {
          text: 'Despesas',
          align: 'start',
          sortable: false,
          value: 'descricao',
        },
        { text: 'Id', align: 'start', value: 'id' },

      ],
      tipoDespesas: [],
    };
  },

  mounted() {
    this.submit();
  },

  methods: {
    async submit() {
      try {
        await this.postTipoDespesa();
        await this.getTipoDespesas();
      } catch (error) {
        console.error(error);
      }
    },

    async postTipoDespesa() {
      try {
        await this.$axios.post('https://localhost:7054/TipoDespesa', this.tipoDespesas);
        console.log(this.tipoDespesas)
      } catch (error) {
        console.error(error);
      }
    },

    async getTipoDespesas() {
      try {
        const response = await this.$axios.get('https://localhost:7054/TipoDespesa');
        this.tipoDespesas = response.data;
        console.log(this.tipoDespesas)
      } catch (error) {
        console.error(error);
      }
    },
  },

};
</script>