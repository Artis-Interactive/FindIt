import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'

import CompanyPage from './components/CompanyPage.vue'
import RegisterCompanyPrev from './components/RegisterCompanyPrev.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: "/", name: "Empresa", component: CompanyPage},
        {path: "/reg-prev", name: "Ingresar a registro de empresa", component: RegisterCompanyPrev}
    ]
})

createApp(App).use(router).mount('#app')
