<template>
  <div id="dynamic-carousel" class="carousel slide">

    <div class="carousel-inner">
      <div v-for="(group, index) in groupedProducts" :key="index" :class="['carousel-item', { active: index == 0 }]">
        <div class="row">
          <div class="col-md-2" v-for="product in group" :key="product.name">
            <button class="product-card" @click="clickOnProduct(product)">
              <img :src="require(`@/${product.image}`)" class="d-block w-100" :alt="product.name">
              <div class="product-card-info">
                <div class="product-name" :title="product.name">{{ product.name }}</div>
                <p>₡{{ product.price }}</p>
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

    computed: {
      groupedProducts() {
        const groups = [];
        for (let index = 0; index < this.products.length; index += this.itemsPerSlide) {
          groups.push(this.products.slice(index, index + this.itemsPerSlide));
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
    transition: 0.2s ease;
    gap: 10%;
  }

  .product-card img {
    width: 100%;
    height: auto;
    max-height: 150px;
    object-fit: cover;
    box-shadow: inset;
    box-shadow: 8px 10px 4px 0px rgba(230, 229, 229, 0.808);
    border-radius: 8px;
  }

  .product-card:hover {
    transition: background-color 0.2s ease;
    scale: 1.05;
  }

  .product-card-info {
    display: flex;
    flex-direction: column;
    gap: 5px;
    font-size: 20px;
}

  .product-name {
    display: -webkit-box; 
    -webkit-box-orient: vertical;
    -webkit-line-clamp: 1; 
    overflow: hidden; 
    text-overflow: ellipsis; 
    max-width: 100%; 
    line-height: 1.2; 
  }


  .carousel-control-prev {
    width: 2%;
    height: 10%;
    top: 30%;
    left: 8%;

  }

  .carousel-control-prev:hover {
    color: #966dc9;
  }

  .carousel-control-next {
    width: 2%;
    height: 10%;
    top: 30%;
    left: 90%;

  }

  .carousel-control-next:hover {
    color: #966dc9;
  }
</style>