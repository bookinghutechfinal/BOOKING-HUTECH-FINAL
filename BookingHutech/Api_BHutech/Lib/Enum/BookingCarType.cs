using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingHutech.Api_BHutech.Lib.Enum
{
    public class BookingCarType
    {
        /// <summary>
        /// Trang thái xe
        /// </summary>
        public enum CarType
        {
            Delete = 0, // đã xóa xe. 
            Active = 1, // hoạt động
            EmptyCar = 2, // xe trống.
            NotEmptyCar = 3, // có người booking
            Maintenance = 4,  // bảo trì, sửa chữa
        }
    }
}