<template>
  <div id="product-container">
      <div id="regresar">
          Volver atras
      </div>
      <div id="img-container">
          <img src="../assets/logo.png" alt="El logo de Vue">
      </div>
      <div id="description-container">
          Descripcion
      </div>
      <div id="buy-container">
          Comprar
      </div>
  </div>
</template>

<script>
  export default {
      name: 'ProductViewBody'
  }
</script>

<style scoped>

  #product-container {
      margin: 0px;
      display: grid;
      grid-template-columns: 1fr 1fr 1fr;
      grid-template-rows: 50px 600px;
  }

  #regresar {
      background-color: aqua;
      grid-column: 1 / 4;
  }

  #img-container {
      background-color: greenyellow;
  }

  #description-container {
      background-color: yellow;
  }

  #buy-container {
      background-color: red;
  }

</style>