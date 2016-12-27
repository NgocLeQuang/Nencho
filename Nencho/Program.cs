using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryLogin;
using Nencho.MyForm;

namespace Nencho
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_ManagerUser());
            //bool temp;
            //do
            //{
            //    temp = false;
            //    Frm_Login a = new Frm_Login();
            //    a.lb_programName.Text = "          Chương trình\n        Nencho";
            //    a.lb_version.Text = @"1.0";
            //    a.IdProject = "Nencho";
            //    a.UrlUpdateVersion = @"\\10.10.10.254\DE_Viet\2016\PHIẾU KIỂM ĐỊNH\Tool";
            //    //a.LoginEvent += a_LoginEvent;
            //    if (a.ShowDialog() == DialogResult.OK)
            //    {
            //        Global.StrUsername = a.StrUserName;
            //        Global.StrBatch = a.StrBatch;
            //        Global.StrRole = a.StrRole;
            //        Global.Strtoken = a.Token;

            //        frm_Main frMain = new frm_Main();

            //        if (frMain.ShowDialog() == DialogResult.Yes)
            //        {
            //            frMain.Close();
            //            temp = true;
            //        }
            //    }
            //}
            //while (temp);
        }

        //private static void a_LoginEvent(string username, string role, ref ComboBox cbb)
        //{
        //    try
        //    {
        //        if (role == "DESO")
        //        {
        //            cbb.DataSource = data_LoadBatch.GetBatNotFinish_MissImageDESO(username);
        //            cbb.DisplayMember = "fBatchName";
        //            cbb.ValueMember = "fBatchName";
        //            if (cbb.Items.Count < 1)
        //            {
        //                cbb.DataSource = data_LoadBatch.GetBatNotFinishDeSo();
        //                cbb.DisplayMember = "fBatchName";
        //                cbb.ValueMember = "fBatchName";
        //            }
        //        }
        //        else if (role == "DEJP")
        //        {
        //            cbb.DataSource = data_LoadBatch.GetBatNotFinish_MissImageDEJP(username);
        //            cbb.DisplayMember = "fBatchName";
        //            cbb.ValueMember = "fBatchName";
        //            if (cbb.Items.Count < 1)
        //            {
        //                cbb.DataSource = data_LoadBatch.GetBatNotFinishDeJP();
        //                cbb.DisplayMember = "fBatchName";
        //                cbb.ValueMember = "fBatchName";
        //            }
        //        }
        //        else
        //        {
        //            cbb.DataSource = data_LoadBatch.GetBatch();
        //            cbb.DisplayMember = "fBatchName";
        //            cbb.ValueMember = "fBatchName";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Lỗi " + e);
        //    }
        //}
    }
}
