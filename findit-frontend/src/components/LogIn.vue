<template>
  <div class="login-page">
    <header class="header">
      <div class="logo-container">
        <h1 class="logo-text">Find It!</h1>
      </div>
      <div class="image-container">
        <img loading="lazy" src="https://cdn.builder.io/api/v1/image/assets/TEMP/b9ce2ece67c8fb0de62d5843afb86d04349a5358848c169eb76f6b945b456c7f?placeholderIfAbsent=true&apiKey=6ec5dbc4b236439ba7ab2d7565d1deca" class="logo-image" alt="Find It! logo" />
      </div>
    </header>
    <main class="main-content">
      <form class="login-form" @submit.prevent="handleSubmit">
        <label for="email" class="form-label">Correo electrónico:</label>
        <input type="email" id="email" class="form-input" required />
        
        <label for="password" class="form-label">Contraseña:</label>
        <input type="password" id="password" class="form-input" required />
        
        <button type="submit" class="submit-button">Iniciar Sesión</button>
      </form>
      <nav class="auth-nav">
        <a href="#" class="auth-link">Registrarme</a>
        <a href="#" class="auth-link">Ingresar sin cuenta</a>
      </nav>
    </main>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: 'Login',
  methods: {
    async handleSubmit() {
     
    }
  }
}
</script>


<style scoped>
.login-page {
  background-color: #fff;
  display: flex;
  flex-direction: column;
  overflow: hidden;
  position: fixed;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
}

.header {
  align-self: flex-end;
  width: 723px;
  max-width: 100%;
  display: flex;
  gap: 20px;
}

.logo-container {
  width: 57%;
}

.logo-text {
  color: #000;
  text-align: center;
  margin-top: 166px;
  font: 600 96px/1.3 Montserrat, sans-serif;
}

.image-container {
  width: 43%;
}

.logo-image {
  aspect-ratio: 0.85;
  object-fit: contain;
  object-position: center;
  width: 100%;
  max-width: 200px;
  height: auto;
}

.main-content {
  border-radius: 36px;
  background: var(--Secondary-Background, #e3ddec);
  box-shadow: 0 4px 4px 0 rgba(0, 0, 0, 0.25);
  width: 552px;
  max-width: 100%;
  padding: 72px 39px 15px;
  margin-bottom: 200px;
  font: 500 20px/1.3 Montserrat, sans-serif;
}

.login-form {
  display: flex;
  flex-direction: column;
}

.form-label {
  align-self: flex-start;
  margin-bottom: 22px;
}

.form-input {
  font-size: 24px;
  border-radius: 20px;
  background-color: #fff;
  height: 57px;
  margin-bottom: 67px;
}

.submit-button {
  font-feature-settings: "liga" off, "clig" off;
  border-radius: 10px;
  background: var(--buttons-primary, #8263a8);
  align-self: center;
  width: 224px;
  max-width: 100%;
  overflow: hidden;
  font-size: 22px;
  color: var(--background, #fbfbfe);
  font-weight: 600;
  text-align: center;
  padding: 19px 37px;
  border: none;
  cursor: pointer;
}

.auth-nav {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 14px;
}

.auth-link {
  font-size: 18px;
  text-align: center;
  margin-top: 16px;
  text-decoration: none;
  color: #000;
}

@media (max-width: 991px) {
  .login-page {
    padding: 0 20px 100px;
  }

  .header {
    flex-direction: column;
    align-items: stretch;
    gap: 0;
  }

  .logo-container,
  .image-container {
    width: 100%;
  }

  .logo-text {
    margin-top: 40px;
    font-size: 40px;
  }

  .logo-image {
    margin-top: 40px;
  }

  .main-content {
    padding: 40px 20px;
  }

  .form-input {
    margin-bottom: 40px;
  }

  .submit-button {
    margin-top: 40px;
    padding: 15px 20px;
  }
}
</style>