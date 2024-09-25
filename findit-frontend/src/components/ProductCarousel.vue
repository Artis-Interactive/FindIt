<template>
  <div id="dynamic-carousel" class="carousel slide">
    <div class="carousel-inner">
      <div v-for="(group, index) in groupedProducts" :key="index" :class="['carousel-item', { active: index == 0 }]">
        <div class="row">
          <div class="col-md-2" v-for="product in group" :key="product.name">
            <button class="product-card" @click="clickOnProduct(product)">
              <img :src="product.image" class="d-block w-100" :alt="product.name">
              <div class="product-card-info">
                <p>{{ product.name }}</p>
                <p>{{ product.price }}</p>
              </div>
            </button>
          </div>
        </div>
      </div>
    </div>
  
    <button class="carousel-control-prev" type="button" data-bs-target="#dynamic-carousel" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" style="filter: invert(100%);"></span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#dynamic-carousel" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"  style="filter: invert(100%);"></span>
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

    mounted() {
      const link = document.createElement("link");
      link.href =
        "https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css";
      link.rel = "stylesheet";
      link.integrity =
        "sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH";
      link.crossOrigin = "anonymous";
      document.head.appendChild(link);

      const script = document.createElement("script");
      script.src =
        "https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js";
      script.integrity =
        "sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz";
      script.crossOrigin = "anonymous";
      document.body.appendChild(script);
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
      clickOnProduct(product) {
        console.log('Clicked on product:', product.name);
      },
    },
  };
</script>
  
<style scoped>
  .carousel-item {
    padding: 50px;
  }

  .carousel-inner .row {
    display: flex;
    justify-content: center;
    margin-left: 28px;
  }

  .product-card {
    background-color: white;
    height: 200px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    overflow: hidden;
    color: black;
    border-radius: 8px;
    width: 230px;
    border: none;
  }

  .product-card img {
    width: 100%;
    height: auto;
    max-height: 150px;
    object-fit: cover;
    box-shadow: inset;
    box-shadow: 1px 1px 1px 1px rgba(172, 171, 171, 0.5);
    border-radius: 8px;
  }

  .product-card:hover {
    background-color: #825BB1;
    border: 1px solid #825BB1;
    color: white;
    transition: background-color 0.2s ease;
  }

  .product-card-info{
    display: flex;
    gap: 100px;
    font-size: 20px;
  }
</style>