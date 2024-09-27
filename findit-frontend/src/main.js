import { createApp } from 'vue'
import App from './App.vue'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap';
import { createRouter, createWebHistory } from 'vue-router'

import HelloWorld from './components/HelloWorld.vue'
import LoginComponent from "./components/LogIn.vue";

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: "/",
            name: "Login",
            component: LoginComponent},
        {
            path: "/home",
            name: "Home",
            component: HelloWorld
        },
        
    ]
})

createApp(App).use(router).mount('#app')
