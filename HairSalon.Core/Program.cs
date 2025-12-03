using System.Data;
using System.Data.SqlClient;

namespace Backend
{
    
    class Program
    {
        private const string dataSource = "DESKTOP-7PUN3QR";
        // Data Source should be name of database server. Properties --> connection properties --> name
        private const string connectionString = "Data Source="+dataSource+";" +
        "Trusted_Connection=true;" +
        "Initial Catalog=SalonDatabase;" +
        "Connection timeout=60";

        static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        static void ReadData(string sqlQuery =@"SELECT * FROM ACCOUNT1" )
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if(myConnection== null)
                {
                    Console.WriteLine("Connection is null. {0}", myConnection.State.ToString());

                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sqlQuery, myConnection);
                    DataSet ds = new DataSet();
                    myConnection.Open();
                    da.Fill(ds);
                    myConnection.Close();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Console.WriteLine("ID: {0}, Username: {1}, Password: {2}", ds.Tables[0].Rows[i].ItemArray[0], ds.Tables[0].Rows[i].ItemArray[1], ds.Tables[0].Rows[i].ItemArray[2]);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error reading data from database.");
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }
                }
            }
        }
        static void InsertData(string sqlInsert)
        {
            using (SqlConnection myConnection = GetConnection())
            {
                if (myConnection == null)
                {
                    Console.WriteLine("Cannot connect to the database: {0}", myConnection.State.ToString());
                    return;
                }

                try
                {
                    // Difference
                    SqlCommand cmd = new SqlCommand(sqlInsert, myConnection);
                    myConnection.Open();
                    cmd.ExecuteNonQuery(); // Difference
                    myConnection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(sqlInsert);
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (myConnection != null)
                    {
                        myConnection.Close();
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            //GetConnection();
            ReadData();
            InsertData(@"INSERT INTO Account1 (Username, Password, Type, State) VALUES ('Admin', 'AdminPassword', 1, 0)");
        }
    }
}