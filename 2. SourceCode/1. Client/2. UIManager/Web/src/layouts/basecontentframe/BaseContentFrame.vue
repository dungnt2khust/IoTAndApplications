<template lang="">
  <div class="base-content-frame defaultScrollbar" :style="customizeStyle(styleCustom)">
    <div v-if="title" class="area-header">
        <div class="area-header__title">
          {{ title }}
        </div>
        <div class="flex-1">
          <slot name="header"></slot>
        </div>
      </div> 
    <div class="frame__content box-sizing-b w-full h-full" :class="{defaultScrollbar: autoScroll}">
      <slot name="content"></slot>
    </div>
    <div class="frame__footer">
      <slot name="footer"></slot>
    </div>
  </div>
</template>
<script>

export default {
  name: "BaseContentFrame",
  props: {
    title: {
      type: [Number, String],
      default: null
    },
    width: {
      type: String,
      default: null
    },
    minWidth: {
      type: String,
      default: null
    },
    maxWidth: {
      type: String,
      default: null
    },
    height: {
      type: String,
      default: null
    },
    minHeight: {
      type: String,
      default: null
    },
    maxHeight: {
      type: String,
      default: null
    },
    bgColor: {
      type: String,
      default: null
    },
    borderRad: {
      type: String,
      default: null
    },
    top: {
      type: String,
      default: null
    },
    bottom: {
      type: String,
      default: null
    },
    left: {
      type: String,
      default: null
    },
    right: {
      type: String,
      default: null
    },
    border: {
      type: String,
      default: null
    },
    zIndex: {
      type: [Number, String],
      default: null
    },
    autoScroll: {
      type: Boolean,
      default: true
    },
    pTop: {
      type: [String, Number],
      default: null
    },
    pBottom: {
      type: [String, Number],
      default: null
    },
    pRight: {
      type: [String, Number],
      default: null
    },
    pLeft: {
      type: [String, Number],
      default: null
    },
    pHor: {
      type: [String, Number],
      default: null
    },
    pVer: {
      type: [String, Number],
      default: null
    },
    boxShadow: {
      type: String,
      default: null
    }
  },
  data() {
    return {
      styleCustom: {
        "width": this.width,
        "min-width": this.minWidth,
        "max-width": this.maxWidth,
        "height": this.height,
        "min-height": this.minHeight,
        "max-height": this.maxHeight,
        "background-color": this.bgColor,
        "border-radius": this.borderRad,
        "top": this.top,
        "bottom": this.bottom,
        "left": this.left,
        "right": this.right,
        "border": this.border,
        "z-index": this.zIndex,
        "padding-top": this.pTop ? this.pTop : this.pVer,
        "padding-bottom": this.pBottom ? this.pBottom : this.pVer,
        "padding-right": this.pRight ? this.pRight : this.pHor,
        "padding-left": this.pLeft ? this.pLeft : this.pHor,
        "box-shadow": this.boxShadow
      }
    };
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/basecontentframe/basecontentframe.scss";
</style>
