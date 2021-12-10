import ProductAPI from '@/api/components/Product/ProductAPI.js'

export default {
  methods: {
    /**
     * Lấy dữ liệu danh sách sản phẩm
     * CreatedBy: NTDUNG (02/11/2021)
     */
    getListProduct(pageNum = 1, pageSize = 10, filterString = "", width = "100px", height = "100px") {
      return ProductAPI.getFilterPaging(filterString, pageNum, pageSize)
        .then(res => {
          if (res && res.data && res.data.Success) {
            this.products = res.data.Data.Records;
            this.products = this.products.map(product => {
              if (product.Image) {
                var src = "data:image/gif;base64," + product.Image;
                product.Image = {
                  src: src,
                  width: width,
                  height: height
                };
              }
              return product;
            });
            return Promise.resolve(this.products);
          }
          return Promise.resolve(null);
        });
    }
  }
};
