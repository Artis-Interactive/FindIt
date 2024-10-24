<template>
  <div class="container">
    <div class="row justify-content-start">
      <a href="/company/register">
        <button class="go_back_button">Regresar</button>
      </a>
    </div>
    <div class="row justify-content-center">
      <h1 class="title">Usuarios de empresa registrados</h1>
    </div>
    <div v-if="companyUsers.length === 0" class="no-users">
      <p class = "no-users-message">No hay usuarios registrados</p>
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
    name: "GeneralUsersist",
    components: {
      ModalComponent,
    },
    data() {
      return {
        companyUsers: [],
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
            if (decodedToken.role === 'EMP') {
              this.getCompanyUsers();
            }
            else {
              this.modalTitle = "Acceso Restringido";
              this.modalMessage = "Para visualizar estos datos debe haber iniciado sesión como empresario";
              this.isModalVisible = true;
            }
          }
          else {
            this.modalTitle = "Acceso Restringido";
            this.modalMessage = "Para visualizar estos datos debe haber iniciado sesión como empresario";
            this.isModalVisible = true;
          }
      },
      getCompanyUsers() {
        axios.get(`${BACKEND_URL}/UserDataSignUp/CompanyUsers`).then((response) => {
          this.companyUsers = response.data;
          if (this.companyUsers.length > 0) {
            this.$nextTick(() => {
              this.renderGrid(); 
            });
          }
        });
      },
      getAccountStateLabel(state) {
        const stateLabels = {
          'ACT': 'Verificado',
          'NotVER': 'No verificado',
          'BAN': 'Bloqueado',
        };
        return stateLabels[state] || 'Estado desconocido';
      },

      renderGrid() {
        new Grid({
          columns: [
            "Nombre",
            "Apellidos",
            "Cédula",
            "Correo",
            "Estado",
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
          data: this.companyUsers.map((user) => [
            user.name,
            user.lastNames,
            user.legalId,
            user.email,
            this.getAccountStateLabel(user.accountState),
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

  .no-users {
    text-align: center;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .no-users-message {
    font-size: 20px;
    font-feature-settings: 'liga' off, 'clig' off;
    font-family: Montserrat;
  }
</style>

