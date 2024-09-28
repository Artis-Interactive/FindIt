import { createApp } from 'vue'
import App from './App.vue'
import './index.css'
import { createRouter, createWebHistory } from 'vue-router'
import SignUp from './components/SignUp.vue'

const router = createRouter({
	history: createWebHistory(),
	routes: [
		{
			path: "/",
			name: "Inicio",
			component: SignUp

		}
	],
});

createApp(App).use(router).mount('#app')
