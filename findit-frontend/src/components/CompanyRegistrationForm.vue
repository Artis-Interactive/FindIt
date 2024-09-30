<template>
  <h1 class="text-center">Find It!</h1>
  <div class="d-flex justify-content-center align-items-center flex-column">
    <div class="background-box">
      <div class="form-container">
        <form @submit.prevent="handleSubmit">
          <div>
            <label for="companyName">Nombre de Empresa:</label>
            <input type="text" id="companyName" v-model="formData.companyName" pattern="[A-Za-z0-9@.]+" required
              placeholder="Tu Empresa" />
          </div>
          <div>
            <label for="companyEmail">Email de Empresa:</label>
            <input type="email" id="companyEmail" v-model="formData.companyEmail" pattern="[A-Za-z0-9@.]+" required
              placeholder="correo@tuempresa.com" />
          </div>
          <div>
            <label for="phone">Teléfono:</label>
            <input type="tel" id="phone" v-model="formData.phoneNumber" required maxlength="8" placeholder="XXXXXXXX"
              pattern="\d{8}" title="El teléfono sólo debe tener números" />
          </div>
          <div>
            <label for="legalID">Cédula:</label>
            <input type="legalID" id="legalID" v-model="formData.idNumber" minlength="9" maxlength="15" required
              pattern="\d+" placeholder="123456789" title="La cédula sólo debe tener números." />
          </div>
          <div class="radio-group">
            <label>
              <input type="radio" name="direction" value="manual" v-model="formData.addressType" required />
              Fisica
            </label>
            <label>
              <input type="radio" name="direction" value="map" v-model="formData.addressType" required />
              Juridica
            </label>
          </div>
          <div>
            <label for="description">Que planeas vender:</label>
            <textarea type="text" id="description" v-model="formData.description"
              placeholder="Utiliza este espacio para describir que tipos de productos planeas vender..." required pattern="[A-Za-zÀ-ÿ0-9\s\.\-,#]+"></textarea>
          </div>


          <!-- Aditional spaces if manual address is selected -->
          <!--<div v-if="formData.addressType === 'manual'">
            <div class="row">
              <div class="column-3">
                <div>
                  <label for="addressProvince">Provincia:</label>
                  <select v-model="formData.addressProvince" id="addressProvince" required class="form-control custom-select">
                    <option value="" disabled>Seleccione una provincia</option>
                    <option>Alajuela</option>
                    <option>Cartago</option>
                    <option>Guanacaste</option>
                    <option>Heredia</option>
                    <option>Limón</option>
                    <option>San José</option>
                    <option>Puntarenas</option>
                  </select>
                </div>
              </div>

              <div class="column-3">
                <div>
                  <label for="addressCanton">Cantón:</label>
                  <input type="text" id="addressCanton" v-model="formData.addressCanton" placeholder="Montes de Oca" required
                    pattern="[A-Za-zÀ-ÿ\s]+" title="El cantón sólo debe tener letras" />
                </div>
              </div>

              <div class="column-3">
                <div>
                  <label for="addressDistrict">Cantón:</label>
                  <input type="text" id="addressDistrict" v-model="formData.addressDistrict" placeholder="San Pedro" required
                    pattern="[A-Za-zÀ-ÿ\s]+" title="El distrito sólo debe tener letras" />
                </div>
              </div>

            </div>
            <div>
              <label for="addressAdditionalDetails">Otras señas:</label>
              <textarea type="text" id="addressAditionalDetails" v-model="formData.addressAdditionalDetails"
                placeholder="De la Iglesia de San Pedro 200 metros al sur" required pattern="[A-Za-zÀ-ÿ0-9\s\.\-,#]+" ></textarea>
            </div>
          </div>-->

          <!-- Aditional spaces if map address is selected -->
          <div v-if="formData.addressType === 'map'">
            <div>
              <!-- Map Selection Component -->
            </div>
          </div>

          <div class="button-container">
            <button type="submit">Registrar Empresa</button>
          </div>
        </form>
      </div>
    </div>
  </div>

</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      formData: {
        companyName: "",
        companyEmail: "",
        phoneNumber: "",
        description: "",
        legalIdType: "",
        legalId: "",
        logo: "",
        heroImage: "",
      },
    };
  },
  methods: {
    handleSubmit() {
      console.log("Datos: ", this.formData);
      this.registerCompany();
    },

    registerCompany() {
				axios.post("https://localhost:7150/api/RegisterCompany",  {
						Name: this.formData.companyName,
            Email: this.formData.companyEmail,
						PhoneNumber: this.formData.phoneNumber,
						Description: this.form.description,
            Type: this.formData.legalIdType,
						LegalID: this.form.legalId,
					})
				.then(function (response) {
					alert ('Empresa registrada con éxito.');
					console.log(response);
					window.location.href = "/";
				})
				.catch(error => {
					console.log(error);
				});
			}
  }
}
</script>

<style scoped>
	@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');

  .column-2 {
    float: left;
    width: 50%;
    padding: 5px;
  }

  .column-3 {
    float: left;
    width: 33%;
    padding: 5px;
  }

  /* Clear floats after the columns */
  .row:after {
    content: "";
    display: table;
    clear: both;
  }

	.d-flex {
    display: flex;
  }

	.form-container {
    width: 600px;
		max-width: 750px;
		margin: 0 auto;
		padding: 15px;
		font-family: 'Montserrat', sans-serif;
	}

	.flex-column {
    flex-direction: column;
  }

	.background-box {
		padding: 10px;
    margin: 0 auto;
		border-radius: 36px;
		background: var(--Secondary-Background, #E3DDEC);
		box-shadow: 0px 4px 4px 0px rgba(0, 0, 0, 0.25);
	}

	form div {
		margin-bottom: 5px;
	}

	label {
		font-style: normal;
		font-weight: 500;
		display: block;
		margin-bottom: 5px;
	}

	.text-center {
    text-align: center;
	}

	h1 {
		font-family: 'Montserrat', sans-serif;
		font-size: 65px;
		font-weight: 600;
		gap: 20px;
		margin-bottom: 10px;
		margin-top: 20px;
	}

	h3 {
		font-family: 'Montserrat', sans-serif;
		font-size: 17px;
		font-weight: 500;
		margin-right: 20px;
	}

	.name-apellidos-container {
		display: flex;
		gap: 20px;
		width: 100%;
  }

	.form-group {
		flex: 1;
		display: flex;
		flex-direction: column;
		min-width: 0;
		margin-bottom: 0;
	}

	.form-group input {
		width: 100%;
		margin-bottom: 5px;
	}

  .form-group textarea {
		width: 100%;
		margin-bottom: 5px;
	}

	input {
		font-family: 'Montserrat', sans-serif;
		width: 100%;
		height: 35px;
		border-radius: 10px;
		padding: 8px;
		box-sizing: border-box;
		border: none;
	}

  textarea {
		font-family: 'Montserrat', sans-serif;
		width: 100%;
		height: 70px;
		border-radius: 10px;
		padding: 8px;
		box-sizing: border-box;
		border: none;
	}

	.radio-group {
		display: flex;
		gap: 15px;
	}

  .radio-group label {
    display: flex;
    align-items: center;
    white-space: nowrap;
  }

  .radio-group input[type="radio"]:checked + span {
    background-color: #8263A8;
  }

	.custom-select {
    font-family: 'Montserrat', sans-serif;
		width: 100%;
		height: 35px;
		border-radius: 10px;
		padding: 8px;
		box-sizing: border-box;
		border: none;
    font-size: 13px; 
    color: #333; 
	}

  .custom-select option {
    font-family: 'Montserrat', sans-serif;
    font-size: 13px;
    color: #333;
  }

	.expiry-date {
		display: flex;
		align-items: center;
	}

		.expiry-date input {
			width: 50px;
			text-align: center;
		}
	
	.small-text {
		font-size: 11px; 
		color: #666; 
	}

	.side-image {
    width: 300px;
    height: auto;
  }

	.button-container {
    display: flex;
    justify-content: center;
		margin-bottom: 0px;
  }

	button {
		font-family: 'Montserrat', sans-serif;
		padding: 15px;
		border-radius: 10px;
		background-color: #8263A8;
		color: white;
		border: none;
		cursor: pointer;
	}

  button:hover {
    background-color: #634a83;
  }
</style>