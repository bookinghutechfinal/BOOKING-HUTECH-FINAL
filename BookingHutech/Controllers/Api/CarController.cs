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
                //var re = Request; 
               // var headers = Request.Headers;
               // string token = Request.Headers.GetValues("SourceSystemCall").First(); // get values 
                if (Permissions.CheckAPIRequest(Request.Headers.GetValues(ApiHeaderKey.BHAPIWebCall.ToString()).First()) == (int)ApiRequestType.Web)
                {
                    var Response = carServices.GetListCarDAL(request);
                    return ApiResponse.Success(Response);
                }
                else {
                    return ApiResponse.Error(001);
                }

                //var re = Request; 
                //var headers = re.Headers; 
                //if (headers.Contains("SourceSystemCall") && headers.GetValues("SourceSystemCall").First() != null) // chổ này kt đúng  = SourceSystemCall 
                //{
                //    //string token = headers.GetValues("SourceSystemCall").First(); // get values
                //    // gọi hàm,  đi tiếp. 
                //    var Response = carServices.GetListCarDAL(request);
                //    return ApiResponse.Success(Response);
                //}
                //else { 
                //    return ApiResponse.Error(001);
                //}

            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                return ApiResponse.Error(001);
               
            }
          
        }

        // hoan thanh chuc nang login
    }
}