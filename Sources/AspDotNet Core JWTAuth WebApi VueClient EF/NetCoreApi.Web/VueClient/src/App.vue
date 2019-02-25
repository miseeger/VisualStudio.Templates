<template>
    <div id="app">
        <div id="nav">
            <router-link to="/"><font-awesome-icon icon="home" />&nbsp;Home&nbsp;</router-link>|
            <router-link to="/testform">Test Form&nbsp;</router-link>|
            <a
                target="_blank"
                href="http://localhost:4746/api/reports/showreport"
            >Example Report&nbsp;</a>|
            <router-link to="/about"><font-awesome-icon icon="info-circle" />&nbsp;About</router-link>
        </div>
        <router-view/>
    </div>
</template>

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
</style>
