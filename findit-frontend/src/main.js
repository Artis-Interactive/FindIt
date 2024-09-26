import { createApp } from 'vue'
import App from './App.vue'
import './index.css'
import { createRouter, createWebHistory } from 'vue-router'
import SignUp from './components/SignUp.vue'
import BusinessAccountRegistrationForm from './components/BusinessAccountRegistrationForm.vue'

const router = createRouter({
	history: createWebHistory(),
	routes: [
		{
			path: "/",
			name: "Inicio",
			component: SignUp

        },
        {
            path: "/business/register",
            name: "Crear Empresa",
            component: BusinessAccountRegistrationForm
		}
	],
});


createApp(App).use(router).mount('#app')
