<template lang="">
  <div
    class="blur w-full h-full pos-absolute"
    :style="[{cursor: 'inherit !important'}, customizeStyle(styleCustom)]"
  >
    <label
      class="block w-full h-full"
      style="cursor: inherit !important"
      :for="id"
    ></label>
    <input
      :id="id"
      ref="inputBlur"
      type="text"
      class="w-0 h-0"
      v-on="inputListeners"
    />
  </div>
</template>
<script>
export default {
  name: "Blur",
  props: {
    id: {
      type: String,
      default: null
    },
    value: {
      type: Boolean,
      default: false
    },
    duration: {
      type: Number,
      default: 100
    },
    zIndex: {
      type: Number,
      default: null
    }
  },
  data() {
    return {
      timeoutBlur: null,
      elementSave: null,
      styleCustom: {
          'z-index': this.zIndex
      }
    };
  },

  computed: {
    /**
     * Lắng nghe sự kiện input
     * CreatedBy: NTDUNG (30/11/2021)
     */
    inputListeners() {
      return Object.assign({}, this.listeners, {
        blur: e => {
          this.timeoutBlur = setTimeout(() => {
            var relatedTarget = e.relatedTarget;
            if (
              relatedTarget &&
              this.checkElementNestedByClass(relatedTarget, "blurable")
            ) {
              this.$refs.inputBlur.focus();
            } else this.$emit("input", false);
          }, this.duration);
        },
        click: () => {
          clearTimeout(this.timeoutBlur);
          if (this.value) this.$emit("input", false);
          else {
            this.$emit("input", true);
            this.$refs.inputBlur.focus();
          }
        }
      });
    }
  }
};
</script>
<style lang=""></style>
