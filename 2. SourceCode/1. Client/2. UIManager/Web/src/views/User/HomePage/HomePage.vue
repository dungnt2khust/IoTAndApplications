<template lang="">
  <base-content-area class="jus-c-center" width="90%">
    <template v-slot:content>
      <div class="w-full">
        <ed-grid-product :products="listProductHot" />
      </div>
    </template>
  </base-content-area>
</template>
<script>
export default {
  name: "HomePage",
  data() {
    return {
      listProductHot: []
    };
  },
  mounted() {
    this.getGridProductHot();
  },
  methods: {
    login() {
      this.$router.push("/login");
    },
    /**
     * Lấy danh sách sản phẩm
     * CreatedBy: NTDUNG (01/12/2021)
     */
    getGridProductHot() {
      this.getListProduct()
        .then(res => {
          this.listProductHot = res;
        })
        .catch(err => {
          console.log(err);
        });
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/HomePage/homepage.scss";
</style>
