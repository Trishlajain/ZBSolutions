using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bal_Library;


namespace Dal_Library
{
  public  class AccountDal
    {
        public bool MyAccount(AccountBal bal,out string IFSC,out int Acno)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ZigmaCS"].ToString());

            try
            {
              
                SqlCommand cmd = new SqlCommand("sp_InsertIntoAccount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.Parameters.Add("@Account_No",SqlDbType.Int);
                cmd.Parameters["@Account_No"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@IFSC",SqlDbType.VarChar,20);
                cmd.Parameters["@IFSC"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@LoginId", bal.UserId);


                //cmd.Parameters.AddWithValue("@Account_No", bal.AccountNo);
                //cmd.Parameters.AddWithValue("@IFSC", bal.IfscCode);

             
                SqlDataReader dr = cmd.ExecuteReader();
                
                Acno = Convert.ToInt32(cmd.Parameters["@Account_No"].Value);
                IFSC = (string)cmd.Parameters["@IFSC"].Value;
                if (Acno!=0)
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
