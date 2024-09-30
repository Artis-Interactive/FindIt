<template>
  <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
  <div>
      <div class="form-body">
          <div class="info-container">
              <header>Creación de un producto</header>
              <form @submit.prevent="handleProductData" class="form">
                  <div class="input-box">
                      <label>Nombre del producto</label>
                      <input v-model="productData.name" type="text" placeholder="Ingrese un nombre">
                  </div>
                  <div class="file-input">
                      <label for="file" class="file-label"><i class="uil uil-image-plus"></i>Escoja una imagen</label>
                      <input type="file" id="file" accept="image/*" @change="onFileSelected">
                      <img src="../assets/product_image_placeholder.png" id="myimage" width="150">
                  </div>
                  <div class="row">
                      <div class="input-box">
                          <label>Precio</label>
                          <input v-model="productData.price" type="number" placeholder="Digite un número" pattern="[a-z]+">
                      </div>
                      <div class="input-box">
                          <label>Stock disponible</label>
                          <input v-model="productData.stockAmount" type="number" placeholder="Digite el stock disponible" pattern="[a-z]+">
                      </div>
                  </div>
                  <div class="input-box">
                      <label >Categoría</label>
                      <div class="row">
                          <div class="select-box">
                              <select>
                                  <option>Category 1</option>
                                  <option>Category 2</option>
                                  <option>Category 3</option>
                                  <option>Category 4</option>
                              </select>
                          </div>
                      </div>
                  </div>
                  <div class="description-box">
                      <label>Descripción</label>
                      <textarea v-model="productData.description" placeholder="Ingrese una descripción" name="" id="" cols="30" rows="10"></textarea>
                  </div>
                  <div class="perishable-box">
                      <h3>¿Es perecedero?</h3>
                      <div class="perishable-option">
                          <div class="perishable">
                              <input type="radio" name="perishable" id="check-yes">
                              <label for="check-yes">Sí</label>
                          </div>
                          <div class="perishable">
                              <input type="radio" name="perishable" id="check-no">
                              <label for="check-no">No</label>
                          </div>
                      </div>
                  </div>
                  <button>Crear</button>
              </form>
          </div>
      </div>
  </div>
</template>

<script>

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
                  perishable: "", 
                  lifespan:"",
                  maxProductionQuantity:"",
                  productionDays:"",
                  orderMaxDate:"",
                  orderMaxTime:""
              }
          }
      },
      methods: {
          handleProductData() {
          
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
      background-color: rgb(130, 106, 251);
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
      
  }

  .file-label:hover{
      background-color: #6b4f8d;
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
  }

  .form .row{
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
  }

  textarea :is(:focus, :valid){
      border-width: 2px;
      padding: 14px;
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

  @media screen and (max-width: 500px) {
      .form .row {
          flex-wrap: wrap;
      }

      .form :where(.perishable-option, .perishable) {
          row-gap: 15px;
      }
  }
</style>