<template>
    <div>
        <b-jumbotron
            header="Reset succeeded!!!"
            lead="You have successfully reset your password and may proceed to log in."
        >
            <b-button variant="primary" @click="login">Login</b-button>
        </b-jumbotron>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({
    methods: {
        login () {
            this.$store.commit("auth/SHOW_AUTH_MODAL");
        },
    }
})
</script>

