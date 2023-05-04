using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibM.BL
{
    internal class CLS_BOR
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADBOR", pr);
            return dt;
        }
        public DataTable LoadBOOKS()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("BR_LOADBOOKFORSELL", pr);
            return dt;
        }

        public DataTable LoadST()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("BR_LOADSTFORSELL", pr);
            return dt;
        }
        // insert data 
        public void Insert(string BNAME, string BTITLE, string BDATE1, string BDATE2,int PRICE)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("BNAME", BNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("BDATE1", BDATE1);
            pr[3] = new SqlParameter("BDATE2", BDATE2);
            pr[4] = new SqlParameter("PRICE", PRICE);

            DAL.open();
            DAL.Excute("PR_INSERTBOR", pr);
            DAL.close();
        }
        // update data 
        public void update(string BNAME, string BTITLE, string BDATE1, string BDATE2, int PRICE,int ID)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("BNAME", BNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("BDATE1", BDATE1);
            pr[3] = new SqlParameter("BDATE2", BDATE2);
            pr[4] = new SqlParameter("PRICE", PRICE);
            pr[5] = new SqlParameter("ID", ID);

            DAL.open();
            DAL.Excute("RR_EDITBRO", pr);
            DAL.close();
        }
        // delete data
        public void delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Id", ID);
            DAL.open();
            DAL.Excute("PR_DELETEBOR", pr);
            DAL.close();

        }
        // search
        public DataTable search(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_BORSEARCH", pr);
            return dt;
        }

    }


  
}
