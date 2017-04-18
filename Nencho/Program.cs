using LibraryLogin;
using Nencho.MyForm;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nencho
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_ExportExcel());
            bool temp;
            do
            {
                temp = false;
                Frm_Login a = new Frm_Login();
                //if (Properties.Settings.Default.Language == "")
                //{
                    a.lb_programName.Text = "NENCHO\n Project Management Program";
                    a.grb_1.Text = "PC information";
                    a.grb_2.Text = "Account information";
                    a.lb_date.Text = "Date: ";
                    a.lb_time.Text = "Time: ";
                    a.lb_batchno.Text = "BatchNO: ";
                    a.btn_thoat.Text = "Exit";
                    a.chb_hienthi.Text = "Show";
                    a.chb_luu.Text = "Save";
                    //}
                    //else 
                if (Properties.Settings.Default.Language == "vi")
                {
                    a.lb_programName.Text = "Chương Trình Quản Lý Dự Án\n Nencho";
                    a.lb_vision.Text = "Phiên bản :";
                    a.grb_1.Text = "Thông Tin PC";
                    a.lb_machine.Text = "Tên PC :";
                    a.lb_user_window.Text = "Tài khoản window:";
                    a.lb_ip.Text = "Địa chỉ IP :";
                    a.grb_2.Text = "Thông Tin Tài Khoản Đăng Nhập";
                    a.lb_username.Text = "Tên đăng nhập :";
                    a.lb_password.Text = "Mật khẩu :";
                    a.lb_role.Text = "Vai trò :";
                    a.lb_date.Text = "Ngày: ";
                    a.lb_time.Text = "Giờ: ";
                    a.lb_batchno.Text = "BatchNO: ";
                    a.btn_thoat.Text = "Thoát";
                    a.chb_hienthi.Text = "Hiển Thị";
                    a.chb_luu.Text = "Lưu";
                }
                a.lb_version.Text = @"1.0.2";
                a.UrlUpdateVersion = @"\\10.10.10.254\DE_Viet\2017\Nencho";
                a.LoginEvent += a_LoginEvent;
                a.ButtonLoginEven += a_ButtonLoginEven;
                if (a.ShowDialog() == DialogResult.OK)
                {
                    Global.StrMachine = a.StrMachine;
                    Global.StrUserWindow = a.StrUserWindow;
                    Global.StrIpAddress = a.StrIpAddress;
                    Global.StrUsername = a.StrUserName;
                    Global.StrBatch = a.StrBatch;
                    Global.StrRole = a.StrRole;
                    Global.Strtoken = a.Token;
                    frm_Main frMain = new frm_Main();

                    if (frMain.ShowDialog() == DialogResult.Yes)
                    {
                        frMain.Close();
                        temp = true;
                    }
                }
            }
            while (temp);
        }
        private static void a_ButtonLoginEven(int iLogin, string strMachine, string strUserWindow, string strIpAddress, string strUsername, string password, string strBatch, string strRole, string strToken, ref bool LoginOk)
        {
            if (iLogin == 1)
            {
                //Kiểm tra Token
                bool has = Global.DataNencho.tbl_TokenLogins.Any(w => w.UserName == strUsername && w.IDProject == Global.StrIdProject);
                if (has)
                {
                    var token = (from w in Global.DataNencho.tbl_TokenLogins where w.UserName == strUsername && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();
                    if (token == "")
                    {
                        Global.DataNencho.updateToken(strUsername, Global.StrIdProject, strToken);
                        Global.DataNencho.InsertLoginTime_new(strUsername, DateTime.Now, strUserWindow, strMachine, strIpAddress, strToken, Global.StrIdProject);
                        LoginOk = true;
                    }
                    else
                    {
                        if (MessageBox.Show("This user has logged in on another machine. Would you like to continue signing in?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            Global.DataNencho.updateToken(strUsername, Global.StrIdProject, strToken);
                            Global.DataNencho.InsertLoginTime_new(strUsername, DateTime.Now, strUserWindow, strMachine, strIpAddress, strToken, Global.StrIdProject);
                            LoginOk = true;
                        }
                        else
                        {
                            LoginOk = false;
                        }
                    }
                }
                else
                {
                    var token = new tbl_TokenLogin();
                    token.UserName = strUsername;
                    token.IDProject = Global.StrIdProject;
                    token.Token = "";
                    token.DateLogin = DateTime.Now; Global.DataNencho.tbl_TokenLogins.InsertOnSubmit(token);
                    Global.DataNencho.SubmitChanges();
                    LoginOk = true;
                    Global.DataNencho.updateToken(strUsername, Global.StrIdProject, strToken);
                    Global.DataNencho.InsertLoginTime_new(strUsername, DateTime.Now, strUserWindow, strMachine, strIpAddress, strToken, Global.StrIdProject);
                }
            }
        }
        private static void a_LoginEvent(string username, string password, ref string strVersion, ref int iKiemtraLogin, ref string role, ref ComboBox cbb)
        {
            try
            {
                iKiemtraLogin = Global.DataNencho.KiemTraLogin(username, password);
                strVersion = (from w in Global.DataNencho.tbl_Versions where w.IdProject == "Nencho" select w.Version).FirstOrDefault();
                role = (from w in Global.DataNencho.GetRoLeUser(username) select w.Column1).FirstOrDefault();
                if (iKiemtraLogin == 1 && role == "Checker1 ")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchDE(username);
                    cbb.DisplayMember = "Cot_Z";
                }
                else if (iKiemtraLogin == 1 && role == "Checker2 ")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchChecker(username);
                    cbb.DisplayMember = "Cot_Z";
                }
                else if (iKiemtraLogin == 1 && role == "Admin")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchAdmin(username);
                    cbb.DisplayMember = "Cot_Z";
                }
                else if (iKiemtraLogin == 1 && role == "Checker1 Checker2 ")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchDE_Cheker(username);
                    cbb.DisplayMember = "Cot_Z";
                }
                else if (iKiemtraLogin == 1 && role == "Checker1 Admin")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchDE_Admin(username);
                    cbb.DisplayMember = "Cot_Z";
                }
                else if (iKiemtraLogin == 1 && role == "Checker2 Admin")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchChecker_Admin(username);
                    cbb.DisplayMember = "Cot_Z";
                }
                else if (iKiemtraLogin == 1 && role == "Checker1 Checker2 Admin")
                {
                    cbb.DataSource = Global.DataNencho.GetBatchDe_Checker_Admin(username);
                    cbb.DisplayMember = "Cot_Z";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting to server, please check your connection Internet");
            }
        }
    }
}