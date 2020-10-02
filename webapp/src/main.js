import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';
import App from './App.vue';
import 'foundation-sites/dist/css/foundation.min.css';
import HelloWorld from './components/HelloWorld';
import AboutPage from './components/AboutPage';
import NoteDisplay from './components/NoteDisplay';

const routes = [
  {path: '/', component: HelloWorld},
  {path: '/note', component: NoteDisplay},
  {path: '/about', component: AboutPage}
];

const router = createRouter({
    history: createWebHistory(),
    routes: routes
  }
);

createApp(App).use(router).mount('#app');
