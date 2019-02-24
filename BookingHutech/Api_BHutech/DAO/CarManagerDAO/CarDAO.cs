﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookingHutech.Api_BHutech.Lib;
using BookingHutech.Api_BHutech.Lib.Utils;
using BookingHutech.Api_BHutech.Models.Response;
 
namespace BookingHutech.Api_BHutech.DAO.CarDAO
{
    public class EmployeeDAO
    {
        static DataAccess db;
        static SqlConnection con; 
        static SqlCommand cmd;
        static SqlDataAdapter adap; 

        /// <summary>
        /// Anh.Tran: Create 23/2/2019 
        /// </summary>
        /// <param name="stringSql">stringSql</param>
        /// <returns>list ListCarResponseModel</returns> 
        public List<ListCarResponseModel> GetListEmployeeDAO(String stringSql)
        {
            db = new DataAccess();
            con = new SqlConnection(db.ConnectionString());
            List<ListCarResponseModel> req = new List<ListCarResponseModel>(); 
            try
            {
                //  con.open();
                con.Open();
                cmd = new SqlCommand(stringSql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListCarResponseModel employeeResponseModel = new ListCarResponseModel();
                    employeeResponseModel.CarID = Int32.Parse(reader["CarID"].ToString());
                    employeeResponseModel.CarName = reader["CarName"].ToString();
                    employeeResponseModel.CarNumber = reader["CarNumber"].ToString();
                    employeeResponseModel.CarTypeID = Int32.Parse(reader["CarTypeID"].ToString()); 
                    employeeResponseModel.CarStatus = Int32.Parse(reader["CarStatus"].ToString()); 
                    req.Add(employeeResponseModel) ;
                }
                con.Close();
                return req;
            }
            catch (BHutechException ex)
            {
                LogWriter.WriteException(ex);
                con.Close();
            }
            return req;
        }
    }
}
 
