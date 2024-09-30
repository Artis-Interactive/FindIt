<template>
	<h1 class="text-center">Find It!</h1>
	<div class="d-flex justify-content-center align-items-center flex-column">
		<div class="background-box">
			<div class="form-container">
				<form @submit.prevent="handleVerification">
					<div class="complete-name">
						<div class="form-group">
							<h3>Verificacion de correo</h3>
							<p>Deseas verificar la correo electronico: {{$route.params.email}}</p>
						</div>
					</div>

					<div class="button-container">
						<button type="submit">Verificar</button>
					</div>
				</form>
			</div>
		</div>
	</div>

</template>

<script>
	import axios from 'axios';

	export default {

		data() {
			return {
			};
		},
		methods: {
			handleVerification() {
				axios.post(`https://localhost:7262/api/UserDataSignUp/Verify?email=${encodeURIComponent(this.$route.params.email)}`)
				.then(function (response) {
					alert('Correo verifiado con éxito.');
					console.log(response);
					window.location.href = "/";
				})
				.catch(error => {
					alert(`Error verificando correo.`);
					console.log(error);
				});
			},
		},
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