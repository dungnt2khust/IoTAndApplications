using System;
using System.Collections.Generic;
using System.Text;
using static EddieShop.Core.Attributes.EddieShopAttributes;

namespace EddieShop.Core.Entities
{
    public class Product : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public String ProductName { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [EddieUnique]
        public String ProductCode { get; set; }

        /// <summary>
        /// Đơn giá
        /// </summary>
        public int? Price { get; set; }

        /// <summary>
        /// Giá cũ
        /// </summary>
        public int? OldPrice { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        public int? TotalPrice { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ảnh chính
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Hiển thị giảm giá
        /// </summary>
        public int ShowDiscount{ get; set; }

        /// <summary>
        /// Giảm giá
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Sản phẩm yêu thích
        /// </summary>
        public int Hot { get; set; }

        /// <summary>
        /// Đã bán
        /// </summary>
        public int Sold { get; set; }

        /// <summary>
        /// Đánh giá
        /// </summary>
        public int Star { get; set; }

        /// <summary>
        /// Yêu thích
        /// </summary>
        public int Like { get; set; }
        #endregion
    }
}
