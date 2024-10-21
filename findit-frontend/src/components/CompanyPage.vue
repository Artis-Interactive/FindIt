<template>
  <header class="header"> <AppHeader /> </header>
   
  <div class="hero-container">
    <img :src="companyHeroImage" alt="Hero Image" class="hero-image">
  </div>

  <div class="info-container">
    <div class="profile-container">
      <img :src="companyProfileImage" alt="Company Profile Picture" class="profile-image"/>
    </div>

    <div class="name-and-schedule">
      <h1 class="company-name">{{ companyData.name }}</h1>
      <a class="company-schedule" @click="showModal()">Ver Horario</a>
    </div>
        
    <div class="address-and-tel">
      <div class="address-section">
        <img src="@/assets/address_icon.png" alt="Adress Icon" class="address-icon">
        <a :href="`https://www.google.com/maps?q=${encodeURIComponent(companyAddress)}`" class="company-address">{{ companyAddress }}</a>
      </div>

      <div class="telephone-section">
        <img src="@/assets/telephone_icon.png" alt="Telephone Icon" class="telephone-icon">
        <h2 class="company-telephone"> {{ companyData.phoneNumber }} </h2>
      </div>
    </div>
  </div> 
  <div class="catalog-container">
    <div class="catalog-header">
      <h3 class="catalog-title">Catálogo</h3>
      <div v-if="isCompanyUser">
        <button class="create-product" @click="this.$router.push('/product-creation')">Añadir producto</button>
      </div>
    </div>
    <div class="catalog-carousel">
      <ProductCarousel :products="products"/>
    </div>
  </div> 

  <ModalComponent
    :isVisible="isModalVisible"
    :title="modalTitle"
    @close="isModalVisible = false"
  >
    <template #body>
      <p v-html="modalMessage"></p>
    </template>
  </ModalComponent>
</template>
  
<script>
  import axios from "axios";
  import AppHeader from './AppHeader.vue'
  import ProductCarousel from './ProductCarousel.vue'
  import ModalComponent from "./ModalComponent.vue";
  import { jwtDecode } from 'jwt-decode';

  export default {
    name: 'CompanyPage',
    components: {
      AppHeader,
      ProductCarousel,
      ModalComponent
    },

    data() {
      return {
        companyHeroImage: "",
        companyProfileImage: "",
        companyStartTime:"",
        companyEndTime:"",
        companyAddress:"",
        isCompanyUser: false,
        companyId: "763E3ADF-A045-4B46-B9FB-40619B2F0220",
        companyData: "",
        isCompanyDataReady: false,
        products: [],
        modalMessage: "",
        modalTitle: "Horario",
        isModalVisible: false,
      }
    },

    methods: {
      verifyLogin() {
      // get token and verify open session:
        const token = localStorage.getItem('token');
          if (token) {
            const decodedToken = jwtDecode(token);
            if(decodedToken.role === "EMP"){
              this.isCompanyUser = true;
            }
            this.obtainData(decodedToken.email);
          }
          else {
            this.modalTitle = "Acceso Restringido";
            this.modalMessage = "Para visualizar estos datos debe iniciar sesión";
            this.isModalVisible = true;
          }
      },

      clickOnCreate() {
        console.log('Create product');
      },

      showModal() {
        this.isModalVisible = true;
      },

      async obtainData(email) {
        try {
          const responseCompany = await axios.get(`https://localhost:7262/api/Company/Email/${email}`);
          this.companyData = responseCompany.data;
          console.log("Datos empresa: ", this.companyData);
          this.isCompanyDataReady = true;

          const responseProducts = await axios.get(`https://localhost:7262/api/Product/Email/${email}`);
          this.products = responseProducts.data;
          console.log("Datos productos: ", this.products);
        } catch (error) {
          console.error("Cannot obtain data:", error);
        }
      },

      async setCompanyData() {
        if (this.companyData) {

          this.companyProfileImage = require(`@/${this.companyData.logo}`);
        
          this.companyHeroImage = require(`@/${this.companyData.heroImage}`);

          this.companyAddress = this.companyData.address.details +
                                ', ' + 
                                this.companyData.address.district +
                                ', ' + 
                                this.companyData.address.canton +
                                ', ' + 
                                this.companyData.address.province;   

          for(let index = 0; index < this.companyData.workingDays.length; index++) {
            this.modalMessage += this.companyData.workingDays[index].day + ": " 
                              + this.companyData.workingDays[index].startTime + " - " 
                              + this.companyData.workingDays[index].endTime + "<br>";
          }
                
        } else {
          console.error("Company data is not available");
        }
      },

      toAMPM(timeString) {
        let [hours, minutes] = timeString.split(':');
        
        hours = parseInt(hours);
        let ampm;
        if(hours < 12){
          ampm = 'AM';
        } else{
          ampm = 'PM';
        }
        hours = hours % 12;
        return `${hours}:${minutes} ${ampm}`;
      },

      formatSchedule(){
        for(let index = 0; index < this.companyData.workingDays.length; index++) {
          this.companyData.workingDays[index].startTime = this.toAMPM(this.companyData.workingDays[index].startTime);
          this.companyData.workingDays[index].endTime = this.toAMPM(this.companyData.workingDays[index].endTime);
        }
      }

    },

    watch: {
      isCompanyDataReady(newValue) {
        if (newValue && this.companyData) {
          this.formatSchedule();
          this.setCompanyData();
          console.log("Horario: ", this.companyData.workingDays);
        }
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
    min-width: 100%;
    min-height: 100%;
    background-color: aquamarine;
  }

  .header{
    width: 100%;
    min-height: 100%;
  }

  .hero-container {
    width: 100%;
    height: 300px;
    overflow: hidden;
    position: relative;
  }

  .hero-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }

  .info-container{
    display: flex;
    height: 200px;
    gap: 30px;
  }

  .profile-container {
    width: 250px; 
    height: 250px; 
    border-radius: 50%; 
    overflow: hidden;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    right: -200px;
    top: -75px;
  }

  .profile-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }   

  .name-and-schedule{
    display: flex;
    flex-direction: column;
    left: 12%;
    top: 20%;
    text-align: left;
    position: relative;
    width: 30%;
  }

  .company-name {
    position: relative;
    font-size: 40px;
    font-family: montserrat;
    font-weight: 600;
    display: block;
    white-space: nowrap;
    overflow: hidden; 
    text-overflow: ellipsis;
  }

  .company-schedule {
    font-size: 20px;
    font-family: montserrat;
    font-weight: 400;
    color: black;
    cursor: pointer;
    display: inline-block;
    white-space: nowrap;
    width: 10%;
  }

  .company-schedule:hover {
    color: #966dc9;
    transition: background-color 0.2s ease;
  }

  .address-and-tel{
    display: flex;
    left: 20%;
    top: 10%;
    flex-direction: column;
    text-align: left;
    position: relative;
    width: 30%;
  }

  .address-section {
    display: flex;
    position: relative;
    height: 100px;
  }

  .address-icon {
    width: 50px;
    height: 50px;
  }

  .company-address {
    font-size: 20px;
    font-family: montserrat;
    font-weight: 400;
    position: relative;
    text-decoration: none;
    color: inherit;
    border: none;
    cursor: pointer;
    text-decoration: underline;
    top: 15px;
    left: 15px;
    overflow: hidden; 
    text-overflow: ellipsis;
    white-space: normal; 
    height: 80%;
    width: 87%;
  }

  .company-address:hover {
    color: #966dc9;
    transition: background-color 0.2s ease;
  }

  .telephone-section {
    display: flex;
    position: relative;
  }

  .telephone-icon {
    width: 50px;
    height: 50px;
  }

  .company-telephone {
    font-size: 20px;
    font-family: montserrat;
    overflow: hidden; 
    text-overflow: ellipsis;
    white-space: nowrap;
    font-weight: 400;
    position: relative;
    top: 15px;
    left: 15px;
  }

  .catalog-container {
    height: 350px;
  }
  
  .catalog-header {
    display: flex;
    justify-content: space-between;
    height: 80px;
  }

  .catalog-title {
    width: 7%;
    font-weight: 700;
    position: relative;
    left: 4%;
  }

  .create-product {
    border-radius: 10px;
    background: var(--buttons-primary, #8263a8);
    overflow: hidden;
    font-size: 20px;
    color: white;
    padding: 10px;
    border: none;
    position: relative;
    cursor: pointer;
    right: 50%;
  }

  .create-product:hover {
    background-color: #966dc9;
    transition: background-color 0.2s ease;
  }

  .catalog-carousel {
    position: relative;
    bottom: 40px;
  }
</style>