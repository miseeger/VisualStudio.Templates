<template>
    <div id="app">
        <div>
            <b-navbar toggleable="md" type="dark" variant="dark">
                <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
                <b-navbar-brand to="/">TypeScript SPA</b-navbar-brand>
                <b-collapse is-nav id="nav_collapse">
                    <b-navbar-nav>
                        <b-nav-item to="/testform">Test Form</b-nav-item>
                        <b-nav-item
                            target="_blank"
                            href="http://localhost:4746/api/reports/showreport">Example Report</b-nav-item>
                        <b-nav-item to="/about">
                            <font-awesome-icon icon="info-circle"/>&nbsp;About
                        </b-nav-item>
                    </b-navbar-nav>
                    <b-navbar-nav class="ml-auto mr-4">
                        <auth-nav-item/>
                    </b-navbar-nav>
                </b-collapse>
            </b-navbar>
        </div>

        <transition name="fade" mode="out-in">
            <router-view/>
        </transition>

        <auth-modal :show="showAuthModal"/>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import AuthNavItem from "./components/AuthNavItem";
import AuthModal from "./components/AuthModal";

export default Vue.extend({
    name: "app",
    components: {
        AuthNavItem,
        AuthModal
    },
    computed: {
        showAuthModal(): void {
            return this.$store.state.showAuthModal;
        }
    }
});
</script>

<style lang="scss">
#app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
}
#nav {
    padding: 30px;
    text-align: center;
    a {
        font-weight: bold;
        color: #2c3e50;
        &.router-link-exact-active {
            color: #42b983;
        }
    }
}
.about {
    text-align: center;
}

.home {
    text-align: center;
}

.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.3s ease-in-out;
}

.fade-enter,
.fade-leave-to {
    opacity: 0;
}
</style>
