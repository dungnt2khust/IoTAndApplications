<template lang="">
  <div
    :class="[
      'col',
      'col-w-' + colW,
      'col-sm-' + colSm,
      'col-xs-' + colXs,
      'col-xl-' + colXl,
      'col-lg-' + colLg,
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
  name: "Col",
  props: {
    colW: {
      type: [Number, String],
      default: 12
    },
    colXs: {
      type: [Number, String],
      default: 0
    },
    colXl: {
      type: [Number, String],
      default: 0
    },
    colSm: {
      type: [Number, String],
      default: 0
    },
    colLg: {
      type: [Number, String],
      default: 0
    },
    orderXs: {
      type: [Number, String],
      default: 20
    },
    orderXl: {
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
@mixin setCol($name) {
  @for $col from 1 to 13 {
    $flexBasis: percentage(1 / 12 * $col);
    .#{"col-" + $name + "-" + $col} {
      flex-basis: $flexBasis !important;
    }
  }
}
@include setCol(w);

@media (max-width: 739px) {
  @include setCol(sm);
}
/* >= Tablet */
@media (min-width: 740px) {
}
/* PC medium resolution > */
@media (min-width: 1113px) {
}
/* Tablet - PC low resolution */
@media (min-width: 740px) and (max-width: 1023px) {
  @include setCol(xs);
}
/* > PC low resolution */
@media (min-width: 1024px) and (max-width: 1239px) {
  @include setCol(xl);
}
/* PC height resolution */
@media (min-width: 1240px) {
   @include setCol(lg);
}
</style>
