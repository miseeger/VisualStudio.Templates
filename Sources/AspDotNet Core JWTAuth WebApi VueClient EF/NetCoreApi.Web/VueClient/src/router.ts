import Vue from 'vue';
import store from "@/store/store";
import Router from 'vue-router';
import Home from './views/Home.vue';

Vue.use(Router);

const router = new Router({
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home,
        },
        {
            path: '/testform',
            name: 'testform',
            meta: { requiresAuth: true },
            component: () => import('./views/TestForm.vue'),
            
        },
        {
            path: '/resetpassword',
            name: 'resetpassword',
            component: () => import('./views/ResetPassword.vue'),
        },        
        {
            path: '/resetpasswordsuccess',
            name: 'resetpasswordsuccess',
            component: () => import('./views/ResetPasswordSuccess.vue'),
        },
        {
            path: '/about',
            name: 'about',
            // route level code-splitting
            // this generates a separate chunk (about.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () => import(/* webpackChunkName: "about" */ './views/About.vue'),
        },
    ],
});

// https://stackoverflow.com/questions/46908306/vuex-accessing-namespaced-module-getters-in-vue-router

router.beforeEach((to, from, next) => {
    if (to.matched.some(route => route.meta.requiresAuth))
    {
        if (!store.getters['auth/isAuthenticated'])
        {
            console.log(`Auth needed! ${from.path}, ${to.path}`);
            store.commit("auth/SHOW_AUTH_MODAL");
            next({ path: from.path, query: { redirect: to.path } });
        } else
        {
            next();
        }
    } else
    {
        next();
    }
});

export default router;
