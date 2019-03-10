<template>
<div>
    <br>
    <b-row class="justify-content-center">
        <br/><br/>
        <reset-password-form></reset-password-form>
    </b-row>
</div>    
</template>

<script lang="ts">
import Vue from "vue";
import ResetPasswordForm from "@/components/ResetPasswordForm.vue";

export default Vue.extend({
    components: {
        ResetPasswordForm
    }
});
</script>


