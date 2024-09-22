<template>
  <div id="dynamic-carousel" class="carousel slide">
    <div class="carousel-indicators">
      <button v-for="(group, index) in groupedProducts" :key="index"
        :data-bs-target="'#dynamic-carousel'" :data-bs-slide-to="index" 
        :class="{ active: index === 0 }"
        style="background-color: #9D77CC;">
      </button>
    </div>
  
    <div class="carousel-inner">
      <div v-for="(group, index) in groupedProducts" :key="index" :class="['carousel-item', { active: index === 0 }]">
        <div class="row">
          <div class="col-md-2" v-for="product in group" :key="product.name">
            <button class="product-card" @click="clickOn(product)">
              <img :src="product.image" class="d-block w-100" :alt="product.name">
              <h5>{{ product.name }}</h5>
              <p>{{ product.price }}</p>
            </button>
          </div>
        </div>
      </div>
    </div>
  
    <button class="carousel-control-prev" type="button" data-bs-target="#dynamic-carousel" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"  style="background-color: #9D77CC;"></span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#dynamic-carousel" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"  style="background-color: #9D77CC;"></span>
    </button>
  </div>
</template>
  
  
<script>
  export default {

    props: {
      products: {
        type: Array,
        required: true
      }
    },

    data() {
      return {
        itemsPerSlide: 5, 
      };
    },
    computed: {
      groupedProducts() {
        const groups = [];
        for (let i = 0; i < this.products.length; i += this.itemsPerSlide) {
          groups.push(this.products.slice(i, i + this.itemsPerSlide));
        }
        return groups;
      },
    },
    methods: {
      clickOn(product) {
        console.log('Clicked on product:', product.name);
      }
    }
  };
</script>
  
<style scoped>
  .carousel-item {
    padding: 50px;
  }

  .carousel-inner .row {
    display: flex;
    justify-content: center;
  }

  .product-card {
    background-color: #9D77CC;
    height: 200px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    overflow: hidden;
    color: white;
    border-radius: 8px;
    width: 230px;
    border: none;
    padding: 0;
  }

  .product-card img {
    width: 100%;
    height: auto;
    max-height: 150px;
    object-fit: cover;
  }

  .product-card:hover {
    background-color: #825BB1;
    transition: background-color 0.2s ease;
  }

</style>