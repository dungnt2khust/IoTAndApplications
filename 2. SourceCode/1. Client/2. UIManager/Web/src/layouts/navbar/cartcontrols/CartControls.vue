<template lang="">
  <div class="cartcontrols pos-relative">
    <ed-icon class="pos-relative" :size="30" :tooltip="$t('i18nCart.Cart')">
      <ed-blur id="cart" v-model="showCart" :zIndex="1" />
      <span class="txt-b-0 txt-s-24 m-r-20"
        ><i class="fas fa-shopping-cart"></i
      ></span>
      <ed-icon
        v-if="listCart.length"
        style="z-index: 0"
        class="pos-absolute"
        bgColor="red"
        top="0"
        right="0"
        translate="10%, -10%"
        borderRad="8px"
        txtSize="12px"
        txtColor="#fff"
        :size="18"
      >
        {{ listCart.length }}
      </ed-icon>
    </ed-icon>
    <BaseContentFrame
      v-if="showCart"
      class="blurable pos-absolute p-10 fx-col aln-i-sbtn"
      tabindex="0"
      width="300px"
      minHeight="200px"
      top="100%"
      right="0"
      boxShadow="0px 0px 15px 10px rgba(162,228,76, 0.5)"
    >
      <template v-slot:content>
        <div class="list-notify defaultScrollbar">
          <div 
            v-for="(cart, index) in listCart.slice().reverse()"
            class="list-notify__item m-r-10 p-l-10"
            :key="index"
          >
            <div class="list-notify__title m-r-10">{{ cart.Title }}</div>
            <div class="list-notify__content">{{ cart.Content }}</div>
          </div>
          <div v-if="!listCart.length">
            {{ $t("i18nCart.NotHaveProduct") }}
          </div>
        </div>
      </template>
      <template v-slot:footer>
        <ed-row class="fx-row jus-c-sbtn">
          <ed-button :label="$t('i18nCart.Checkout')" :type="3" />
          <ed-button :label="$t('i18nCart.Cart')" :type="3" />
        </ed-row>
      </template>
    </BaseContentFrame>
  </div>
</template>
<script>
export default {
  name: "CartControls",
  data() {
    return {
      listCart: [],
      showCart: false
    };
  }
};
</script>
<style lang="scss"></style>
