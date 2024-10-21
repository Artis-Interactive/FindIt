<template>
  <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
  <div class="body_div">
    <div class="wrapper">
    <div class="card_container">

      <div class="imgbox">
        <img v-if="imgURL" :src="imgURL" alt="Product Image" />
        <img v-else src="../assets/product_image_placeholder.png" alt="Product Image">
      </div>
      <div class="card details">
        <h2>Brazalete Aura 14K</h2>
        <p class="label">Categoría: Accesorios</p>
        <p class="label">Perecedero</p>
        <div class="description">
          <p>
            Este producto posee una fecha de caducidad.
          </p>
          <!-- <img v-if="imgURL" :src="imgURL" alt="Product Image" />
          <p v-else>No Image Found</p> -->
        </div>
      </div>
      <div class="card buy">
        <div class="price"><span>₡20.000</span><p>Envío gratis</p></div>
        <div class="btns">
          <div class="stock-btns">
            <button @click="restarQuantity" class="minus-btn b-stock">-</button>
            <p class="quantity p-stock"> {{ quantity_amount }}</p>
            <button @click="sumarQuantity" class="plus-btn b-stock">+</button>
            <p class="stock-amount p-stock"> Unidades disponibles: {{ stock_amount }}</p>
          </div>
          <button class="buy-btn purchase-btn"><i class="uil uil-shopping-bag"></i>Comprar ahora</button>
          <button class="cart-btn purchase-btn"><i class="uil uil-shopping-cart"></i>Agregar al carrito</button>
        </div>
      </div>
      <div class="about-product">
      <h3>Sobre este producto</h3>
      <p>Brazalete de alta calidad hecho con oro de 14k. Ligero y ajustable, ideal para pasar el día sin molestias.</p>
    </div>
    </div>
    </div>
  </div>

</template>

<script>
import axios from 'axios';
export default {
  name: 'ProductDetails',
  components: {
  }, 
  data() {
      return {
        stock_amount: 10,
        quantity_amount: 1,
        available_stock: true,
        productID: this.$route.params.productID,
        imgURL: null
      }
  },
  methods: {
    loadProductData() {
      axios.get(`https://localhost:7262/api/Product/LoadProductImage?productId=${this.productID}`, {
        responseType: 'blob'
      }).then((response) => {
        this.imgURL = response.data;
        console.log(this.imgURL);
        console.log(URL.createObjectURL(this.imgURL))
        this.imgURL = URL.createObjectURL(this.imgURL)
      });
    },
    sumarQuantity() {
      if (this.quantity_amount < 99 && this.quantity_amount < this.stock_amount) {
        this.quantity_amount++;
      }
    },
    restarQuantity() {
      if (this.quantity_amount > 1) {
        this.quantity_amount--;
      }
    }
  },
  created() {
    this.loadProductData();
  }
}

</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;800&display=swap');
  
  *{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'poppins', sans-serif;
  }

  .body_div{
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    scale: 1;
  }

  .wrapper{
    position: relative;
    width: 100%;
    background: white;
    padding: 0 4em;
    /* box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); */
  }

  .card_container{
    background: white;
    position: relative;
    display: grid;
    grid-template-columns: 2fr 3fr 1.4fr;
    grid-row: 1fr 1fr;
    border-radius: 10px;
    margin: 2.5em 0;
    box-shadow: 0 10px 5px rgba(0, 0, 0, 0.3);
    height: 100%;
  }

  .imgbox{
    position: relative;
    height: 100%;
    border-radius: 10px 0 0 0;
    overflow: hidden;
  }

  .imgbox img{
    position: absolute;
    height: 100%;
    width: 100%;
    object-fit: cover;
    transition: 0.2s ease;
  }

  .imgbox:hover img{
    scale: 1.1;
  }

  .card{
    position: relative;
    padding: 15px;
    border-color: transparent;
  }

  .card h2{
    font-weight: 600;
  }

  .card .label {
    color: #3f3f3f;
  }
  
  .description {
    margin-top: 15px;
  }

  .description p{
    font-size: 0.9em;
  }

  .price{
    position: relative;
    margin-top: 10px;
  }

  .price span {
    font-size: 1.6em;
    font-weight: 600;
  }

  .buy {
    position: relative;
  }

  .buy p{
    /* color: #07a507; */
    color: #8263A8;
    font-size: 1.1em;
    font-weight: 600;
  }

  .buy .btns{
    width: 100%;
    height: auto;
    display: flex;
    flex-direction: column;
    justify-content: end;
  }

  .btns .purchase-btn {
    border: none;
    outline: none;
    margin: 5px 0;
    padding: 0.6vw 0;
    width: 90%;
    font-size: 80%;
    cursor: pointer;
  }

  .btns .buy-btn{
    /* background-color: #07a507; */
    background-color: #8263A8;
    color: white;
  }

  .btns .purchase-btn:hover{
    background-color: tomato;
    color: white;
  }

  .stock-btns{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    grid-template-rows: 1fr 1fr 1fr 1fr;
    width: 200px;
    height: 100px;
    align-items: center;
    justify-content: center;
    justify-items: center;
  }

  .btns .b-stock{
    font-weight: 600;
    height: 30px;
    width: 30px;
    border-radius: 100%;
    border: #8263A8;
    border-color: #8263A8;
    transition: 0.1s;
    grid-row: 3/4;
    cursor: pointer;
  }

  .btns .b-stock:hover{
    background-color: #8263A8;
    color: white;
  }

  .btns .quantity{
    text-align: center;
    color: black;
    grid-row: 3/4;
  }

  .btns .stock-amount{
    grid-row: 4/5;
    grid-column: 1/7;
    font-weight: 300;
    color: #818181;
    font-size: 16px;
  }

  .about-product{
    background-color: white;
    width: 100%;
    padding: 1em 4em;
    border-radius: 10px;
    grid-column: 1/4;
  }

</style>