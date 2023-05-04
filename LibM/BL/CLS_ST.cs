using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LibM.BL
{
    internal class CLS_ST
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADST", pr);
            return dt;
        }

        // insert student 
        public void Insert(string SNAME, string TLOCATION, string PHONE, string EMAIL, string SCHOOL, string DEP, MemoryStream COVER)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("TLOCATION", TLOCATION);
            pr[2] = new SqlParameter("PHONE", PHONE);
            pr[3] = new SqlParameter("EMAIL", EMAIL);
            pr[4] = new SqlParameter("SCHOOL", SCHOOL);
            pr[5] = new SqlParameter("DEP", DEP);
            pr[6] = new SqlParameter("COVER", COVER.ToArray());
            DAL.open();
            DAL.Excute("PR_INSERTST", pr);
            DAL.close();
        }

        public DataTable LOADEDIT(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELECTEDITST", pr);
            return dt;
        }
        // UPDATE DATA
        public void updata(string SNAME, string TLOCATION, string PHONE, string EMAIL, string SCHOOL, string DEP, MemoryStream COVER, int ID)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("TLOCATION", TLOCATION);
            pr[2] = new SqlParameter("PHONE", PHONE);
            pr[3] = new SqlParameter("EMAIL", EMAIL);
            pr[4] = new SqlParameter("SCHOOL", SCHOOL);
            pr[5] = new SqlParameter("DEP", DEP);
            pr[6] = new SqlParameter("COVER", COVER.ToArray());
            pr[7] = new SqlParameter("ID", ID);

            DAL.open();
            DAL.Excute("PR_EDITST", pr);
            DAL.close();
        }
        // delete data
        public void delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Id", ID);
            DAL.open();
            DAL.Excute("P_DELETETST", pr);
            DAL.close();

        }
        // search
        public DataTable search(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SEARCHST", pr);
            return dt;
        }
    }
}
