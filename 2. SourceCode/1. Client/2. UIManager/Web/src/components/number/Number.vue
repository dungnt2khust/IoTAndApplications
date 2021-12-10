<template lang="">
  <div class="number fx-row aln-i-center" :class="{disable: disable}">
    <div
      class="number__minus fx-center"
      :class="{ 'number--disable': value == min }"
      @click="decreaseNum()"
    >
      <div class="mi-24">
        <div class="mi-minus"></div>
      </div>
    </div>
    <input
      class="number__value txt-smb-1 txt-s-16 mi-30"
      type="number"
      :readonly="disable"
      :disabled="disable"
      @blur="changeNum($event)"
      :value="value"
    />
    <div
      class="number__plus fx-center"
      :class="{ 'number--disable': value == max }"
      @click="increaseNum()"
    >
      <div class="mi-24">
        <div class="mi-plus"></div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Number",
  props: {
    value: {
      type: [String, Number],
      default: null
    },
    max: {
      type: [Number, String],
      default: null
    },
    min: {
      type: [Number, String],
      default: null
    },
    disable: {
      type: Boolean,
      default: false
    }
  },
  methods: {
    /**
     * Blur input
     * CreatedBy: NTDUNG (02/12/2021)
     */
    changeNum(e) {
      var value = e.target.value;
      if (this.max !== undefined && +value > this.max) value = this.max;
      if (this.min !== undefined && +value < this.min) value = this.min
      this.$emit("input", value);
    },
    /**
     * Tăng
     * CreatedBy: NTDUNG (02/12/2021)
     */
    increaseNum() {
      if (!this.disable)
        if (this.max !== undefined) {
          if (this.value < this.max) this.$emit("input", this.value + 1);
        } else {
          this.$emit("input", this.value + 1);
        }
    },
    /**
     * Giảm
     * CreatedBy: NTDUNG (02/12/2021)
     */
    decreaseNum() {
      if (!this.disable)
        if (this.min !== undefined) {
          if (this.value > this.min) this.$emit("input", this.value - 1);
        } else {
          this.$emit("input", this.value - 1);
        }
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/number/number.scss";
</style>
