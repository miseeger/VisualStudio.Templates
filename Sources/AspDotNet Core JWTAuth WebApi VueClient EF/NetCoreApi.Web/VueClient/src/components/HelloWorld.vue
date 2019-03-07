<template>
    <div class="hello">
        <h2>{{ msg }}</h2>
        <p>
            This welcome page was made with plain Boostrap 4 - The auth dialogs and pages are made with Boostrap Vue.
        </p>
        <div class="row justify-content-md-center">
            <div class="col-md-6">
                <div>&nbsp;</div>
                <div class="alert alert-warning" v-if="loading">
                    <font-awesome-icon icon="cog" spin /> 
                    &nbsp;loading Album from API ...
                </div>
                <div class="alert alert-success" v-else>
                    Random album: {{ album.title }} by {{ album.artistName }}
                </div>
                <button class="btn btn-sm btn-success" @click="loadRandomAlbum"><font-awesome-icon icon="redo" /> &nbsp;Another random album</button>
                <div>&nbsp;</div>
            </div>
        </div>
        <p>
            For a guide and recipes on how to configure / customize this project,
            <br>check out the
            <a
                href="https://cli.vuejs.org"
                target="_blank"
                rel="noopener"
            >vue-cli documentation</a>.
        </p>
        <h3>Installed CLI Plugins</h3>
        <ul>
            <li>
                <a
                    href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-babel"
                    target="_blank"
                    rel="noopener"
                >babel</a>
            </li>
            <li>
                <a
                    href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-typescript"
                    target="_blank"
                    rel="noopener"
                >typescript</a>
            </li>
            <li>
                <a
                    href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-pwa"
                    target="_blank"
                    rel="noopener"
                >pwa</a>
            </li>
            <li>
                <a
                    href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-unit-jest"
                    target="_blank"
                    rel="noopener"
                >unit-jest</a>
            </li>
            <li>
                <a
                    href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-e2e-cypress"
                    target="_blank"
                    rel="noopener"
                >e2e-cypress</a>
            </li>
        </ul>
        <h3>Essential Links</h3>
        <ul>
            <li>
                <a href="https://vuejs.org" target="_blank" rel="noopener">Core Docs</a>
            </li>
            <li>
                <a href="https://forum.vuejs.org" target="_blank" rel="noopener">Forum</a>
            </li>
            <li>
                <a href="https://chat.vuejs.org" target="_blank" rel="noopener">Community Chat</a>
            </li>
            <li>
                <a href="https://twitter.com/vuejs" target="_blank" rel="noopener">Twitter</a>
            </li>
            <li>
                <a href="https://news.vuejs.org" target="_blank" rel="noopener">News</a>
            </li>
        </ul>
        <h3>Ecosystem</h3>
        <ul>
            <li>
                <a href="https://router.vuejs.org" target="_blank" rel="noopener">vue-router</a>
            </li>
            <li>
                <a href="https://vuex.vuejs.org" target="_blank" rel="noopener">vuex</a>
            </li>
            <li>
                <a
                    href="https://github.com/vuejs/vue-devtools#vue-devtools"
                    target="_blank"
                    rel="noopener"
                >vue-devtools</a>
            </li>
            <li>
                <a href="https://vue-loader.vuejs.org" target="_blank" rel="noopener">vue-loader</a>
            </li>
            <li>
                <a
                    href="https://github.com/vuejs/awesome-vue"
                    target="_blank"
                    rel="noopener"
                >awesome-vue</a>
            </li>
        </ul>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import * as AlbumService from "@/services/AlbumService";

export default Vue.extend({
    data() {
        return {
            album: {},
            loading: false
        };
    },
    props: {
        msg: {
            type: String
        }
    },
    created(): void {
        let vm = this;
        this.loadRandomAlbum();
        this.$toastr.s("HelloWorld was created ... !!!");
    },
    methods: {
        loadRandomAlbum(): void {
            this.loading = true;

            AlbumService.getAlbumById(Math.floor(Math.random() * 256)).then(
                response => {
                    this.album = response.data;

                    // a short delay just to show the "load"-label ;-)
                    setTimeout(() => {
                        this.loading = false;
                    }, 1000);
                }
            );
        }
    }
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
    margin: 40px 0 0;
}
ul {
    list-style-type: none;
    padding: 0;
}
li {
    display: inline-block;
    margin: 0 10px;
}
a {
    color: #42b983;
}
</style>
