﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LibM.BL
{
    internal class CLS_SELL
    {
        DAL.CLS_DAL DAL = new LibM.DAL.CLS_DAL();
        public DataTable Load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADSELL", pr);
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
        public void Insert(string SNAME, string BTITLE,  int PRICE, string BDATE)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("PRICE", PRICE);
            pr[3] = new SqlParameter("BDATE", BDATE);

            DAL.open();
            DAL.Excute("PR_INSERTSELL", pr);
            DAL.close();
        }
        // UPDATE data 

        public void update(string SNAME, string BTITLE, int PRICE, string BDATE,int ID)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("PRICE", PRICE);
            pr[3] = new SqlParameter("BDATE", BDATE);
            pr[4] = new SqlParameter("ID", ID);

            DAL.open();
            DAL.Excute("PR_UPDATESELL", pr);
            DAL.close();
        }
        // delete data
        public void delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Id", ID);
            DAL.open();
            DAL.Excute("PR_SELLDELETE", pr);
            DAL.close();

        }
        // search
        public DataTable search(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_SELLSEARCH", pr);
            return dt;
        }
    }
}
