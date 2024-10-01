<template>
  <header class="header">
    <a href="/home" class="logo-link">Find It!</a>
      <form class="search-form" @submit.prevent>
        <label for="search-input" class="visually-hidden">Buscar</label>
        <input type="text" id="search-input" class="search-input" placeholder="Buscar" aria-label="Buscar">
        <button type="submit" class="search-button" aria-label="Iniciar búsqueda">
          <img src="https://cdn.builder.io/api/v1/image/assets/TEMP/65b76f8685b87fca694b268512b8f8fde853f5d9645cc50ac7c7cc415e147f7d?placeholderIfAbsent=true&apiKey=08942a56d4504ffdbe772eb802c3751e" alt="" class="search-icon" />
        </button>
      </form>
      <nav class="main-nav">
        <ul class="nav-list">
          <li><a href="/home" class="nav-link">Inicio</a></li>
          <li><a href="/company" class="nav-link">Empresa</a></li>
          <li><a href="/profile" class="nav-link">Mi perfil</a></li>
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
    gap: 20px;
    color: #000;
    flex-wrap: wrap;
    padding: 10px 20px;
    font: 600 24px/1.3 Montserrat, sans-serif;
    justify-content: space-between;
    position: relative;
  }
  
  .logo-link {
    font-size: 40px;
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
    gap: 20px;
    color: rgba(0, 0, 0, 0.7);
    font-weight: 400;
    white-space: nowrap;
    flex-wrap: wrap;
    margin: auto 0;
    padding: 5px 10px;
    border: 1px solid #000;
  }
  
  .search-input {
    border: none;
    outline: none;
    font-size: 20px;
    font-family: inherit;
    width: 800px;
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
    gap: 20px;
  }
  
  .nav-link {
    text-decoration: none;
    color: inherit;
    font-size: 20px;
  }
  
  .cart-button {
    font-feature-settings: "liga" off, "clig" off;
    border-radius: 10px;
    background: var(--buttons-primary, #8263a8);
    align-self: stretch;
    overflow: hidden;
    font-size: 20px;
    color: var(--background, #fbfbfe);
    text-align: center;
    padding: 15px 20px;
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
  
  @media (max-width: 1524px) {
    .header {
      padding: 6px 10px;
      font: 600 20px/1.3 Montserrat, sans-serif;
    }

    .logo-link {
      font-size: 28px;
    }

    .search-form {
      padding: 3px 6px;
    }

    .search-input {
      font-size: 16px;
      max-width: 150px;
    }

    .search-icon {
      width: 25px;
    }

    .nav-link {
      font-size: 16px;
      padding: 4px 8px;
    }

    .cart-button {
      font-size: 16px;
      padding: 8px 12px;
    }
  }

  @media (max-width: 768px) {
    .header {
      padding: 4px 6px;
      font: 600 16px/1.3 Montserrat, sans-serif;
    }

    .logo-link {
      font-size: 24px;
    }

    .search-form {
      padding: 2px 4px;
    }

    .search-input {
      font-size: 14px;
      max-width: 120px;
    }

    .search-icon {
      width: 22px;
    }

    .nav-link {
      font-size: 14px;
      padding: 2px 4px;
    }

    .cart-button {
      font-size: 14px;
      padding: 6px 10px;
    }
  }

  @media (max-width: 480px) {
    .header {
      padding: 2px 4px;
      font: 600 12px/1.3 Montserrat, sans-serif;
    }

    .logo-link {
      font-size: 18px;
    }

    .search-form {
      padding: 2px 2px;
    }

    .search-input {
      font-size: 10px;
      max-width: 80px;
    }

    .search-icon {
      width: 18px;
    }

    .nav-link {
      font-size: 10px;
      padding: 2px 2px;
    }

    .cart-button {
      font-size: 10px;
      padding: 2px 4px;
    }
  }

  @media (max-width: 360px) {
    .header {
      padding: 1px 2px;
      font: 600 10px/1.3 Montserrat, sans-serif;
    }

    .logo-link {
      font-size: 16px;
    }

    .search-form {
      padding: 1px 2px;
    }

    .search-input {
      font-size: 8px;
      max-width: 60px;
    }

    .search-icon {
      width: 16px;
    }

    .nav-link {
      font-size: 8px;
      padding: 1px 2px;
    }

    .cart-button {
      font-size: 8px;
      padding: 1px 2px;
    }
  }
</style>