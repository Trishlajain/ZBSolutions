using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Bal_Library;
using System.Configuration;

namespace Dal_Library
{
    public class LoginDal
    {
        public bool Login(LoginBal bal)
        {
            bool status=false;            
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ZigmaCS"].ToString());

            try
            {
                //First Table
                SqlCommand cmd = new SqlCommand("ValidateUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginId", bal.UserId);
                cmd.Parameters.AddWithValue("@LoginPass", bal.Password);
                //Second Table 
                cn.Open();
                SqlDataReader dr=cmd.ExecuteReader();       

                if (dr.HasRows)
                {
                    status = true;      
                }              
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;
        }


  


    }
}
