<template>
  <div class="container">
    <div class="row justify-content-start">
      <a href="/business/register">
        <button class="button">Regresar</button>
      </a>
    </div>
    <div class="row justify-content-center">
      <h1 class="title">Mis Empresas</h1>
    </div>
    <div v-if="companies.length === 0" class="no-companies">
      <p class = "no-companies-message">Aún no ha registrado ninguna empresa</p>
      <a href="/business/register">
        <button class="button">Registrar</button>
      </a>
    </div>
    <table v-else class="table">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Identificación</th>
          <th>Número de teléfono</th>
          <th>Correo</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(company, index) in companies" :key="index">
          <td>{{ company.name }}</td>
          <td>{{ company.legalID }}</td>
          <td>{{ company.phoneNumber }}</td>
          <td>{{ company.email }}</td>
        </tr>
      </tbody>
    </table>
    <ModalComponent
        :isVisible="isModalVisible"
        :title="modalTitle"
        @close="isModalVisible = false"
      >
        <template #body>
          <p>{{ modalMessage }}</p>
        </template>
      </ModalComponent>
  </div>
</template>

<script>
import axios from "axios";
import ModalComponent from "./ModalComponent.vue";
import { jwtDecode } from 'jwt-decode';

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
      axios.get(`https://localhost:7262/api/Company/UserCompanies/${email}`,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('token')}`
        }
      }).then((response) => {
        this.companies = response.data;
      });
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

.table {
  width: 100%;
  border-collapse: collapse;
  font-feature-settings: 'liga' off, 'clig' off;
  font-family: Montserrat;
}

.table td {
  border: 1px solid #ccc;
  padding: 10px;
  text-align: left;
  background-color: #E3DDEC;
}

.table th {
  border: 1px solid #ccc;
  padding: 10px;
  text-align: left;
  background-color: #8263a8;
  color: white;
}

</style>
