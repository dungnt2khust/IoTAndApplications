using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class Meansure : BaseEntity
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid? MeansureID { get; set; }

        /// <summary>
        /// Tham chiếu id người dùng
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Nhịp tim
        /// </summary>
        public int HeartBeat { get; set; }
    }
}
