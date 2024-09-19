<template>
  <div>
    <Header>
      <AppHeader />
    </Header>
  </div>

  <div class="hero">
    <div class="image-container">
      <img :src="heroImage" alt="Hero Image" class="hero-image">
    </div>
  </div>

  <div class="company-header">

    <div class="company-profile">
      <img :src="companyProfile" alt="Company Profile Picture" class="company-profile-img"/>
    </div>

    <h1 class="company-name">{{ companyName }}</h1>

    <h2 class="company-schedule">Horario: {{ companyOpeningTime }} - {{ companyClosingTime }}</h2>

    <div class="address-section">
      <img src="./assets/address_icon.png" alt="Adress Icon" class="address-icon">
      <a :href="`https://www.google.com/maps?q=${encodeURIComponent(companyAddress)}`" class="company-address"> {{ companyAddress }}</a>
    </div>

    <div class="telephone-section">
      <img src="./assets/telephone_icon.png" alt="Telephone Icon" class="telephone-icon">
      <h2 class="company-telephone"> {{ companyTel }} </h2>
    </div>
  </div>
</template>
  
<script>
import AppHeader from './components/AppHeader.vue'

export default {
  name: 'CompanyPage',
  components: {
    AppHeader
  },
  data() {
    return {
      heroImage: require("./assets/company_page_hero.jpg"),
      companyProfile: require("./assets/company_profile.png"),
      companyName: "N&W Jewerly",
      companyOpeningTime: "10:00 AM",
      companyClosingTime: "5:00 PM",
      companyAddress: "Guachipelín, San Rafael de Escazú, San José",
      companyTel: "2222-4444",
    }
  }
}
</script>

<style>
    html, body {
        margin: 0;
        padding: 0;
        width: 100%;
        height: 100%;
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

    .company-name {
        top: -75px;
        right: -250px;
        position: relative;
        font-size: 40px;
        font-family: montserrat;
    }

    .company-header {
        display: flex;
        align-items: center;
    }

    .company-schedule {
        position: relative;
        left: -27px;
        top: -30px;
        font-size: 20px;
        font-family: montserrat;
        font-weight: 400;
    }

    .address-section {
        display: flex;
        position: relative;
        right: -450px;
        top: -70px;
    }

    .address-icon {
        width: 50px;
        height: 50px;
    }

    .company-address {
        font-size: 20px;
        font-family: montserrat;
        font-weight: 400;
        right: -20px;
        bottom: -20px;
        position: relative;
        text-decoration: none;
        color: inherit;
        border: none;
        cursor: pointer;
        padding: 0;
    }

    .telephone-section {
        display: flex;
        position: relative;
        left: -35px;
        bottom: -5px;

    }

    .telephone-icon {
        width: 50px;
        height: 50px;
    }

    .company-telephone {
        font-size: 20px;
        font-family: montserrat;
        font-weight: 400;
        right: -20px;
        position: relative;

    }
</style>