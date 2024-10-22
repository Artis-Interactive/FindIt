<template>
	<div class="header-container">
		<h1 class="text-center">Find It!</h1>
		<div class="image-container">
			<img loading="lazy" src="https://cdn.builder.io/api/v1/image/assets/TEMP/b9ce2ece67c8fb0de62d5843afb86d04349a5358848c169eb76f6b945b456c7f?placeholderIfAbsent=true&apiKey=6ec5dbc4b236439ba7ab2d7565d1deca" class="logo-image" alt="Find It! logo" />
		</div>
	</div>
	<div class="d-flex justify-content-center align-items-center flex-column">
		<div class="background-box">
			<div class="form-container">
				<form @submit.prevent="handleSubmit">
					<div class="complete-name">
						<div class="form-group">
							<label for="name">Nombre:<span class="required-asterisk">*</span></label>
							<input type="text"
											id="name"
											v-model="form.name"
											required
											maxlength="50"
											placeholder="Juan"
											pattern="[A-Za-zÀ-ÿ\s]+"
											title="Nombre sólo debe contener letras." />
						</div>

						<div class="form-group">
							<label for="lastNames">Apellidos:<span class="required-asterisk">*</span></label>
							<input type="text"
											id="lastNames"
											v-model="form.LastNames"
											required
											maxlength="100"
											placeholder="Ramírez Ortega"
											pattern="[A-Za-zÀ-ÿ\s]+"
											title="Los apellidos sólo deben contener letras." />
						</div>
					</div>

					<div>
						<label for="email">Email:<span class="required-asterisk">*</span></label>
						<input type="email"
										id="email"
										v-model="form.email"
										pattern="[A-Za-z0-9@.]+"
										required
										placeholder="juan.ortega@xxxx.xxxx" />
					</div>

					<div>
						<label for="legalID">Cédula:<span class="required-asterisk">*</span></label>
						<input type="legalID"
										id="legalID"
										v-model="form.legalID"
										minlength="9"
										maxlength="15"
										required
										pattern="\d+"
										placeholder="123456789"
										title="La cédula sólo debe tener números." />
					</div>

					<div>
						<label for="PhoneNumber">Teléfono:<span class="required-asterisk">*</span></label>
						<input type="tel"
										id="PhoneNumber"
										v-model="form.PhoneNumber"
										required
										maxlength="8"
										placeholder="XXXXXXXX" 
										pattern="\d{8}" 
										title="El teléfono sólo debe tener números" />
					</div>

					<div>
						<label for="birthdate">Fecha de Nacimiento:<span class="required-asterisk">*</span></label>
						<input type="date"
										id="birthdate"
										v-model="form.birthdate"
										:max="currentDate"
										min="1924-01-01"
										required />
					</div>

					<div class="radio-group">
						<h3>Dirección:<span class="required-asterisk">*</span></h3>
						<label>
							<input type="radio"
											name="direction"
											value="manual"
											v-model="selectedDirection" />
											Manual
						</label>

						<label>
							<input type="radio"
											name="direction"
											value="map"
											v-model="selectedDirection" />
											Marcar en mapa
						</label>
					</div>

					<!-- Aditional spaces if manual is selected -->
					<div v-if="selectedDirection === 'manual'">
						<div>
							<label for="province">Provincia:</label>
							<select v-model="form.province"
											id="province"
											required
											class="form-control custom-select">
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

						<div>
							<label for="canton">Cantón:</label>
							<input type="text"
											id="canton"
											v-model="form.canton"
											placeholder="Montes de Oca"
											required
											pattern="[A-Za-zÀ-ÿ\s]+" 
											title="El cantón sólo debe tener números"/>
						</div>

						<div>
							<label for="district">Distrito:</label>
							<input type="text"
											id="district"
											v-model="form.district"
											placeholder="San Pedro"
											required
											pattern="[A-Za-zÀ-ÿ\s]+" 
											title="El distrito sólo debe tener letras."/>
						</div>

						<div>
							<label for="details">Otras señas:</label>
							<input type="text"
											id="details"
											v-model="form.details"
											placeholder="De la Iglesia de San Pedro 200 metros al sur"
											required
											pattern="[A-Za-zÀ-ÿ0-9\s\.\-,#]+" />
						</div>

					</div>

					<div class="radio-group">
						<h3>Método de pago:<span class="required-asterisk">*</span></h3>
						<label>
							<input type="radio"
											name="paymentMethod"
											value="card"
											v-model="selectedPaymentMethod" />
							Tarjeta
						</label>

						<label>
							<input type="radio"
											name="paymentMethod"
											value="sinpe"
											v-model="selectedPaymentMethod" />
							SINPE
						</label>
					</div>

					<!-- Aditional spaces if card is selected -->
					<div v-if="selectedPaymentMethod === 'card'">
						<div>
							<label for="nameOnCard">Nombre:</label>
							<input type="text"
											id="nameOnCard"
											v-model="form.nameOnCard"
											placeholder="Juan Ramirez M"
											maxlength="100"
											required
											pattern="[A-Za-z\s]+" />
						</div>

						<div>
							<label for="cardNumber">Número de tarjeta:</label>
							<input type="text"
											id="cardNumber"
											v-model="form.cardNumber"
											placeholder="1111222233334444"
											maxlength="16"
											minlength="16"
											pattern="\d{16}"
											required />
						</div>

						<div>
							<label for="cvv">CVV:</label>
							<input type="text"
											id="cvv"
											v-model="form.cvv"
											required
											maxlength="3"
											placeholder="123"
											pattern="\d{3}" />
						</div>

						<div>
							<label for="expirationDate">Fecha de Expiración:</label>
							<input type="date"
											id="expirationDate"
											v-model="form.expirationDate"
											:max="maxDate"
											:min="minDate"
											required />
						</div>
					</div>

					<div>
						<label for="password">Contraseña:<span class="required-asterisk">*</span></label>
						<input type="password"
										id="password"
										v-model="form.password"
										required
										minlength="10"
										maxlength="20"
										placeholder="La contraseña debe ser entre 10 y 20 caracteres."
										pattern="(?=.*[A-Za-z])(?=.*\d)(?=.*[$!%&*?])[A-Za-z\d$!%&*?]+" />
										<small class="small-text">La contraseña debe contener al menos una letra, un número y un caracter especial ($, !, %, &, *, ?).</small>
					</div>

					<div>
              <label for="confirmPassword">Confirmar contraseña:<span class="required-asterisk">*</span></label>
              <input type="password"
                     id="confirmPassword"
                     v-model="form.confirmPassword"
                     required
                     minlength="10"
                     maxlength="20"
                     placeholder="Reingrese la contraseña para confirmar." />
            </div>
					<div class="button-container">
						<button type="submit">Registrarme</button>
					</div>
					<span class="required-text">* Campos requeridos</span>
					
					
				</form>
			</div>
			<ModalComponent
        :isVisible="isModalVisible"
        :title="modalTitle"
        @close="isModalVisible = false"
      >
        <template #body>
          <p>{{ modalMessage }}</p>
        </template>
      </ModalComponent>
		</div>
	</div>

</template>

<script>
	import ModalComponent from './ModalComponent.vue';
	import bcrypt from 'bcryptjs';
	import axios from 'axios';
	import { BACKEND_URL, HOSTED_URL } from '@/config';

	export default {
		name: 'SignUpComponent',
		components: {
			ModalComponent,
		},
		data() {
			return {
				modalTitle: '',
				modalMessage: '',
				isModalVisible: false,
				form: {
					name: "",
					lastNames: "",
					birthdate: "",
					legalID: "",
					email: "",
					PhoneNumber: "",
					password: "",
				},
				submitted: false,
				currentDate: new Date().toISOString().split('T')[0],
				selectedDirection: "",
				selectedPaymentMethod: ""
			};
		},
		methods: {
			async handleSubmit() {
				if (!this.validatePassword()) {
					return;
				}
				try {
					const emailAndLegalIDValid = await this.emailAndLegalIDExists(this.form.email, this.form.legalID)
					if (!emailAndLegalIDValid) {
						return;
					}
					await this.registerUser();

					if (this.selectedDirection === 'manual') {
						await this.registerAddress(this.form.legalID);
					}

					if (this.selectedPaymentMethod === 'card') {
						await this.registerCardInfo(this.form.legalID);
					}
					this.modalTitle = "Usuario registrado";
					this.modalMessage = "El usuario fue registrado exitosamente. ¡Por favor revisa tu bandeja de entrada para verificar tu cuenta!";
					this.isModalVisible = true;
					window.location.href = `/`;

			} catch(error) {
					console.log("Error al registrar usuario: ", error);
					this.modalTitle = "Error en el registro";
					this.modalMessage = error.response?.data || "Ocurrió un error durante el registro.";
					this.isModalVisible = true;
				}
			},
			validatePassword() {
				if (this.form.password !== this.form.confirmPassword) {
					this.modalTitle = "Error de contraseña";
					this.modalMessage = "Las contraseñas no coinciden.";
					this.isModalVisible = true;
					return false;
				}
				return true;
			},
			async emailAndLegalIDExists(email, legalID) {
				try{
					await axios.get(`${BACKEND_URL}/UserDataSignUp/GetUserByEmail/${encodeURIComponent(email)}`);
					
					await axios.get(`${BACKEND_URL}/UserDataSignUp/LegalID/${legalID}`);
					
					return true;
				}
				catch(error) {
					if (error.config.url.includes('Email')) {
						this.modalTitle = "Error de registro";
						this.modalMessage = "El correo ya se encuentra registrado.";
						this.isModalVisible = true;
					} else if (error.config.url.includes('LegalID')) {
						this.modalTitle = "Error de registro";
						this.modalMessage = "La cédula ya se encuentra registrada.";
						this.isModalVisible = true;
					} else {
						this.modalTitle = "Error de registro";
						this.modalMessage = "Ocurrió un error durante el registro.";
						this.isModalVisible = true;
					}
					this.isModalVisible = true;
					return false;
				}
			},
			async registerUser() {
				
				const salt = '$2b$10$eImiTXuWVyfVz1uFyyf065'
				const hash = bcrypt.hashSync(this.form.password, salt);
				try {
					await axios.post(`${BACKEND_URL}/UserDataSignUp`,  {
						name: this.form.name,
						LastNames: this.form.LastNames,
						birthdate: this.form.birthdate,
						legalID: this.form.legalID,
						email: this.form.email,
						PhoneNumber: this.form.PhoneNumber,
						password: hash,
					});

					await axios.post(`${BACKEND_URL}/EmailNotification/send`,  {
						to: this.form.email,
						subject: "Verificación de correo electrónico",
						body: `Ingresa a la siguiente dirección url para verificar tu cuenta de FindIt: ${HOSTED_URL}/email-verification/${this.form.email}`,
					});
				} catch (error) {
					throw new Error("Error al registrar usuario."+ (error.response?.data || error.message));
				}
			},
			async registerAddress(legalID) {
				try {
					await axios.post(`${BACKEND_URL}/Address/AddAddress?legalId=${legalID}`, {
						province: this.form.province,
						canton: this.form.canton,
						district: this.form.district,
						details: this.form.details
					});
				} catch (error) {
					throw new Error("Error al registrar dirección."+ (error.response?.data || error.message));
				}
			},
			async registerCardInfo(legalID) {
				try {
					await axios.post(`${BACKEND_URL}/Card?legalId=${legalID}`, {
						cardNumber: this.form.cardNumber,
						nameOnCard: this.form.nameOnCard,
						expirationDate: this.form.expirationDate
					});
				} catch (error) {
					throw new Error("Error al registrar tarjeta."+ (error.response?.data || error.message));
				}
			}
		},
		computed: {
			minDate() {
				return this.currentDate;
			},
			maxDate() {
				const maxDate = new Date();
				maxDate.setFullYear(maxDate.getFullYear() + 5);
				return maxDate.toISOString().split('T')[0];
			}
		}
	};
</script>

<style scoped>
	@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');

	.header-container {
		display: flex;
		align-items: center;
		justify-content: center;
	}

	.image-container {
		position: absolute;
		top: 0px;
		right: 200px;
		display: flex;
		justify-content: flex-end;
		width: 246px;
		height: 288px;
		flex-shrink: 0;
	}

	.d-flex {
    display: flex;
  }

	.required-asterisk {
    color: red;
    margin-left: 5px;
	}	

	.form-container {
		display: flex;
		max-width: 600px;
		margin: 0 auto;
		padding: 20px;
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
		margin-bottom: 15px;
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
		margin-bottom: 15px;
	}

	input {
		font-family: 'Montserrat', sans-serif;
		width: 100%;
		height: 33px;
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
		align-items: center;
		position: relative;
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
	
	.required-text {
		margin-left: 10px;
		margin-bottom: -50px;
		padding: 0px;
		padding-bottom: 0px;
		color: red;
		text-align: right;
		font-weight: bold;
	}

	.required-text-inline {
		position: absolute;
		top: -20px;
		margin-left: 10px;
		color: red;
		font-weight: bold;
}

</style>