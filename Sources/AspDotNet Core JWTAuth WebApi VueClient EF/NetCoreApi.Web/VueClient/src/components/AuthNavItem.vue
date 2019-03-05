<template>
    <b-nav-item-dropdown v-if="isAuthenticated" right>
        <template slot="button-content">
            <font-awesome-icon icon="user"/>
            &nbsp;{{ loggedInUser }}
        </template>
        <b-dropdown-item @click="logout">
            <font-awesome-icon icon="sign-out-alt"/>
            Logout
        </b-dropdown-item>
    </b-nav-item-dropdown>
    <b-nav-item v-else @click="login">
        <font-awesome-icon icon="user"/>
        Login / register
    </b-nav-item>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters } from "vuex";

export default Vue.extend({
    name: "auth-nav-item",
    computed: {
        ...mapGetters('auth', ['isAuthenticated', 'loggedInUser']),
    },
    methods: {
        login() {
            this.$store.commit("auth/SHOW_AUTH_MODAL");
        },
        logout() {
            this.$store.dispatch("auth/logout").then(() => {
                if (this.$route.meta.requiresAuth) {
                    this.$router.push("/");
                }
            });
        }
    }
});
</script>
