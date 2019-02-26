using System;
using System.Web.Http;
using BookingHutech.Api_BHutech.Lib;
using BookingHutech.Api_BHutech.Models.Response;
using BookingHutech.Api_BHutech.CarServices.CarServices;
using Demo.Api_BHutech.Models.Response;
using System.Net.Http;
using System.Linq;
using BookingHutech.Api_BHutech.BHutech_Services;
using static BookingHutech.Api_BHutech.Lib.Enum.BookingType;



namespace BookingHutech.Controllers.Api
{
    public class CarController : ApiController
    {

       
        /// <summary>
        /// Anh.Tran: Create 24/1/2019
        /// GetListEmployeeDAL
        /// </summary>
        /// <param name="">ListCarRequestModel</param>
        /// <returns>ApiResponse</returns> 
        [HttpPost]
        public ApiResponse GetListCar([FromBody] ListCarRequestModel request) {
            CarServices carServices = new CarServices();
            try
            {
                 
                if (Permissions.CheckAPIRequest(Request.Headers.GetValues(ApiHeaderKey.BHAPIWebCall.ToString()).First()) == (int)ApiRequestType.Web)
                {
                    var Response = carServices.GetListCarDAL(request);
                    return ApiResponse.Success(Response);
                }
                // sai header .
                else{ 
                    return ApiResponse.ApiNotPermissionCall();
                }
  
            }
            // thiếu header. 
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                return ApiResponse.ApiNotPermissionCall();

            }
          
        }


        // hoan thanh chuc nang login fix bug

 

    }
}