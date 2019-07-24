using Bal_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Library;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Dal_Library
{
    public class SignUpDal
    {
        public bool SignUp(SignUpBal bal)
        {
            bool status = false;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager
                  .ConnectionStrings["ZigmaCS"].ToString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertIntoSignUp", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Loginid", bal.UserId);
                    cmd.Parameters.AddWithValue("@Name", bal.Fullname);
                    cmd.Parameters.AddWithValue("@Address", bal.Address);
                    cmd.Parameters.AddWithValue("@Pno", bal.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DOB", bal.DateOfBirth);
                    cmd.Parameters.AddWithValue("@NewPass", bal.Password);                  
                    cn.Open();
                    int row = cmd.ExecuteNonQuery();

                    if (row==-1)
                    {
                        status = true;
                    }           
                }
                catch (Exception ex)
                {
                    status = false;
                    throw new Exception(ex.Message);
                }
               return status;
                
            }
        }
    }
}
