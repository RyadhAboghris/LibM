using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibM.DAL
{
    internal class CLS_DAL
    {
        SqlConnection con = new SqlConnection();

        public CLS_DAL()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBLIBM.mdf;Integrated Security=True");
        }

        public void open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


        }
        public void close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        // fun to read data
        public DataTable read(String store, SqlParameter[] pr)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if(pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            da.Fill(dt);
            return dt;
        }

        // excute to insert , edit , delete
        public void Excute(String store, SqlParameter[] pr)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            cmd.ExecuteNonQuery();
        }
    }
    }
