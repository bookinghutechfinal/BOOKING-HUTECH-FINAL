using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingHutech.Api_BHutech.Models.Response;
using BookingHutech.Api_BHutech.DAO.EmployeeManagerDAO;
using BookingHutech.Api_BHutech.Lib.Utils;
using Demo.Api_BHutech.Models.Response;
using BookingHutech.Api_BHutech.Lib;

namespace BookingHutech.Api_BHutech.DAL.EmployeeManagerDAL
{
    public class EmployeeDAL
    {

        ListEmployeeResponseModel res = new ListEmployeeResponseModel();


        /// <summary>
        /// Anh.Tran: Create 24/1/2019
        /// GetListEmployeeDAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>list employee</returns>
        public ApiResponse GetListEmployeeDAL()
        {
            try

            {

                try
                {
                    EmployeeDAO employeeDAO = new EmployeeDAO();
                    string uspGetListEmployee = Prototype.SqlCommandStore.uspGetListEmployee;
                    res.listEmployee = employeeDAO.GetListEmployeeDAO(uspGetListEmployee);
                    return ApiResponse.Success(res); // lấy thành công. 
                }
                catch (BHutechException ex)
                {
                    LogWriter.WriteException(ex);
                    return ApiResponse.Error(107); //Hệ thống không thể kết nối đến Server!!
                }
            }
            catch (BHutechException ex)
            {
                LogWriter.WriteException(ex);
                return ApiResponse.Error(106); //Hệ thống có lỗi trong quá trình xử lý!
            }
        }
    }
}