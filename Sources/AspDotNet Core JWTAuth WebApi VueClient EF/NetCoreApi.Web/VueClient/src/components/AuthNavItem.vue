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

export default Vue.extend({
    name: "auth-nav-item",
    computed: {
        isAuthenticated(): boolean {
            return this.$store.getters.isAuthenticated;
        },
        loggedInUser(): string {
            return this.$store.getters.loggedInUser;
        }
    },
    methods: {
        login() {
            this.$store.commit("SHOW_AUTH_MODAL");
        },
        logout() {
            this.$store.dispatch("logout").then(() => {
                if (this.$route.meta.requiresAuth) {
                    this.$router.push("/");
                }
            });
        }
    }
});
</script>
