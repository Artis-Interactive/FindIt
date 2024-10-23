<template>
  <div class="container">
    <div class="row justify-content-start">
      <a href="/home">
        <button class="button">Regresar</button>
      </a>
    </div>
    <div class="row justify-content-center">
      <h1 class="title">Mis Empresas</h1>
    </div>
    <div v-if="companies.length === 0" class="no-companies">
      <p class = "no-companies-message">Aún no ha registrado ninguna empresa</p>
      <a href="/company/register">
        <button class="button">Registrar</button>
      </a>
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
    name: "PersonalCompanyList",
    components: {
      ModalComponent,
    },
    data() {
      return {
        companies: [],
        modalTitle: '',
        modalMessage: '',
        isModalVisible: false,
      };
    },
    methods: {
      verifyLogin() {
        // get token and verify open session:
        const token = localStorage.getItem('token');
          if (token) {
            const decodedToken = jwtDecode(token);
            this.getUserCompanies(decodedToken.email);
          }
          else {
            this.modalTitle = "Acceso Restringido";
            this.modalMessage = "Para visualizar estos datos debe iniciar sesión";
            this.isModalVisible = true;
          }
      },
      getUserCompanies(email) {
        axios.get(`${BACKEND_URL}/Company/UserCompanies/${email}`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        }).then((response) => {
          this.companies = response.data;
          if (this.companies.length > 0) {
            this.$nextTick(() => {
              this.renderGrid(); 
            });
          }
        });
      },
      renderGrid() {
        new Grid({
          columns: [
            "Nombre",
            "Identificación",
            "Número de Teléfono",
            "Correo",
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
          data: this.companies.map((company) => [
            company.name,
            company.legalID,
            company.phoneNumber,
            company.email,
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
    mounted() {
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

  .button {
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

  .no-companies {
    text-align: center;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .no-companies-message {
    font-size: 20px;
    font-feature-settings: 'liga' off, 'clig' off;
    font-family: Montserrat;
  }
</style>
