<template>
  <div class="container">
    <div class="grid-container">
      <header class="header"> <AppHeader /> </header>

      <article class="main">

        <div class="hero">
          <div class="image-container">
            <img :src="companyHeroImage" alt="Hero Image" class="hero-image">
          </div>
        </div>

        <div class="company-profile">
          <img :src="companyProfileImage" alt="Company Profile Picture" class="company-profile-img"/>
        </div>

        <div class="name-and-schedule">
          <h1 class="company-name">{{ companyData.name }}</h1>
          <h2 class="company-schedule">Horario: {{ companyStartTime }} - {{ companyEndTime }}</h2>
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
        
      </article>

      <article class="catalog">
        <h3 class="catalog-title">Catálogo</h3>
        <div v-if="isCompanyUser">
          <button class="create-product" @click="clickOnCreate()">Añadir producto</button>
        </div>
        <div class="catalog-carousel-container">
          <ProductCarousel :products="products"/>
        </div>
      </article>

    </div>
  </div>
</template>
  
<script>
import axios from "axios";
import AppHeader from './AppHeader.vue'
import ProductCarousel from './ProductCarousel.vue'

export default {
  name: 'CompanyPage',
  components: {
    AppHeader,
    ProductCarousel
  },

  data() {
    return {
      companyHeroImage: "",
      companyProfileImage: "",
      companyStartTime:"",
      companyEndTime:"",
      companyAddress:"",
      isCompanyUser: true,
      isCompanySection: true,
      companyId: "b3ad3854-758d-4288-bd50-04d8933c664d",
      companyData: "",
      isCompanyDataReady: false,
      products: [],
    }
  },

  methods: {
    clickOnCreate() {
      console.log('Create product');
    },

    async obtainData() {
      try {
        const responseCompany = await axios.get(`https://localhost:7262/api/Company/CompanyID/${this.companyId}`);
        this.companyData = responseCompany.data;
        console.log("Datos empresa: ", this.companyData);
        this.isCompanyDataReady = true;

        const responseProducts = await axios.get(`https://localhost:7262/api/Product/CompanyID/${this.companyId}`);
        this.products = responseProducts.data;
        console.log("Datos productos: ", this.products);
      } catch (error) {
        console.error("Error al obtener los datos:", error);
      }
    },

    async setCompanyData() {
      if (this.companyData) {
        this.companyProfileImage = require(`@/${this.companyData.logo}`);
        console.log("Logo: ", this.companyProfileImage);
        this.companyHeroImage = require(`@/${this.companyData.heroImage}`);
        this.companyAddress = this.companyData.address.details +
                              ', ' + 
                              this.companyData.address.district +
                              ', ' + 
                              this.companyData.address.canton +
                              ', ' + 
                              this.companyData.address.province;                  
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
      console.log("hola");
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
        this.setCompanyData();
        this.formatSchedule();
        console.log("Horario: ", this.companyData.workingDays);
      }
    },
  },

  created() {
    this.obtainData();
  },
};
</script>


<style scoped>
  .container {
    display: flex;
    justify-content: center; 
    align-items: center; 
    height: 100vh; 
  }

  .grid-container > * {
    height: 100%;
    text-align: center;

  }

  .header {
    grid-area: header;
  }

  .main {
    grid-area: main;
  }

  .catalog{
    grid-area: catalog;
    font: montserrat;
  }

  .grid-container {
    min-height: 100vh;
    display: grid;
    grid-template: 
      "header" 73px
      "main" 490px
      "catalog" 365px;
  }

  .image-container {
    width: 1879px;
    height: 300px;
    overflow: hidden;
    position: relative;
  }

  .hero-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }

  .company-profile {
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

  .company-profile-img {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }   

  .name-and-schedule{
    display: flex;
    flex-direction: column;
    bottom: 45%;
    left: 25%;
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
  }

  .address-and-tel{
    display: flex;
    flex-direction: column;
    bottom: 63%;
    left: 60%;
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
    bottom: 10px;
    left: 15px;
  }

  .catalog-title {
    width: 7%;
    font-weight: 700;
    position: relative;
    left: 5%;
    top: 10%;
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
    left: 40%;
    
  }

  .create-product:hover {
    background-color: #966dc9;
    transition: background-color 0.2s ease;
  }
  .catalog-carousel-container{
    position: relative;
    bottom: 8%;
  }

</style>