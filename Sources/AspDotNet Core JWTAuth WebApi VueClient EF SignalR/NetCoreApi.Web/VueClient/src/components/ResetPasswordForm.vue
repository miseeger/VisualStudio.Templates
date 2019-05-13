<template>
    <div class="row">
        <b-card title="Reset Your Password" style="max-width: 40rem;" class="mb-4 text-left">
            <form @submit.prevent="resetPassword" class="p-2">
                <b-alert
                    variant="danger"
                    :show="errors !== null"
                    dismissible
                    @dismissed="errors = null"
                >
                    <div v-for="(error, index) in errors" :key="index">
                        <font-awesome-icon
                            icon="exclamation-triangle"
                            :style="{ color: 'darkred' }"
                        />
                        &nbsp;{{ error }}
                    </div>
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
                    <b-button variant="primary" type="submit">Reset</b-button>
                </b-form-group>
            </form>
        </b-card>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import { IErrors } from "@/interfaces/IErrors";

export default Vue.extend({
    name: "register-form",
    data() {
        return {
            code: "",
            email: "",
            password: "",
            confirmPassword: "",
            errors: null as IErrors | null
        };
    },
    created() {
        this.email = this.$route.query.email as string;
        this.code = this.$route.query.code as string;
    },
    methods: {
        resetPassword() {
            const payload = {
                Code: this.code,
                Email: this.email,
                Password: this.password,
                ConfirmPassword: this.confirmPassword
            };

            this.$store
                .dispatch("auth/resetPassword", payload)
                .then(response => {
                    this.errors = null;
                    this.code = "";
                    this.email = "";
                    this.password = "";
                    this.confirmPassword = "";
                    this.$router.push("resetpasswordsuccess");

                    // this.$emit("success");
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
        }
    }
});
</script>