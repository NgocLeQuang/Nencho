using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Nencho.MyForm
{
    public partial class frm_Main : XtraForm
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult=DialogResult.Yes;
        }

        private void btn_exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_quanlyuser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ManagerUser fuser=new frm_ManagerUser();
            fuser.ShowDialog();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            if (Global.StrRole == "Admin")
            {
                baritem_Manager.Enabled = true;

            }
        }
    }
}