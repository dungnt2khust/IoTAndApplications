<template lang="">
  <div class="chart">
    <apexchart 
      width="98%"
      type="radar"
      :options="chartOptions"
      :series="series"
    ></apexchart>
  </div>
</template>
<script>
export default {
  name: "Chart",
  data() {
    return {
      series: [
        {
          name: "Series 1",
          data: [80, 50, 30, 40, 100, 20]
        }
      ],
      chartOptions: {
        chart: {
          height: 350,
          type: "radar"
        },
        title: {
          // text: "Basic Radar Chart"
        },
        xaxis: {
          categories: ["January", "February", "March", "April", "May", "June"]
        }
      }
    };
  },
  mounted() {}
};
</script>
<style lang=""></style>
