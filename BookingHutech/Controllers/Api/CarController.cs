using System;
using System.Web.Http;
using BookingHutech.Api_BHutech.Lib;
using BookingHutech.Api_BHutech.Models.Response;
using BookingHutech.Api_BHutech.CarServices.CarServices;
using Demo.Api_BHutech.Models.Response;

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
                var Response = carServices.GetListCarDAL(request); 
                return ApiResponse.Success(Response);
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                return ApiResponse.Error();
               
            }
        }
    }
}