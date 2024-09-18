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
      companyName: "N&W Jewerly",
      companySchedule: "Horario: 10:00 AM - 5:00PM",
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
        width: 2505px;
        height: 500px;
        overflow: hidden;
    }

    .hero-image {
        width: 100%;
        height: 100%;
        object-fit: cover;
    }
</style>