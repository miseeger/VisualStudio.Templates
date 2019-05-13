<template>
    <form @submit.prevent="triggerEmail" class="p-2">
        <b-alert
            variant="danger"
            :show="error !== null"
            dismissible
            @dismissed="error = null"
        >{{ error }}</b-alert>
        <b-alert
            :show="dismissCountDown"
            dismissible
            variant="success"
            @dismissed="dismissCountDown=0"
            @dismiss-count-down="countDownChanged"
        >An email to reset your password was sent.</b-alert>
        <p>Enter your e-mail address to reset your password.</p>
        <b-form-group label="E-mail">
            <b-form-input v-model.trim="email"/>
        </b-form-group>
        <b-form-group>
            <b-button variant="primary" type="submit" :disabled="auth.loading">Send</b-button>
            <b-button variant="default" @click="close" :disabled="auth.loading">Close</b-button>
        </b-form-group>
    </form>
</template>

<script lang="ts">
import Vue from "vue";
import { mapState } from "vuex";
import { IErrors } from '@/interfaces/IErrors';

export default Vue.extend({
    name: "forgot-password-form",
    data() {
        return {
            email: "",
            emailSent: false,
            error: null as string | null,
            dismissSecs: 2,
            dismissCountDown: 0,
        };
    },
    computed: {
        ...mapState(['auth']),
    },
    methods: {
        countDownChanged(dismissCountDown: number) {
            this.dismissCountDown = dismissCountDown
        },
        triggerEmail() {
            const payload = {
                email: this.email
            };

            this.$store
                .dispatch("auth/forgotPassword", payload)
                .then(response => {
                    this.error = null;
                    this.email = "";
                    this.emailSent = true;
                    this.dismissCountDown = this.dismissSecs

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
        close() {
            this.$emit("close");
        }
    }
});
</script>

