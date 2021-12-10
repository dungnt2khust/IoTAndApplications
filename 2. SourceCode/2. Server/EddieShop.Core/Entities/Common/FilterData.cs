using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities.Common
{
    public class FilterData
    {
        /// <summary>
        /// Những thuộc tính cần tính tổng
        /// </summary>
        public List<string>? TotalFields { get; set; }

        /// <summary>
        /// Những thuộc tính cần lấy trong một khoảng ngày tháng
        /// </summary>
        public List<RangeDate>? RangeDates { get; set; }
    }
}
