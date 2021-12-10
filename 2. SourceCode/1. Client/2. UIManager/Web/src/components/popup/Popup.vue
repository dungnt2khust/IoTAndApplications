<template lang="">
  <div class="popup">
    <FullScreen>
      <BaseContentFrame :autoScroll="autoScroll">
        <template v-slot:content>
          <div class="popup__header fx-s-between">
            <div class="popup__title">{{ title }}</div>
            <slot name="header"></slot>
          </div>
          <div class="popup__content">
            <slot name="content"></slot>
          </div>
          <div class="popup__footer">
            <slot name="footer"></slot>
          </div>
        </template>
      </BaseContentFrame>
    </FullScreen>
  </div>
</template>
<script>
export default {
  name: "Popup",
  props: {
    title: {
      type: String,
      default: ""
    },
    autoScroll: {
      type: Boolean,
      default: true
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/popup/popup.scss";
</style>
