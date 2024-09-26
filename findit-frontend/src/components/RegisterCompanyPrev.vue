<template>
  <div class="container">
    <div class="grid-container">
      <header class="header"><AppHeader/></header>
      <div class="main">
        <h1 style="font-weight: 530;">
            Comienza tu camino al éxito. <br>
            Registra tu empresa y lleva tus productos al siguiente nivel.
        </h1>
        <button class="register-button" @click="handleRegister">Regístrate</button>
      </div>
    </div>
  </div>
</template>

<script>
  import AppHeader from './AppHeader.vue';
  export default {
    components: {
      AppHeader,
    },
  }
</script>

<style>
  html, body {
    margin: 0;
    padding: 0;
    width: 100%;
    height: 100%;
  }
</style>

<style scoped>
  html, body {
    margin: 0;
    padding: 0;
    width: 100%;
    height: 100%;
  }

  .container {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100vw;  
    height: 100vh; 
  }

  .grid-container {
    display: grid;
    width: 100%;  
    height: 100%; 
    grid-template:
      "header header header" 73px
      "main main main" 1fr;
  }

  .grid-container > * {
    text-align: center;
    height: 100%;
  }

  .header {
    grid-area: header;
  }

  .main {
    grid-area: main;
    font-family: montserrat;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 35px;
  }

  .register-button {
    font: 500 26px/1.3 Montserrat, sans-serif;
    padding: 20px 35px;
    border-radius: 10px;
    background: var(--buttons-primary, #8263a8);
    color: var(--background, #fbfbfe);
    text-align: center;
    white-space: nowrap;
    overflow: hidden;
    border: none;
    cursor: pointer;
    transition: background-color 0.3s ease;
  }

  .register-button:hover {
    background-color: var(--buttons-primary-hover, #6f4e94);
  } 

  @media (max-width: 768px) {
    .main h1 {
      font-size: 20px;
      text-align: center; 
    }

    .register-button {
      font-size: 18px;
      padding: 12px 20px;
    }
  }

  @media (max-width: 480px) {
    .main h1 {
      font-size: 16px;
      padding: 0 10px; 
    }

    .register-button {
      font-size: 16px;
      width: 100%; 
      padding: 10px; 
    }
  }

  @media (max-width: 375px) {
    .main h1 {
      font-size: 18px;
    }

    .register-button {
      font-size: 16px;
      padding: 10px;
    }
  }

  @media (max-width: 320px) {
    .main h1 {
      font-size: 14px;
    }

    .register-button {
      font-size: 14px;
      padding: 8px;
    }
  }
</style>
