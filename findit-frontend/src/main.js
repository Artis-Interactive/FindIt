import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'

import CompanyPage from './components/CompanyPage.vue'
import RegisterCompanyPrev from './components/RegisterCompanyPrev.vue'
import LogIn from './components/LogIn.vue'
import SignUp from './components/SignUp.vue'
import GeneralCompanyList from './components/GeneralCompanyList.vue';
import GeneralUserList from './components/GeneralUserList.vue'
import EmailVerification from './components/EmailVerification.vue'
import PersonalCompanyList from './components/PersonalCompanyList.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: "/Users", name: "UsersList", component: GeneralUserList },
        { path: "/", name: "Log In", component: LogIn },
        { path: "/business", name: "Empresa", component: CompanyPage },
        { path: "/business/register", name: "Ingresar a registro de empresa", component: RegisterCompanyPrev },
        { path: "/signUp", name: "Sign Up", component: SignUp },
        { path: '/email-verification/:email', name: 'EmailVerification', component: EmailVerification, 
            props: route => ({
                email: route.params.email
            })
        },
        {path: "/allcompanies", name: "AllCompanies", component: GeneralCompanyList},
        {path: "/mycompanies", name: "MyCompanies", component: PersonalCompanyList},
    ]
})

createApp(App).use(router).mount('#app')
