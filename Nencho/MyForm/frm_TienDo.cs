using System;
using System.Data;
using System.Linq;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace Nencho.MyForm
{
    public partial class frm_TienDo : XtraForm
    {
        private string loai;
        public frm_TienDo()
        {
            InitializeComponent();
        }

        private void frm_TienDo_Load(object sender, EventArgs e)
        {
            var fBatchName = (from w in Global.DataNencho.tbl_Batches orderby w.ID select new { w.fBatchName }).ToList();
            cbb_Batch.Properties.DataSource = fBatchName;
            cbb_Batch.Properties.DisplayMember = "fBatchName";
            cbb_Batch.Properties.ValueMember = "fBatchName";
            cbb_Batch.Text = Global.StrBatch;
        }
        private void ThongKe()
        {
            try
            {
                if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value == "CHECKER1")
                {
                    chartControl1.DataSource = null;
                    chartControl1.Series.Clear();
                    chartControl1.DataSource = Global.DataNencho.ThongKeTienDo_Checker1(cbb_Batch.Text);
                    Series series1 = new Series("Series1", ViewType.Pie);
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "name";
                    series1.ValueScaleType = ScaleType.Numerical;
                    series1.ValueDataMembers.AddRange(new string[] { "soluong" });
                    chartControl1.Series.Add(series1);
                    ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                    chartControl1.PaletteName = "Palette 1";
                    loai = "CHECKER1";
                    btn_ChiTiet.Visible = true;
                }
                else
                {
                    chartControl1.DataSource = null;
                    chartControl1.Series.Clear();
                    chartControl1.DataSource = Global.DataNencho.ThongKeTienDo_Checker2(cbb_Batch.Text);
                    Series series1 = new Series("Series1", ViewType.Pie);
                    series1.ArgumentScaleType = ScaleType.Qualitative;
                    series1.ArgumentDataMember = "name";
                    series1.ValueScaleType = ScaleType.Numerical;
                    series1.ValueDataMembers.AddRange(new string[] { "soluong" });
                    chartControl1.Series.Add(series1);
                    ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                    chartControl1.PaletteName = "Palette 1";
                    loai = "CHECKER2";
                    btn_ChiTiet.Visible = true;
                }
               
            }
            catch (Exception)
            {

            }

        }

        private void cbb_Batch_EditValueChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            var frm = new frm_ChiTietTienDo();
            frm.lb_fBatchName.Text = cbb_Batch.Text;
            frm.Loai = loai;
            frm.ShowDialog();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe();
        }
    }
}