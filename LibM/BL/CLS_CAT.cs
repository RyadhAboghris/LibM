using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibM.BL
{
    internal class CLS_CAT
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();

        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADCAT", pr);
            return dt;
        }
        // search
        public DataTable search(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_CATSEARCH", pr);
            return dt;
        }
        // insert data
        public void Insert(string CAT_NAME)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            DAL.open();
            DAL.Excute("P_ADDCAT", pr);
            DAL.close();
        }
        //updata data
        public void updata(string CAT_NAME, int ID)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            pr[1] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_EDITCAT", pr);
            DAL.close();
        }
        // delete data
        public void delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Id", ID);
            DAL.open();
            DAL.Excute("P_DELETECAT", pr);
            DAL.close();

        }
     
    }
}
