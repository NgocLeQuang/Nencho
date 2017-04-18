using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Nencho.MyForm
{
    public partial class frm_ManagerUser : XtraForm
    {
        public frm_ManagerUser()
        {
            InitializeComponent();
        }

        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private void frm_ManagerUser_Load(object sender, EventArgs e)
        {
            dgv_listuser.DataSource = Global.DataNencho.GetListUser();
        }
       
        private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            try
            {
                string Username, Password, nhanvien;

                Username = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserName")!=null? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserName").ToString():"";
                Password = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password")!= null? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString():"";
                nhanvien = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Nhanvien")!=null? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Nhanvien").ToString():"";

                txt_username.Text = Username;
                txt_password.Text = Password;
                txt_nhanvien.Text = nhanvien;
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                var token = (from w in Global.DataNencho.GetToken(Global.StrUsername) select w.Token).FirstOrDefault();
                if (token == Global.Strtoken)
                {
                    string pass = GetMd5Hash(txt_password.Text);

                    if (!string.IsNullOrEmpty(txt_nhanvien.Text) && !string.IsNullOrEmpty(txt_username.Text) && !string.IsNullOrEmpty(pass))
                    {
                        int r = Global.DataNencho.InsertUser(txt_username.Text, pass, null, txt_nhanvien.Text);
                        if (r == 0)
                        {
                            MessageBox.Show("UserName already exists, Please enter another UserName !");
                        }
                        if (r == 1)
                        {
                            MessageBox.Show("Added UserName '" + txt_username.Text + "' !");
                            frm_ManagerUser_Load(sender, e);
                            txt_username.Text = "";
                            txt_nhanvien.Text = "";
                            txt_password.Text = "";
                            txt_username.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter the full information before saving!");
                    }
                }
                else
                {
                    MessageBox.Show("Your username is logged in on another PC, please log in again and repeat transactions!");
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                var token = (from w in Global.DataNencho.GetToken(Global.StrUsername) select w.Token).FirstOrDefault();
                if (token == Global.Strtoken)
                {
                    string pass = GetMd5Hash(txt_password.Text);

                    if (!string.IsNullOrEmpty(txt_nhanvien.Text) && !string.IsNullOrEmpty(txt_username.Text) &&
                        !string.IsNullOrEmpty(pass))
                    {
                        DialogResult thongbao =
                            MessageBox.Show("You sure want to edit UserName information '" + txt_username.Text + "'",
                                "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (thongbao == DialogResult.Yes)
                        {
                            Global.DataNencho.UpdateUser(txt_username.Text, pass, null, txt_nhanvien.Text);
                            frm_ManagerUser_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter the full information before saving!");
                    }
                }
                else
                {
                    MessageBox.Show("Your user is logged in on another PC, please log in again and repeat transactions!!");
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i);
            }
        }
        
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string username = gridView1.GetFocusedRowCellValue("UserName") != null ? gridView1.GetFocusedRowCellValue("UserName").ToString() : "";
                DialogResult thongbao = MessageBox.Show("You sure you want to delete UserName '" + username + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        Global.DataNencho.DeleteUsername(username);
                        frm_ManagerUser_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Username does not exist, can't removed!");
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i);
            }
        }

        private void btn_delete_user_Click(object sender, EventArgs e)
        {
            try
            {
                string username = gridView1.GetFocusedRowCellValue("UserName") != null ? gridView1.GetFocusedRowCellValue("UserName").ToString() : "";
                DialogResult thongbao = MessageBox.Show("You sure you want to delete UserName '" + username + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        Global.DataNencho.DeleteUsername(username);
                        frm_ManagerUser_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Username does not exist, can't removed!");
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i);
            }
        }
    }
}