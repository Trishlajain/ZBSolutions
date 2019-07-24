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
    public class BenDal
    {
        public bool benDetails(BeneficiaryBal bal)
        {
            bool status = false;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager
                  .ConnectionStrings["ZigmaCS"].ToString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertBeneficiary", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NickName", bal.Nickname);
                    cmd.Parameters.AddWithValue("@BenId", bal.BeneficiaryId);
                    cmd.Parameters.AddWithValue("@LoginId", bal.UserId);

                    cn.Open();
                    int row = cmd.ExecuteNonQuery();

                    if (row == -1)
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

        public bool ShowBen(BeneficiaryBal bal, out string Nick, out int Bid)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ZigmaCS"].ToString());

            try
            {

                SqlCommand cmd = new SqlCommand("ShowBeneficiary", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.Parameters.Add("@BenId", SqlDbType.Int);
                cmd.Parameters["@BenId"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@NickName", SqlDbType.VarChar, 10);
                cmd.Parameters["@NickName"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@LoginId", bal.UserId);


                //cmd.Parameters.AddWithValue("@Account_No", bal.AccountNo);
                //cmd.Parameters.AddWithValue("@IFSC", bal.IfscCode);


                SqlDataReader dr = cmd.ExecuteReader();

                Bid = Convert.ToInt32(cmd.Parameters["@BenId"].Value);
                Nick = (string)cmd.Parameters["@NickName"].Value;
                if (Bid != 0)
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
