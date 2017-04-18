using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nencho.MyForm
{
    public partial class frm_ManagerFile : DevExpress.XtraEditors.XtraForm
    {
        public frm_ManagerFile()
        {
            InitializeComponent();
        }

        private void RefreshGrid()
        {
            var dbGrid = from w in Global.DataNencho.tbl_Batches select new { w.fBatchName, w.UserCreate, w.DateCreate, w.UrlFileExcel };
            gridControl1.DataSource = dbGrid;
        }

        private void btn_AddBatch_Click(object sender, EventArgs e)
        {
            new frm_CreateFile().ShowDialog();
            RefreshGrid();
        }

        private void frm_ManagerFile_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btn_DeleteBatch_Click(object sender, EventArgs e)
        {
            try
            {
                string fbatchname = gridView1.GetFocusedRowCellValue("fBatchName").ToString();
                if (MessageBox.Show("You sure you want to remove the batch: " + fbatchname + "?", "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Global.DataNencho.DeleteFile(fbatchname);
                    MessageBox.Show("Delete Batch success!");
                    RefreshGrid();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Batch to delete!");
            }
        }
    }
}