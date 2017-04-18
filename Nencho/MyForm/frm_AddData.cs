using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nencho.MyForm
{
    public partial class frm_adddata : DevExpress.XtraEditors.XtraForm
    {
        public frm_adddata()
        {
            InitializeComponent();
        }

        public bool Cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
            return true;
        }

        public void LoadNumericalGridview(object sender, RowIndicatorCustomDrawEventArgs e, GridView dgv)
        {
            try
            {
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    SizeF size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 width = Convert.ToInt32(size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { Cal(width, dgv); }));
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_column36_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_column36);
        }

        private void dgv_column37_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_column37);
        }

        private void dgv_column38_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_column38);
        }

        private void frm_adddata_Load(object sender, EventArgs e)
        {
            gridControl_column36.DataSource = Global.DataNencho.GetDataColumn36();
            gridControl_column37.DataSource = Global.DataNencho.GetDataColumn37();
            cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
            cbb_column38.DisplayMember = "dataColumn37";
            gridControl_column38.DataSource = Global.DataNencho.GetDataColumn38();
        }

        private void dgv_column36_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            string strColumn36 = dgv_column36.GetRowCellValue(dgv_column36.FocusedRowHandle, "dataColumn36").ToString();
            rtb_column36.Text = "";
            rtb_column36.Text = strColumn36;
        }

        private void btn_add_column36_Click(object sender, EventArgs e)
        {
            int r = Global.DataNencho.InSertDataColumn36(rtb_column36.Text);

            if (r == 1)
            {
                MessageBox.Show("This data already exists in the system.");
            }
            else if (r == 0)
            {
                gridControl_column36.DataSource = Global.DataNencho.GetDataColumn36();
                MessageBox.Show("Saved data.");
            }
        }

        private void btn_edit_column36_Click(object sender, EventArgs e)
        {
            string column36 = dgv_column36.GetRowCellValue(dgv_column36.FocusedRowHandle, "id").ToString();
            DialogResult thongbao = MessageBox.Show("You sure you want to edit Data '" + column36 + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.DataNencho.UpdateDataColumn36(Convert.ToInt32(dgv_column36.GetRowCellValue(dgv_column36.FocusedRowHandle, "id").ToString()), rtb_column36.Text);
                if (r == 1)
                {
                    gridControl_column36.DataSource = Global.DataNencho.GetDataColumn36();
                    MessageBox.Show("Saved data.");
                }
                else if (r == 0)
                {
                    MessageBox.Show("Unsaved data, please check back.");
                }
            }
        }

        private void btn_delete_column36_Click(object sender, EventArgs e)
        {
            string column36 = dgv_column36.GetRowCellValue(dgv_column36.FocusedRowHandle, "id").ToString();
            DialogResult thongbao = MessageBox.Show("You sure you want to delete Data '" + column36 + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.DataNencho.DeleteDataColumn36(Convert.ToInt32(dgv_column36.GetRowCellValue(dgv_column36.FocusedRowHandle, "id").ToString()));
                if (r == 1)
                {
                    gridControl_column36.DataSource = Global.DataNencho.GetDataColumn36();
                    MessageBox.Show("Deleted data.");
                }
                else if (r == 0)
                {
                    MessageBox.Show("Not delete this data, please check back.");
                }
            }
        }

        private void dgv_column37_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            string strColumn37 = dgv_column37.GetRowCellValue(dgv_column37.FocusedRowHandle, "dataColumn37").ToString();
            rtb_column37.Text = "";
            rtb_column37.Text = strColumn37;
        }

        private void btn_add_column37_Click(object sender, EventArgs e)
        {
            int r = Global.DataNencho.InSertDataColumn37(rtb_column37.Text);

            if (r == 1)
            {
                MessageBox.Show("This data already exists in the system.");
            }
            else if (r == 0)
            {
                cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
                cbb_column38.DisplayMember = "dataColumn37";
                gridControl_column37.DataSource = Global.DataNencho.GetDataColumn37();
                MessageBox.Show("Saved data.");
            }
        }

        private void btn_edit_column37_Click(object sender, EventArgs e)
        {
            string column37 = dgv_column37.GetRowCellValue(dgv_column37.FocusedRowHandle, "id").ToString();
            DialogResult thongbao = MessageBox.Show("You sure you want to edit Data '" + column37 + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.DataNencho.UpdateDataColumn37(Convert.ToInt32(dgv_column37.GetRowCellValue(dgv_column37.FocusedRowHandle, "id").ToString()), rtb_column37.Text);
                if (r == 1)
                {
                    cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
                    cbb_column38.DisplayMember = "dataColumn37";
                    gridControl_column37.DataSource = Global.DataNencho.GetDataColumn37();
                    MessageBox.Show("Saved data.");
                }
                else if (r == 0)
                {
                    MessageBox.Show("Not delete this data, please check back.");
                }
            }
        }

        private void btn_delete_column37_Click(object sender, EventArgs e)
        {
            string column37 = dgv_column37.GetRowCellValue(dgv_column37.FocusedRowHandle, "id").ToString();
            DialogResult thongbao = MessageBox.Show("You sure you want to delete Data '" + column37 + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.DataNencho.DeleteDataColumn37(Convert.ToInt32(dgv_column37.GetRowCellValue(dgv_column37.FocusedRowHandle, "id").ToString()));
                if (r == 1)
                {
                    cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
                    cbb_column38.DisplayMember = "dataColumn37";
                    gridControl_column37.DataSource = Global.DataNencho.GetDataColumn37();
                    MessageBox.Show("Deleted data.");
                }
                else if (r == 0)
                {
                    MessageBox.Show("Not delete this data, please check back.");
                }
            }
        }

        private void dgv_column38_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            string strColumn38 = dgv_column38.GetRowCellValue(dgv_column38.FocusedRowHandle, "dataColumn38").ToString();
            rtb_column38.Text = "";
            rtb_column38.Text = strColumn38;
            cbb_column38.Text = "";
            cbb_column38.SelectedText = dgv_column38.GetRowCellValue(dgv_column38.FocusedRowHandle, "dataColumn37").ToString();
        }

        private void btn_add_column38_Click(object sender, EventArgs e)
        {
            int r = Global.DataNencho.InSertDataColumn38(cbb_column38.Text, rtb_column38.Text);

            if (r == 1)
            {
                MessageBox.Show("This data already exists in the system.");
            }
            else if (r == 0)
            {
                cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
                cbb_column38.DisplayMember = "dataColumn37";
                gridControl_column38.DataSource = Global.DataNencho.GetDataColumn38();
                MessageBox.Show("Saved data.");
            }
        }

        private void btn_edit_column38_Click(object sender, EventArgs e)
        {
            string column38 = dgv_column38.GetRowCellValue(dgv_column38.FocusedRowHandle, "id").ToString();
            DialogResult thongbao = MessageBox.Show("You sure you want to edit Data '" + column38 + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.DataNencho.UpdateDataColumn38(Convert.ToInt32(dgv_column38.GetRowCellValue(dgv_column38.FocusedRowHandle, "id").ToString()), cbb_column38.Text, rtb_column38.Text);
                if (r == 1)
                {
                    cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
                    cbb_column38.DisplayMember = "dataColumn37";
                    gridControl_column38.DataSource = Global.DataNencho.GetDataColumn38();
                    MessageBox.Show("Saved data.");
                }
                else if (r == 0)
                {
                    MessageBox.Show("Not delete this data, please check back.");
                }
            }
        }

        private void btn_delete_column38_Click(object sender, EventArgs e)
        { string column38 = dgv_column38.GetRowCellValue(dgv_column38.FocusedRowHandle, "id").ToString();
            DialogResult thongbao = MessageBox.Show("You sure you want to edit Data '" + column38 + "'", "Affirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                int r = Global.DataNencho.DeleteDataColumn38(Convert.ToInt32(dgv_column38.GetRowCellValue(dgv_column38.FocusedRowHandle, "id").ToString()));
                if (r == 1)
                {
                    cbb_column38.DataSource = Global.DataNencho.GetDataColumn37();
                    cbb_column38.DisplayMember = "dataColumn37";
                    gridControl_column38.DataSource = Global.DataNencho.GetDataColumn38();
                    MessageBox.Show("Unsaved data, please check back.");
                }
                else if (r == 0)
                {
                    MessageBox.Show("Not delete this data, please check back.");
                }
            }
        }
    }
}