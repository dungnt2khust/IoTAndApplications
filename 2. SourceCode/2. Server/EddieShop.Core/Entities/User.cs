using System;
using System.Collections.Generic;
using System.Text;

namespace EddieShop.Core.Entities
{
    public class User : Account
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid? UserID { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Tình trạng sức khoẻ
        /// </summary>
        public int HealthStatus { get; set; }

        /// <summary>
        /// Nghề nghiệp
        /// </summary>
        public int Job { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
