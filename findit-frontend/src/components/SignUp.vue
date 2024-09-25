<template>
	<h1 class="text-center">Find It!</h1>
	<div class="d-flex justify-content-center align-items-center flex-column">
		<div class="background-box">
			<div class="form-container">
				<form @submit.prevent="handleSubmit">
					<div class="complete-name">
						<div class="form-group">
							<label for="name">Nombre:</label>
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
							<label for="lastName">Apellidos:</label>
							<input type="text"
											id="lastName"
											v-model="form.LastNames"
											required
											maxlength="100"
											placeholder="Ramírez Ortega"
											pattern="[A-Za-zÀ-ÿ\s]+"
											title="Los apellidos sólo deben contener letras." />
						</div>
					</div>

					<div>
						<label for="email">Email:</label>
						<input type="email"
										id="email"
										v-model="form.email"
										pattern="[A-Za-z0-9@.]+"
										required
										placeholder="juan.ortega@xxxx.xxxx" />
					</div>

					<div>
						<label for="legalID">Cédula:</label>
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
						<label for="phone">Teléfono:</label>
						<input type="tel"
										id="phone"
										v-model="form.PhoneNumber"
										required
										maxlength="8"
										placeholder="XXXXXXXX" 
										pattern="\d{8}" 
										title="El teléfono sólo debe tener números" />
					</div>

					<div>
						<label for="birthdate">Fecha de Nacimiento:</label>
						<input type="date"
										id="birthdate"
										v-model="form.birthdate"
										:max="currentDate"
										min="1924-01-01"
										required />
					</div>

					<div class="radio-group">
						<h3>Dirección:</h3>
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
							<label for="provincia">Provincia:</label>
							<select v-model="form.provincia"
											id="provincia"
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
							<label for="distrito">Distrito:</label>
							<input type="text"
											id="distrito"
											v-model="form.distrito"
											placeholder="San Pedro"
											required
											pattern="[A-Za-zÀ-ÿ\s]+" 
											title="El distrito sólo debe tener letras."/>
						</div>

						<div>
							<label for="signs">Otras señas:</label>
							<input type="text"
											id="signs"
											v-model="form.signs"
											placeholder="De la Iglesia de San Pedro 200 metros al sur"
											required
											pattern="[A-Za-zÀ-ÿ0-9\s\.\-,#]+" />
						</div>

					</div>

					<div class="radio-group">
						<h3>Método de pago:</h3>
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
							<label for="nameCard">Nombre:</label>
							<input type="text"
											id="nameCard"
											v-model="form.nameCard"
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
											@input="formatCardNumber"
											placeholder="1111 2222 3333 4444"
											maxlength="19"
											minlength="19"
											pattern="\d{4} \d{4} \d{4} \d{4}"
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
							<label for="expiraryDate">Fecha de Experación:</label>
							<input type="date"
											id="expiraryDate"
											v-model="form.expiraryDate"
											:max="maxDate"
											:min="minDate"
											required />
						</div>
					</div>

					<div>
						<label for="password">Contraseña:</label>
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
              <label for="confirmPassword">Confirmar Contraseña:</label>
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
				</form>
			</div>
		</div>
	</div>

</template>

<script>
	import bcrypt from 'bcryptjs';
	import axios from 'axios';

	export default {

		data() {
			return {
				form: {
					name: "",
					lastName: "",
					birthdate: "",
					legalID: "",
					email: "",
					phone: "",
					password: "",
				},
				submitted: false,
				currentDate: new Date().toISOString().split('T')[0],
				selectedDirection: "",
				selectedPaymentMethod: ""
			};
		},
		methods: {
			formatCardNumber(event) {
				let input = event.target.value.replace(/\D/g, '');
				this.unformattedCardNumber = input;
				if (input.length > 4) {
						input = input.match(/.{1,4}/g).join(' ');
				}
				event.target.value = input;
				this.form.cardNumber = input;
			},
			handleSubmit() {
				if (!this.validatePassword()) {
					return;
				}
				this.emailAndLegalIDExists(this.form.email, this.form.legalID)
					.then(isValid => {
						if (isValid) {
							this.registerUser();
						}
					})
					.catch(error => {
						console.log(error);
					});
			},
			validatePassword() {
				if (this.form.password !== this.form.confirmPassword) {
					alert('Las contraseñas no coinciden.');
					return false;
				}
				return true;
			},
			async emailAndLegalIDExists(email, legalID) {
				try{
					await axios.get(`https://localhost:7262/api/UserDataSignUp/Email/${encodeURIComponent(email)}`);
					
					await axios.get(`https://localhost:7262/api/UserDataSignUp/LegalID/${legalID}`);
					
					return true;
				}
				catch(error) {
					if (error.config.url.includes('Email')) {
						alert('El correo ya se encuentra registrado.');
					} else if (error.config.url.includes('LegalID')) {
						alert('La cédula ya se encuentra registrada.');
					} else {
						console.log(error);
					}
					return false;
				}
			},
			registerUser() {
				const salt = bcrypt.genSaltSync(10);
				const hash = bcrypt.hashSync(this.form.password, salt);
				this.form.password = hash;
				axios.post("https://localhost:7262/api/UserDataSignUp",  {
						name: this.form.name,
						LastNames: this.form.LastNames,
						birthdate: this.form.birthdate,
						legalID: this.form.legalID,
						email: this.form.email,
						PhoneNumber: this.form.PhoneNumber,
						password: this.form.password
					})
				.then(function (response) {
					alert ('Usuario registrado con éxito.');
					console.log(response);
					window.location.href = "/";
				})
				.catch(error => {
					console.log(error);
				});
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

	.d-flex {
    display: flex;
  }

	.form-container {
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