using System.Data;
using System.Data.SqlClient;

namespace ScodedAll.Models
{
    public class MemberDataAccessLayer
    {
        string connectionStringName = ConnectionString.CName;

        public void TestMem()
        {
            string result;
            SqlConnection conObj=new SqlConnection(connectionStringName);
            SqlCommand cmdObj = new SqlCommand("Select * from Members",conObj);
            try
            {
                conObj.Open();
                result = Convert.ToString(cmdObj.ExecuteScalar());
                Console.WriteLine("Result ="+result);
            }
            catch (Exception)
            {

                Console.WriteLine("error");
            }
            finally
            {
                conObj.Close();
            }
        }

        public void TestMemNonQuery()
        {
            int result;
            SqlConnection conObj = new SqlConnection(connectionStringName);
            SqlCommand cmdObj = new SqlCommand("Select * from Members", conObj);
            try
            {
                conObj.Open();
                result = cmdObj.ExecuteNonQuery();
                Console.WriteLine("Result =" + result);
            }
            catch (Exception)
            {

                Console.WriteLine("error");
            }
            finally
            {
                conObj.Close();
            }
        }

        public void TestCOnnection()
        {
            bool status;
            SqlConnection conObj = new SqlConnection(connectionStringName);
            SqlCommand cmdObj = new SqlCommand("Select * from Members", conObj);
            conObj.Open();
            try
            {
                conObj.Open();
                status = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                status = false;
            }
            finally
            {
                conObj.Close();
            }
            if(status)
            {
                Console.WriteLine("Connection Successful");
            }
            else
            {
                Console.WriteLine("Failed to established a connections");
            }

        }


        public void InsertProduct()
        {
            int count=-1;
            SqlConnection conObj = new SqlConnection(connectionStringName);
            try
            {
                SqlCommand cmdObj = new SqlCommand();
                cmdObj.CommandText = @"INSERT INTO Products VALUES('P1010','Shirt')
                                       INSERT INTO Products VALUES('P1011','Cap')";
                cmdObj.Connection = conObj;

                conObj.Open();
                count = cmdObj.ExecuteNonQuery();
                //Console.WriteLine("Result =" + result);
            }
            catch (Exception)
            {

                count = -99;
            }
            finally
            {
                conObj.Close();
            }
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                SqlConnection conObj = new SqlConnection(connectionStringName);
                SqlCommand cmd1 = new SqlCommand("Select * from Members", conObj);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);
                SqlCommand cmd2 = new SqlCommand("Select * from Products", conObj);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
                da2.Fill(dt2);
                ds.Tables.Add(dt1);
                ds.Tables.Add(dt2);

            }
            catch (Exception ex)
            {

                ds = null;
            }
            return ds;
        }

        public void MemberDataOutput()
        {
            DataTable dtMemberss = new DataTable();
            SqlConnection conObj = new SqlConnection(connectionStringName);
            SqlCommand cmdObj = new SqlCommand("Select * from Members;Select * from Products", conObj);
            SqlDataAdapter daObj = new SqlDataAdapter(cmdObj);
            daObj.Fill(dtMemberss);
            string data = string.Empty;

            if (dtMemberss.Rows.Count != 0)
            {
                Console.WriteLine("Members are:");
                foreach (DataRow row in dtMemberss.Rows)
                {
                    data = row[1].ToString();
                    Console.WriteLine(row[1]);
                }
            }
            else
            {
                Console.WriteLine("Details not founds");
            }
            var b = data;

        }
    }
}
