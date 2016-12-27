using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Nencho.MyForm
{
    public partial class frm_ManagerUser : XtraForm
    {
        public frm_ManagerUser()
        {
            InitializeComponent();
        }

        private void frm_ManagerUser_Load(object sender, EventArgs e)
        {
            dgv_listuser.DataSource = Global.DataNencho.GetListUser();
            cbb_role.DataSource = Global.DataNencho.GetListRole();
            cbb_role.DisplayMember = "RoleName";
            cbb_role.ValueMember = "IdRole";
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string username = gridView1.GetFocusedRowCellValue("UserName") != null ? gridView1.GetFocusedRowCellValue("UserName").ToString() : "";
            DialogResult thongbao = MessageBox.Show("Bạn chắc chắn muốn xóa UserName '" + username + "'", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(username))
                {
                    Global.DataNencho.DeleteUsername(username);
                    frm_ManagerUser_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Username không tồn tại, không thể xóa!");
                }
            }
        }

        private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            string Username, Password, roleid, nhanvien;

            Username = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserName").ToString();
            Password = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString();
            roleid = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IdRole").ToString();
            nhanvien = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Nhanvien").ToString();

            txt_username.Text = Username;
            txt_password.Text = Password;
            txt_nhanvien.Text = nhanvien;
            cbb_role.SelectedValue = roleid;}

        private void btn_them_Click(object sender, EventArgs e)
        {
            string pass = GetMd5Hash(txt_password.Text);

            string roleid = cbb_role.SelectedValue != null ? cbb_role.SelectedValue.ToString() : "";

            if (!string.IsNullOrEmpty(roleid) && !string.IsNullOrEmpty(txt_nhanvien.Text) && !string.IsNullOrEmpty(txt_username.Text) && !string.IsNullOrEmpty(pass))
            {
                int r = Global.DataNencho.InsertUser(txt_username.Text, pass, roleid, txt_nhanvien.Text);
                if (r == 0)
                {
                    MessageBox.Show("UserName đã tồn tại, Vui lòng nhập UserName khác !");
                }
                if (r == 1)
                {
                    MessageBox.Show("Đã thêm UserName '" + txt_username.Text + "' !");
                    frm_ManagerUser_Load(sender, e);
                    txt_username.Text = "";
                    txt_nhanvien.Text = "";
                    txt_password.Text = "";
                    txt_username.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin trước khi lưu !");
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string pass = GetMd5Hash(txt_password.Text);
            string roleid = cbb_role.SelectedValue != null ? cbb_role.SelectedValue.ToString() : "";

            if (!string.IsNullOrEmpty(roleid) && !string.IsNullOrEmpty(txt_nhanvien.Text) && !string.IsNullOrEmpty(txt_username.Text) && !string.IsNullOrEmpty(pass))
            {
                DialogResult thongbao = MessageBox.Show("Bạn chắc chắn muốn sửa UserName '" + txt_username.Text + "'", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    Global.DataNencho.UpdateUser(txt_username.Text, pass, roleid, txt_nhanvien.Text);
                    frm_ManagerUser_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin trước khi lưu !");
            }
        }
    }
}