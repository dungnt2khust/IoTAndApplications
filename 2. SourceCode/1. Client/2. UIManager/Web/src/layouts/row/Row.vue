<template lang="">
  <div
    :class="[
      'row fx-wrap',
      'row-w-' + rowW,
      'row-xs-' + rowXs,
      'row-sm-' + rowSm,
      'row-lg-' + rowLg, 
      'row-xl-' + rowXl,
      'order-lg-' + orderLg,
      'order-xs-' + orderXs,
      'order-sm-' + orderSm,
      'order-xl-' + orderXl
    ]"
    :style="customizeStyle(styleCustom)"
  >
    <slot></slot>
  </div>
</template>
<script>
export default {
  name: "Row",
  props: {
    rowW: {
      type: [Number, String],
      default: 12
    },
    rowXs: {
      type: [Number, String],
      default: 0
    },
    rowSm: {
      type: [Number, String],
      default: 0
    },
    rowLg: {
      type: [Number, String],
      default: 0
    },
    rowXl: {
      type: [Number, String],
      default: 0
    },
    orderXs: {
      type: [Number, String],
      default: 20
    },
    orderSm: {
      type: [Number, String],
      default: 20
    },
    orderLg: {
      type: [Number, String],
      default: 20
    },
    orderXl: {
      type: [Number, String],
      default: 20
    }, 
    height: {
      type: [Number, String],
      default: null
    }
  },
  data() {
    return {
      styleCustom: {
        height: this.height
      }
    };
  }
};
</script>
<style lang="scss">
@mixin setRow($name) {
  @for $row from 1 to 13 {
    $flexBasis: percentage(1 / 12 * $row);
    .#{"row-" + $name + "-" + $row} {
      flex-basis: $flexBasis !important;
    }
  }
}
@include setRow(w);
@media (max-width: 739px) {
  @include setRow(sm);
}
/* >= Tablet */
@media (min-width: 740px) {
}
/* PC medium resolution > */
@media (min-width: 1113px) {
}
/* Tablet - PC low resolution */
@media (min-width: 740px) and (max-width: 1023px) {
  @include setRow(xs);
}
/* > PC low resolution */
@media (min-width: 1024px) and (max-width: 1239px) {
  @include setRow(xl);
}
/* PC height resolution */
@media (min-width: 1240px) {
  @include setRow(lg);
}
</style>
