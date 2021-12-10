<template lang="">
  <div class="header pos-relative">
    <div class="header__main">
      <Logo />
    </div> 
    <nav-bar />
  </div>
</template>
<script>
// Components
import NavBar from "@/layouts/navbar/NavBar.vue";
import Logo from "@/layouts/logo/Logo.vue";

export default {
  name: "Header",
  components: {
    NavBar,
    Logo
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/header/header.scss";
</style>
