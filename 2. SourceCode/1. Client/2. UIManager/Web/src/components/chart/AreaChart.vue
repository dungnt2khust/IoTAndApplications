<template lang="">
  <div class="chart">
    <apexchart
      width="100%"
      type="area"
      :options="chartOptions"
      style="overflow:hidden;"
      :series="series"
    ></apexchart>
  </div>
</template>
<script>
export default {
  name: "Chart",
  props: {
    titlorderXs: {
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
    },e: {
      type: [Number, String],
      default: ""
    },
    categories: {
      type: Array,
      default: () => []
    },
    data1: {
      type: Array,
      default: () => []
    },
    name1: {
      type: [Number, String],
      default: ""
    },
    data2: {
      type: Array,
      default: () => []
    },
    name2: {
      type: [Number, String],
      default: ""
    }
  },
  data() {
    return {
      series: [
        {
          name: this.name1,
          data: this.data1
        },
        {
          name: this.name2,
          data: this.data2
        }
      ],
      chartOptions: {
        title: {
          text: this.title
        },
        chart: {
          // height: 350,
          type: "area"
        },
        dataLabels: {
          enabled: false
        },
        stroke: {
          curve: "smooth"
        },
        xaxis: {
          type: "datetime",
          categories: this.categories
        },
        tooltip: {
          x: {
            // format: "dd/MM/yy HH:mm"
            format: "dd/MM/yyyy"
          }
        }
      }
    };
  },
  mounted() {}
};
</script>
<style lang=""></style>
