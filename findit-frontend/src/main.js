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
import ProductCreation from './components/ProductCreation.vue'
import CompanyRegistrationForm from './components/CompanyRegistrationForm.vue'
import PersonalCompanyList from './components/PersonalCompanyList.vue'
import GeneralProductList from './components/GeneralProductList.vue'
import MyProfile from './components/MyProfile.vue'
import CompanyProductList from './components/CompanyProductList.vue'
import CompanyUserList from './components/CompanyUserList.vue'
import HomePage from './components/HomePage.vue'
import ProfileAddresses from './components/ProfileAddresses'
import ShoppingCart from './components/ShoppingCart.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: "/UsersCompany", name: "CompanyUserList", component: CompanyUserList },
        { path: "/Users", name: "UsersList", component: GeneralUserList },
        { path: "/", name: "Log In", component: LogIn },
        { path: "/home", name: "HomePage", component: HomePage },
        { path: "/company", name: "Empresa", component: CompanyPage },
        { path: "/company/register", name: "Ingresar a registro de empresa", component: RegisterCompanyPrev },
        { path: "/company/register-form", name: "Crear Empresa", component: CompanyRegistrationForm },
        { path: "/signUp", name: "Sign Up", component: SignUp },
        { path: "/email-verification/:email", name: "EmailVerification", component: EmailVerification, 
            props: route => ({
                email: route.params.email
            })
        },
        { path: '/product-creation/', name: 'ProductCreation', component: ProductCreation},
        // { path: '/product-creation/:companyID', name: 'ProductCreation', component: ProductCreation, 
        //     props: route => ({
        //         companyID: route.params.companyID
        //     })
        // },
        {path: "/allcompanies", name: "AllCompanies", component: GeneralCompanyList},
        {path: "/mycompanies", name: "MyCompanies", component: PersonalCompanyList},
        {path: "/allproducts", name: "AllProducts", component: GeneralProductList},
        {path: "/profile", name: "Profile", component: MyProfile},
        {path: "/companyproducts", name: "CompanyProducts", component: CompanyProductList},
        {path: "/profile/settings", name: "ProfileSettings"},
        {path: "/profile/payment-methods", name: "ProfilePaymentMethods"},
        {path: "/profile/addresses", name: "ProfileAddresses", component: ProfileAddresses},
        {path: "/cart", name: "ShoppingCart", component: ShoppingCart}
    ]
})

createApp(App).use(router).mount('#app')