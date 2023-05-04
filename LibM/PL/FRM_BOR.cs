using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LibM.PL
{
    public partial class FRM_BOR : Form
    {
        public int ID;
        public FRM_BOR()
        {
            InitializeComponent();
        }

        private void FRM_ADDBOOKS_Load(object sender, EventArgs e)
        {

            BL.CLS_SELL BLSELL = new BL.CLS_SELL();
            // load books
            DataTable dt1=new DataTable();
             dt1 = BLSELL.LoadBOOKS();
            dataGridView2.DataSource = dt1;
            // load students
            DataTable dt2 = new DataTable();
            dt2 = BLSELL.LoadST();
            dataGridView1.DataSource = dt2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }

       

        private void btnadd_Click(object sender, EventArgs e)
        {

           
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            if (txt_price.Text == "")
            {
                PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
                FError.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {


                    // add
                    BL.CLS_BOR BLBOR = new BL.CLS_BOR();
                    BLBOR.Insert(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToString(txt_date1.Value), Convert.ToString(txt_date2.Value),Convert.ToInt16(txt_price.Text));
                    PL.FRM_DADD Fadd = new FRM_DADD();
                    Fadd.Show();
                    this.Close();
                }
                else
                {
                    ////updata

                    BL.CLS_BOR BLBOR = new BL.CLS_BOR();
                    BLBOR.update(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToString(txt_date1.Value), Convert.ToString(txt_date2.Value), Convert.ToInt16(txt_price.Text),ID);
                    PL.FRM_DEDIT fEDIT = new FRM_DEDIT();
                    fEDIT.Show();
                    this.Close();
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
