using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookingHutech.Api_BHutech.Lib;
using BookingHutech.Api_BHutech.Lib.Utils;
using BookingHutech.Api_BHutech.Models.Response;

namespace BookingHutech.Api_BHutech.DAO.EmployeeManagerDAO
{
    public class EmployeeDAO
    {
        static DataAccess db;
        static SqlConnection con; 
        static SqlCommand cmd;
        static SqlDataAdapter adap;
        ListEmployeeResponseModel employeeResponseModel;
        List<ListEmployeeResponseModel> listEmployeeResponsesModel;

        /// <summary>
        /// Anh.Tran: Create 24/1/2019
        /// Get list employee
        /// </summary>
        /// <param name="stringSql">Procedure</param>
        /// <returns>list employee</returns>
        public List<ListEmployeeResponseModel> GetListEmployeeDAO(String stringSql)
        {
            db = new DataAccess();
            con = new SqlConnection(db.ConnectionString());
            listEmployeeResponsesModel = new List<ListEmployeeResponseModel>(); 
            try
            {
                //  con.open();
                con.Open();
                cmd = new SqlCommand(stringSql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeResponseModel = new ListEmployeeResponseModel();
                    employeeResponseModel.ID = Int32.Parse(reader["ID"].ToString());
                    employeeResponseModel.FullName = reader["FullName"].ToString();
                    employeeResponseModel.Age = Int32.Parse(reader["Age"].ToString());
                    employeeResponseModel.Address = reader["Address"].ToString();
                    listEmployeeResponsesModel.Add(employeeResponseModel);
                }
                con.Close();
                return listEmployeeResponsesModel;
            }
            catch (BHutechException ex)
            {
                LogWriter.WriteException(ex);
                con.Close();
            }
            return listEmployeeResponsesModel;
        }
    }
}