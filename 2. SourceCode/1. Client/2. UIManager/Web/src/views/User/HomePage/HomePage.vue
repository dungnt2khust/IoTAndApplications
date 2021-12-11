<template lang="">
  <base-content-area class="jus-c-center p-t-20" width="90%">
    <template v-slot:content>
      <ed-row class="fx-wrap gut-12 gut-v-12" :rowW="12">
        <ed-col :orderLg="1" :colLg="4" :colXl="6" :colXs="12" :colSm="12">
          <base-content-frame
            title=" Nhịp tim 7 ngày gần đây"
            bgColor="#fff"
            height="100%"
            :autoScroll="false"
            pHor="10px"
            pVer="10px"
            boxShadow="2px 2px 10px 2px rgba(0, 0, 0, 0.2)"
          >
            <template v-slot:content>
              <ed-bar-chart
                name="Nhịp tim"
                :data="heartBeatData"
                :categories="heartBeatDate"
              />
            </template>
          </base-content-frame>
        </ed-col>
        <ed-col :orderLg="3" :colLg="4" :colXl="6" :colXs="12" :colSm="12">
          <div class="fx-wrap gut-12 gut-v-12">
            <ed-col :colLg="12" :colXl="12" :colXs="6" :colSm="12">
              <base-content-frame
                title="Báo cáo hôm nay"
                bgColor="#fff"
                :autoScroll="false"
                pHor="10px"
                pVer="10px"
                boxShadow="2px 2px 10px 2px rgba(0, 0, 0, 0.2)"
              >
                <template v-slot:content>
                  <ed-button
                    class="m-t-20"
                    label="Nhịp tim cao nhất"
                    :type="1"
                    txtPos="center"
                    bgColor="#5DCE00"
                  />
                  <!-- <div class="txt-smb-1 txt-s-20 txt-align-center m-t-20">Hãy đo nhịp tim mới</div> -->
                  <div class="txt-smb-1 txt-s-30 txt-align-center">90</div>
                  <ed-button
                    class="m-t-20"
                    label="Nhịp tim thấp nhất"
                    :type="2"
                    txtPos="center"
                    bgColor="#A2E44C"
                  />
                  <!-- <div class="txt-smb-1 txt-s-20 txt-align-center m-t-20">Hãy đo nhịp tim mới</div> -->
                  <div class="txt-smb-1 txt-s-30 txt-align-center">77</div>
                </template>
              </base-content-frame>
            </ed-col>
            <ed-col :colLg="12" :colXl="12" :colXs="6" :colSm="12">
              <base-content-frame
                title="Thông tin cho bạn"
                bgColor="#fff"
                height="100%"
                :autoScroll="false"
                pHor="10px"
                pVer="10px"
                boxShadow="2px 2px 10px 2px rgba(0, 0, 0, 0.2)"
              >
                <template v-slot:content>
                  <ed-button
                    label="Nhịp tim của bạn cao vãi lìn ra. Đi bệnh viện đê."
                    :type="1"
                    bgColor="#00E396"
                  />
                  <ed-button
                    class="m-t-20"
                    label="Nhịp tim của bạn cao vãi lìn ra. Đi bệnh viện đê."
                    :type="1"
                    bgColor="#008FFB"
                  />
                </template>
              </base-content-frame>
            </ed-col>
          </div>
        </ed-col>
        <ed-col :orderLg="2" :colLg="4" :colXl="12" :colXs="12" :colSm="12">
          <base-content-frame
            title="Cao nhất, thấp nhất trong ngày"
            bgColor="#fff"
            height="100%"
            :autoScroll="false"
            pHor="10px"
            pVer="10px"
            boxShadow="2px 2px 10px 2px rgba(0, 0, 0, 0.2)"
          >
            <template v-slot:content>
              <ed-area-chart
                name1="Cao nhất"
                name2="Thấp nhất"
                :data1="areaData1"
                :data2="areaData2"
                :categories="areaCategories"
              />
            </template>
          </base-content-frame>
        </ed-col>
      </ed-row>
    </template>
  </base-content-area>
</template>
<script>
export default {
  name: "HomePage",
  data() {
    return {
      heartBeatDate: [
        "01/12",
        "04/12",
        "05/12",
        "10/12",
        "12/12",
        "20/12",
        "22/12",
        "31/12"
      ],
      heartBeatData: [88, 89, 91, 82, 85, 79, 90, 92],
      areaCategories: [
        "2021-12-14T00:00:00.000Z",
        "2021-12-15T01:30:00.000Z",
        "2021-12-16T02:30:00.000Z",
        "2021-12-17T03:30:00.000Z",
        "2021-12-18T04:30:00.000Z",
        "2021-12-19T05:30:00.000Z",
        "2021-12-20T06:30:00.000Z"
      ],

      areaData1: [88, 79, 80, 90, 83, 85, 77],
      areaData2: [90, 81, 85, 81, 90, 79, 77]
    };
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/views/HomePage/homepage.scss";
</style>
