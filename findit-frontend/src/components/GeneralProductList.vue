<template>
    <div class="container mt-5">
      <h1 class="display-4 text-center">Lista de productos (General)</h1>
      <div class="row-justify-content-end">
        <div class="col-2">
        </div>
      </div>
      <table
        class="table is-bordered is-striped is-narrow is-hoverable
    is-fullwidth"
        >
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Empresa</th>
              <th>Categoría</th>
              <th>Tipo</th>
              <th>Precio</th>
              <th>Días de entrega</th>
              <th>Inventario</th>
              <th>Producción max. por día</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(product, index) of products" :key="index">
              <td>{{ product.name }}</td>
              <td>{{ product.companyName }}</td>
              <td>{{ product.category.categoryName }}</td>
              <td>{{ product.type }}</td>
              <td>{{ product.price }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </template>

<script>
import axios from "axios";
export default {
    data() {
    return {
      products : [],
    };
  },
  
  methods: {
    getProducts() {
      axios.get("https://localhost:7262/api/Product").then((response) => {
      this.products = response.data;
      console.log(response.data);
      });
    },
  },
  created: function () {
      this.getProducts();
  }
}
</script>

<style scoped>

</style>