<template>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
    <div>
        <div class="form-body">
            <div class="info-container">
                <header>Creación de un producto</header>
                <form @submit.prevent="handleProductData" class="form">
                    <div class="input-box">
                        <label>Nombre del producto</label>
                        <input v-model="productData.name" type="text" placeholder="Ingrese un nombre" required>
                    </div>
                    <div class="file-input">
                        <label for="file" class="file-label"><i class="uil uil-image-plus"></i>Escoja una imagen</label>
                        <input type="file" id="file" accept="image/*" @change="onFileSelected">
                        <img src="../assets/product_image_placeholder.png" id="myimage" width="150">
                    </div>
                    <div class="info-row">
                        <div class="input-box">
                            <label>Precio</label>
                            <input v-model="productData.price" type="number" placeholder="Digite un número" min="1">
                        </div>
                        <div class="input-box">
                            <label>Stock disponible</label>
                            <input v-model="productData.stockAmount" type="number" placeholder="Digite el stock disponible" min="0">
                        </div>
                    </div>
                    <div class="input-box">
                        <label >Categoría</label>
                        <div class="info-row">
                            <div class="select-box">
                                <select v-model="this.productData.category" required>
                                    <option v-for="(category, index) of categories" :key="index"> {{ category }} </option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="description-box">
                        <label>Descripción</label>
                        <textarea v-model="productData.description" placeholder="Ingrese una descripción" name="" id="" cols="30" rows="10" maxlength="1000" required></textarea>
                    </div>
                    <div class="perishable-box">
                        <h3>¿Es perecedero?</h3>
                        <div class="perishable-option">
                            <div class="perishable">
                                <input type="radio" name="perishable" id="check-yes" @change="perishableTrue">
                                <label for="check-yes">Sí</label>
                            </div>
                            <div class="perishable">
                                <input type="radio" name="perishable" id="check-no" @change="perishableFalse">
                                <label for="check-no">No</label>
                            </div>
                        </div>
                    </div>
                    <div v-if="this.perishable">
                        <div class="info-row">
                            <div class="input-box">
                                <label>Tiempo de vida</label>
                                <input v-model="productData.lifespan" type="number" placeholder="Digite un número" required>
                            </div>
                            <div class="input-box">
                                <label>Máxima producción al día</label>
                                <input v-model="productData.maxProductionQuantity" type="number" placeholder="Digite un número" required>
                            </div>
                        </div>
                        <div class="info-row">
                            <div class="input-box">
                                <label>Fecha límite para ordenar</label>
                                <input v-model="productData.orderMaxDate" type="date" placeholder="Digite un número" required>
                            </div>
                            <div class="input-box">
                                <label>Hora límite para ordenar</label>
                                <input v-model="productData.orderMaxTime" type="time" placeholder="Digite un número" required>
                            </div>
                        </div>
                    </div>
                    <div class="days-container">
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="monday" name="days" value="Lunes">
                            <label for="monday">Lunes</label>
                        </div>
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="tuesday" name="days" value="Martes">
                            <label for="tuesday">Martes</label>
                        </div>
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="wednesday" name="days" value="Miercoles">
                            <label for="wednesday">Miércoles</label>
                        </div>
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="thursday" name="days" value="Jueves">
                            <label for="thursday">Jueves</label>
                        </div>
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="friday" name="days" value="Viernes">
                            <label for="friday">Viernes</label>
                        </div>
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="saturday" name="days" value="Sábado">
                            <label for="saturday">Sábado</label>
                        </div>
                        <div class="days-box">
                            <input v-model="this.productData.productionDays" type="checkbox" id="sunday" name="days" value="Domingo">
                            <label for="sunday">Domingo</label>
                        </div>
                    </div>
                    <div>{{ productData.productionDays }}</div>
                    <div class="submit-btn-container">
                        <button type="submit">Crear producto</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'ProductCreation',
        components: {
        }, 
        data() {
            return {
                productData: { 
                    name: "", 
                    category:"",
                    price:"",
                    stockAmount:"",
                    description:"",
                    image:"",
                    lifespan:"",
                    maxProductionQuantity:"",
                    productionDays: [],
                    orderMaxDate:"",
                    orderMaxTime:""
                },
                categories: [
                    'Calzado',
                    'Zapatos',
                    'Anillos',
                    'Computadoras'
                ],
                perishable: false,
                productID: ""
            }
        },
        methods: {
            handleProductData() {
                // axios.post("https://localhost:7019/api/Paises", {
                // nombre: this.datosFormulario.nombre,
                // continente: this.datosFormulario.continente,
                // idioma: this.datosFormulario.idioma,
                // })
                // .then(function (response) {
                //     console.log(response);
                //     window.location.href = "/";
                // })
                // .catch(function (error) {
                //     console.log(error);
                // });

                let categoryID = this.categories.find(this.isCategoryValid).categoryID;
                let jsonMsg = 
                {
                    "product": {
                        "productID": "invalidProductID",
                        "categoryID": categoryID,
                        "companyID": this.$route.params.companyID,
                        "name": this.productData.name,
                        "description": this.productData.description,
                        "image": this.productData.image,
                        "price": this.productData.price
                    },
                    "stock": this.productData.stockAmount
                }

                console.log(this.productData)
                if (this.productData.image) {

                    axios.post('https://localhost:7262/api/Product/CreateNonPerishableProduct', jsonMsg)
                    .then(response => {
                    console.log('Image uploaded successfully:', response.data);
                    })
                    .catch(error => {
                    console.error('Error uploading image:', error);
                    });

                    axios.get("https://localhost:7262/api/Product/ProductID", {
                        params: {
                            companyId: this.$route.params.companyID,
                            categoryId: categoryID,
                            name: this.productData.name,
                            description: this.productData.description,
                            img: this.productData.image,
                            price: this.productData.price
                        }
                    }).then(
                    (response) => {
                        this.productID = response.data;
                    });

                    const formData = new FormData();
                    formData.append('image', this.productData.image);
                    formData.append('productId', 'AJJAHGSVEJJUE');

                    axios.post('https://localhost:7262/api/Product/UploadImage', formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                    })
                    .then(response => {
                    console.log('Image uploaded successfully:', response.data);
                    })
                    .catch(error => {
                    console.error('Error uploading image:', error);
                    });
                } else {
                    alert('Please select an image first');
                }
            },
            async getCategories() {
                axios.get("https://localhost:7262/api/Category").then(
                    (response) => {
                        console.log(response.data);
                        this.categories = response.data;
                });
            },
            onFileSelected(event){
                this.productData.image = event.target.files[0];
                if (this.productData.image == null){
                    return;
                }
                var reader = new FileReader();

                var imgtag = document.getElementById("myimage");
                imgtag.title = this.productData.image.name;

                reader.onload = function(event) {
                imgtag.src = event.target.result;
                };
                reader.readAsDataURL(this.productData.image);

                console.log(this.productData)
            },
            perishableFalse(){
                this.perishable = false
                console.log(this.perishable)
            },
            perishableTrue(){
                this.perishable = true
                console.log(this.perishable)
            },
            isCategoryValid(category) {
                return category === this.productData.category;
            }
        }
    }
</script>

<style scoped>
    @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;800&display=swap');

    *{
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: 'poppins', sans-serif;
    }

    .form-body{
        min-height: 100vh;
        display: flex;
        align-items: center;
        justify-content: center;
        padding: 20px;
        background-color: #e3ddec;
    }

    .info-container{
        position: relative;
        max-width: 700px;
        width: 100%;
        background-color:white;
        padding: 25px;
        border-radius: 8px;
        box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
    }

    .info-container header{
        font-size: 1.5rem;
        color: #333;
        font: 500;
        text-align: center;
        font-weight: 500;
    }

    .info-container .form{
        margin-top: 30px;
    }

    .form .input-box{
        width: 100%;
        margin-top: 20px;
    }

    .form .file-input{
        width: 100%;
        margin-top: 20px;
        display: flex;
        align-items: center;
        justify-content:space-evenly;
    }

    input[type="file"]{
        display: none;
    }

    .file-label{
        color: #8263A8;
        border: 2px #8263A8 solid;

        background-color: white;
        height: 60px;
        outline: none;
        padding: 15px 15px;
        cursor: pointer;
        font-size: 1.1em;
        font-weight: 600;
        transition: 0.1s;
        border-radius: 10px;
    }

    .file-label:hover{
        background-color: #8263A8;
        color: white;
    }

    .input-box label{
        color: #333;
    }

    .form :where(.input-box input, .select-box){
        position: relative;
        height: 50px;
        width: 100%;
        outline: none;
        font-size: 1rem;
        color: #707070;
        border: 1px solid #ddd;
        border-radius: 6px;
        padding: 0 15px;
        transition: 0.1s;
    }

    .form .input-box input:focus{
        border-color: #4671EA;
    }

    .form .select-box select:hover{
        cursor: pointer;
    }

    .form .select-box:has(select:focus){
        border-color: #4671EA;
    }

    .form .info-row{
        display: flex;
        column-gap: 15px;
    }

    .form .description-box {
        margin-top: 20px;
    }

    .form .description-box textarea{
        width: 100%;
        height: 180px;
        padding: 10px;
        outline: none;
        resize: none;
        font-size: 16px;
        border-radius: 5px;
        border-color: #bfbfbf;
        color: #707070;
        border-style: solid;
    }

    .form .description-box textarea:focus{
        border-color: #4671EA;
    }

    .form .perishable-box{
        margin-top: 20px;
    }

    .perishable-box h3{
       color: #333;
       font-size: 1rem;
       font-weight: 400;
       margin-bottom: 8px; 
    }

    .form :where(.perishable-option, .perishable) {
        display: flex;
        align-items: center;
        column-gap: 50px;
        flex-wrap: wrap;
    }

    .form .perishable{
        column-gap: 5px;
    }

    .form :where(.perishable input, .perishable label){
        cursor: pointer;
    }

    .select-box select{
        height: 100%;
        width: 100%;
        outline: none;
        border: none;
        color: #707070;
        font-size: 1rem;
    }

    .form .submit-btn-container{
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .form button{
        color: white;
        background-color: #8263A8;
        height: 60px;
        border: none;
        outline: none;
        padding: 15px 15px;
        cursor: pointer;
        font-size: 1.1em;
        font-weight: 600;
        transition: 0.1s;
        margin-top: 20px;
    }

    .form button:hover{
        background-color: #6b4f8d;
    }

    input::-webkit-outer-spin-button,
    input::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
    }

    /* Firefox */
    input[type=number] {
    -moz-appearance: textfield;
    appearance: textfield;
    }

    @media screen and (max-width: 550px) {
        .form .info-row {
            flex-wrap: wrap;
        }

        .form :where(.perishable-option, .perishable) {
            row-gap: 15px;
        }
    }
</style>