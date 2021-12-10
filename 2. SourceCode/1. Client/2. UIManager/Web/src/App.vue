<template>
  <div id="app">
    <Header/>
    <Main/>
    <Tooltip/>
    <Loading/>
  </div>
</template>

<script>
// Components
import Header from "@/layouts/header/Header.vue"
import Main from "@/layouts/main/Main.vue"
import Tooltip from "@/components/tooltip/Tooltip.vue"
import Loading from "@/layouts/loading/Loading.vue"

// Plugins

export default {
  name: "App",
  components: {
    Header,
    Main,
    Tooltip,
    Loading
  } 
};
</script>
<style>
  @import url('./assets/css/main.css');
</style>
<style lang="scss">
  @import "@/assets/scss/common/common.scss";
</style>
