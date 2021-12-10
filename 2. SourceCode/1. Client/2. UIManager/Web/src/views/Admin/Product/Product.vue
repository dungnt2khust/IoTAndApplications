<template lang="">
  <base-content-area
    class="jus-c-center"
    title="Quản lý sản phẩm"
    width="70%"
    bgColor="#fff"
  >
    <template v-slot:header>
      <div class="fx-row jus-c-fend">
        <ed-button width="fit-content" label="Thêm sản phẩm" type="1" />
      </div>
    </template>
    <template v-slot:content>
      <div class="fx-wrap w-full">
        <ed-row>
          <ed-select-box
            :options="options"
            v-model="currValue"
            width="200px"
            query="name"
          />
        </ed-row>
        <ed-row>
          <ed-list-grid
            class="m-t-20"
            :listData="listProduct"
            :dblClick="
              productID => {
                productDetail(productID);
              }
            "
            itemID="ProductID"
            query="ProductName"
          ></ed-list-grid>
        </ed-row>
      </div>
    </template>
  </base-content-area>
</template>
<script>
// Plugins
import ProductAPI from "@/api/components/Product/ProductAPI.js";

export default {
  name: "Product",
  data() {
    return {
      options: [
        { name: "Tất cả sản phẩm" },
        { name: "Hàng đổi trả" },
        { name: "Hàng tồn kho" },
        { name: "Hàng 2hand" }
      ],
      currValue: 0,
      listProduct: []
    };
  },
  mounted() {
    this.getProductsFilterPaging(this.currValue);
  },
  methods: {
    /**
     * Đi đến trang chi tiết sản phẩm
     * CreatedBy: NTDUNG (08/12/2021)
     */
    productDetail(productID) {
      this.$router.push(`/product-detail/${productID}`);
    },
    /**
     * Lấy dữ liệu danh sách sản phẩm
     * CreatedBy: NTDUNG (08/12/2021)
     */
    getProducts(filterString, pageNum, pageSize, filterData) {
      console.log(filterData);
      ProductAPI.getFilterPaging(filterString, pageNum, pageSize, filterData)
        .then(res => {
          if (res.data.Success) {
            this.listProduct = res.data.Data.Records;
          }
        })
        .catch(err => {
          console.log(err);
        });
    },
    /**
     * Tạo ra lọc cho danh sách sản phẩm
     * CreatedBy: NTDUNG (08/12/2021) */
    getProductsFilterPaging(option) {
      switch (option) {
        case 0:
          var filterData = {
            TotalFields: ["Price", "OldPrice"],
            RangeDates: [
              {
                FieldName: "ModifiedDate",
                FromDate: new Date(2021, 11, 22),
                ToDate: new Date(2021, 11, 24)
              }
            ]
          };
          this.getProducts("", 1, 10, filterData);
          break;
        case 1:
          var filterData = {
            TotalFields: ["Price", "OldPrice"],
          };
          this.getProducts("", 1, 10, filterData);
          break;
        case 2:
          var filterData = {
            TotalFields: ["Price", "OldPrice"],
          };
          this.getProducts("", 1, 1, filterData);
          break;
        case 3:
          var filterData = {
            TotalFields: ["Price", "OldPrice"],
          };
          this.getProducts("", 1, 2, filterData);
          break;
      }
    }
  },
  watch: {
    currValue: function(value) {
      this.getProductsFilterPaging(value);
    }
  }
};
</script>
<style lang=""></style>
