module.exports = {
    outputDir: '../wwwroot',
    publicPath: "/",
    runtimeCompiler: true, // <-- set to true in order to get rid of vue-toastr warning
    chainWebpack: config => {
        // aspnet uses the other hmr so remove this one
        config.plugins.delete('hmr');
    }
}