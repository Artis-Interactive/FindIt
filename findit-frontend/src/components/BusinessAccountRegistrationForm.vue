<template>
    <main
        class="flex flex-col self-center px-5 pt-11 pb-3.5 mt-8 w-full shadow-sm bg-zinc-200 max-w-[1043px] rounded-[36px] max-md:max-w-full">
        <section class="flex flex-wrap gap-8 font-medium leading-tight max-md:max-w-full">
            <div class="flex flex-col flex-1 grow shrink-0 self-start basis-0 w-fit max-md:max-w-full">
                <label for="companyName" class="self-start text-xl text-black">
                    Nombre Empresa: <span class="text-red-600">*</span>
                </label>
                <input type="text" id="companyName"
                    class="px-16 pt-1.5 pb-10 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5 max-md:max-w-full"
                    placeholder="0/150" maxlength="150" required aria-required="true" />
            </div>
            <div class="flex flex-col flex-1 grow shrink-0 basis-0 w-fit max-md:max-w-full">
                <label for="companyEmail" class="self-start text-xl text-black">
                    Correo electrónico empresa: <span class="text-red-600">*</span>
                </label>
                <input type="email" id="companyEmail"
                    class="px-4 py-6 mt-1.5 text-base whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pr-5 max-md:max-w-full"
                    placeholder="xxxxx@xxx.xxx" required aria-required="true" />
            </div>
        </section>
        <section class="mt-6 max-md:mr-1.5 max-md:max-w-full">
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
                                        <input type="text" id="ownerName"
                                            class="px-16 pt-1.5 pb-10 mt-2 max-w-full text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 w-[233px] max-md:pl-5"
                                            placeholder="0/50" maxlength="50" />
                                        <label for="scheduleStart" class="flex gap-2 self-start mt-3 whitespace-nowrap">
                                            <span class="grow text-xl text-black">Horario:</span>
                                            <span class="self-start text-base text-red-600">*</span>
                                        </label>
                                        <div
                                            class="flex flex-col py-3.5 pr-8 pl-3 mt-3 bg-white rounded-3xl max-md:pr-5">
                                            <span class="self-start text-base text-stone-900 text-opacity-70">
                                                Inicio:
                                            </span>
                                            <input type="time" id="scheduleStart"
                                                class="self-end text-xl text-stone-900 text-opacity-50" required
                                                aria-required="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="flex flex-col ml-5 w-[58%] max-md:ml-0 max-md:w-full">
                                    <div
                                        class="flex flex-col items-start w-full font-medium leading-tight max-md:mt-3.5">
                                        <label for="ownerLastName" class="flex whitespace-nowrap">
                                            <span class="text-xl text-black">Apellidos:</span>
                                            <span class="self-start text-base text-red-600">*</span>
                                        </label>
                                        <input type="text" id="ownerLastName"
                                            class="self-stretch px-16 pt-2.5 pb-9 mt-1 text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:pl-5"
                                            placeholder="0/100" maxlength="100" required aria-required="true" />
                                        <div
                                            class="flex flex-col py-3.5 pr-12 pl-3.5 mt-10 max-w-full bg-white rounded-3xl w-[244px] max-md:pr-5 max-md:ml-2">
                                            <span class="self-start text-base text-stone-900 text-opacity-70">
                                                Cierre:
                                            </span>
                                            <input type="time" id="scheduleEnd"
                                                class="self-center text-xl text-stone-900 text-opacity-50" required
                                                aria-required="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="flex gap-10 mt-10 max-w-full w-[335px]">
                            <span class="my-auto text-xl font-medium leading-tight text-black">
                                Dirección:
                            </span>
                            <div class="flex flex-1 gap-4">
                                <div
                                    class="flex flex-col justify-center items-center px-1.5 w-7 h-7 bg-white rounded-full">
                                    <div class="flex shrink-0 rounded-full bg-zinc-500 h-[15px] w-[15px]"></div>
                                </div>
                                <span class="my-auto text-lg font-medium leading-tight text-black">
                                    Manual:
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="flex flex-col ml-5 w-[42%] max-md:ml-0 max-md:w-full">
                    <div
                        class="flex flex-col items-start w-full text-xl font-medium leading-tight text-black max-md:mt-3">
                        <label for="phone">
                            Teléfono: <span class="text-red-600">*</span>
                        </label>
                        <input type="tel" id="phone"
                            class="self-stretch px-16 pt-1.5 pb-10 mt-2.5 w-full text-sm whitespace-nowrap bg-white rounded-3xl text-stone-900 text-opacity-50 max-md:px-5"
                            placeholder="0/100" maxlength="100" required aria-required="true" />
                        <label for="idNumber" class="mt-5">Cédula jurídica o de identidad:</label>
                        <input type="text" id="idNumber"
                            class="flex shrink-0 self-stretch bg-white rounded-3xl h-[57px]" />
                        <div class="flex gap-3.5 mt-9 text-lg">
                            <input type="checkbox" id="mapMarker" class="flex shrink-0 w-7 h-7 bg-white rounded-full" />
                            <label for="mapMarker" class="my-auto basis-auto">Marcar en mapa</label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section
            class="flex gap-5 justify-between mt-1.5 text-base font-medium leading-tight whitespace-nowrap text-stone-900 text-opacity-70 max-md:mr-2 max-md:max-w-full">
            <select class="px-3 pt-2.5 pb-10 bg-white rounded-3xl max-md:pr-5">
                <option value="">Provincia</option>
            </select>
            <select class="px-5 pt-2 pb-11 bg-white rounded-3xl max-md:pr-5">
                <option value="">Cantón</option>
            </select>
            <select class="px-3.5 pt-2 pb-10 bg-white rounded-3xl max-md:pr-5">
                <option value="">Distrito</option>
            </select>
        </section>
        <textarea
            class="px-3 pt-3 pb-10 mt-5 text-base font-medium leading-tight bg-white rounded-3xl text-stone-900 text-opacity-70 max-md:pr-5 max-md:mr-1 max-md:max-w-full"
            placeholder="Otras señas:"></textarea>
        <label for="products" class="self-start mt-7 text-xl font-medium leading-tight text-black max-md:ml-0.5">
            Productos ofrecidos:
        </label>
        <textarea id="products"
            class="px-4 pt-4 pb-20 mt-3 w-full text-base font-medium leading-tight bg-white rounded-3xl text-stone-900 text-opacity-70 max-md:pr-5"
            placeholder="Ingrese los diferentes productos que ofrece:"></textarea>
        <button type="submit"
            class="overflow-hidden self-center px-6 py-5 mt-8 ml-3 max-w-full text-2xl font-semibold leading-tight text-center rounded-xl bg-slate-500 text-slate-50 w-[259px] max-md:px-5">
            Registrar empresa
        </button>
        <p class="self-end mt-1 text-sm font-medium leading-tight text-red-600 max-md:mr-2.5">
            *Campo requerido
        </p>
    </main>
</template>

<script>
export default {
    name: 'RegistrationForm',
    // Add any necessary component logic here
}
</script>