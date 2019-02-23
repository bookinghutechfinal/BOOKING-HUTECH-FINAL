﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingHutech.Api_BHutech.Models.Response;
using BookingHutech.Api_BHutech.DAO.CarDAO;
using BookingHutech.Api_BHutech.Lib.Utils;
using Demo.Api_BHutech.Models.Response;
using BookingHutech.Api_BHutech.Lib;
 

namespace BookingHutech.Api_BHutech.CarServices.CarServices
{
    public class CarServices
    {

        /// <summary>
        /// Anh.Tran: Create 24/1/2019 
        /// GetListEmployeeDAL
        /// </summary>
        /// <param name="">ListCarRequestModel</param>
        /// <returns>ListCarResponseModel</returns> 
        public List<ListCarResponseModel> GetListCarDAL(ListCarRequestModel request)
        {

            ListCarResponseModel result = new ListCarResponseModel();
            EmployeeDAO employeeDAO = new EmployeeDAO();
            try
            {
              
                string uspGetListEmployee = string.Format("{0} {1}", Prototype.SqlCommandStore.uspGetListCarByCarStatus, request.CarStatus) ;
                return result.listCar = employeeDAO.GetListEmployeeDAO(uspGetListEmployee);
                //return result; 
            }
            catch (BHutechException ex)
            {
                LogWriter.WriteException(ex); 
            }
             return result.listCar = null; 
        }
    }
}