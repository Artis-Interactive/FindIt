<template>
  <h1 class="text-center">Find It!</h1>
  <div class="d-flex justify-content-center align-items-center flex-column">
    <div class="background-box">
      <div class="form-container">
        <form @submit.prevent="handleSubmit">
          <div>
            <label for="companyName">Nombre de Empresa:</label>
            <input type="text" id="companyName" v-model="formData.companyName" required
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
            <input type="legalID" id="legalID" v-model="formData.legalId" minlength="9" maxlength="15" required
              pattern="\d+" placeholder="123456789" title="La cédula sólo debe tener números." />
          </div>
          <div class="radio-group">
            <label>
              <input type="radio" name="type" value="physical" v-model="formData.legalIdType" required />
              Fisica
            </label>
            <label>
              <input type="radio" name="type" value="legal" v-model="formData.legalIdType" required />
              Juridica
            </label>
          </div>
          <div>
            <label for="description">Que planeas vender:</label>
            <textarea type="text" id="description" v-model="formData.description"
              placeholder="Utiliza este espacio para describir que tipos de productos planeas vender..." required pattern="[A-Za-zÀ-ÿ0-9\s\.\-,#]+"></textarea>
          </div>

          <div class="map">
						<h3>Ingresar su dirección o marcar en el mapa:<span class="required-asterisk">*</span></h3>
						<input
							type="text"
							id="location-input"
							placeholder="Ingrese su dirección"
						/> <br> <br/>
						<div id="map" style="height: 500px; width: 100%;"></div>
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
/* global google */
import axios from "axios";
import { jwtDecode } from 'jwt-decode';
import { BACKEND_URL } from "@/config";

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
      latitude: null,
			longitude: null,
    };
  },
  mounted() {
    this.loadGoogleMapsScript();
  },
  methods: {
    verifyLogin() {
      // get token and verify open session:
      
      const token = localStorage.getItem('token');
      if (!token) {
        this.modalTitle = "Acceso Restringido";
        this.modalMessage = "Para visualizar estos datos debe iniciar sesión";
        this.isModalVisible = true;
      }
    },

    async handleSubmit() {
      try {
        await this.registerCompany();

        if (this.latitude !== null && this.longitude !== null) {
          await this.registerAddress(this.formData.legalId);
          alert ('Empresa registrada con éxito.');
          window.location.href = "/";
        } else {
          console.error("Latitude or Longitude is missing.");
        }
      } catch (error) {
        console.log("Error during submission:", error);
      }
    },

    loadGoogleMapsScript() {
      const apiKey = process.env.VUE_APP_GOOGLE_MAPS_API_KEY;
      const script = document.createElement('script');
      script.src = `https://maps.googleapis.com/maps/api/js?key=${apiKey}&libraries=places,marker`;
      script.async = true;
      script.defer = true;
      document.head.appendChild(script);

      // Listener to initialize the map once the script is loaded
      script.onload = () => {
        this.initMap();
      };
		},

    initMap() {
      const ucr = { lat: 9.937256786417928, lng: -84.05086517247322 };
      const costaRicaLimit = this.getCostaRicaBounds();

      const map = this.createMap(ucr, costaRicaLimit);
      const marker = this.createMarker(ucr, map);
      // Event listener for map clicks
      this.addMapClickListener(map, marker);
      this.initAutocomplete(map, marker);
    },

    getCostaRicaBounds() {
      return {
        north: 11.219,
        south: 8.032,
        west: -86.745,
        east: -82.555,
      };
    },

		createMap(center, bounds) {
      return new google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: center,
        mapId: "c08b039bbc429250",
        restriction: {
          latLngBounds: bounds,
          strictBounds: true,
        },
      });
    },

    createMarker(position, map) {
      return new google.maps.marker.AdvancedMarkerElement({
        position: position,
        map: map,
        draggable: true,
      });
    },

    addMapClickListener(map, marker) {
      map.addListener("click", (event) => {
        marker.position = event.latLng;
        this.latitude = event.latLng.lat();
        this.longitude = event.latLng.lng();
        map.setCenter(event.latLng);
      });
      map.setZoom(15);
    },

    initAutocomplete(map, marker) {
      const input = document.getElementById("location-input");
      const autocomplete = new google.maps.places.Autocomplete(input);

      // Set bounds and component restrictions
      const defaultBounds = new google.maps.LatLngBounds(
        new google.maps.LatLng(9.5, -85.0),
        new google.maps.LatLng(10.5, -83.0)
      );
      autocomplete.setBounds(defaultBounds);
      autocomplete.setComponentRestrictions({ country: "cr" });

      // Event listener for place selection
      autocomplete.addListener("place_changed", () => {
        const place = autocomplete.getPlace();
        if (!place.geometry) {
          window.alert("No details available for that address.");
          return;
        }
        
        // Set map and marker to new location
        map.setCenter(place.geometry.location);
        marker.position = place.geometry.location;
      });
    },

    async registerCompany() {
      try {
        await axios.post(`${BACKEND_URL}/Company/CreateCompany`,  {
          companyId: "",
          name: this.formData.companyName,
          email: this.formData.companyEmail,
          phoneNumber: this.formData.phoneNumber,
          description: this.formData.description,
          type: this.formData.legalIdType,
          legalID: this.formData.legalId,
          logo: "",
          heroImage: "",
          workingDays: [],
          address: {
            coords: "",
          },
        });
        const token = localStorage.getItem('token');
        const decodedToken = jwtDecode(token);
        await axios.post(`${BACKEND_URL}/Company/AddCompanyToUser?userToken=${decodedToken.email}&companyLegalId=${this.formData.legalId}`);

      } catch (error) {
        console.log(error);
      }
    },

    async registerAddress(legalID) {
      try {
        const coords = `${this.latitude},${this.longitude}`;
        await axios.post(`${BACKEND_URL}/Address/AddCompanyAddress?legalId=${legalID}`, {
          coords: coords	
        });
      } catch (error) {
        throw new Error("Error al registrar dirección."+ (error.response?.data || error.message));
      }
    },
  },
  created() {
    this.verifyLogin();
  },
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