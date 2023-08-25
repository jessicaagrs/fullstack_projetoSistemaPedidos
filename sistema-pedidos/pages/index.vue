<template>
  <v-sheet
    class="mx-auto"
    elevation="8"
    max-width="800"
  >
    <v-slide-group
      v-model="currentIndex"
      class="pa-4"
      selected-class="bg-primary"
      show-arrows
    >
      <v-slide-item
        v-for="(image, index) in images"
        :key="index"
        v-slot="{ isSelected, toggle, selectedClass }"
      >
        <v-card
          :class="['ma-4', selectedClass]"
          height="500"
          width="100%"
          @click="toggle"
        >
          <img :src="image" alt="Slide Image" class="d-block w-100 h-100">
        </v-card>
      </v-slide-item>
    </v-slide-group>

    <v-expand-transition>
      <v-sheet
        v-if="currentIndex !== null"
        height="50"
      >
        <div class="d-flex fill-height align-center justify-center">
          <h3 class="text-h6">
            <p>{{ imageTexts[currentIndex] }}</p> 
          </h3>
        </div>
      </v-sheet>
    </v-expand-transition>
  </v-sheet>
</template>

<script>
export default {
  data: () => ({
    currentIndex: null,
    images: ['img1.jpg', 'img2.jpg', 'img3.jpg', 'img4.jpg','img5.jpg','img6.jpg'],
    imageTexts: [
      'O sistema permite vincular uma despesa ao seu pedido.',
      'Cadastre fornecedores.',
      'Informe os impostos de cada produto',
      'Cadastre produtos.',
      'Cadastre seus pedidos.',
      'Edite, exclua ou visualize dados pelas tabelas em cada módulo.'
    ]
  }),
  methods: {
    getImagePath(image) {
      return `${process.env.BASE_URL}/${image}`;
    }
  }
};
</script>
