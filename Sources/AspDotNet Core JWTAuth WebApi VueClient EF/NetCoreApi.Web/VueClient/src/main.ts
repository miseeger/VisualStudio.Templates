import Vue from 'vue';
import BootstrapVue from 'bootstrap-vue';
import VueToastr from 'vue-toastr';

import App from './App.vue';
import router from './router';
import store from './store/store';
import './registerServiceWorker';

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'vue-toastr/dist/vue-toastr.min.css';

import { FontAwesomeIcon, FontAwesomeLayers, FontAwesomeLayersText } from '@/assets/iconPack';

Vue.component('font-awesome-icon', FontAwesomeIcon);
Vue.component('font-awesome-layers', FontAwesomeLayers);
Vue.component('font-awesome-layers-text', FontAwesomeLayersText);

Vue.config.productionTip = false;

Vue.use(BootstrapVue);
Vue.use(VueToastr, {
    defaultPosition: "toast-top-right",
    defaultTimeout: 3000,
    defaultProgressBar: false,
    defaultProgressBarValue: 0,
    defaultCloseOnHover: false
});

new Vue({
    router,
    store,
    render: (h) => h(App),
}).$mount('#app');
