<template>
    <div class="flex overflow-hidden flex-col pb-10 bg-white">
      <header class="flex flex-wrap gap-10 items-center px-8 py-6 text-2xl font-semibold leading-tight text-black bg-zinc-200 max-md:px-5">
        <h1 class="grow shrink self-stretch my-auto text-5xl w-[153px] max-md:text-4xl">
          Find It!
        </h1>
        <div class="flex flex-wrap gap-10 self-stretch px-5 py-3 my-auto whitespace-nowrap bg-white rounded-3xl border border-black border-solid text-black text-opacity-70 max-md:pl-5 max-md:max-w-full">
          <label for="searchInput" class="sr-only">Buscar</label>
          <input id="searchInput" type="text" placeholder="Buscar" class="my-auto bg-transparent border-none focus:outline-none" />
          <img loading="lazy" src="https://cdn.builder.io/api/v1/image/assets/TEMP/c293b837c11bd4c8ec953d37e31dcdfe06b0de53df2bde7635f666005f51eee3?placeholderIfAbsent=true&apiKey=77ee1f2eedc0493ea9dd5ee5dc15e5c8" class="object-contain shrink-0 aspect-square w-[35px]" alt="" />
        </div>
        <nav>
          <ul class="flex gap-10 items-center">
            <li><a href="#" class="self-stretch my-auto">Inicio</a></li>
            <li><a href="#" class="grow shrink self-stretch my-auto w-[97px]">Empresa</a></li>
            <li><a href="#" class="self-stretch my-auto">Mi perfil</a></li>
          </ul>
        </nav>
        <button class="overflow-hidden self-stretch px-6 py-5 text-2xl text-center rounded-xl bg-slate-500 text-slate-50 max-md:px-5">
          Carrito (0)
        </button>
      </header>
      <main class="flex flex-col self-center px-5 pt-11 pb-3.5 mt-8 w-full shadow-sm bg-zinc-200 max-w-[1043px] rounded-[36px] max-md:max-w-full">
        <form>
          <div class="flex flex-wrap gap-8 font-medium leading-tight max-md:max-w-full">
            <div class="flex flex-col flex-1 grow shrink-0 self-start basis-0 w-fit max-md:max-w-full">
              <label for="companyName" class="self-start text-xl text-black">
                Nombre Empresa: <span class="text-red-600">*</span>
              </label>
              <input id="companyName" type="text" maxlength="150" class="px-16 pt-1.5 pb-10 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5 max-md:max-w-full" placeholder="0/150" required />
            </div>
            <div class="flex flex-col flex-1 grow shrink-0 basis-0 w-fit max-md:max-w-full">
              <label for="companyEmail" class="self-start text-xl text-black">
                Correo electrónico empresa: <span class="text-red-600">*</span>
              </label>
              <input id="companyEmail" type="email" class="px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full" placeholder="xxxxx@xxx.xxx" required />
            </div>
          </div>
          <div class="mt-6 max-md:mr-1.5 max-md:max-w-full">
            <div class="flex gap-5 max-md:flex-col">
              <div class="flex flex-col w-[58%] max-md:ml-0 max-md:w-full">
                <div class="flex flex-col w-full max-md:mt-2.5 max-md:max-w-full">
                  <div class="max-md:max-w-full">
                    <div class="flex gap-5 max-md:flex-col">
                      <div class="flex flex-col w-[42%] max-md:ml-0 max-md:w-full">
                        <div class="flex flex-col mt-1 w-full font-medium leading-tight max-md:mt-4">
                          <label for="ownerName" class="self-start text-xl text-black">
                            Nombre dueño:
                          </label>
                          <input id="ownerName" type="text" maxlength="50" class="px-16 pt-1.5 pb-10 mt-2 max-w-full text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 w-[233px] max-md:pl-5" placeholder="0/50" />
                          <div class="flex gap-2 self-start mt-3 whitespace-nowrap">
                            <label for="scheduleStart" class="grow text-xl text-black">Horario:</label>
                            <span class="self-start text-base text-red-600">*</span>
                          </div>
                          <div class="flex flex-col py-3.5 pr-8 pl-3 mt-3 bg-white rounded-3xl max-md:pr-5">
                            <label for="scheduleStart" class="self-start text-base text-stone-900 text-opacity-70">
                              Inicio:
                            </label>
                            <input id="scheduleStart" type="time" class="self-end text-xl text-stone-900 text-opacity-50" required />
                          </div>
                        </div>
                      </div>
                      <div class="flex flex-col ml-5 w-[58%] max-md:ml-0 max-md:w-full">
                        <div class="flex flex-col items-start w-full font-medium leading-tight max-md:mt-3.5">
                          <label for="ownerLastName" class="flex whitespace-nowrap">
                            <span class="text-xl text-black">Apellidos:</span>
                            <span class="self-start text-base text-red-600">*</span>
                          </label>
                          <input id="ownerLastName" type="text" maxlength="100" class="self-stretch px-16 pt-2.5 pb-9 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5" placeholder="0/100" required />
                          <div class="flex flex-col py-3.5 pr-12 pl-3.5 mt-10 max-w-full bg-white rounded-3xl w-[244px] max-md:pr-5 max-md:ml-2">
                            <label for="scheduleEnd" class="self-start text-base text-stone-900 text-opacity-70">
                              Cierre:
                            </label>
                            <input id="scheduleEnd" type="time" class="self-center text-xl text-stone-900 text-opacity-50" required />
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="flex gap-10 mt-10 max-w-full w-[335px]">
                    <label for="addressInput" class="my-auto text-xl font-medium leading-tight text-black">
                      Dirección:
                    </label>
                    <div class="flex flex-1 gap-4">
                      <div class="flex flex-col justify-center items-center px-1.5 w-7 h-7 bg-white rounded-full">
                        <div class="flex shrink-0 rounded-full bg-zinc-500 h-[15px] w-[15px]"></div>
                      </div>
                      <label for="manualAddress" class="my-auto text-lg font-medium leading-tight text-black">
                        Manual:
                      </label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="flex flex-col ml-5 w-[42%] max-md:ml-0 max-md:w-full">
                <div class="flex flex-col items-start w-full text-xl font-medium leading-tight text-black max-md:mt-3">
                  <label for="phoneNumber">
                    Teléfono: <span class="text-red-600">*</span>
                  </label>
                  <input id="phoneNumber" type="tel" maxlength="100" class="self-stretch px-16 pt-1.5 pb-10 mt-2.5 w-full text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:px-5" placeholder="0/100" required />
                  <label for="idNumber" class="mt-5">Cédula jurídica o de identidad:</label>
                  <input id="idNumber" type="text" class="flex shrink-0 self-stretch bg-white rounded-3xl h-[57px]" />
                  <div class="flex gap-3.5 mt-9 text-lg">
                    <input type="checkbox" id="mapMarker" class="flex shrink-0 w-7 h-7 bg-white rounded-full" />
                    <label for="mapMarker" class="my-auto basis-auto">Marcar en mapa</label>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="flex gap-5 justify-between mt-1.5 text-base font-medium leading-tight whitespace-nowrap text-stone-900 text-opacity-70 max-md:mr-2 max-md:max-w-full">
            <select class="px-3 pt-2.5 pb-10 bg-white rounded-3xl max-md:pr-5">
              <option value="">Provincia</option>
            </select>
            <select class="px-5 pt-2 pb-11 bg-white rounded-3xl max-md:pr-5">
              <option value="">Cantón</option>
            </select>
            <select class="px-3.5 pt-2 pb-10 bg-white rounded-3xl max-md:pr-5">
              <option value="">Distrito</option>
            </select>
          </div>
          <label for="additionalDetails" class="sr-only">Otras señas:</label>
          <textarea id="additionalDetails" class="px-3 pt-3 pb-10 mt-5 text-base font-medium leading-tight bg-white rounded-3xl text-stone-900 text-opacity-70 max-md:pr-5 max-md:mr-1 max-md:max-w-full w-full" placeholder="Otras señas:"></textarea>
          <label for="offeredProducts" class="self-start mt-7 text-xl font-medium leading-tight text-black max-md:ml-0.5">
            Productos ofrecidos:
          </label>
          <textarea id="offeredProducts" class="px-4 pt-4 pb-20 mt-3 w-full text-base font-medium leading-tight bg-white rounded-3xl text-stone-900 text-opacity-70 max-md:pr-5" placeholder="Ingrese los diferentes productos que ofrece:"></textarea>
          <button type="submit" class="overflow-hidden self-center px-6 py-5 mt-8 ml-3 max-w-full text-2xl font-semibold leading-tight text-center rounded-xl bg-slate-500 text-slate-50 w-[259px] max-md:px-5">
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
  export default {
    name: 'BusinessAccountRegistrationForm',
    // Component logic goes here
  }
  </script>