<template>
  <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
  <div class="body_div">
    <div v-if="isProductLoaded" class="wrapper">
    <div class="card_container">

      <div class="imgbox">
        <img v-if="imgURL" :src="imgURL" alt="Product Image" />
        <img v-else src="../assets/product_image_placeholder.png" alt="Product Image">
      </div>
      <div class="card details">
        <h2> {{ this.productData.product.name }} </h2>
        <p class="label">Categoría: {{ this.categoryName }}</p>
        <p class="label"> {{ this.isPerishable ? "Perecedero" : "No perecedero" }} </p>
        <div class="description">
          <p v-if="this.isPerishable">
            Este producto caducará el 
            {{ this.productExpirationDay }} de 
            {{ this.productExpirationMonthName }} de 
            {{ this.productExpirationYear }} a las 
            {{ this.productExpirationTime }}
          </p>
          <p v-if="this.isPerishable">
            {{ this.productionDaysText }}
          </p>
        </div>
      </div>
      <div class="card buy">
        <div class="price"><span>₡{{ this.productData.product.price }}</span><p>Envío gratis</p></div>
        <div v-if="stock_amount != 0" class="btns">
          <div class="stock-btns">
            <button @click="restarQuantity" class="minus-btn b-stock">-</button>
            <p class="quantity p-stock"> {{ quantity_amount }}</p>
            <button @click="sumarQuantity" class="plus-btn b-stock">+</button>
            <p class="stock-amount p-stock"> Unidades disponibles: {{ stock_amount }}</p>
          </div>
          <button class="buy-btn purchase-btn"><i class="uil uil-shopping-bag"></i>Comprar ahora</button>
          <button class="cart-btn purchase-btn"><i class="uil uil-shopping-cart"></i>Agregar al carrito</button>
        </div>
        <div v-else class="btns">
          <div class="stock-btns">
            <p class="stock-amount out-of-stock">Existencias agotadas</p>
          </div>
          <button class="buy-btn purchase-btn btn-disabled" disabled><i class="uil uil-shopping-bag"></i>Comprar ahora</button>
          <button class="cart-btn purchase-btn btn-disabled" disabled><i class="uil uil-shopping-cart"></i>Agregar al carrito</button>
        </div>
      </div>
      <div class="about-product">
      <h3>Sobre este producto</h3>
      <p>{{ this.productData.product.description }}</p>
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
        stock_amount: 0,
        quantity_amount: 1,
        available_stock: true,
        productID: this.$route.params.productID,
        productData: null,
        categoryName: null,
        originalPrice: null,
        productionDaysText: null,
        productExpirationDay: null,
        productExpirationMonthName: null,
        productExpirationYear: null,
        productExpirationTime: null,
        imgURL: null,
        isPerishable: false,
        isProductLoaded: false,
      }
  },
  methods: {
    loadImageData() {
      axios.get(`https://localhost:7262/api/Product/LoadProductImage?productId=${this.productID}`, {
        responseType: 'blob'
      }).then((response) => {
        this.imgURL = URL.createObjectURL(response.data);
      });
    },
    loadProductData() {
      axios.get(`https://localhost:7262/api/Product/IsProductPerishable/${this.productID}`
      ).then((response) => {
        this.isPerishable = response.data;
        if (this.isPerishable) {
          this.loadPerishableData();
        } else {
          this.loadNonPerishableData();
        }
      });
    },
    loadPerishableData() {
      axios.get(`https://localhost:7262/api/PerishableProduct/GetFullProduct?productId=${this.productID}`
      ).then((response) => {
        this.productData = response.data;
        console.log("Is it perishable?")
        console.log(this.isPerishable);
        console.log("The product data:")
        console.log(this.productData);
        this.isProductLoaded = true;
        this.formatData()
      });
    },
    loadNonPerishableData() {
      axios.get(`https://localhost:7262/api/NonPerishableProduct/GetFullProduct?productId=${this.productID}`
      ).then((response) => {
        this.productData = response.data;
        console.log("Is it perishable?")
        console.log(this.isPerishable);
        console.log("The product data:")
        console.log(this.productData);
        this.formatData()
      });
    },
    loadCategoryData() {
      axios.get(`https://localhost:7262/api/Category/CategoryID/${this.productData.product.categoryID}`
      ).then((response) => {
        this.categoryName = response.data.categoryName;
        console.log("The category name is:")
        console.log(this.categoryName);
        this.isProductLoaded = true;
      });
    },
    formatPrice() {
      var price = this.productData.product.price
      price = price.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
      this.productData.product.price = price;
    },
    setStock() {
      this.stock_amount = this.isPerishable ? this.productData.productionBatch.amount : this.productData.stock;
    },
    formatExpirationDate() {
      var dateString = this.productData.productionBatch.productionDate.slice(0, 10);
      var lifespan = this.productData.lifespan;
      var day   = parseInt(dateString.substring(0,2));
      var month  = parseInt(dateString.substring(3,5));
      var year   = parseInt(dateString.substring(6,10));
      var date = new Date(year, month - 1, day);
      date.setDate(date.getDate() + lifespan);
      this.productExpirationDay = date.getDate();
      this.productExpirationMonthName = date.toLocaleString('default', { month: 'long' });
      this.productExpirationYear = date.getUTCFullYear();
      console.log(this.productExpirationDay);
      console.log(this.productExpirationMonthName);
      console.log(this.productExpirationYear);
      this.productExpirationTime = this.formatExpirationTime();
    },
    formatExpirationTime() {
      var unparsedTime = this.productData.productionBatch.orderDeadline;
      var time;
      var hours = parseInt(unparsedTime.substring(0,2))
      var minutes = parseInt(unparsedTime.substring(3, 5))
      var postfix = hours < 12 ? "AM" : "PM";
      hours = (hours % 12) == 0 ? 12 : hours % 12;
      hours = hours < 10 ? "0" + hours.toString() : hours.toString()
      minutes = minutes < 10 ? "0" + minutes.toString() : minutes.toString()
      time = parseInt(minutes) ? hours + ":" + minutes + postfix : hours + postfix;
      return time
    },
    formatProductionDays() {
      var days = ["lunes", "martes", "miercoles", "jueves", "viernes", "sabados", "domingos"]
      var productionDaysString = "Este producto está disponible los ";
      var productionDaysList = this.productData.productionDays;
      var productionDaysNumbered = []
      for (let i = 0; i < productionDaysList.length; i++) {
        switch(productionDaysList[i]) {
          case "Lunes":
            productionDaysNumbered[i] = 0; break;
          case "Martes":
            productionDaysNumbered[i] = 1; break;
          case "Miercoles":
            productionDaysNumbered[i] = 2; break;
          case "Jueves":
            productionDaysNumbered[i] = 3; break;
          case "Viernes":
            productionDaysNumbered[i] = 4; break;
          case "Sabado":
            productionDaysNumbered[i] = 5; break;
          case "Domingo":
            productionDaysNumbered[i] = 6; break;
          default:
            productionDaysNumbered[i] = 7
        }
      }

      productionDaysNumbered.sort()
      for (let i = 0; i < productionDaysList.length - 1; i++) {
        productionDaysString += days[productionDaysNumbered[i]];
        if (i == productionDaysList.length - 2) {
          productionDaysString += " y ";
        } else {
          productionDaysString += ", ";
        }
      }
      productionDaysString += days[productionDaysNumbered[productionDaysList.length - 1]];
      productionDaysString += "."
      this.productionDaysText = productionDaysString;
      console.log(productionDaysList)
      console.log(productionDaysString)
    },
    formatData() {
      this.originalPrice = this.productData.product.price
      this.loadCategoryData();
      this.formatPrice();
      this.setStock();
      if (this.isPerishable) {
        this.formatExpirationDate();
        this.formatProductionDays();
      }
    },
    sumarQuantity() {
      if (this.quantity_amount < 99 && this.quantity_amount < this.stock_amount) {
        this.quantity_amount++;
        this.productData.product.price = this.originalPrice * this.quantity_amount;
        this.formatPrice()
      }
    },
    restarQuantity() {
      if (this.quantity_amount > 1) {
        this.quantity_amount--;
        this.productData.product.price = this.originalPrice * this.quantity_amount;
        this.formatPrice()
      }
    }
  },
  created() {
    this.loadImageData();
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
    box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
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

  .buy div .out-of-stock {
    color: lightcoral;
    font-weight: 300;
    /* height: 180px; */
  }

  .btns .btn-disabled {
    background-color: #eaeaea;
    color: #818181;
    cursor:default;
  }

  .btns .btn-disabled:hover {
    background-color: #eaeaea;
    color: #818181;
  }

</style>