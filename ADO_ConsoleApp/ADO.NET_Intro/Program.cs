using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            //pr.createTable();
            //pr.insertData();
            //pr.deleteData();
            pr.queryingDb();
            Console.ReadKey();
        }
        public void createTable()
        {
            SqlConnection cn = null;
            try
            {

                cn = new SqlConnection("data source=.; database=student; integrated security=SSPI");

                // writing sql query  
                SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", cn);  
                  
                cn.Open(); // Opening Connection
                cm.ExecuteNonQuery(); // Executing the SQL query 
                 
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                cn.Close();
            }
        }

        public void insertData()
        {
            SqlConnection cn = null;
            try
            {

                cn = new SqlConnection("data source=.; database=student; integrated security=SSPI");

                // writing sql query  
                SqlCommand cm = new SqlCommand("insert student (id, name, email, join_date)values('102', 'Ronald Trump', 'ronald@example.com', '1/12/2017')", cn);  

                cn.Open(); // Opening Connection
                cm.ExecuteNonQuery(); // Executing the SQL query 

                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            } 
            finally
            {
                cn.Close();
            }
        }

        public void queryingDb()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection("data source=.; database=student; integrated security =SSPI");

                SqlCommand cm = new SqlCommand("select * from student", cn);

                cn.Open();
                //SqlDataReader sdr = cm.ExecuteReader();
                //while (sdr.Read())
                //{
                //    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); 
                //}

                Object sdr = cm.ExecuteScalar();
                Console.WriteLine(sdr);

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                cn.Close();
            }
        }
        public void deleteData()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection("data source=.; database=student; integrated security =SSPI");

                SqlCommand cm = new SqlCommand("delete from student where id = 101", cn);

                cn.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
