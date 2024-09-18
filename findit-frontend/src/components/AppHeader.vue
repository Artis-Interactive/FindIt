<template>
  <header class="header">
    <a href="https://www.amazon.com" class="logo-link">Find It!</a>
      <form class="search-form" @submit.prevent>
        <label for="search-input" class="visually-hidden">Buscar</label>
        <input type="text" id="search-input" class="search-input" placeholder="Buscar" aria-label="Buscar">
        <button type="submit" class="search-button" aria-label="Iniciar búsqueda">
          <img src="https://cdn.builder.io/api/v1/image/assets/TEMP/65b76f8685b87fca694b268512b8f8fde853f5d9645cc50ac7c7cc415e147f7d?placeholderIfAbsent=true&apiKey=08942a56d4504ffdbe772eb802c3751e" alt="" class="search-icon" />
        </button>
      </form>
      <nav class="main-nav">
        <ul class="nav-list">
          <li><a href="#" class="nav-link">Inicio</a></li>
          <li><a href="#" class="nav-link">Empresa</a></li>
          <li><a href="#" class="nav-link">Mi perfil</a></li>
        </ul>
      </nav>
    <button class="cart-button">Carrito ({{ cartItemCount }})</button>
  </header>
</template>
  
<script>
  export default {
    data() {
      return {
        cartItemCount: 0
      }
    },
  }
</script>

<style scoped>
  .header {
    background: var(--Secondary-Background, #e3ddec);
    display: flex;
    align-items: center;
    gap: 40px 43px;
    color: #000;
    flex-wrap: wrap;
    padding: 23px 31px;
    font: 600 24px/1.3 Montserrat, sans-serif;
    justify-content: space-between;
  }
  
  .logo-link {
    font-size: 48px;
    font-family: 600;
    color: inherit;
    text-decoration: none;
    font: montserrat;
    background: none;
    border: none;
    cursor: pointer;
    padding: 0;
  }
  
  .search-form {
    border-radius: 20px;
    background-color: #fff;
    align-self: stretch;
    display: flex;
    gap: 40px 100px;
    color: rgba(0, 0, 0, 0.7);
    font-weight: 400;
    white-space: nowrap;
    flex-wrap: wrap;
    margin: auto 0;
    padding: 11px 19px;
    border: 1px solid #000;
  }
  
  .search-input {
    border: none;
    outline: none;
    font-size: inherit;
    font-family: inherit;
    width: 1000px;
  }
  
  .search-button {
    background: none;
    border: none;
    cursor: pointer;
    padding: 0;
  }
  
  .search-icon {
    aspect-ratio: 1;
    object-fit: contain;
    object-position: right;
    width: 35px;
  }
  
  .main-nav {
    align-self: stretch;
    margin: auto 0;
  }
  
  .nav-list {
    list-style-type: none;
    padding: 0;
    margin: 0;
    display: flex;
    gap: 40px;
  }
  
  .nav-link {
    text-decoration: none;
    color: inherit;
  }
  
  .cart-button {
    font-feature-settings: "liga" off, "clig" off;
    border-radius: 10px;
    background: var(--buttons-primary, #8263a8);
    align-self: stretch;
    overflow: hidden;
    font-size: 22px;
    color: var(--background, #fbfbfe);
    text-align: center;
    padding: 19px 25px;
    border: none;
    cursor: pointer;
  }
  
  .visually-hidden {
    position: absolute;
    width: 1px;
    height: 1px;
    padding: 0;
    margin: -1px;
    overflow: hidden;
    clip: rect(0, 0, 0, 0);
    white-space: nowrap;
    border: 0;
  }
  
  @media (max-width: 991px) {
    .header {
      padding: 0 20px;
    }
  
    .logo {
      font-size: 40px;
    }
  
    .search-form {
      max-width: 100%;
      padding-left: 20px;
      white-space: initial;
    }
  
    .cart-button {
      padding: 19px 20px;
    }
  }
</style>