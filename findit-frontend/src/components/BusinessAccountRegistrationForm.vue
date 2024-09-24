<template>
  <div class="flex overflow-hidden flex-col pb-10 bg-white">
    <header
      class="flex flex-wrap gap-10 items-center px-8 py-6 text-2xl font-semibold leading-tight text-black bg-zinc-200 max-md:px-5">
      <h1 class="grow shrink self-stretch my-auto text-5xl w-[153px] max-md:text-4xl">
        Find It!
      </h1>
      <div
        class="flex flex-wrap gap-10 self-stretch px-5 py-3 my-auto whitespace-nowrap bg-white rounded-3xl border border-black border-solid text-black text-opacity-70 max-md:pl-5 max-md:max-w-full">
        <label for="searchInput" class="sr-only">Buscar</label>
        <input v.model="formData." id="searchInput" type="text" placeholder="Buscar"
          class="my-auto bg-transparent border-none focus:outline-none" />
        <img loading="lazy"
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/c293b837c11bd4c8ec953d37e31dcdfe06b0de53df2bde7635f666005f51eee3?placeholderIfAbsent=true&apiKey=77ee1f2eedc0493ea9dd5ee5dc15e5c8"
          class="object-contain shrink-0 aspect-square w-[35px]" alt="" />
      </div>
      <nav>
        <ul class="flex gap-10 items-center">
          <li><a href="#" class="self-stretch my-auto">Inicio</a></li>
          <li><a href="#" class="grow shrink self-stretch my-auto w-[97px]">Empresa</a></li>
          <li><a href="#" class="self-stretch my-auto">Mi perfil</a></li>
        </ul>
      </nav>
      <button
        class="overflow-hidden self-stretch px-6 py-5 text-2xl text-center rounded-xl bg-slate-500 text-slate-50 max-md:px-5">
        Carrito (0)
      </button>
    </header>
    <main
      class="flex flex-col self-center px-5 pt-11 pb-3.5 mt-8 w-full shadow-sm bg-zinc-200 max-w-[900px] rounded-[36px] max-md:max-w-full">
      <form @submit.prevent="registerBusinessAccount">
        <div class="flex flex-wrap gap-8 font-medium leading-tight max-md:max-w-full">
          <div class="flex flex-col flex-1 grow shrink-0 self-start basis-0 w-fit max-md:max-w-full">
            <label for="companyName" class="self-start text-xl text-black">
              Nombre Empresa: <span class="text-red-600">*</span>
            </label>
            <input v.model="formData.companyName" id="companyName" type="text" maxlength="150"
              class="px-16 pt-1.5 pb-10 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5 max-md:max-w-full"
              placeholder="Tu Empresa" required />
          </div>
          <div class="flex flex-col flex-1 grow shrink-0 basis-0 w-fit max-md:max-w-full">
            <label for="companyEmail" class="self-start text-xl text-black">
              Correo electrónico empresa: <span class="text-red-600">*</span>
            </label>
            <input v.model="formData.companyEmail" id="companyEmail" type="email"
              class="flex self-stretch px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full"
              placeholder="correo@tuempresa.com" required />
          </div>
        </div>
        <div class="mt-6 max-md:mr-1.5 max-md:max-w-full">
          <div class="flex gap-5 max-md:flex-col">
            <div class="flex flex-col w-[50%] max-md:ml-0 max-md:w-full">
              <div class="flex flex-col w-full max-md:mt-2.5 max-md:max-w-full">
                <div class="max-md:max-w-full">
                  <div class="flex gap-5 max-md:flex-col">
                    <div class="flex flex-col w-[46%] max-md:ml-0 max-md:w-full">
                      <div class="flex flex-col mt-1 w-full font-medium leading-tight max-md:mt-4">
                        <label for="ownerName" class="self-start text-xl text-black">
                          <span class="text-xl text-black">Nombre: </span>
                          <span class="self-start text-base text-red-600">*</span>
                        </label>
                        <input v.model="formData.ownerName" id="ownerName" type="text" maxlength="50"
                          class="px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full"
                          placeholder="Juan" required />
                        <div class="flex gap-2 self-start mt-3 whitespace-nowrap">
                          <label for="scheduleStart" class="grow text-xl text-black">Horario: </label>
                          <span class="self-start text-base text-red-600">*</span>
                        </div>
                        <div
                          class="px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full">
                          <label for="scheduleStart" class="self-start text-base text-stone-900 text-opacity-70">
                            Inicio:
                          </label>
                          <input v.model="formData.scheduleStart" id="scheduleStart" type="time"
                            class="self-end text-xl text-stone-900 text-opacity-50" required />
                        </div>
                      </div>
                    </div>
                    <div class="flex flex-col ml-5 w-[46%] max-md:ml-0 max-md:w-full">
                      <div class="flex flex-col mt-1 w-full font-medium leading-tight max-md:mt-4">
                        <label for="ownerLastName" class="flex whitespace-nowrap">
                          <span class="text-xl text-black">Apellidos: </span>
                          <span class="self-start text-base text-red-600">*</span>
                        </label>
                        <input v.model="formData.ownerLastName" id="ownerLastName" type="text" maxlength="100"
                          class="px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full"
                          placeholder="Perez Lopez" required />
                        <div
                          class="px-4 py-6 mt-12 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full">
                          <label for="scheduleEnd" class="self-start text-base text-stone-900 text-opacity-70">
                            Cierre:
                          </label>
                          <input v.model="formData.scheduleEnd" id="scheduleEnd" type="time"
                            class="self-center text-xl text-stone-900 text-opacity-50" required />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="flex gap-10 mt-10 max-w-full w-[335px]">
                  <label for="addressInput" class="my-auto text-xl font-medium leading-tight text-black">
                    Dirección:
                  </label>
                  <input type="checkbox" v.model="formData." id="mapMarker"
                    class="flex shrink-0 w-7 h-7 bg-white rounded-full" />
                  <label for="manualAddress" class="my-auto basis-auto">Manual</label>
                  <input type="checkbox" v.model="formData." id="mapMarker"
                    class="flex shrink-0 w-7 h-7 bg-white rounded-full" />
                  <label for="mapMarker" class="my-auto basis-auto">Mapa</label>
                </div>
              </div>
            </div>
            <div class="flex flex-col ml-5 w-[42%] max-md:ml-0 max-md:w-full">
              <div class="flex flex-col items-start w-full text-xl font-medium leading-tight text-black max-md:mt-3">
                <label for="phoneNumber">
                  Teléfono: <span class="text-red-600">*</span>
                </label>
                <input v.model="formData.phoneNumber" id="phoneNumber" type="tel" maxlength="100"
                  class="flex self-stretch px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full"
                  placeholder="+506 8888-8888" required />
                <label for="idNumber" class="mt-5">
                  Cédula jurídica o de identidad:
                </label>
                <input v.model="formData.idNumber" id="idNumber" type="text"
                  class="flex self-stretch px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full"
                  placeholder="3-101-000000" />
              </div>
            </div>
          </div>
        </div>
        <div
          class="flex gap-5 justify-between mt-1.5 text-base font-medium leading-tight whitespace-nowrap text-stone-900 text-opacity-70 max-md:mr-2 max-md:max-w-full">
          <select v.model="formData.addressProvince"
            class="px-16 pt-1.5 pb-10 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5 max-md:max-w-full">
            <option value="">Provincia</option>
          </select>
          <select v.model="formData.addressCanton"
            class="px-16 pt-1.5 pb-10 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5 max-md:max-w-full">
            <option value="">Cantón</option>
          </select>
          <select v.model="formData.addressDistrict"
            class="px-16 pt-1.5 pb-10 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5 max-md:max-w-full">
            <option value="">Distrito</option>
          </select>
        </div>
        <label for="addressAdditionalDetails" class="sr-only">Otras señas:</label>
        <textarea v.model="formData.addressAdditionalDetails" id="addressAdditionalDetails"
          class="px-3 pt-3 pb-10 mt-5 text-base font-medium leading-tight bg-white rounded-3xl text-stone-900 text-opacity-70 max-md:pr-5 max-md:mr-1 max-md:max-w-full w-full"
          placeholder="Otras señas:"></textarea>
        <label for="offeredProducts" class="self-start mt-7 text-xl font-medium leading-tight text-black max-md:ml-0.5">
          Productos ofrecidos:
        </label>
        <textarea v.model="formData.offeredProducts" id="offeredProducts"
          class="px-4 pt-4 pb-20 mt-3 w-full text-base font-medium leading-tight bg-white rounded-3xl text-stone-900 text-opacity-70 max-md:pr-5"
          placeholder="Ingrese los diferentes productos que ofrece:"></textarea>
        <button type="submit"
          class="overflow-hidden self-center px-6 py-5 mt-8 ml-3 max-w-full text-2xl font-semibold leading-tight text-center rounded-xl bg-slate-500 text-slate-50 w-[259px] max-md:px-5">
          Registrar empresa
        </button>
        <p class="self-end mt-1 text-sm font-medium leading-tight text-red-600 max-md:mr-2.5">
          *Campo requerido
        </p>
      </form>
    </main>
  </div>
</template>

<script>
// import axios from "axios";

export default {
  data() {
    return {
      formData: {
        companyName: "",
        companyEmail: "",
        ownerName: "",
        ownerLastName: "",
        scheduleStart: "",
        scheduleEnd: "",
        phoneNumber: "",
        idNumber: "",
        addressProvince: "",
        addressCanton: "",
        addressDistrict: "",
        addressAdditionalDetails: "",
        offeredProducts: "",
      },
    };
  },
  methods: {
    registerBusinessAccount() {
      console.log("Datos: ", this.formData);
      /*axios.post("https://localhost:7150/api/Paises", {
        nombre: this.formData.nombre,
        continente: this.formData.continente,
        idioma: this.formData.idioma,
      }).then(function (response) {
        console.log(response);
        window.location.href = "/";
      }).catch(function (error) {
        console.log(error);
      });*/
    }
  }
}
</script>