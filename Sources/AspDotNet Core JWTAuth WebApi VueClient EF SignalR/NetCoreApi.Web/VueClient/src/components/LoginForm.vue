<template>
    <form @submit.prevent="login" class="p-2">
        <b-alert
            variant="danger"
            :show="error !== null"
            dismissible
            @dismissed="error = null"
        >{{ error }}</b-alert>
        <b-alert
            variant="success"
            :show="registered && error === null"
            dismissible
        >Registration successful. Please login to continue.</b-alert>
        <p>Login with your e-mail address and password.</p>
        <b-form-group label="E-mail">
            <b-form-input v-model.trim="email"/>
        </b-form-group>
        <b-form-group label="Password">
            <b-form-input v-model.trim="password" type="password"/>
            <b-button variant="link" @click="forgotPassword">I forgot my password...</b-button>
        </b-form-group>
        <b-form-group>
            <b-button variant="primary" type="submit" :disabled="auth.loading">Login</b-button>
            <b-button variant="default" @click="close" :disabled="auth.loading">Cancel</b-button>
        </b-form-group>
    </form>
</template>

<script lang="ts">
import Vue from "vue";
import { mapState } from "vuex";
import { IErrors } from '@/interfaces/IErrors';

export default Vue.extend({
    name: "login-form",
    props: {
        registered: {
            type: Boolean,
            required: false
        }
    },
    data() {
        return {
            email: "",
            password: "",
            error: null as string | null
        };
    },
    computed: {
        ...mapState(['auth']),
    },
    methods: {
        login() {
            const payload = {
                email: this.email,
                password: this.password
            };

            this.$store
                .dispatch("auth/login", payload)
                .then(response => {
                    this.error = null;
                    this.email = "";
                    this.password = "";

                    if (this.$route.query.redirect) {
                        this.$router.push(
                            this.$route.query.redirect.toString()
                        );
                    }
                })
                .catch(error => {
                    this.error = error.data;
                });
        },
        forgotPassword(){
            this.close();
            this.$store.commit("auth/SHOW_FORGOT_PASSWORD_MODAL");
        },
        close() {
            this.$emit("close");
        }
    }
});
</script>

