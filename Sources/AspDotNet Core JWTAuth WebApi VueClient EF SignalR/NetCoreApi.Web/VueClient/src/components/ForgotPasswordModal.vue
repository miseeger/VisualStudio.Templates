<template>
    <b-modal v-model="show" hide-header hide-footer no-close-on-backdrop no-close-on-esc>
        <forgot-password-form @close="close"/>
    </b-modal>
</template>

<script lang="ts">
import Vue from "vue";
import ForgotPasswordForm from "./ForgotPasswordForm.vue";
import RegisterForm from "./RegisterForm.vue";

export default Vue.extend({
    name: "forgot-password-modal",
    components: {
        ForgotPasswordForm
    },
    props: {
        show: {
            type: Boolean,
            required: true
        }
    },
    methods: {
        close() {
            this.$store.commit("auth/HIDE_FORGOT_PASSWORD_MODAL");
            let query = Object.assign({}, this.$route.query);
            delete query.redirect;
            this.$router.push({ query: query });
        }
    }
});
</script>

