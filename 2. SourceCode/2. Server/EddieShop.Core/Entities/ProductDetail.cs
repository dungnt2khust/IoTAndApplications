using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class ProductDetail : BaseEntity
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid ProductDetailID { get; set; }

        /// <summary>
        /// Tham chiếu người dùng
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Tham chiếu sản phẩm
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// Bình luận
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Đánh giá
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Yêu thích
        /// </summary>
        public int Like { get; set; }
    }
}
