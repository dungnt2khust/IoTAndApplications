<template lang="">
  <div
    class="button"
    v-on="tooltip ? tooltipListeners(tooltip) : {}"
    @click="handleButtonClick"
    :class="[`button--${type}`, { 'button--disable': disable }]"
    :style="customizeStyle(style)"
  >
    <div class="button__label">
      {{ label }}
    </div>
    <div class="button__sublabel">
      {{ subLabel }}
    </div>
  </div>
</template>
<script>
// Library
import commonFunction from "@/mixins/commonFunction.js";

export default {
  name: "Button",
  mixins: [commonFunction],
  props: {
    tooltip: {
      type: [String, Number],
      default: null
    },
    label: {
      type: String,
      default: "Button"
    },
    subLabel: {
      type: String,
      default: null
    },
    type: {
      type: [Number, String],
      default: 0
    },
    width: {
      type: String,
      default: null
    },
    txtPos: {
      type: String,
      default: null
    },
    method: {
      type: Function,
      default: () => {}
    },
    disable: {
      type: Boolean,
      default: false
    },
    bgColor: {
      type: String,
      default: null
    }
  },
  data() {
    return {
      style: {
        width: this.width,
        "text-align": this.txtPos,
        "background-color": this.bgColor
      }
    };
  },
  methods: {
    /**
     * Xử lý ấn nút
     * CreatedBy: NTDUNG (01/12/2021)
     */
    handleButtonClick() {
      if (!this.disable) this.method();
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/button/button.scss";
</style>
