<template>
  <router-view></router-view>

	<div class="d-flex justify-content-center align-items-center vh-100">

		<h3 class="text-center">Formulario de registro de usuario</h3>
		<div class="form-container">
			<form @submit.prevent="handleSubmit">
				<div>
					<label for="name">Nombre:</label>
					<input type="text"
									id="name"
									v-model="form.name"
									required
									maxlength="50"
									placeholder="Juan"
									pattern="[A-Za-zÀ-ÿ\s]+"
									title="Nombre sólo debe contener letras" />
				</div>

				<div>
					<label for="lastName">Apellidos:</label>
					<input type="text"
									id="lastName"
									v-model="form.lastName"
									required
									maxlength="100"
									placeholder="Ramírez Ortega"
									pattern="[A-Za-zÀ-ÿ\s]++"
									title="Los apellidos sólo deben contener letras" />
				</div>

				<div>
					<label for="email">Email:</label>
					<input type="email"
									id="email"
									v-model="form.email"
									required
									placeholder="juan.ortega@xxxx.xxxx" />
				</div>

				<div>
					<label for="phone">Teléfono:</label>
					<input type="tel"
									id="phone"
									v-model="form.phone"
									@input="formatTelephone"
									required
									maxlength="9"
									placeholder="XXXX-XXXX" 
									pattern="\d{4}-\d{4}" />
				</div>

				<div>
					<label for="FechaNacimiento">Fecha de Nacimiento:</label>
					<input type="date"
									id="birthdate"
									v-model="form.birthdate"
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
										pattern="[A-Za-zÀ-ÿ\s]+" />
					</div>

					<div>
						<label for="distrito">Distrito:</label>
						<input type="text"
										id="distrito"
										v-model="form.distrito"
										placeholder="San Pedro"
										required
										pattern="[A-Za-zÀ-ÿ\s]+" />
					</div>

					<div>
						<label for="signs">Otras señas:</label>
						<input type="text"
										id="signs"
										v-model="form.signs"
										placeholder="De la Iglesia de San Pedro 200 metros al sur"
										required
										pattern="[A-Za-zÀ-ÿ\s]+" />
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
						<label for="expiraryDate">Fecha de expiración:</label>
						<input type="text"
										id="expiraryDate"
										v-model="form.expiraryDate"
										@input="formatexpiraryDate"
										placeholder="mm/aaaa"
										maxlength="7"
										pattern="(0[1-9]|1[0-2])\/[0-9]{4}"
										required />
					</div>

					<div>
						<label for="cvv">CVV:</label>
						<input type="text"
										id="cvv"
										v-model="form.cvv"
										required
										maxlength="3"
										pattern="\d{3}" />
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

				<button type="submit">Registrarme</button>
			</form>
			<p v-if="submitted">Form submitted! Data: {{ form }}</p>
		</div>

	</div>
</template>

<script></script>
<script>
	export default {
		data() {
			return {
				form: {
					name: '',
					lastName: '',
					birthdate: '',
					email: '',
					password: '',
				},
				selectedDirection: '',
				selectedPaymentMethod: ''
			};
		},
		methods: {
			formatexpiraryDate() {
				if (this.form.expiraryDate.length === 2 && !this.form.expiraryDate.includes('/')) {
					this.form.expiraryDate += '/';
				}
			},
			formatTelephone(event) {
				let input = event.target.value.replace(/\D/g, '');
				if (input.length > 4) {
					input = input.slice(0, 4) + '-' + input.slice(4, 8);
				}
				event.target.value = input.slice(0, 9);
				this.form.phone = event.target.value;
			},
			handleSubmit() {
				this.submitted = true;
				console.log('Form Data:', this.form);
			}
		}
	};
</script>

<style></style>

<style scoped>
	@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');

	.form-container {
		max-width: 400px;
		margin: 0 auto;
		font-family: 'Montserrat', sans-serif;
	}

	form div {
		margin-bottom: 15px;
	}

	label {
		display: block;
		margin-bottom: 5px;
	}

	input {
		font-family: 'Montserrat', sans-serif;
		width: 100%;
		padding: 8px;
		box-sizing: border-box;
	}

	.radio-group {
		display: flex;
		gap: 15px;
	}

		.radio-group label {
			display: flex;
			align-items: center;
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

	button {
		font-family: 'Montserrat', sans-serif;
		padding: 10px;
		background-color: #8263A8;
		color: white;
		border: none;
		cursor: pointer;
	}

		button:hover {
			background-color: #634a83;
		}
</style>