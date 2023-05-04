using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace LibM.BL
{
    internal class CLS_USERS
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADUSER", pr);
            return dt;
        }

        // insert data 
        public void Insert(string CNAME, string CUSER, string CPASSWORD, string CPREM, string CSTATE)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("CNAME", CNAME);
            pr[1] = new SqlParameter("CUSER", CUSER);
            pr[2] = new SqlParameter("CPASSWORD", CPASSWORD);
            pr[3] = new SqlParameter("CPREM", CPREM);
            pr[4] = new SqlParameter("CSTATE", CSTATE);

            DAL.open();
            DAL.Excute("PR_INSERTUSER", pr);
            DAL.close();
        }
        // update data 
        public void update(string CNAME, string CUSER, string CPASSWORD, string CPREM, int ID)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("CNAME", CNAME);
            pr[1] = new SqlParameter("CUSER", CUSER);
            pr[2] = new SqlParameter("CPASSWORD", CPASSWORD);
            pr[3] = new SqlParameter("CPREM", CPREM);
            pr[4] = new SqlParameter("ID", ID);

            DAL.open();
            DAL.Excute("PR_INSERTUSER", pr);
            DAL.close();
        }

        // delete data
        public void delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Id", ID);
            DAL.open();
            DAL.Excute("PR_DELETEUSER", pr);
            DAL.close();

        }

        // logout
        public void logout()
        {
            SqlParameter[] pr =null;
          

            DAL.open();
            DAL.Excute("PR_LOGOUT", pr);
            DAL.close();
        }

        public DataTable login(string CUSER,string CPASSWORD)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("CUSER", CUSER);
            pr[1] = new SqlParameter("CPASSWORD", CPASSWORD);

            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOGIN", pr);
            return dt;
        }


        // update data for login
        public void updateLogin( string CUSER, string CPASSWORD)
        {
            SqlParameter[] pr = new SqlParameter[2];

            pr[0] = new SqlParameter("CUSER", CUSER);
            pr[1] = new SqlParameter("CPASSWORD", CPASSWORD);


            DAL.open();
            DAL.Excute("PR_UPDATELOGIN", pr);
            DAL.close();
        }
        // load data for check start
        public DataTable STARTLOADDATA()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_START", pr);
            return dt;
        }



    }
}
