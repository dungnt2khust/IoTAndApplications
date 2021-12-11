<template lang="">
  <div class="chart">
    <apexchart
      width="98%"
      type="bar"
      :options="chartOptions"
      :series="series"
    ></apexchart>
  </div>
</template>
<script>
export default {
  name: "BarChart",
  props: {
    title: {
      type: [Number, String],
      default: ""
    },
    categories: {
      type: Array,
      default: () => []
    },
    data: {
      type: Array,
      default: () => []
    },
    name: {
      type: [Number, String],
      default: ""
    }
  },
  data() {
    return {
      chartOptions: {
        title: {
          text: this.title
        },
        chart: {
          id: "vuechart-example"
        },
        xaxis: {
          categories: this.categories
        }
      },
      series: [
        {
          name: this.name,
          data: this.data 
        }
      ]
    };
  },
  mounted() {}
};
</script>
<style lang=""></style>
