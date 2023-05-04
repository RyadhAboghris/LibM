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
    public partial class FRM_ADDSTUDENT : Form
    {
        public int ID;
        public FRM_ADDSTUDENT()
        {
            InitializeComponent();
        }

        private void FRM_ADDBOOKS_Load(object sender, EventArgs e)
        {

            
           
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
            OpenFileDialog ofd = new OpenFileDialog();
            var result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                cover.Image=Image.FromFile(ofd.FileName);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
            FCAT.btnadd.ButtonText = "اضافة";
            FCAT.ID = 0;
            FCAT.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (txt_name.Text == ""||txt_location.Text==""||txt_email.Text=="")
            {
                PL.FRM_ERRORINSERT FError = new FRM_ERRORINSERT();
                FError.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {
                    MemoryStream ma=new MemoryStream();
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // add
                    BL.CLS_ST BLST= new BL.CLS_ST();
                    BLST.Insert(txt_name.Text, txt_location.Text,txt_phone.Text, txt_email.Text, txt_school.Text, txt_dept.Text, ma);
                    PL.FRM_DADD Fadd = new FRM_DADD();
                    Fadd.Show();
                    this.Close();
                }
                else
                {
                    //updata

                    MemoryStream ma = new MemoryStream();
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);
                    BL.CLS_ST BLST = new BL.CLS_ST();

                    BLST.updata(txt_name.Text, txt_location.Text, txt_phone.Text, txt_email.Text, txt_school.Text, txt_dept.Text, ma, ID);
                    PL.FRM_DEDIT fEDIT = new FRM_DEDIT();
                    fEDIT.Show();
                    this.Close();
                }

            }
        }

        private void txt_name_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_location_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_phone_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_dept_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_school_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
