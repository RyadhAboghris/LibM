using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.IO;

namespace LibM.PL
{
    public partial class FRM_MAIN : Form
    {
        string State;
        int ID;
        //var for cat
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
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
           
            PL.FRM_LOGIN Login =new FRM_LOGIN();
            USERS.logout();
            this.Hide();
            Login.Show();

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            PL.FRM_REPORT Report=new FRM_REPORT();
            Report.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (P_MB.Size.Width == 200)
            {
                P_MB.Width = 50;
                button1.RightToLeft=RightToLeft.Yes;
                button2.RightToLeft=RightToLeft.Yes;
                button3.RightToLeft=RightToLeft.Yes;
                button4.RightToLeft=RightToLeft.Yes;
                button5.RightToLeft=RightToLeft.Yes;
                button6.RightToLeft=RightToLeft.Yes;
                button7.RightToLeft=RightToLeft.Yes;
                lb_name.Visible=false;
                lb_prem.Visible=false;
            }
            else {
                P_MB.Width = 200;
                button1.RightToLeft = RightToLeft.No;
                button2.RightToLeft = RightToLeft.No;
                button3.RightToLeft = RightToLeft.No;
                button4.RightToLeft = RightToLeft.No;
                button5.RightToLeft = RightToLeft.No;
                button6.RightToLeft = RightToLeft.No;
                button7.RightToLeft = RightToLeft.No;
                lb_name.Visible = true;
                lb_prem.Visible = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            P_HOME.Visible= false;
            P_MAIN.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_search.Visible = true;

            State = "CAT";
            Lb_Title.Text = "الاصناف";
            // load data
            try
            {
                DataTable dt = new DataTable();

                dt = BLCAT.Load();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الصنف";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            P_HOME.Visible = true;
            P_MAIN.Visible=false;
            Lb_Title.Text = "الرئيسة";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // Add categoty
            if (State == "CAT")
            {
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "اضافة";
                FCAT.ID = 0;
                bunifuTransition1.ShowSync(FCAT);
            }
            // Add BOOKS
            if (State == "BOOKS")
            {
                PL.FRM_ADDBOOKS FBOOKS = new FRM_ADDBOOKS();
                FBOOKS.btnadd.ButtonText = "اضافة";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);
            }
            
            // Add studen
            if (State == "ST")
            {
                PL.FRM_ADDSTUDENT FSTUDENT = new FRM_ADDSTUDENT();
                FSTUDENT.btnadd.ButtonText = "اضافة";
                FSTUDENT.ID = 0;
                bunifuTransition1.ShowSync(FSTUDENT);
            }
            
            // Add sell
            if (State == "SELL")
            {
                PL.FRM_MAKESELL FSELLT = new FRM_MAKESELL();
                FSELLT.btnadd.ButtonText = "اضافة";
                FSELLT.ID = 0;
                bunifuTransition1.ShowSync(FSELLT);
            }
            
            // Add BOR
            if (State == "BOR")
            {
                PL.FRM_BOR FBOR = new FRM_BOR();
                FBOR.btnadd.ButtonText = "اضافة";
                FBOR.ID = 0;
                bunifuTransition1.ShowSync(FBOR);
            }
            
            // Add USER
            if (State == "USER")
            {
                PL.FRM_ADDUSER FUSER = new FRM_ADDUSER();
                FUSER.btnadd.ButtonText = "اضافة";
                FUSER.ID = 0;
                bunifuTransition1.ShowSync(FUSER);
            }
        }

        private void FRM_MAIN_Activated(object sender, EventArgs e)
        {
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
            // for prem
            if (lb_prem.Text == "مدير")
            {
                bunifuThinButton23.Enabled = true;
                button6.Enabled = true;
            }else if(lb_prem.Text == "مستخدم")
            {
                bunifuThinButton23.Enabled = false;
                button6.Enabled = false;
            }
            if(State == "CAT")
            {
                // load data
                try
                {
                    DataTable dt = new DataTable();

                    dt = BLCAT.Load();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الصنف";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (State == "BOOKS")
            {

                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                bunifuThinButton24.Visible = true;
                State = "BOOKS";
                Lb_Title.Text = "الكتب";
                // load data
                try
                {
                    DataTable dt = new DataTable();

                    dt = BLBOOkS.Load();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[2].HeaderText = "المؤلف";
                    dataGridView1.Columns[3].HeaderText = "التصنيف";
                    dataGridView1.Columns[4].HeaderText = "السعر";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }else if(State == "ST")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                bunifuThinButton24.Visible = true;
                State = "ST";
                Lb_Title.Text = "الطلاب";
                // load data
                try
                {
                    DataTable dt = new DataTable();

                    dt = BLST.Load();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الطالب";
                    dataGridView1.Columns[2].HeaderText = "السكن";
                    dataGridView1.Columns[3].HeaderText = "رقم الهاتف";
                    dataGridView1.Columns[4].HeaderText = "البريد الإلكتروني";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (State == "SELL")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                bunifuThinButton24.Visible = false;
                State = "SELL";
                Lb_Title.Text = "البيع";
                // load data
                try
                {
                    DataTable dt = new DataTable();

                    dt = BSELL.Load();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[2].HeaderText = "المشتري";
                    dataGridView1.Columns[3].HeaderText = "السعر";
                    dataGridView1.Columns[4].HeaderText = "التاريخ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (State == "BOR")
            {

                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                bunifuThinButton24.Visible = false;
                State = "BOR";
                Lb_Title.Text = "الاستعارة";
                // load data
                try
                {
                    DataTable dt = new DataTable();

                    dt = BOR.Load();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم المشتري";
                    dataGridView1.Columns[2].HeaderText = "اسم الكتاب";
                    dataGridView1.Columns[3].HeaderText = "بداية الاستعارة";
                    dataGridView1.Columns[4].HeaderText = "نهاية الاستعارة";
                    dataGridView1.Columns[5].HeaderText = "السعر";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else
            if (State == "USER")
            {


                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                bunifuThinButton24.Visible = false;
                State = "USER";
                Lb_Title.Text = "المستخدمين";
                // load data
                try
                {
                    DataTable dt = new DataTable();

                    dt = USERS.Load();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].HeaderText = "التسلسل";
                    dataGridView1.Columns[1].HeaderText = "اسم الكامل";
                    dataGridView1.Columns[2].HeaderText = "اسم المستخدم";
                    dataGridView1.Columns[3].HeaderText = "كلمة السر";
                    dataGridView1.Columns[4].HeaderText = "الصلاحية";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            // edit categoty
            if (State == "CAT")
            {
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "تعديل";
                FCAT.txt_catname.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                FCAT.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                bunifuTransition1.ShowSync(FCAT);
            }
            //EDIT BOOKS
            else if (State == "BOOKS")
            {

                try
                {
                    PL.FRM_ADDBOOKS FBOOKS = new FRM_ADDBOOKS();
                    FBOOKS.btnadd.ButtonText = "تعديل";
                    FBOOKS.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();

                    dt = BLBOOkS.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["TITLE"];
                    object obj2 = dt.Rows[0]["AUTHER"];
                    object obj3 = dt.Rows[0]["CAT"];
                    object obj4 = dt.Rows[0]["PRICE"];
                    object obj5 = dt.Rows[0]["BDATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FBOOKS.txt_title.Text = obj1.ToString();
                    FBOOKS.txt_auther.Text = obj2.ToString();
                    FBOOKS.comboBox1.Text = obj3.ToString();
                    FBOOKS.txt_price.Text = obj4.ToString();
                    String dateTime = obj5.ToString();
                    FBOOKS.txt_date.Value = DateTime.Parse(dateTime);
                    FBOOKS.txt_rate.Value = (int)obj6;
                    // load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FBOOKS.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FBOOKS);
                }
                catch
                {

                }

            } //EDIT student 
            else if (State == "ST")
            {

                try
                {
                    PL.FRM_ADDSTUDENT FST = new FRM_ADDSTUDENT();
                    FST.btnadd.ButtonText = "تعديل";
                    FST.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();

                    dt = BLST.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["SNAME"];
                    object obj2 = dt.Rows[0]["TLOCATION"];
                    object obj3 = dt.Rows[0]["PHONE"];
                    object obj4 = dt.Rows[0]["EMAIL"];
                    object obj5 = dt.Rows[0]["SCHOOL"];
                    object obj6 = dt.Rows[0]["DEP"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FST.txt_name.Text = obj1.ToString();
                    FST.txt_location.Text = obj2.ToString();
                    FST.txt_phone.Text = obj3.ToString();
                    FST.txt_email.Text = obj4.ToString();
                    FST.txt_school.Text = obj5.ToString();
                    FST.txt_dept.Text = obj6.ToString();
                    // load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FST.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FST);
                }
                catch
                {

                }

            }
            else if (State == "SELL")
            {

                try
                {
                    PL.FRM_MAKESELL FSELL = new FRM_MAKESELL();
                    FSELL.btnadd.ButtonText = "تعديل";
                    FSELL.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    
                    bunifuTransition1.ShowSync(FSELL);
                }
                catch
                {

                }

            }
            else if (State == "BOR")
            {

                try
                {
                    PL.FRM_BOR FBOR = new FRM_BOR();
                    FBOR.btnadd.ButtonText = "تعديل";
                    FBOR.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);

                    bunifuTransition1.ShowSync(FBOR);
                }
                catch
                {

                }

            }
            else if (State == "USER")
            {

                try
                {
                    PL.FRM_ADDUSER FUSER = new FRM_ADDUSER();
                    FUSER.btnadd.ButtonText = "تعديل";
                    FUSER.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);

                    bunifuTransition1.ShowSync(FUSER);
                }
                catch
                {

                }

            }

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            // delete categoty
            if (State == "CAT")
            {
                BLCAT.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            // delete books

            else if (State == "BOOKS")
            {
                BLBOOkS.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }  // delete student

            else if (State == "ST")
            {
                BLST.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            // delete SELL

            else if (State == "BOR")
            {
                BOR.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            // delete SELL

            else if (State == "SELL")
            {
                BSELL.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
            // delete USER

            else if (State == "USER")
            {
                USERS.delete(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE Fdelete = new FRM_DDELETE();
                Fdelete.Show();
            }
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

            // search categoty
            if (State == "CAT")
            {
                DataTable dt = new DataTable();

                dt = BLCAT.search(txt_search.Text);

                 
                dataGridView1.DataSource = dt;

            }
            else // search BOOKS
            if (State == "BOOKS")
            {
                DataTable dt = new DataTable();

                dt = BLBOOkS.search(txt_search.Text);


                dataGridView1.DataSource = dt;

            }
            else // search STUDENT
            if (State == "ST")
            {
                DataTable dt = new DataTable();

                dt = BLST.search(txt_search.Text);


                dataGridView1.DataSource = dt;

            }
            else // search SELL
            if (State == "SELL")
            {
                DataTable dt = new DataTable();

                dt = BSELL.search(txt_search.Text);


                dataGridView1.DataSource = dt;

            }
            else // search BOR
            if (State == "BOR")
            {
                DataTable dt = new DataTable();

                dt = BOR.search(txt_search.Text);


                dataGridView1.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            bunifuThinButton24.Visible = true;
            txt_search.Visible = true;
            State = "BOOKS";
            Lb_Title.Text = "الكتب";
            // load data
            try
            {
                DataTable dt = new DataTable();

                dt = BLBOOkS.Load();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[2].HeaderText = "المؤلف";
                dataGridView1.Columns[3].HeaderText = "التصنيف";
                dataGridView1.Columns[4].HeaderText = "السعر";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            // det books
            if (State == "BOOKS")
            {
                try
                {
                    DataTable dt = new DataTable();

                    dt = BLBOOkS.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["TITLE"];
                    object obj2 = dt.Rows[0]["AUTHER"];
                    object obj3 = dt.Rows[0]["CAT"];
                    object obj4 = dt.Rows[0]["PRICE"];
                    object obj5 = dt.Rows[0]["BDATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    PL.FRM_DETBOOKS DETBOOKS=new PL.FRM_DETBOOKS();
                    DETBOOKS.txt_title.Text = obj1.ToString();
                    DETBOOKS.txt_auther.Text = obj2.ToString();
                    DETBOOKS.txt_cat.Text = obj3.ToString();
                    DETBOOKS.txt_price.Text = obj4.ToString();
                    String dateTime = obj5.ToString();
                    DETBOOKS.txt_date.Value = DateTime.Parse(dateTime);
                    DETBOOKS.txt_rate.Value = (int)obj6;
                    // load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    DETBOOKS.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(DETBOOKS);
                }
                catch
                {

                }
            }//EDIT student 
            else if (State == "ST")
            {

                try
                {
                    PL.FRM_DETST FST = new FRM_DETST();
                    DataTable dt = new DataTable();

                    dt = BLST.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["SNAME"];
                    object obj2 = dt.Rows[0]["TLOCATION"];
                    object obj3 = dt.Rows[0]["PHONE"];
                    object obj4 = dt.Rows[0]["EMAIL"];
                    object obj5 = dt.Rows[0]["SCHOOL"];
                    object obj6 = dt.Rows[0]["DEP"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FST.txt_name.Text = obj1.ToString();
                    FST.txt_location.Text = obj2.ToString();
                    FST.txt_phone.Text = obj3.ToString();
                    FST.txt_email.Text = obj4.ToString();
                    FST.txt_school.Text = obj5.ToString();
                    FST.txt_dept.Text = obj6.ToString();
                    // load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FST.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FST);
                }
                catch
                {

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            bunifuThinButton24.Visible = true;
            txt_search.Visible = true;
            State = "ST";
            Lb_Title.Text = "الطلاب";
            // load data
            try
            {
                DataTable dt = new DataTable();

                dt = BLST.Load();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الطالب";
                dataGridView1.Columns[2].HeaderText = "السكن";
                dataGridView1.Columns[3].HeaderText = "رقم الهاتف";
                dataGridView1.Columns[4].HeaderText = "البريد الإلكتروني";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_search.Visible = true;
            State = "SELL";
            Lb_Title.Text = "البيع";
            // load data
            try
            {
                DataTable dt = new DataTable();

                dt = BSELL.Load();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[2].HeaderText = "المشتري";
                dataGridView1.Columns[3].HeaderText = "السعر";
                dataGridView1.Columns[4].HeaderText = "التاريخ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_search.Visible = true;
            State = "BOR";
            Lb_Title.Text = "الاستعارة";
            // load data
            try
            {
                DataTable dt = new DataTable();

                dt = BOR.Load();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم المشتري";
                dataGridView1.Columns[2].HeaderText = "اسم الكتاب";
                dataGridView1.Columns[3].HeaderText = "بداية الاستعارة";
                dataGridView1.Columns[4].HeaderText = "نهاية الاستعارة";
                dataGridView1.Columns[5].HeaderText = "السعر";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {



            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            bunifuThinButton24.Visible = false;
            txt_search.Visible = false;
            State = "USER";
            Lb_Title.Text = "المستخدمين";
            // load data
            try
            {
                DataTable dt = new DataTable();

                dt = USERS.Load();
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "التسلسل";
                dataGridView1.Columns[1].HeaderText = "اسم الكامل";
                dataGridView1.Columns[2].HeaderText = "اسم المستخدم";
                dataGridView1.Columns[3].HeaderText = "كلمة السر";
                dataGridView1.Columns[4].HeaderText = "الصلاحية";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lb_name_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = true;
            P_MAIN.Visible = false;
            Lb_Title.Text = "الرئيسة";
        }

        private void button12_Click(object sender, EventArgs e)
        {

            
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "اضافة";
                FCAT.ID = 0;
                bunifuTransition1.ShowSync(FCAT);
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PL.FRM_BOR FBOR = new FRM_BOR();
            FBOR.btnadd.ButtonText = "اضافة";
            FBOR.ID = 0;
            bunifuTransition1.ShowSync(FBOR);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PL.FRM_MAKESELL FSELLT = new FRM_MAKESELL();
            FSELLT.btnadd.ButtonText = "اضافة";
            FSELLT.ID = 0;
            bunifuTransition1.ShowSync(FSELLT);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PL.FRM_ADDSTUDENT FSTUDENT = new FRM_ADDSTUDENT();
            FSTUDENT.btnadd.ButtonText = "اضافة";
            FSTUDENT.ID = 0;
            bunifuTransition1.ShowSync(FSTUDENT);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PL.FRM_ADDBOOKS FBOOKS = new FRM_ADDBOOKS();
            FBOOKS.btnadd.ButtonText = "اضافة";
            FBOOKS.ID = 0;
            bunifuTransition1.ShowSync(FBOOKS);
        }
    }
}
