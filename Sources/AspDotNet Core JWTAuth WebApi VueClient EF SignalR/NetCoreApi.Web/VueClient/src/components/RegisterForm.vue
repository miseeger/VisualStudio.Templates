<template>
    <form @submit.prevent="submit" class="p-2">
        <b-alert variant="danger" :show="errors !== null" dismissible @dismissed="errors = null">
            <div v-for="(error, index) in errors" :key="index"><font-awesome-icon icon="exclamation-triangle" :style="{ color: 'darkred' }"/>&nbsp;{{ error }}</div>
        </b-alert>
        <b-form-group label="E-mail">
            <b-form-input v-model.trim="email"/>
        </b-form-group>
        <b-form-group label="Password">
            <b-form-input v-model.trim="password" type="password"/>
        </b-form-group>
        <b-form-group label="Confirm Password">
            <b-form-input v-model.trim="confirmPassword" type="password"/>
        </b-form-group>
        <b-form-group>
            <b-button variant="primary" type="submit" :disabled="auth.loading">Register</b-button>
            <b-button variant="default" @click="close" :disabled="auth.loading">Cancel</b-button>
        </b-form-group>
    </form>
</template>

<script lang="ts">
import Vue from "vue";
import { mapState } from "vuex";
import { IErrors } from "@/interfaces/IErrors";

export default Vue.extend({
    name: "register-form",
    data() {
        return {
            email: "",
            password: "",
            confirmPassword: "",
            errors: null as IErrors | null
        };
    },
    computed: {
        ...mapState(['auth']),
    },
    methods: {
        submit() {
            const payload = {
                Email: this.email,
                Password: this.password,
                ConfirmPassword: this.confirmPassword
            };

            this.$store
                .dispatch("auth/register", payload)
                .then(response => {
                    this.errors = null;
                    this.email = "";
                    this.password = "";
                    this.confirmPassword = "";

                    this.$emit("success");
                })
                .catch(error => {
                    console.log(error.data);
                    if (
                        typeof error.data === "string" ||
                        error.data instanceof String
                    ) {
                        this.errors = { error: error.data };
                    } else {
                        this.errors = error.data;
                    }
                });
        },
        close() {
            this.errors = null;
            this.$emit("close");
        }
    }
});
</script>

