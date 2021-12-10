<template lang="">
  <div
    class="base-content-area defaultScrollbar"
    :style="customizeStyle(styleWrapperCustom)"
  >
    <div class="fx-col w-full h-full " :style="customizeStyle(styleCustom)">
      <div v-if="title" class="area-header">
        <div class="area-header__title">
          {{ title }}
        </div>
        <div class="flex-1">
          <slot name="header"></slot>
        </div>
      </div>
      <div class="area-content fx-wrap p-10">
        <slot name="content"></slot>
      </div>
      <div class="area-footer">
        <slot name="footer"></slot>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "BaseContentArea",
  props: {
    title: {
      type: String,
      default: null
    },
    pos: {
      type: String,
      default: null
    },
    width: {
      type: [Number, String],
      default: null
    },
    height: {
      type: [Number, String],
      default: null
    },
    minWidth: {
      type: [Number, String],
      default: null
    },
    minHeight: {
      type: [Number, String],
      default: null
    },
    maxWidth: {
      type: [Number, String],
      default: null
    },
    maxHeight: {
      type: [Number, String],
      default: null
    },
    bgColor: {
      type: String,
      default: null
    },
    bgWrapperColor: {
      type: String,
      default: null
    },
    pHor: {
      type: String,
      default: null
    },
    pVer: {
      type: String,
      default: null
    },
    pTop: {
      type: String,
      default: null
    },
    pBot: {
      type: String,
      default: null
    },
    pLeft: {
      type: String,
      default: null
    },
    pRight: {
      type: String,
      default: null
    },
    mHor: {
      type: String,
      default: null
    },
    mVer: {
      type: String,
      default: null
    },
    mTop: {
      type: String,
      default: null
    },
    mBot: {
      type: String,
      default: null
    },
    mLeft: {
      type: String,
      default: null
    },
    mRight: {
      type: String,
      default: null
    }
  },
  data() {
    return {
      styleCustom: {
        "background-color": this.bgColor,
        "height": this.height,
        "width": this.width,
        "min-width": this.minWidth,
        "min-height": this.minHeight,
        "max-width": this.maxWidth,
        "max-height": this.maxHeight
      },
      styleWrapperCustom: {
        "background-color": this.bgWrapperColor,
        "padding-left": this.pLeft ? this.pLeft : this.pHor,
        "padding-right": this.pRight ? this.pRight : this.pHor,
        "padding-bottom": this.pBot ? this.pBot : this.pVer,
        "padding-top": this.pTop ? this.pTop : this.pVer,
        "margin-left": this.mLeft ? this.mLeft : this.mHor,
        "margin-right": this.mRight ? this.mRight : this.mHor,
        "margin-bottom": this.mBot ? this.mBot : this.mVer,
        "margin-top": this.mTop ? this.mTop : this.mVer
      }
    };
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/basecontentarea/basecontentarea.scss";
</style>
