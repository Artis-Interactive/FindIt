import { createApp } from 'vue'
import App from './App.vue'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap';
import { createRouter, createWebHistory } from 'vue-router'

import HelloWorld from './components/HelloWorld.vue'
import SignUp from './components/SignUp.vue'
import GeneralProductList from './components/GeneralProductList.vue';


const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: "/home",
            name: "Home",
            component: HelloWorld
        },
        {
            path: "/",
            name: "Login",
            component: GeneralProductList
        },
        {
			path: "/signup",
			name: "SignUp",
			component: SignUp

		},
        
    ]
});

createApp(App).use(router).mount('#app')
