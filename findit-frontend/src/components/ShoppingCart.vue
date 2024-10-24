<template>
  <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
  <div>
    <AppHeader></AppHeader>
    <div class="cartTitle"><h1><i class="uil uil-shopping-cart"></i>Mi carrito</h1></div>
    <div class="cartBody"></div>
  </div>
</template>

<script>
  // import axios from 'axios';
  import AppHeader from './AppHeader.vue';
  // import { BACKEND_URL } from "@/config";
  export default {
    name: 'ShoppingCart',
        components: {
            AppHeader
        }, 
        data() {
            return {
                products: [
                  {name: "Test", img: "", basePrice: 500, cartQuantity: 5, companyName: "TestComp", productionDays: ["Lunes", "Sabado"]},
                  {name: "TP", img: "", basePrice: 45600, cartQuantity: 65, companyName: "Comp", productionDays: ["Miercoles"]},
                  {name: "Marco", img: "", basePrice: 1, cartQuantity: 777, companyName: "Marquillos", productionDays: ["Miercoles", "Sabado", "Domingo"]}
                ]
            }
        },
        methods: {
        handleProductsData() {}
        },
        created() {}
  }
</script>

<style scoped>

</style>