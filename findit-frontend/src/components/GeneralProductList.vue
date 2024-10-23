<template>
  <div class="container">
    <div class="row justify-content-start">
      <a href="/home">
        <button class="go_back_button">Regresar</button>
      </a>
    </div>
    <div class="row justify-content-center">
      <h1 class="title">Productos Registrados</h1>
    </div>
    <div ref="grid"></div>
  </div>
  <ModalComponent
    :isVisible="isModalVisible"
    :title="modalTitle"
    @close="isModalVisible = false"
  >
    <template #body>
      <p>{{ modalMessage }}</p>
    </template>
  </ModalComponent>
</template>

<script>
  import axios from "axios";
  import ModalComponent from "./ModalComponent.vue";
  import { jwtDecode } from 'jwt-decode';
  import { BACKEND_URL } from "@/config";
  import { Grid } from "gridjs";
  import "gridjs/dist/theme/mermaid.css";

  export default {
    name: "GeneralProductList",
    components: {
      ModalComponent,
    },
    data() {
      return {
        products: [],
        modalTitle: '',
        modalMessage: '',
        isModalVisible: false,
      };
    },
    methods: {
      verifyLogin() {
        // get token and verify user being admin:
        const token = localStorage.getItem('token');
          if (token) {
            const decodedToken = jwtDecode(token);     
            if (decodedToken.role === 'ADM') {
              this.getProducts();
            }
            else {
              this.modalTitle = "Acceso Restringido";
              this.modalMessage = "Para visualizar estos datos debe haber iniciado sesión como administrador";
              this.isModalVisible = true;
            }
          }
          else {
            this.modalTitle = "Acceso Restringido";
            this.modalMessage = "Para visualizar estos datos debe haber iniciado sesión como administrador";
            this.isModalVisible = true;
          }
      },
      getProducts() {
        axios.get(`${BACKEND_URL}/Product`).then((response) => {
          this.products = response.data;
          this.renderGrid();
        });
      },
      renderGrid() {
        new Grid({
          columns: [
            "Nombre",
            "Empresa",
            "Categoría",
            "Tipo",
            "Precio",
            "Días de entrega",
            "Inventario",
            "Producción max. por día",
          ],
          style: {
            td: {
              border: '1px solid #ccc',
              'background-color': '#E3DDEC'
            },
            th: {
              'font-size': '15px',
              'background-color': '#8263a8',
              'color': 'white'
            },
          },
          data: this.products.map((product) => [
            product.name,
            product.companyName,
            product.category.categoryName,
            product.type,
            product.price,
            product.perishableProducts.every(
              (p) => p.productionDay === null
            )
              ? "No aplica"
              : product.perishableProducts
                  .filter((p) => p.productionDay !== null)
                  .map((p) => p.productionDay)
                  .join(", "),
            product.nonPerishableProduct.amount,
            product.productionBatch.amount,
          ]),
          pagination: {
            enabled: true,
            limit: 6,
          },
          sort: true, 
          search: true,
          resizable: true, 
          fixedHeader: true,
          width: '100%',
          height: '500px',
          language: {
          search: {
            placeholder: "Buscar",
          },
          pagination: {
            previous: "Anterior", 
            next: "Siguiente",
            showing: " ",
            results: () => "",
          },
          sort: {
            sortAsc: "Ordenar de forma ascendente",
            sortDesc: "Ordenar de forma descendente",
          },
        }
        }).render(this.$refs.grid);
      },
    },
    created() {
      this.verifyLogin();
    },
  };
</script>

<style scoped>
  @import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');

  .container {
    max-width: 800px;
    margin: auto;
    padding: 20px;
    font-feature-settings: 'liga' off, 'clig' off;
    font-family: Montserrat;
  }

  .row {
    margin-bottom: 20px;
  }

  .go_back_button {
    padding: 10px 15px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-feature-settings: 'liga' off, 'clig' off;
    font-family: Montserrat;
    background-color: #8263a8;
    color: white;
  }

  .title {
    font-size: 2rem;
    text-align: center;
    margin-top: 10px; 
    font-feature-settings: 'liga' off, 'clig' off;
    font-family: Montserrat;
  }
</style>