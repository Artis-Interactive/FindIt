<template>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div class="layout-container">
      <div class="navbar">navbar</div>
      <div class="go-back-container">
        Regresar
      </div>
      <div class="img-container">
        <svg width="564" height="556" viewBox="0 0 564 556" fill="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
        <rect width="564" height="556" rx="10" fill="url(#pattern0_105_103)"/>
        <defs>
        <pattern id="pattern0_105_103" patternContentUnits="objectBoundingBox" width="1" height="1">
        <use xlink:href="#image0_105_103" transform="matrix(0.0013587 0 0 0.00137825 0 -0.00719424)"/>
        </pattern>
        <image id="image0_105_103" width="736" height="736" xlink:href="data:image/jpeg;base64,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"/>
        </defs>
        </svg>
  
      </div>
      <div class="desc-container">
        <h1>PRODUCTO</h1>
        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Placeat odit voluptatem pariatur voluptates nulla soluta vero excepturi maxime voluptas inventore illo molestias accusamus, consectetur, earum facilis ullam. Voluptatem, non atque.
        Possimus facere modi praesentium sequi corrupti totam ullam error accusantium vel placeat eligendi molestiae culpa porro, soluta, eum harum labore. Tenetur commodi perspiciatis corrupti modi sequi nam nesciunt, hic dolorem!
        At id doloribus impedit cumque cupiditate laudantium ex sit, delectus ipsum facilis reiciendis, ipsam voluptatem nobis rerum aut illo laborum vero, consectetur deserunt molestiae exercitationem? Odit porro sequi temporibus modi.
        Impedit in quidem expedita obcaecati corrupti hic animi, reiciendis quo error iste dolorum id pariatur nesciunt ipsa asperiores, voluptate assumenda totam quibusdam odio! Optio minus molestiae repellat ipsum minima a.
        Aperiam nostrum magnam inventore placeat maiores est repellat quas quia sapiente reprehenderit nobis excepturi nam ut debitis consequuntur perferendis voluptates, et tempore aliquam? Eum inventore ratione nesciunt adipisci, dicta ducimus?
        Amet, aperiam maxime iure suscipit ea asperiores saepe eius expedita itaque vitae obcaecati, modi iste, ad voluptatum minus recusandae repellat aut inventore nesciunt perspiciatis sit eos dicta vero. Accusamus, consequuntur.
        Corporis fugiat aspernatur asperiores labore sapiente saepe nostrum ut veniam, fugit cupiditate totam obcaecati exercitationem, impedit adipisci reiciendis. Veritatis, quod similique quo quisquam laboriosam nulla temporibus ratione tempora at beatae.
        Nisi obcaecati a in dolorem facere repudiandae veritatis, dolore non dolorum, eligendi deleniti tenetur? Cumque amet error a dignissimos voluptas ut quisquam, vitae eum, hic esse animi sapiente incidunt tempora.
        Itaque, odio. Porro vitae sapiente excepturi harum quos repellendus hic temporibus et aperiam. Consequuntur totam, a voluptas molestiae nobis eos nemo aspernatur quod aperiam enim iste? Vitae laboriosam quasi itaque?
        Tempora velit rem assumenda quas et eligendi! Quis quidem, ipsa aperiam esse voluptatem tempora ad repellendus ex cumque et sit, voluptatum perferendis recusandae impedit. Aliquid fugit quibusdam quisquam magni odit!
        Dicta officia vel nobis vero veniam? Quam debitis ipsa voluptas unde pariatur optio, quasi repellat blanditiis animi tempore et culpa. Ex earum deserunt repellendus alias illum laudantium quaerat praesentium nesciunt?
        Maxime ab voluptates dolorem modi? Asperiores provident quibusdam molestiae consequuntur necessitatibus numquam commodi accusantium ad praesentium! Ducimus commodi incidunt, cum assumenda fugit sunt fuga id a, animi inventore, quidem consectetur.
        Qui eveniet debitis aspernatur nostrum laborum itaque quisquam, ut, culpa unde possimus labore accusantium deserunt rem laboriosam assumenda ullam cum ab nemo magnam autem fugiat praesentium eius fugit repellendus. Officia?
        Ab dolorem laborum quibusdam voluptatibus temporibus similique molestias molestiae explicabo eveniet reprehenderit! Repudiandae atque numquam fuga expedita molestias exercitationem, voluptatum sit dicta modi vel! Officiis nihil nobis doloremque nesciunt fuga.
        Ea, recusandae sunt fugit in enim veniam vitae hic consequatur ut laudantium tempore ex cupiditate maxime, similique reprehenderit obcaecati quidem doloremque sint. Quis ex assumenda, quasi beatae perferendis illum neque!
        Reiciendis nihil magni natus. Culpa eius odit commodi in iure? Quod, ullam earum temporibus pariatur architecto nemo dolores sit enim? Laboriosam eius dolorum animi nulla minima, sint quo laborum culpa!
        Voluptates maiores quibusdam quam consectetur dolorem perspiciatis sit atque tempore, nemo, sint vel corporis necessitatibus, fuga expedita dolore laudantium facere exercitationem architecto veniam eius impedit deserunt non dicta porro. Nesciunt!
        Obcaecati, alias perspiciatis consequatur ut doloribus similique repudiandae tempore optio, ex explicabo repellendus autem assumenda! Ea hic modi tempore, cumque optio repellat nulla unde illo eligendi, dolorum, ex odit ipsum!
        Autem ullam ab adipisci, numquam totam, quasi assumenda dolore fugiat quae doloribus, quaerat provident! Earum deleniti vel vero recusandae optio consequuntur perspiciatis, ipsam quae maiores blanditiis eligendi voluptatibus ut quis?
        Unde perspiciatis, consectetur autem sunt saepe natus quam ad officiis distinctio, cupiditate repellat quasi molestias minus, eligendi suscipit porro neque. Atque quae corporis suscipit pariatur? Cum ipsa incidunt dolores fuga.</p>
      </div>
      <div class="buy-container">
        <div class="buy-items-container">
          <h1 class="price">₡20.000</h1>
          <p class="shipping-price">Envío: ₡1.700</p>
          <div class="stock-container">
            <button class="minus-btn q-btn">-</button>
            <p class="quantity">1</p>
            <button class="plus-btn q-btn">+</button>
            <p class="stock-amount">Out of Stock</p>
          </div>
          <button class="cart-btn">Añadir al carrito</button>
        </div>
      </div>
    </div>
  </template>
  
  <script>
    export default {
    
    }
  </script>
  
  <style scoped>
  
    .layout-container{
      display: grid;
      grid-template-columns: 450px 1fr 450px;
      grid-template-rows: 75px auto auto;
      font-family: montserrat;
    }
  
    .navbar{
      grid-column: 1/4;
      grid-row: 1/2;
      background-color: #E3DDEC;
    }
  
    .go-back-container{
      grid-column: 1/4;
      grid-row: 2/3;
      background-color: rgba(130, 99, 168, 0.57);
    }
  
    .img-container{
      grid-column: 1/2;
      grid-row: 3/4;
      display: flex;
      margin-left: 30px;
      margin-top: 30px;
    }
  
    .desc-container{
      grid-column: 2/3;
      grid-row: 3/4;
      background-color: white;
      margin-top: 30px;
      text-align: left;
      padding-left: 20px;
      padding-right: 20px;
    }
  
    .buy-container{
      grid-column: 3/4;
      grid-row: 3/4;
      background-color: white;
      margin-top: 30px;
    }
  
    .buy-items-container{
      background-color: white;
      width: 350px;
      height: 500px;
      border-radius: 10px;
      padding: 10px;
      position: relative;
      display: flex;
      flex-direction: column;
      align-items: start;
      box-shadow: 0px 0px 5px 5px rgb(0, 0, 0, 0.05);
    }
  
    .cart-btn{
      background-color: #8263A8;
      color: white;
      height: 50px;
      width: 250px;
      border-color: #8263A8;
      border: transparent;
      border-radius: 5px;
      position: absolute;
      bottom: 10%;
      left: 15%;
      font-weight: 600;
      font-size: 20px;
    }
  
    .stock-container{
      display: grid;
      grid-template-columns: 40px 40px 40px;
      grid-template-rows: 40px 40px;
      align-items: center;
      justify-items: center;
      position: absolute;
      bottom: 20%;
      left: 15%
  
    }
  
    .stock-amount{
      grid-column: 1/4;
      grid-row: 2/3;
    }
  
    .q-btn{
      width: 30px;
      height: 30px;
      border-radius: 40px;
      border-color: #8263A8;
      background-color: white;
      color: #8263A8;
      font-weight: 900;
      transition: 0.2s;
    }
  
    .q-btn:hover{
      background-color: #8263A8;
      border-color: transparent;
      color: white;
    }
  </style>