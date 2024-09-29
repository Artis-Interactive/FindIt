import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'

import CompanyPage from './components/CompanyPage.vue'
import RegisterCompanyPrev from './components/RegisterCompanyPrev.vue'
import LogIn from './components/LogIn.vue'
import SignUp from './components/SignUp.vue'
import GeneralProductList from './components/GeneralProductList.vue';


const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: "/", name: "Empresa", component: CompanyPage},
        {path: "/regPrev", name: "Ingresar a registro de empresa", component: RegisterCompanyPrev},
        {path: "/logIn", name: "Log In", component: LogIn},
        {path: "/signUp", name: "Sign Up", component: SignUp},
    ]
})

createApp(App).use(router).mount('#app')
