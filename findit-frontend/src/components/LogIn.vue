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
        <a href="/signUp" class="auth-link">Registrarme</a>
        <a href="/home" class="auth-link">Continuar sin cuenta</a>
      </nav>
      <ModalComponent
        :isVisible="isModalVisible"
        :title="modalTitle"
        @close="isModalVisible = false"
      >
        <template #body>
          <p>{{ modalMessage }}</p>
        </template>
      </ModalComponent>
    </main>
  </div>
</template>

<script>
import axios from "axios";
import ModalComponent from './ModalComponent.vue';
import bcrypt from 'bcryptjs';

export default {
  name: 'LoginComponent',
  components: {
    ModalComponent,
  },
  data() {
      return {
        modalTitle: '',
        modalMessage: '',
        isModalVisible: false,
      };
    },
  methods: {
    async handleSubmit() {
      // Get input data:
      const email = document.getElementById("email").value;
      const salt = '$2b$10$eImiTXuWVyfVz1uFyyf065'
			const password = bcrypt.hashSync(document.getElementById("password").value, salt);
      // Send to backend:
      axios.post("https://localhost:7262/api/User", { email, password })
        .then((response) => {
          // Process response:
          const data = response.data;
          if (data.message === "NoUser") {
            this.modalTitle = "Error de inicio de sesión";
            this.modalMessage = "El correo ingresado no está asociado a ninguna cuenta.";
            this.isModalVisible = true;
          }
          else if (data.message === "Ban") {
            this.modalTitle = "Error de inicio de sesión";
            this.modalMessage = "Esta cuenta se encuentra deshabilitada.";
            this.isModalVisible = true;
          }
          else if (data.message === "NotVer") {
            this.modalTitle = "Error de inicio de sesión";
            this.modalMessage = "El correo asociado a la cuenta con la desea ingresar aún no ha sido verificado.";
            this.isModalVisible = true;
          }
          else if (data.message === "NotPass") {
            this.modalTitle = "Error de inicio de sesión";
            this.modalMessage = "La contraseña ingresada no es correcta.";
            this.isModalVisible = true;
          }
          else if (data.message === "Allow") {
            // Store log in token:
            localStorage.setItem('token', data.token);
            // Go to home menu:
            this.$router.push("/company/register");
          }
        })
        .catch((error) => {
          console.error("Error al enviar la solicitud:", error);
        });
    }
  }
}
</script>


<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');

.login-page {
  background-color: #fff;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  position: relative;
  overflow: hidden;
  padding: 0 20px 40px 0;
  transform: translateY(-10px)
}

.header {
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  width: 100%;
  height: 288px;
  margin: 0 auto;
  gap: 20px;
  padding-left: 20px;
}

.logo-container {
  display: flex;
  height: 124.8px;
  justify-content: center;
  padding-right: 25px;
}

.logo-text {
  color: #000;
  text-align: center;
  font-feature-settings: 'liga' off, 'clig' off;
  font-family: Montserrat;
  font-size: 96px;
  font-style: normal;
  font-weight: 600;
  line-height: 130%;
  margin: 40px 0 0 0;
}

.image-container {
  position: absolute;
  right: 300px;
  display: flex;
  justify-content: flex-end;
  width: 246px;
  height: 288px;
  flex-shrink: 0;
}

.logo-image {
  aspect-ratio: 0.85;
  object-fit: contain;
  object-position: center;
  width: 246px;
  max-width: 200px;
  height: 288px;
}

.main-content {
  border-radius: 36px;
  background: var(--Secondary-Background, #e3ddec);
  box-shadow: 0 4px 4px 0 rgba(0, 0, 0, 0.25);
  width: 552px;
  height: 524;
  max-width: 100%;
  padding: 72px 39px 15px;
}

.login-form {
  display: flex;
  flex-direction: column;
}

.form-label {
  display: flex;
  width: 212px;
  height: 34px;
  flex-direction: column;
  justify-content: center;
  flex-shrink: 0;
  color: #000;
  font-feature-settings: 'liga' off, 'clig' off;
  font-family: Montserrat;
  font-size: 20px;
  font-style: normal;
  font-weight: 500;
  line-height: 26px;
}

.form-input {
  font-size: 20px;
  border-radius: 20px;
  background-color: #fff;
  height: 57px;
  margin-bottom: 62px;
  border: none;
  padding: 20px;
}

.submit-button {
  display:inline-flex;
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
  font-feature-settings: 'liga' off, 'clig' off;
  font-family: Montserrat;
  padding: 18.5px 36px 18.5px 37px;
  justify-content: center;
  align-items: center;
  border: none;
  cursor: pointer;
}

.auth-nav {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.auth-link {
  display: flex;
  width: 212px;
  height: 34px;
  flex-direction: column;
  justify-content: center;
  flex-shrink: 0;
  text-decoration: none;
  color: #000;
  text-align: center;
  font-feature-settings: 'liga' off, 'clig' off;
  font-family: Montserrat;
  font-size: 18px;
  font-style: normal;
  font-weight: 500;
  line-height: 130%;
  text-decoration-line: underline;
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