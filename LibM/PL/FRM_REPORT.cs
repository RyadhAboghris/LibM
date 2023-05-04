using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LibM.PL
{
    public partial class FRM_REPORT : Form
    {  //var for cat
        BL.CLS_CAT BLCAT = new BL.CLS_CAT();
        //var for books
        BL.CLS_BOOKS BLBOOkS = new BL.CLS_BOOKS();
        //var for studern
        BL.CLS_ST BLST = new BL.CLS_ST();
        //var for studern
        BL.CLS_SELL BSELL = new BL.CLS_SELL();
        //var for BOR
        BL.CLS_BOR BOR = new BL.CLS_BOR();
        //var for USERS
        BL.CLS_USERS USERS = new BL.CLS_USERS();
        public FRM_REPORT()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_REPORT_Load(object sender, EventArgs e)
        {
            PL.FRM_MAIN Home=new PL.FRM_MAIN();
            lb_name.Text = Home.lb_name.Text;
            lb_perm.Text = Home.lb_name.Text;
            lb_date.Text = DateTime.Now.ToString();
            //

            //FOR check number 

            try
            {
                DataTable dt = new DataTable();

                dt = BLBOOkS.Load();
                lb_books.Text = dt.Rows.Count.ToString();
                dt = BLST.Load();
                lb_student.Text = dt.Rows.Count.ToString();
                dt = BSELL.Load();
                lb_sell.Text = dt.Rows.Count.ToString();
                dt = BOR.Load();
                lb_bor.Text = dt.Rows.Count.ToString();
                dt = BLCAT.Load();
                lb_cat.Text = dt.Rows.Count.ToString();
                dt = USERS.Load();
                lb_users.Text = dt.Rows.Count.ToString();



            }
            catch { }
          
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img=new Bitmap(panel1.Width,panel1.Height);
            panel1.DrawToBitmap(img, new Rectangle(Point.Empty, panel1.Size));
            e.Graphics.DrawImage(img,0,0);
        }
    }
}
