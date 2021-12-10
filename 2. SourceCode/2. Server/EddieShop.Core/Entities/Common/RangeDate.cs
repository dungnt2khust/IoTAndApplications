using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities.Common
{
    public class RangeDate
    {
        /// <summary>
        /// Tên trường
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Từ ngày
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? ToDate { get; set; }
    }
}
