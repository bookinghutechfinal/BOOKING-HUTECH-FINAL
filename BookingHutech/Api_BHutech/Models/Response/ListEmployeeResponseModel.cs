using Demo.Api_BHutech.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingHutech.Api_BHutech.Models.Response
{
    public class ListEmployeeResponseModel : Car
    {
        // danh sách nhân viên được trả về.
        public List<ListEmployeeResponseModel> listEmployee { get; set; }
    }
    
}