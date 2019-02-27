<template>
    <div class="col-md-4 container">
        <br>
        <div class="card">
            <div class="card-header">
                <h4>Test Form*</h4>
            </div>
            <div class="card-body">
                <vue-form-generator :schema="schema" :model="model" :options="formOptions"></vue-form-generator>
            </div>
            <div class="card-footer text-muted">
                <a
                    href="https://github.com/vue-generators/vue-form-generator"
                    class="card-link"
                >*generated with Vue-Form-Generator</a>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import VueFormGenerator from "vue-form-generator";
import "vue-form-generator/dist/vfg.css";

Vue.use(VueFormGenerator);

export default Vue.extend({
    components: {
        "vue-form-generator": VueFormGenerator.component
    },
    data() {
        return {
            model: {
                id: 1,
                name: "John Doe",
                password: "J0hnD03!x4",
                skills: ["Javascript", "VueJS"],
                email: "john.doe@gmail.com",
                status: true
            },
            schema: {
                fields: [
                    {
                        type: "input",
                        inputType: "text",
                        label: "ID (disabled text field)",
                        model: "id",
                        readonly: true,
                        disabled: true
                    },
                    {
                        type: "input",
                        inputType: "text",
                        label: "Name",
                        model: "name",
                        placeholder: "Your name",
                        featured: true,
                        required: true,
                        validator: VueFormGenerator.validators.string
                    },
                    {
                        type: "input",
                        inputType: "password",
                        label: "Password",
                        model: "password",
                        min: 6,
                        required: true,
                        hint: "Minimum 6 characters",
                        validator: VueFormGenerator.validators.string
                    },
                    {
                        type: "select",
                        label: "Skills",
                        model: "skills",
                        values: ["Javascript", "VueJS", "CSS3", "HTML5"]
                    },
                    {
                        type: "input",
                        inputType: "email",
                        label: "E-mail",
                        model: "email",
                        placeholder: "User's e-mail address",
                        validator: VueFormGenerator.validators.email
                    },
                    {
                        type: "checkbox",
                        label: "Status",
                        model: "status",
                        default: true
                    }
                ]
            },
            formOptions: {
                validateAfterLoad: true,
                validateAfterChanged: true,
                validateAsync: true
            }
        };
    }
});
</script>

<style lang="scss" scoped>
#app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
}
</style>
