<template>
  <AppHeader />
  <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
  <div class="general-container">
    <div class="user-container">
      <img src="../assets/company_profile.png" alt="Imagen de usuario">
      <h2> {{ this.name }}</h2>
    </div>
    <div class="btns">
      <button @click="this.$router.push('/profile/settings')" class="personal-data btn"><i class="uil uil-user"></i>Información personal</button>
      <button @click="this.$router.push('/profile/payment-methods')" class="payment-methods btn"><i class="uil uil-credit-card"></i>Métodos de pago</button>
      <button @click="this.$router.push('/profile/addresses')" class="locations btn"><i class="uil uil-location-point"></i>Direcciones</button>
    </div>
  </div>
</template>

<script>
  import { jwtDecode } from 'jwt-decode';
  import axios from 'axios';
  import AppHeader from './AppHeader.vue'
  export default {
    name: "MyProfile",
    components: {
      AppHeader
    },
    data() {
      return {
        name: "Placeholder"
      };
    },
    methods: {
      getName() {
        const token = localStorage.getItem('token');
          if (token) {
            const decodedToken = jwtDecode(token); 
            console.log(decodedToken.email);
            axios.get(`https://localhost:7262/api/User/User/${encodeURIComponent(decodedToken.email)}`,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('token')}`
        }
      }).then(
              (response) => {
              console.log(response.data)
              this.name = response.data.name + " " + response.data.lastNames
            });
          }
      }
    },
    created() {
      this.getName();
    }
};
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;800&display=swap');
  
  .general-container{
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  .user-container{
    display: flex;
    flex-direction: row;
    align-items: center;
    padding: 40px;
    width: 80%;
    min-width: 800px;
  }

  .user-container img {
    width: 200px;
    height: 200px;
    border-radius: 50%;
    margin-right: 20px;
  }

  .user-container h2{
    font-family: 'poppins', sans-serif;
    font-weight: 600;
    font-size: 2.5em;
  }

  .btns{
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-template-rows: 1fr 1fr;
    background-color: #E3DDEC;
    width: 80%;
    min-width: 800px;
    height: 100%;
    min-height: 450px;
    align-items: center;
    justify-items: center;
    justify-self: center;
    align-self: center;
    border-radius: 10px;
  }
  
  .btns button {
    border: none;
    outline: none;
    margin: 5px 0;
    padding: 0.6vw 0;
    width: 70%;
    height: 70%;
    font-size: 1.5em;
    cursor: pointer;
    background-color: #8263A8;
    color: white;
    font-family: 'poppins', sans-serif;
    font-weight: 600;
    transition: 0.2s ease;
    margin-left: 10px;
  }

  .btns button:hover{
    background-color: #5f487c;
  }
</style>