using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Nencho.MyForm
{
    public partial class frm_Main : XtraForm
    {
        private DataView clone = null;
        public frm_Main()
        {
            InitializeComponent();
        }

        public bool Cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
            return true;
        }
        private void SetComboBox(System.Windows.Forms.ComboBox cbb)
        {
            foreach (string item in cbb.Items)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item == Global.StrBatch)
                    {
                        cbb.SelectedItem = Global.StrBatch;
                        break;
                    }
                }
            }
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

        private void SetValueText(string truongSo, GridView dgv)
        {
            var values = dgv.GetRowCellValue(dgv.FocusedRowHandle, truongSo) != null ? dgv.GetRowCellValue(dgv.FocusedRowHandle, truongSo).ToString() : "";
            if (values == "1")
                dgv.SetRowCellValue(dgv.FocusedRowHandle, truongSo, "○");
        }

        private void SetColorCell(object sender, RowCellStyleEventArgs e, string fielname, string s)
        {
            try
            {
                GridView view = sender as GridView;
                string cot = view.GetRowCellDisplayText(e.RowHandle, view.Columns[fielname]);
                if (e.Column.FieldName == fielname && e.RowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
                {
                    if (cot == s)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }
        private void SetColorCell1(object sender, RowCellStyleEventArgs e, string fielname, string s)
        {
            try
            {
                GridView view = sender as GridView;
                string cot = view.GetRowCellDisplayText(e.RowHandle, view.Columns[fielname]);
                if (e.Column.FieldName == fielname && e.RowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
                {
                    if (cot != s)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }
        private void LoadDE()
        {
            //---Load Tab DE
            //Load Data Combobox BatchNoComplete DE

            cbb_batchnode_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;

            //Load Data Combobox BatchNO DE

            if (!string.IsNullOrEmpty((Global.StrBatch)))
            {
                cbb_batchno_de.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value == false && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                SetComboBox(cbb_batchno_de);
            }

            if (!string.IsNullOrEmpty(cbb_batchno_de.Text))
            {
                btn_submit_de.Enabled = true;
            }

            //Load gridControl DE

            gridControl_de.DataSource = Global.DataNencho.GetDataDE(cbb_batchno_de.Text, Global.StrUsername);
            Lookupedit_column36.DataSource = from w in Global.DataNencho.tbl_DataColumn36s select w.dataColumn36;
            Lookupedit_Column37.DataSource = from w in Global.DataNencho.tbl_DataColumn37s select w.dataColumn37;
            Lookupedit_Column38.DataSource = from w in Global.DataNencho.tbl_DataColumn38s select w.dataColumn38;

            tab_checker1.PageVisible = true;
            tab_error.PageVisible = true;
            tab_error_checker1.PageVisible = true;

        }
        private void LoadCheck()
        {
            //---Load Tab Checker
            //Load Data Combobox BatchNoComplete Chercker

            cbb_batchnochecker_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Check.Value && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;

            //Load Data Combobox BatchNo_Checker

            if (!string.IsNullOrEmpty(Global.StrBatch))
            {
                cbb_batchno_checker.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.SubmitFile_Check.Value == false && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                SetComboBox(cbb_batchno_checker);
            }

            if (!string.IsNullOrEmpty(cbb_batchno_checker.Text))
            {
                btn_submit_checker.Enabled = true;
            }

            //Load Data gridControl Checker

            gridControl_checker.DataSource = Global.DataNencho.GetDataChecker(cbb_batchno_checker.Text, Global.StrUsername);
            LookUpEdit_Column57.DataSource = from w in Global.DataNencho.tbl_DataColumn36s select w.dataColumn36;
            LookUpEdit_Column58.DataSource = from w in Global.DataNencho.tbl_DataColumn37s select w.dataColumn37;
            LookUpEdit_Column59.DataSource = from w in Global.DataNencho.tbl_DataColumn38s select w.dataColumn38;

            tab_checker2.PageVisible = true;
            tab_error.PageVisible = true;
            tab_error_checker2.PageVisible = true;
        }
        private void LoadAdmin()
        {
            //---Load Tad Admin
            //Load Data Combobox Batchno Admin and Load Data Combobox BatNo Amin Completed

            if (!string.IsNullOrEmpty(Global.StrBatch))
            {
                btn_submit_admin.Text = "Submit";
                cbb_batchnoadmin_complete.DataSource = (from w in Global.DataNencho.GetBatchAdmin_Complete(Global.StrUsername) select w.Cot_Z).ToList();
                cbb_batchnoadmin_complete.DisplayMember = "Cot_Z";
                cbb_batchno_admin.DataSource = (from w in Global.DataNencho.GetBatchAdmin(Global.StrUsername) select w.Cot_Z).ToList();
                cbb_batchno_admin.DisplayMember = "Cot_Z";
                SetComboBox(cbb_batchno_admin);
                gridControl_checker2.DataSource = Global.DataNencho.GetDataChecker_TabAdmin(cbb_batchno_admin.Text);
                gridControl_admin.DataSource = Global.DataNencho.GetDataAdmin(cbb_batchno_admin.Text, Global.StrUsername);
            }
            else
            {
                btn_submit_admin.Text = "Edit";
                cbb_batchnoadmin_complete.DataSource = Global.DataNencho.GetBatchAdmin_Complete(Global.StrUsername);
                cbb_batchnoadmin_complete.DisplayMember = "Cot_Z";
                gridControl_checker2.DataSource = Global.DataNencho.GetDataChecker_TabAdmin(cbb_batchnoadmin_complete.Text);
                gridControl_admin.DataSource = Global.DataNencho.GetDataAdminComplete(cbb_batchnoadmin_complete.Text, Global.StrUsername);
            }
            
            //Load Data GridControl Checker

            LookUpEdit_Column96.DataSource = from w in Global.DataNencho.tbl_DataColumn36s select w.dataColumn36;
            LookUpEdit_Column97.DataSource = from w in Global.DataNencho.tbl_DataColumn37s select w.dataColumn37;
            LookUpEdit_Column98.DataSource = from w in Global.DataNencho.tbl_DataColumn38s select w.dataColumn38;

            //Load Data GridControl Admin

            baritem_Option.Enabled = true;
            baritem_Manager.Enabled = true;
            tab_admin.PageVisible = true;
            tab_checker1.PageVisible = true;
            tab_checker2.PageVisible = true;

            dgv_de.OptionsBehavior.ReadOnly = true;
            dgv_checker.OptionsBehavior.ReadOnly = true;

            tab_error.PageVisible = false;
            tab_error_checker1.PageVisible = false;
            dgv_error_checker1.OptionsBehavior.ReadOnly = true;
            tab_error_checker2.PageVisible = false;
            dgv_error_checker2.OptionsBehavior.ReadOnly = true;
            //Load Data other But not edit
            //----Load Data  DE

            cbb_batchnode_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.Cot_Z != null && w.Cot_Z != "" && w.Cot_Z != " All" group w by w.Cot_Z into g select g.Key;
            cbb_batchno_de.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value == false && w.Cot_Z != null && w.Cot_Z != "" && w.Cot_Z != " All" group w by w.Cot_Z into g select g.Key;
            SetComboBox(cbb_batchno_de);
            gridControl_de.DataSource = Global.DataNencho.GetDataDE(cbb_batchno_de.Text,"");
            btn_submit_de.Enabled = false;
            dgv_de.OptionsBehavior.ReadOnly = true;

            //----Load Data Checker
            cbb_batchnochecker_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Check.Value && w.Cot_Z != null && w.Cot_Z != "" && w.Cot_Z != " All" group w by w.Cot_Z into g select g.Key;
            cbb_batchno_checker.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.SubmitFile_Check.Value == false && w.Cot_Z != null && w.Cot_Z != "" && w.Cot_Z != " All" group w by w.Cot_Z into g select g.Key;
            SetComboBox(cbb_batchno_checker);
            gridControl_checker.DataSource = Global.DataNencho.GetDataChecker(cbb_batchno_checker.Text, "");
            btn_submit_checker.Enabled = false;
            dgv_checker.OptionsBehavior.ReadOnly = true;
            //---Load Data Error

        }

        private void LoadError_De()
        {
            cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Input == true && w.SubmitFile_Input_2.Value && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;

            //Load Data Combobox BatchNO Error
            if (!string.IsNullOrEmpty((Global.StrBatch)))
            {
                cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Input == true && w.SubmitFile_Input_2.Value == false && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                SetComboBox(cbb_batchno_error);
                gridControl_error_cherker1.DataSource = Global.DataNencho.GetDataErrorDE(Global.StrBatch, Global.StrUsername);
            }

            //Load gridControl DE
            gridControl_de.DataSource = Global.DataNencho.GetDataDE(cbb_batchno_de.Text, Global.StrUsername);

            tab_checker1.PageVisible = true;
            tab_error_checker1.PageVisible = true;
            dgv_error_checker1.OptionsBehavior.ReadOnly = false;
        }

        private void LoadError_Checker()
        {
            cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Check == true && w.SubmitFile_Check_2.Value && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;

            //Load Data Combobox BatchNO Error
            if (!string.IsNullOrEmpty((Global.StrBatch)))
            {
                cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Check == true && w.SubmitFile_Check_2.Value == false && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                SetComboBox(cbb_batchno_error);
                gridControl_error_checker2.DataSource = Global.DataNencho.GetDataErrorChecker(Global.StrBatch, Global.StrUsername);
            }

            //Load gridControl Checker
            gridControl_de.DataSource = Global.DataNencho.GetDataDE(cbb_batchno_de.Text, Global.StrUsername);
            dgv_error_checker2.OptionsBehavior.ReadOnly = false;
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                baritem_Option.Enabled = false;
                baritem_Manager.Enabled = false;
                tab_admin.PageVisible = false;
                tab_checker1.PageVisible = false;
                tab_checker2.PageVisible = false;
                tab_error.PageVisible = false;
                tab_error_checker1.PageVisible = false;
                tab_error_checker2.PageVisible = false;

                if (Global.StrRole == "ADMIN")
                {
                    LoadAdmin();
                }
                else if (Global.StrRole == "CHECKER1 ")
                {
                    LoadDE();
                    LoadError_De();
                }
                else if (Global.StrRole == "CHECKER2 ")
                {
                    LoadCheck();
                    LoadError_Checker();
                }
                else if (Global.StrRole == "CHECKER1 CHECKER2 ")
                {
                    LoadDE();
                    LoadCheck();
                    cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Check == true && w.SubmitFile_Check_2.Value && w.Cot_AB == Global.StrUsername) || (w.Error_Input == true && w.SubmitFile_Input_2.Value && w.Cot_AA == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                    cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Input == true && w.SubmitFile_Input_2.Value == false && w.Cot_AA == Global.StrUsername) || (w.Error_Check == true && w.SubmitFile_Check_2.Value == false && w.Cot_AB == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                }
                else if (Global.StrRole == "CHECKER1 ADMIN")
                {
                    LoadAdmin();
                    LoadDE();
                    LoadError_De();
                }
                else if (Global.StrRole == "CHECKER2 ADMIN")
                {
                    LoadAdmin();
                    LoadCheck();
                    LoadError_Checker();
                }
                else if (Global.StrRole == "CHECKER1 CHECKER2 ADMIN")
                {
                    LoadAdmin();
                    LoadDE();
                    LoadCheck();
                    cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Check == true && w.SubmitFile_Check_2.Value && w.Cot_AB == Global.StrUsername) || (w.Error_Input == true && w.SubmitFile_Input_2.Value && w.Cot_AA == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                    cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Input == true && w.SubmitFile_Input_2.Value == false && w.Cot_AA == Global.StrUsername) || (w.Error_Check == true && w.SubmitFile_Check_2.Value == false && w.Cot_AB == Global.StrUsername) group w by w.Cot_Z into g select g.Key;

                }
                //---Load Tab Division

                cbb_batchno_division.DataSource = Global.DataNencho.GetBatchDivision();
                cbb_batchno_division.DisplayMember = "Cot_Z";
                cbb_batchno_division.ValueMember = "Cot_Z";
                cbb_batchno_division.Text = " All";
                gridControl_Division.DataSource = Global.DataNencho.GetDataDivision_Load();

                if (!string.IsNullOrEmpty(cbb_batchno_error.Text))
                {
                    btn_submit_error.Enabled = true;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void btn_logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btn_exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }


        private void btn_nangsuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_NangSuat().ShowDialog();
            frm_Main_Load(sender, e);
        }
        private void btn_quanlyuser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ManagerUser fuser = new frm_ManagerUser();
            fuser.ShowDialog();
            frm_Main_Load(sender, e);
        }

        private void btn_adddata_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_adddata f = new frm_adddata();
            f.ShowDialog();
            frm_Main_Load(sender, e);
        }

        private void btn_ManagerFiles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_ManagerFile().ShowDialog();
            frm_Main_Load(sender, e);
        }

        private void btn_ExportExcel_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ExportExcel frmExportExcel = new frm_ExportExcel();
            frmExportExcel.ShowDialog();
            frm_Main_Load(sender, e);
        }

        #region Tabdivision

        private void dgv_Division_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            //Load numerical order of gridControl
            LoadNumericalGridview(sender, e, dgv_Division);
        }

        private void dgv_Division_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                //Load Color cell gridControl
                SetColorCell(sender, e, "Cot_M", "0");
                SetColorCell(sender, e, "Cot_N", "0");
                SetColorCell1(sender, e, "Cot_S", "0");
                SetColorCell1(sender, e, "Cot_T", "0");
                SetColorCell1(sender, e, "Cot_U", "0");
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbbbatchno_division_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl_Division.DataSource = Global.DataNencho.GetDataDivision(cbb_batchno_division.Text);
            if (cbb_batchno_division.Text == " All")
                gridControl_Division.DataSource = Global.DataNencho.GetDataDivision_Load();
        }

        #endregion Tabdivision

        #region Tab_DE
        
        private void Lookupedit_Column37_EditValueChanged(object sender, EventArgs e)
        {
            dgv_de.SetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38", "");
        }
        
        private void dgv_de_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;
                if (view.FocusedColumn.FieldName == "Truong_38")
                {
                    LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                    string countryCode = Convert.ToString(view.GetFocusedRowCellValue("Truong_37"));
                    editor.Properties.DataSource = from w in Global.DataNencho.tbl_DataColumn38s where w.dataColumn37 == countryCode select w.dataColumn38;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbb_batchnode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "CHECKER1 " || Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN" || Global.StrRole == "CHECKER1 ADMIN")
                {
                    gridControl_de.DataSource = Global.DataNencho.GetDataDE(cbb_batchno_de.Text, Global.StrUsername);
                    btn_submit_de.Enabled = !string.IsNullOrEmpty(cbb_batchno_de.Text);
                    dgv_de.OptionsBehavior.ReadOnly = false;
                }
                else
                {
                    gridControl_de.DataSource = Global.DataNencho.GetDataDE(cbb_batchno_de.Text, "");
                    dgv_de.OptionsBehavior.ReadOnly = true;
                    btn_submit_de.Enabled = false;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_de_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                SetValueText("Truong_26", dgv_de);
                SetValueText("Truong_27", dgv_de);
                SetValueText("Truong_28", dgv_de);
                SetValueText("Truong_29", dgv_de);
                SetValueText("Truong_30", dgv_de);
                SetValueText("Truong_31", dgv_de);
                SetValueText("Truong_32", dgv_de);
                SetValueText("Truong_33", dgv_de);
                SetValueText("Truong_34", dgv_de);
                SetValueText("Truong_35", dgv_de);
                if (e.Column.FieldName == "Truong_40")
                {
                    dgv_de.PostEditor();
                    var valueTruong40 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_40") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_40").ToString() : "";
                    dgv_de.SetRowCellValue(dgv_de.FocusedRowHandle, "Truong_43", !string.IsNullOrEmpty(valueTruong40) ? "○" : "");
                }

                if (e.Column.FieldName == "Truong_36")
                {
                    if ((dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_36(dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }
                if (e.Column.FieldName == "Truong_37")
                {
                    if ((dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_37(dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }
                if (e.Column.FieldName == "Truong_38")
                {
                    if ((dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38").ToString() : "")!="")
                    {
                        int r = Global.DataNencho.CheckTruong_38(dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }

                string truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, truong39, truong40, truong41, truong42, truong43, cot_g;
                truong26 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_26") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_26").ToString() : "";
                truong27 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_27") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_27").ToString() : "";
                truong28 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_28") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_28").ToString() : "";
                truong29 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_29") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_29").ToString() : "";
                truong30 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_30") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_30").ToString() : "";
                truong31 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_31") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_31").ToString() : "";
                truong32 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_32") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_32").ToString() : "";
                truong33 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_33") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_33").ToString() : "";
                truong34 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_34") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_34").ToString() : "";
                truong35 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_35") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_35").ToString() : "";
                truong36 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_36").ToString() : "";
                truong37 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_37").ToString() : "";
                truong38 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_38").ToString() : "";
                truong39 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_39") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_39").ToString() : "";
                truong40 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_40") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_40").ToString() : "";
                truong41 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_41") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_41").ToString() : "";
                truong42 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_42") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_42").ToString() : "";
                truong43 = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_43") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Truong_43").ToString() : "";
                cot_g = dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Cot_G") != null ? dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle, "Cot_G").ToString() : "";

                Global.DataNencho.Update_TableInput(Global.StrUsername, cot_g, cbb_batchno_de.Text, truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, truong39, truong40, truong41, truong42, truong43);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_de_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_de);
        }

        private void btn_submit_de_Click(object sender, EventArgs e)
        {
            try
            {
                Global.DataNencho.UpdateTimeLastRequest(Global.Strtoken);
                DialogResult thongbao = MessageBox.Show("You certainly have completed Batch " + cbb_batchno_de.Text, "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                int countRowNull = 0; string s = null;
                if (thongbao == DialogResult.Yes)
                {
                    for (int i = 0; i < dgv_de.RowCount; i++)
                    {
                        if (string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_26") != null ? dgv_de.GetRowCellValue(i, "Truong_26").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_27") != null ? dgv_de.GetRowCellValue(i, "Truong_27").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_28") != null ? dgv_de.GetRowCellValue(i, "Truong_28").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_29") != null ? dgv_de.GetRowCellValue(i, "Truong_29").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_30") != null ? dgv_de.GetRowCellValue(i, "Truong_30").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_31") != null ? dgv_de.GetRowCellValue(i, "Truong_31").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_32") != null ? dgv_de.GetRowCellValue(i, "Truong_32").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_33") != null ? dgv_de.GetRowCellValue(i, "Truong_33").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_34") != null ? dgv_de.GetRowCellValue(i, "Truong_34").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_35") != null ? dgv_de.GetRowCellValue(i, "Truong_35").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_36") != null ? dgv_de.GetRowCellValue(i, "Truong_36").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_37") != null ? dgv_de.GetRowCellValue(i, "Truong_37").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_38") != null ? dgv_de.GetRowCellValue(i, "Truong_38").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_39") != null ? dgv_de.GetRowCellValue(i, "Truong_39").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_40") != null ? dgv_de.GetRowCellValue(i, "Truong_40").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_41") != null ? dgv_de.GetRowCellValue(i, "Truong_41").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_42") != null ? dgv_de.GetRowCellValue(i, "Truong_42").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_43") != null ? dgv_de.GetRowCellValue(i, "Truong_43").ToString() : "") ||
                            string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_40") != null ? dgv_de.GetRowCellValue(i, "Truong_40").ToString() : ""))
                        {
                            countRowNull += 1;
                            s += (i + 1) + "\n";
                        }
                    }
                    if (countRowNull == 0)
                    {
                        for (int i = 0; i < dgv_de.RowCount; i++)
                        {
                            string truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, cot_g;
                            truong26 = dgv_de.GetRowCellValue(i, "Truong_26") != null ? dgv_de.GetRowCellValue(i, "Truong_26").ToString() : "";
                            truong27 = dgv_de.GetRowCellValue(i, "Truong_27") != null ? dgv_de.GetRowCellValue(i, "Truong_27").ToString() : "";
                            truong28 = dgv_de.GetRowCellValue(i, "Truong_28") != null ? dgv_de.GetRowCellValue(i, "Truong_28").ToString() : "";
                            truong29 = dgv_de.GetRowCellValue(i, "Truong_29") != null ? dgv_de.GetRowCellValue(i, "Truong_29").ToString() : "";
                            truong30 = dgv_de.GetRowCellValue(i, "Truong_30") != null ? dgv_de.GetRowCellValue(i, "Truong_30").ToString() : "";
                            truong31 = dgv_de.GetRowCellValue(i, "Truong_31") != null ? dgv_de.GetRowCellValue(i, "Truong_31").ToString() : "";
                            truong32 = dgv_de.GetRowCellValue(i, "Truong_32") != null ? dgv_de.GetRowCellValue(i, "Truong_32").ToString() : "";
                            truong33 = dgv_de.GetRowCellValue(i, "Truong_33") != null ? dgv_de.GetRowCellValue(i, "Truong_33").ToString() : "";
                            truong34 = dgv_de.GetRowCellValue(i, "Truong_34") != null ? dgv_de.GetRowCellValue(i, "Truong_34").ToString() : "";
                            truong35 = dgv_de.GetRowCellValue(i, "Truong_35") != null ? dgv_de.GetRowCellValue(i, "Truong_35").ToString() : "";
                            truong36 = dgv_de.GetRowCellValue(i, "Truong_36") != null ? dgv_de.GetRowCellValue(i, "Truong_36").ToString() : "";
                            truong37 = dgv_de.GetRowCellValue(i, "Truong_37") != null ? dgv_de.GetRowCellValue(i, "Truong_37").ToString() : "";
                            truong38 = dgv_de.GetRowCellValue(i, "Truong_38") != null ? dgv_de.GetRowCellValue(i, "Truong_38").ToString() : "";
                            cot_g = dgv_de.GetRowCellValue(i, "Cot_G") != null ? dgv_de.GetRowCellValue(i, "Cot_G").ToString() : "";
                            Global.DataNencho.Update_TableFile_Checker1(cot_g, cbb_batchno_de.Text);
                            Global.DataNencho.InsertTableChecker(cot_g, cbb_batchno_de.Text, truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, "");
                        }
                        cbb_batchnode_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                        cbb_batchno_de.Text = "";
                        cbb_batchno_de.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value == false && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                    }
                    else
                    {
                        DialogResult notifyRowNull = MessageBox.Show("Still  " + countRowNull + " lines: \n" + s + "no data, you still want to Submit", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (notifyRowNull != DialogResult.Yes) return;
                        for (int i = 0; i < dgv_de.RowCount; i++)
                        {
                            if (!string.IsNullOrEmpty(dgv_de.GetRowCellValue(i, "Truong_40") != null ? dgv_de.GetRowCellValue(i, "Truong_40").ToString() : ""))
                            {
                                string truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, truong43, cot_g;
                                truong26 = dgv_de.GetRowCellValue(i, "Truong_26") != null ? dgv_de.GetRowCellValue(i, "Truong_26").ToString() : "";
                                truong27 = dgv_de.GetRowCellValue(i, "Truong_27") != null ? dgv_de.GetRowCellValue(i, "Truong_27").ToString() : "";
                                truong28 = dgv_de.GetRowCellValue(i, "Truong_28") != null ? dgv_de.GetRowCellValue(i, "Truong_28").ToString() : "";
                                truong29 = dgv_de.GetRowCellValue(i, "Truong_29") != null ? dgv_de.GetRowCellValue(i, "Truong_29").ToString() : "";
                                truong30 = dgv_de.GetRowCellValue(i, "Truong_30") != null ? dgv_de.GetRowCellValue(i, "Truong_30").ToString() : "";
                                truong31 = dgv_de.GetRowCellValue(i, "Truong_31") != null ? dgv_de.GetRowCellValue(i, "Truong_31").ToString() : "";
                                truong32 = dgv_de.GetRowCellValue(i, "Truong_32") != null ? dgv_de.GetRowCellValue(i, "Truong_32").ToString() : "";
                                truong33 = dgv_de.GetRowCellValue(i, "Truong_33") != null ? dgv_de.GetRowCellValue(i, "Truong_33").ToString() : "";
                                truong34 = dgv_de.GetRowCellValue(i, "Truong_34") != null ? dgv_de.GetRowCellValue(i, "Truong_34").ToString() : "";
                                truong35 = dgv_de.GetRowCellValue(i, "Truong_35") != null ? dgv_de.GetRowCellValue(i, "Truong_35").ToString() : "";
                                truong36 = dgv_de.GetRowCellValue(i, "Truong_36") != null ? dgv_de.GetRowCellValue(i, "Truong_36").ToString() : "";
                                truong37 = dgv_de.GetRowCellValue(i, "Truong_37") != null ? dgv_de.GetRowCellValue(i, "Truong_37").ToString() : "";
                                truong38 = dgv_de.GetRowCellValue(i, "Truong_38") != null ? dgv_de.GetRowCellValue(i, "Truong_38").ToString() : "";
                                //truong43 = dgv_de.GetRowCellValue(i, "Truong_43") != null ? dgv_de.GetRowCellValue(i, "Truong_43").ToString() : "";
                                cot_g = dgv_de.GetRowCellValue(i, "Cot_G") != null ? dgv_de.GetRowCellValue(i, "Cot_G").ToString() : "";

                                Global.DataNencho.Update_TableFile_Checker1(cot_g, cbb_batchno_de.Text);
                                Global.DataNencho.InsertTableChecker(cot_g, cbb_batchno_de.Text, truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, "");
                            }
                        }
                        cbb_batchnode_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                        cbb_batchno_de.Text = "";
                        cbb_batchno_de.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value == false && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbb_batchnode_complete_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "CHECKER1 " || Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN" || Global.StrRole == "CHECKER1 ADMIN")
                {
                    gridControl_de.DataSource = Global.DataNencho.GetDataDEComplete(cbb_batchnode_complete.Text, Global.StrUsername);
                }
                else
                {
                    gridControl_de.DataSource = Global.DataNencho.GetDataDEComplete(cbb_batchnode_complete.Text, "");
                }
                dgv_de.OptionsBehavior.ReadOnly = true;
                btn_submit_de.Enabled = false;
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        #endregion Tab_DE

        #region Tab_Checker

        private void LookUpEdit_Column58_EditValueChanged(object sender, EventArgs e)
        {
            dgv_checker.SetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38", "");
        }
        private void dgv_checker_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;
                if (view.FocusedColumn.FieldName == "Truong_38")
                {
                    LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                    string countryCode = Convert.ToString(view.GetFocusedRowCellValue("Truong_37"));
                    editor.Properties.DataSource = from w in Global.DataNencho.tbl_DataColumn38s where w.dataColumn37 == countryCode select w.dataColumn38;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbb_batchnochecker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN" || Global.StrRole == "CHECKER2 ADMIN")
                {
                    gridControl_checker.DataSource = Global.DataNencho.GetDataChecker(cbb_batchno_checker.Text, Global.StrUsername);
                    btn_submit_checker.Enabled = !string.IsNullOrEmpty(cbb_batchno_checker.Text);
                    dgv_checker.OptionsBehavior.ReadOnly = false;
                }
                else
                {
                    gridControl_checker.DataSource = Global.DataNencho.GetDataChecker(cbb_batchno_checker.Text, "");
                    btn_submit_checker.Enabled = false;
                    dgv_checker.OptionsBehavior.ReadOnly = true;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_checker_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                SetValueText("Truong_26", dgv_checker);
                SetValueText("Truong_27", dgv_checker);
                SetValueText("Truong_28", dgv_checker);
                SetValueText("Truong_29", dgv_checker);
                SetValueText("Truong_30", dgv_checker);
                SetValueText("Truong_31", dgv_checker);
                SetValueText("Truong_32", dgv_checker);
                SetValueText("Truong_33", dgv_checker);
                SetValueText("Truong_34", dgv_checker);
                SetValueText("Truong_35", dgv_checker);
                if (e.Column.FieldName == "Truong_40")
                {
                    dgv_checker.PostEditor();
                    var valueTruong40 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_40") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_40").ToString() : "";
                    dgv_checker.SetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_43", !string.IsNullOrEmpty(valueTruong40) ? "○" : "");
                }

                if (e.Column.FieldName == "Truong_36")
                {
                    if ((dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_36(dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }
                if (e.Column.FieldName == "Truong_37")
                {
                    if ((dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_37(dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }
                if (e.Column.FieldName == "Truong_38")
                {
                    if ((dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_38(dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }

                string truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, truong39, truong40, truong41, truong42, truong43, cot_g;
                truong26 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_26") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_26").ToString() : "";
                truong27 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_27") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_27").ToString() : "";
                truong28 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_28") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_28").ToString() : "";
                truong29 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_29") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_29").ToString() : "";
                truong30 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_30") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_30").ToString() : "";
                truong31 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_31") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_31").ToString() : "";
                truong32 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_32") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_32").ToString() : "";
                truong33 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_33") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_33").ToString() : "";
                truong34 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_34") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_34").ToString() : "";
                truong35 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_35") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_35").ToString() : "";
                truong36 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_36").ToString() : "";
                truong37 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_37").ToString() : "";
                truong38 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_38").ToString() : "";
                truong39 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_39") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_39").ToString() : "";
                truong40 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_40") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_40").ToString() : "";
                truong41 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_41") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_41").ToString() : "";
                truong42 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_42") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_42").ToString() : "";
                truong43 = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_43") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_43").ToString() : "";
                cot_g = dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Cot_G") != null ? dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle, "Cot_G").ToString() : "";

                Global.DataNencho.Update_TableChecker(Global.StrUsername, cot_g, cbb_batchno_checker.Text, truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, truong39, truong40, truong41, truong42, truong43);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_checker_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_checker);
        }

        private void btn_submit_checker_Click(object sender, EventArgs e)
        {
            try
            {
                Global.DataNencho.UpdateTimeLastRequest(Global.Strtoken);
                DialogResult thongbao = MessageBox.Show("You certainly have completed Batch " + cbb_batchno_de.Text, "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                int countRowNull = 0; string s = null;
                if (thongbao == DialogResult.Yes)
                {
                    for (int i = 0; i < dgv_checker.RowCount; i++)
                    {
                        if (string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_26") != null ? dgv_checker.GetRowCellValue(i, "Truong_26").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_27") != null ? dgv_checker.GetRowCellValue(i, "Truong_27").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_28") != null ? dgv_checker.GetRowCellValue(i, "Truong_28").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_29") != null ? dgv_checker.GetRowCellValue(i, "Truong_29").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_30") != null ? dgv_checker.GetRowCellValue(i, "Truong_30").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_31") != null ? dgv_checker.GetRowCellValue(i, "Truong_31").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_32") != null ? dgv_checker.GetRowCellValue(i, "Truong_32").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_33") != null ? dgv_checker.GetRowCellValue(i, "Truong_33").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_34") != null ? dgv_checker.GetRowCellValue(i, "Truong_34").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_35") != null ? dgv_checker.GetRowCellValue(i, "Truong_35").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_36") != null ? dgv_checker.GetRowCellValue(i, "Truong_36").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_37") != null ? dgv_checker.GetRowCellValue(i, "Truong_37").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_38") != null ? dgv_checker.GetRowCellValue(i, "Truong_38").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_39") != null ? dgv_checker.GetRowCellValue(i, "Truong_39").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_41") != null ? dgv_checker.GetRowCellValue(i, "Truong_41").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_42") != null ? dgv_checker.GetRowCellValue(i, "Truong_42").ToString() : "") &&
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_43") != null ? dgv_checker.GetRowCellValue(i, "Truong_43").ToString() : "") ||
                            string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_40") != null ? dgv_checker.GetRowCellValue(i, "Truong_40").ToString() : ""))
                        {
                            countRowNull += 1;
                            s += (i + 1) + "\n";
                        }
                    }
                    if (countRowNull == 0)
                    {
                        for (int i = 0; i < dgv_checker.RowCount; i++)
                        {
                            string cot_g;
                            cot_g = dgv_checker.GetRowCellValue(i, "Cot_G") != null ? dgv_checker.GetRowCellValue(i, "Cot_G").ToString() : "";
                            if (!string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_40") != null ? dgv_checker.GetRowCellValue(i, "Truong_40").ToString() : ""))
                            {
                                string fbatchname, username, idfile,cot_AG;
                                fbatchname = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.fBatchName).FirstOrDefault();
                                username = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.Cot_AE).FirstOrDefault();
                                idfile = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.Cot_K).FirstOrDefault();
                                cot_AG=(from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.Cot_AG).FirstOrDefault();
                                Global.DataNencho.InsertAdmin(fbatchname, username, idfile, cot_g, cbb_batchno_checker.Text,cot_AG);
                            }
                            Global.DataNencho.Update_TableFile_Checker2(cot_g, cbb_batchno_checker.Text);
                        }
                        cbb_batchnochecker_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Check.Value && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                        cbb_batchno_checker.Text = "";
                        cbb_batchno_checker.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.SubmitFile_Check.Value == false && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                    }
                    else
                    {
                        int n = 0;
                        for (int i = 0; i < dgv_checker.RowCount; i++)
                        {
                            if (string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_40") != null ? dgv_checker.GetRowCellValue(i, "Truong_40").ToString() : ""))
                            {
                                n += 1;
                            }
                        }
                        if (n <= 0)
                        {
                            for (int i = 0; i < dgv_checker.RowCount; i++)
                            {
                                string cot_g;
                                cot_g = dgv_checker.GetRowCellValue(i, "Cot_G") != null ? dgv_checker.GetRowCellValue(i, "Cot_G").ToString() : "";
                                if (!string.IsNullOrEmpty(dgv_checker.GetRowCellValue(i, "Truong_40") != null ? dgv_checker.GetRowCellValue(i, "Truong_40").ToString() : ""))
                                {
                                    string fbatchname, username, idfile,cot_AG;
                                    fbatchname = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.fBatchName).FirstOrDefault();
                                    username = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.Cot_AE).FirstOrDefault();
                                    idfile = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.Cot_K).FirstOrDefault();
                                    cot_AG = (from w in Global.DataNencho.tbl_Files where w.Cot_G == cot_g && w.Cot_Z == cbb_batchno_checker.Text select w.Cot_AG).FirstOrDefault();
                                    Global.DataNencho.InsertAdmin(fbatchname, username, idfile, cot_g, cbb_batchno_checker.Text,cot_AG);
                                }
                                Global.DataNencho.Update_TableFile_Checker2(cot_g, cbb_batchno_checker.Text);
                            }
                            cbb_batchnochecker_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Check.Value && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                            cbb_batchno_checker.Text = "";
                            cbb_batchno_checker.DataSource = from w in Global.DataNencho.tbl_Files where w.SubmitFile_Input.Value && w.SubmitFile_Check.Value == false && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                        }
                        else
                        {
                            MessageBox.Show("Section 「作業時間」 has not added a " + n + " box, Please enter before Submit");
                        }
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbb_batchnochecker_complete_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN" || Global.StrRole == "CHECKER2 ADMIN")
                {
                    gridControl_checker.DataSource = Global.DataNencho.GetDataCheckerComplete(cbb_batchnochecker_complete.Text, Global.StrUsername);
                }
                else
                {
                    gridControl_checker.DataSource = Global.DataNencho.GetDataCheckerComplete(cbb_batchnochecker_complete.Text,"");
                }
                dgv_checker.OptionsBehavior.ReadOnly = true;
                btn_submit_checker.Enabled = false;
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        #endregion Tab_Checker

        #region TabAdmin
        private string text_batchno;
        private int choseBatchno;

        public void SaveDataAdmin()
        {
            for (int i = 0; i < dgv_admin.RowCount; i++)
            {
                string cot_g = dgv_admin.GetRowCellValue(i, "Cot_G") != null ? dgv_admin.GetRowCellValue(i, "Cot_G").ToString() : "";
                if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_53") != null ? dgv_admin.GetRowCellValue(i, "Truong_53").ToString() : "") ||
                    !string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_54") != null ? dgv_admin.GetRowCellValue(i, "Truong_54").ToString() : "") ||
                    !string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_55") != null ? dgv_admin.GetRowCellValue(i, "Truong_55").ToString() : "") ||
                    !string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_56") != null ? dgv_admin.GetRowCellValue(i, "Truong_56").ToString() : ""))
                {
                    Global.DataNencho.Update_TableFile_Checker1_Error(cbb_batchno_admin.Text, cot_g);
                }
                else
                {
                    Global.DataNencho.Update_TableFile_Checker1_NoError(cbb_batchno_admin.Text, cot_g);
                }
                if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_60") != null ? dgv_admin.GetRowCellValue(i, "Truong_60").ToString() : "") ||
                    !string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_61") != null ? dgv_admin.GetRowCellValue(i, "Truong_61").ToString() : "") ||
                    !string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_62") != null ? dgv_admin.GetRowCellValue(i, "Truong_62").ToString() : "") ||
                    !string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_63") != null ? dgv_admin.GetRowCellValue(i, "Truong_63").ToString() : ""))
                {
                    Global.DataNencho.Update_TableFile_Checker2_Error(cbb_batchno_admin.Text, cot_g);
                }
                else
                {
                    Global.DataNencho.Update_TableFile_Checker2_NoError(cbb_batchno_admin.Text, cot_g);
                }
                Global.DataNencho.Update_TableFile_Admin(cbb_batchno_admin.Text);
            }
        }
        public static string batch;
        public void SaveDataAdmin_Edit()
        {
            int x = 0;
            DialogResult thongbao = new DialogResult();
            for (int i = 0; i < dgv_temp.RowCount; i++)
            {
                if ((dgv_temp.GetRowCellValue(i, "Truong_53") != null ? dgv_temp.GetRowCellValue(i, "Truong_53").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_53") != null ? dgv_admin.GetRowCellValue(i, "Truong_53").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_54") != null ? dgv_temp.GetRowCellValue(i, "Truong_54").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_54") != null ? dgv_admin.GetRowCellValue(i, "Truong_54").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_55") != null ? dgv_temp.GetRowCellValue(i, "Truong_55").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_55") != null ? dgv_admin.GetRowCellValue(i, "Truong_55").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_56") != null ? dgv_temp.GetRowCellValue(i, "Truong_56").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_56") != null ? dgv_admin.GetRowCellValue(i, "Truong_56").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_60") != null ? dgv_temp.GetRowCellValue(i, "Truong_60").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_60") != null ? dgv_admin.GetRowCellValue(i, "Truong_60").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_61") != null ? dgv_temp.GetRowCellValue(i, "Truong_61").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_61") != null ? dgv_admin.GetRowCellValue(i, "Truong_61").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_62") != null ? dgv_temp.GetRowCellValue(i, "Truong_62").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_62") != null ? dgv_admin.GetRowCellValue(i, "Truong_62").ToString() : "") ||
                    (dgv_temp.GetRowCellValue(i, "Truong_63") != null ? dgv_temp.GetRowCellValue(i, "Truong_63").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_63") != null ? dgv_admin.GetRowCellValue(i, "Truong_63").ToString() : ""))
                    x += 1;
            }
            if (x > 0)
            {
                thongbao = MessageBox.Show("Edited data, you want to save it", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (thongbao == DialogResult.Yes)
                {
                    for (int i = 0; i < dgv_temp.RowCount; i++)
                    {
                        string cot_g = dgv_admin.GetRowCellValue(i, "Cot_G") != null ? dgv_admin.GetRowCellValue(i, "Cot_G").ToString() : "";
                        if ((dgv_temp.GetRowCellValue(i, "Truong_53") != null ? dgv_temp.GetRowCellValue(i, "Truong_53").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_53") != null ? dgv_admin.GetRowCellValue(i, "Truong_53").ToString() : "") ||
                            (dgv_temp.GetRowCellValue(i, "Truong_54") != null ? dgv_temp.GetRowCellValue(i, "Truong_54").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_54") != null ? dgv_admin.GetRowCellValue(i, "Truong_54").ToString() : "") ||
                            (dgv_temp.GetRowCellValue(i, "Truong_55") != null ? dgv_temp.GetRowCellValue(i, "Truong_55").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_55") != null ? dgv_admin.GetRowCellValue(i, "Truong_55").ToString() : "") ||
                            (dgv_temp.GetRowCellValue(i, "Truong_56") != null ? dgv_temp.GetRowCellValue(i, "Truong_56").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_56") != null ? dgv_admin.GetRowCellValue(i, "Truong_56").ToString() : ""))
                        {
                            if (string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_53") != null ? dgv_admin.GetRowCellValue(i, "Truong_53").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_54") != null ? dgv_admin.GetRowCellValue(i, "Truong_54").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_55") != null ? dgv_admin.GetRowCellValue(i, "Truong_55").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_56") != null ? dgv_admin.GetRowCellValue(i, "Truong_56").ToString() : ""))
                            {
                                Global.DataNencho.Update_TableFile_Checker1_NoError(batch, cot_g);
                            }
                            else
                            {
                                Global.DataNencho.Update_TableFile_Checker1_Error(batch, cot_g);
                                Global.DataNencho.DeleteData_De(cot_g, batch);
                            }
                        }
                        if ((dgv_temp.GetRowCellValue(i, "Truong_60") != null ? dgv_temp.GetRowCellValue(i, "Truong_60").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_60") != null ? dgv_admin.GetRowCellValue(i, "Truong_60").ToString() : "") ||
                            (dgv_temp.GetRowCellValue(i, "Truong_61") != null ? dgv_temp.GetRowCellValue(i, "Truong_61").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_61") != null ? dgv_admin.GetRowCellValue(i, "Truong_61").ToString() : "") ||
                            (dgv_temp.GetRowCellValue(i, "Truong_62") != null ? dgv_temp.GetRowCellValue(i, "Truong_62").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_62") != null ? dgv_admin.GetRowCellValue(i, "Truong_62").ToString() : "") ||
                            (dgv_temp.GetRowCellValue(i, "Truong_63") != null ? dgv_temp.GetRowCellValue(i, "Truong_63").ToString() : "") != (dgv_admin.GetRowCellValue(i, "Truong_63") != null ? dgv_admin.GetRowCellValue(i, "Truong_63").ToString() : ""))
                        {
                            if (string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_60") != null ? dgv_admin.GetRowCellValue(i, "Truong_60").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_61") != null ? dgv_admin.GetRowCellValue(i, "Truong_61").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_62") != null ? dgv_admin.GetRowCellValue(i, "Truong_62").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_63") != null ? dgv_admin.GetRowCellValue(i, "Truong_63").ToString() : ""))
                            {
                                Global.DataNencho.Update_TableFile_Checker2_NoError(batch, cot_g);
                            }
                            else
                            {
                                Global.DataNencho.Update_TableFile_Checker2_Error(batch, cot_g);
                                Global.DataNencho.DeleteData_Check(cot_g, batch);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dgv_temp.RowCount; i++)
                    {
                        Global.DataNencho.RestoreTableAdmin(dgv_temp.GetRowCellValue(i, "Cot_G") != null ? dgv_temp.GetRowCellValue(i, "Cot_G").ToString() : "",
                                                            batch,
                                                            dgv_temp.GetRowCellValue(i, "Truong_53") != null ? dgv_temp.GetRowCellValue(i, "Truong_53").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_54") != null ? dgv_temp.GetRowCellValue(i, "Truong_54").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_55") != null ? dgv_temp.GetRowCellValue(i, "Truong_55").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_56") != null ? dgv_temp.GetRowCellValue(i, "Truong_56").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_60") != null ? dgv_temp.GetRowCellValue(i, "Truong_60").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_61") != null ? dgv_temp.GetRowCellValue(i, "Truong_61").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_62") != null ? dgv_temp.GetRowCellValue(i, "Truong_62").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_63") != null ? dgv_temp.GetRowCellValue(i, "Truong_63").ToString() : "",
                                                            dgv_temp.GetRowCellValue(i, "Truong_67") != null ? dgv_temp.GetRowCellValue(i, "Truong_67").ToString() : "");
                    }
                }
            }
        }
        private void LookUpEdit_Column97_EditValueChanged(object sender, EventArgs e)
        {
            dgv_checker2.SetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38", "");
        }
        
        private void dgv_admin_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int n;
                if (int.TryParse(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Truong_67"]), out n))
                {
                    int valuecot = Convert.ToInt16(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Truong_67"]));
                    if (e.Column.FieldName == "Truong_67")
                    {
                        if (valuecot <= 2 && valuecot!=0)
                        {
                            e.Appearance.BackColor = Color.Blue;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else if(valuecot == 3|| valuecot == 4)
                        {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else if (valuecot >= 5)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_cheker2_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;
                if (view.FocusedColumn.FieldName == "Truong_38")
                {
                    LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                    string countryCode = Convert.ToString(view.GetFocusedRowCellValue("Truong_37"));
                    editor.Properties.DataSource = from w in Global.DataNencho.tbl_DataColumn38s where w.dataColumn37 == countryCode select w.dataColumn38;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbb_batchno_admin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btn_submit_admin.Text = "Submit";
                gridControl_checker2.DataSource = Global.DataNencho.GetDataChecker_TabAdmin(cbb_batchno_admin.Text);
                gridControl_admin.DataSource = Global.DataNencho.GetDataAdmin(cbb_batchno_admin.Text, Global.StrUsername);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_cheker2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                SetValueText("Truong_26", dgv_checker2);
                SetValueText("Truong_27", dgv_checker2);
                SetValueText("Truong_28", dgv_checker2);
                SetValueText("Truong_29", dgv_checker2);
                SetValueText("Truong_30", dgv_checker2);
                SetValueText("Truong_31", dgv_checker2);
                SetValueText("Truong_32", dgv_checker2);
                SetValueText("Truong_33", dgv_checker2);
                SetValueText("Truong_34", dgv_checker2);
                SetValueText("Truong_35", dgv_checker2);

                if (e.Column.FieldName == "Truong_36")
                {
                    if ((dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_36(dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }
                if (e.Column.FieldName == "Truong_37")
                {
                    if ((dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_37(dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }
                if (e.Column.FieldName == "Truong_38")
                {
                    if ((dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38").ToString() : "") != "")
                    {
                        int r = Global.DataNencho.CheckTruong_38(dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38").ToString() : "");
                        if (r == 0)
                        {
                            string s = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38").ToString() : "";
                            MessageBox.Show("You have changed to " + s);
                        }
                    }
                }

                string truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38, cot_g;
                truong26 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_26") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_26").ToString() : "";
                truong27 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_27") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_27").ToString() : "";
                truong28 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_28") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_28").ToString() : "";
                truong29 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_29") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_29").ToString() : "";
                truong30 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_30") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_30").ToString() : "";
                truong31 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_31") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_31").ToString() : "";
                truong32 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_32") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_32").ToString() : "";
                truong33 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_33") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_33").ToString() : "";
                truong34 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_34") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_34").ToString() : "";
                truong35 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_35") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_35").ToString() : "";
                truong36 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_36").ToString() : "";
                truong37 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_37").ToString() : "";
                truong38 = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Truong_38").ToString() : "";
                cot_g = dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Cot_G") != null ? dgv_checker2.GetRowCellValue(dgv_checker2.FocusedRowHandle, "Cot_G").ToString() : "";

                Global.DataNencho.Update_TableChecker_Admin(cot_g, cbb_batchno_admin.Text, truong26, truong27, truong28, truong29, truong30, truong31, truong32, truong33, truong34, truong35, truong36, truong37, truong38);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_cheker2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_checker2);
        }

        private void dgv_admin_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_admin);
        }

        private void cbb_batchnoadmin_complete_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (btn_submit_admin.Text == "Edit")
                {
                    SaveDataAdmin_Edit();
                    gridControl_temp.DataSource = Global.DataNencho.GetDataAdminComplete(cbb_batchnoadmin_complete.Text, Global.StrUsername);
                    batch = cbb_batchnoadmin_complete.Text;
                }
                btn_submit_admin.Text = "Edit";
                gridControl_checker2.DataSource = Global.DataNencho.GetDataChecker_TabAdmin(cbb_batchnoadmin_complete.Text);
                gridControl_admin.DataSource = Global.DataNencho.GetDataAdminComplete(cbb_batchnoadmin_complete.Text, Global.StrUsername);
                btn_submit_admin.Enabled = true;
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void GetSum()
        {
            int truong53 = 0, truong54 = 0, truong55 = 0, truong56 = 0, truong60 = 0, truong61 = 0, truong62 = 0, truong63 = 0;

            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_53") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_53").ToString() : ""))
            {
                truong53 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_53").ToString());
            }
            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_54") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_54").ToString() : ""))
            {
                truong54 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_54").ToString());
            }
            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_55") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_55").ToString() : ""))
            {
                truong55 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_55").ToString());
            }
            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_56") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_56").ToString() : ""))
            {
                truong56 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_56").ToString());
            }

            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_60") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_60").ToString() : ""))
            {
                truong60 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_60").ToString());
            }
            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_61") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_61").ToString() : ""))
            {
                truong61 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_61").ToString());
            }
            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_62") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_62").ToString() : ""))
            {
                truong62 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_62").ToString());
            }
            if (!string.IsNullOrEmpty(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_63") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_63").ToString() : ""))
            {
                truong63 = Convert.ToInt32(dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_63").ToString());
            }
            int sum = truong53 + truong54 + truong55 + truong56 + truong60 + truong61 + truong62 + truong63;
            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_67", sum);
        }

        private void dgv_admin_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Truong_53" || e.Column.FieldName == "Truong_54" || e.Column.FieldName == "Truong_55" || e.Column.FieldName == "Truong_56" ||
                    e.Column.FieldName == "Truong_60" || e.Column.FieldName == "Truong_61" || e.Column.FieldName == "Truong_62" || e.Column.FieldName == "Truong_63")
                {
                    GetSum();
                }

                if (e.Column.FieldName == "Truong_69" || e.Column.FieldName == "Truong_72")
                {
                    string truong_69 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_69") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_69").ToString() : "";
                    string truong_72 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_72") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_72").ToString() : "";
                    if (!string.IsNullOrEmpty(truong_69) && !string.IsNullOrEmpty(truong_72))
                    {
                        if (DateTime.Compare(DateTime.Parse(truong_69), DateTime.Parse(truong_72)) <= 0)
                        {
                            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_74", "納品済");
                        }
                        else
                        {
                            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_74", "遅れ");
                        }
                    }
                }

                string truong51, truong52, truong53, truong54, truong55, truong56, truong57, truong60, truong61, truong62, truong63, truong64, truong67, truong68, truong69, truong70, truong71, truong72, truong73, truong74, cot_g;
                truong51 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_51") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_51").ToString() : "";
                truong52 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_52") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_52").ToString() : "";
                truong53 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_53") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_53").ToString() : "";
                truong54 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_54") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_54").ToString() : "";
                truong55 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_55") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_55").ToString() : "";
                truong56 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_56") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_56").ToString() : "";
                truong57 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_57") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_57").ToString() : "";
                truong60 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_60") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_60").ToString() : "";
                truong61 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_61") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_61").ToString() : "";
                truong62 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_62") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_62").ToString() : "";
                truong63 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_63") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_63").ToString() : "";
                truong64 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_64") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_64").ToString() : "";
                truong67 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_67") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_67").ToString() : "";
                truong68 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_68") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_68").ToString() : "";
                truong69 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_69") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_69").ToString() : "";
                truong70 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_70") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_70").ToString() : "";
                truong71 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_71") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_71").ToString() : "";
                truong72 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_72") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_72").ToString() : "";
                truong73 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_73") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_73").ToString() : "";
                truong74 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_74") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_74").ToString() : "";
                cot_g = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Cot_G") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle, "Cot_G").ToString() : "";
                if (btn_submit_admin.Text == "Submit")
                {
                    Global.DataNencho.Update_TableAdmin(Global.StrUsername, cot_g, cbb_batchno_admin.Text, truong51, truong52, truong53, truong54, truong55, truong56, truong57, truong60, truong61, truong62, truong63, truong64, truong67, truong68, truong69, truong70, truong71, truong72, truong73, truong74);
                }
                else if (btn_submit_admin.Text == "Edit")
                {
                    Global.DataNencho.Update_TableAdmin(Global.StrUsername, cot_g, cbb_batchnoadmin_complete.Text, truong51, truong52, truong53, truong54, truong55, truong56, truong57, truong60, truong61, truong62, truong63, truong64, truong67, truong68, truong69, truong70, truong71, truong72, truong73, truong74);
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void btn_submit_admin_Click(object sender, EventArgs e)
        {
            try
            {
                Global.DataNencho.UpdateTimeLastRequest(Global.Strtoken);
                if (btn_submit_admin.Text == "Submit")
                {
                    DialogResult thongbao = MessageBox.Show(" You certainly have completed Batch " + cbb_batchno_de.Text,
                        "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    int countRowNull = 0;
                    string s = null;
                    if (thongbao == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgv_admin.RowCount; i++)
                        {
                            if (string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_51") != null ? dgv_admin.GetRowCellValue(i, "Truong_51").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_52") != null ? dgv_admin.GetRowCellValue(i, "Truong_52").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_53") != null ? dgv_admin.GetRowCellValue(i, "Truong_53").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_54") != null ? dgv_admin.GetRowCellValue(i, "Truong_54").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_55") != null ? dgv_admin.GetRowCellValue(i, "Truong_55").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_56") != null ? dgv_admin.GetRowCellValue(i, "Truong_56").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_57") != null ? dgv_admin.GetRowCellValue(i, "Truong_57").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_60") != null ? dgv_admin.GetRowCellValue(i, "Truong_60").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_61") != null ? dgv_admin.GetRowCellValue(i, "Truong_61").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_62") != null ? dgv_admin.GetRowCellValue(i, "Truong_62").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_63") != null ? dgv_admin.GetRowCellValue(i, "Truong_63").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_64") != null ? dgv_admin.GetRowCellValue(i, "Truong_64").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_67") != null ? dgv_admin.GetRowCellValue(i, "Truong_67").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_68") != null ? dgv_admin.GetRowCellValue(i, "Truong_68").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_69") != null ? dgv_admin.GetRowCellValue(i, "Truong_69").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_70") != null ? dgv_admin.GetRowCellValue(i, "Truong_70").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_71") != null ? dgv_admin.GetRowCellValue(i, "Truong_71").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_72") != null ? dgv_admin.GetRowCellValue(i, "Truong_72").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_73") != null ? dgv_admin.GetRowCellValue(i, "Truong_73").ToString() : ""))
                            {
                                countRowNull += 1;
                                s += (i + 1) + "\n";
                            }
                        }
                        if (countRowNull == 0)
                        {
                            SaveDataAdmin();

                            cbb_batchnoadmin_complete.Text = "";
                            cbb_batchnoadmin_complete.DataSource = Global.DataNencho.GetBatchAdmin_Complete(Global.StrUsername);
                            cbb_batchnoadmin_complete.DisplayMember = "Cot_Z";

                            cbb_batchno_admin.Text = "";
                            cbb_batchno_admin.DataSource = Global.DataNencho.GetBatchAdmin(Global.StrUsername);
                            cbb_batchno_admin.DisplayMember = "Cot_Z";
                        }
                        else
                        {
                            DialogResult notifyRowNull = MessageBox.Show("Still " + countRowNull + " lines: \n" + s + "no data, you still want to Submit", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (notifyRowNull != DialogResult.Yes) return;
                            SaveDataAdmin();

                            cbb_batchnoadmin_complete.Text = "";
                            cbb_batchnoadmin_complete.DataSource = Global.DataNencho.GetBatchAdmin_Complete(Global.StrUsername);
                            cbb_batchnoadmin_complete.DisplayMember = "Cot_Z";

                            cbb_batchno_admin.Text = "";
                            cbb_batchno_admin.DataSource = Global.DataNencho.GetBatchAdmin(Global.StrUsername);
                            cbb_batchno_admin.DisplayMember = "Cot_Z";
                        }
                    }
                }
                else if (btn_submit_admin.Text == "Edit")
                {
                    DialogResult thongbao = MessageBox.Show(" You certainly have completed Batch " + cbb_batchno_de.Text,"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    int countRowNull = 0;
                    string s = null;
                    if (thongbao == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgv_admin.RowCount; i++)
                        {
                            if (string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_51") != null ? dgv_admin.GetRowCellValue(i, "Truong_51").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_52") != null ? dgv_admin.GetRowCellValue(i, "Truong_52").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_53") != null ? dgv_admin.GetRowCellValue(i, "Truong_53").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_54") != null ? dgv_admin.GetRowCellValue(i, "Truong_54").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_55") != null ? dgv_admin.GetRowCellValue(i, "Truong_55").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_56") != null ? dgv_admin.GetRowCellValue(i, "Truong_56").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_57") != null ? dgv_admin.GetRowCellValue(i, "Truong_57").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_60") != null ? dgv_admin.GetRowCellValue(i, "Truong_60").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_61") != null ? dgv_admin.GetRowCellValue(i, "Truong_61").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_62") != null ? dgv_admin.GetRowCellValue(i, "Truong_62").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_63") != null ? dgv_admin.GetRowCellValue(i, "Truong_63").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_64") != null ? dgv_admin.GetRowCellValue(i, "Truong_64").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_67") != null ? dgv_admin.GetRowCellValue(i, "Truong_67").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_68") != null ? dgv_admin.GetRowCellValue(i, "Truong_68").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_69") != null ? dgv_admin.GetRowCellValue(i, "Truong_69").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_70") != null ? dgv_admin.GetRowCellValue(i, "Truong_70").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_71") != null ? dgv_admin.GetRowCellValue(i, "Truong_71").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_72") != null ? dgv_admin.GetRowCellValue(i, "Truong_72").ToString() : "") &&
                                string.IsNullOrEmpty(dgv_admin.GetRowCellValue(i, "Truong_73") != null ? dgv_admin.GetRowCellValue(i, "Truong_73").ToString() : ""))
                            {
                                countRowNull += 1;
                                s += (i + 1) + "\n";
                            }
                        }
                        if (countRowNull == 0)
                        {
                            SaveDataAdmin_Edit();
                            gridControl_temp.DataSource = Global.DataNencho.GetDataAdminComplete(cbb_batchnoadmin_complete.Text, Global.StrUsername);
                            batch = cbb_batchnoadmin_complete.Text;

                            cbb_batchnoadmin_complete.Text = "";
                            cbb_batchnoadmin_complete.DataSource = (from w in Global.DataNencho.GetBatchAdmin_Complete(Global.StrUsername) select w.Cot_Z).ToList();
                            cbb_batchnoadmin_complete.DisplayMember = "Cot_Z";

                            cbb_batchno_admin.Text = "";
                            cbb_batchno_admin.DataSource = (from w in Global.DataNencho.GetBatchAdmin(Global.StrUsername) select w.Cot_Z).ToList();
                            cbb_batchno_admin.DisplayMember = "Cot_Z";
                        }
                        else
                        {
                            DialogResult notifyRowNull = MessageBox.Show("Still " + countRowNull + " lines: \n" + s + "no data, you still want to Edit", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (notifyRowNull != DialogResult.Yes) return;
                            SaveDataAdmin_Edit();
                            gridControl_temp.DataSource = Global.DataNencho.GetDataAdminComplete(cbb_batchnoadmin_complete.Text, Global.StrUsername);
                            batch = cbb_batchnoadmin_complete.Text;

                            cbb_batchnoadmin_complete.Text = "";
                            cbb_batchnoadmin_complete.DataSource = (from w in Global.DataNencho.GetBatchAdmin_Complete(Global.StrUsername) select w.Cot_Z).ToList();
                            cbb_batchnoadmin_complete.DisplayMember = "Cot_Z";

                            cbb_batchno_admin.Text = "";
                            cbb_batchno_admin.DataSource = (from w in Global.DataNencho.GetBatchAdmin(Global.StrUsername) select w.Cot_Z).ToList();
                            cbb_batchno_admin.DisplayMember = "Cot_Z";
                        }
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void TextEdit7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion TabAdmin

        #region TabError

        private void dgv_error_checker1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_error_checker1);
        }

        private void dgv_error_checker2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadNumericalGridview(sender, e, dgv_error_checker2);
        }

        private void cbb_batchno_error_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "CHECKER1 " || Global.StrRole == "CHECKER1 ADMIN")
                {
                    gridControl_error_cherker1.DataSource = Global.DataNencho.GetDataErrorDE(cbb_batchno_error.Text, Global.StrUsername);
                    btn_submit_error.Enabled = !string.IsNullOrEmpty(cbb_batchno_error.Text);
                    dgv_error_checker1.OptionsBehavior.ReadOnly = false;
                }
                else if (Global.StrRole == "CHECKER2 " || Global.StrRole == "CHECKER2 ADMIN")
                {
                    gridControl_error_checker2.DataSource = Global.DataNencho.GetDataErrorChecker(cbb_batchno_error.Text, Global.StrUsername);
                    btn_submit_error.Enabled = !string.IsNullOrEmpty(cbb_batchno_error.Text);
                    dgv_error_checker2.OptionsBehavior.ReadOnly = false;
                }
                else if (Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN")
                {
                    gridControl_error_cherker1.DataSource = Global.DataNencho.GetDataErrorDE(cbb_batchno_error.Text, Global.StrUsername);
                    btn_submit_error.Enabled = !string.IsNullOrEmpty(cbb_batchno_error.Text);
                    dgv_error_checker1.OptionsBehavior.ReadOnly = false;

                    gridControl_error_checker2.DataSource = Global.DataNencho.GetDataErrorChecker(cbb_batchno_error.Text, Global.StrUsername);
                    btn_submit_error.Enabled = !string.IsNullOrEmpty(cbb_batchno_error.Text);
                    dgv_error_checker2.OptionsBehavior.ReadOnly = false;

                    if (gridControl_error_cherker1.DataSource != null)
                        xtraTabControl2.SelectedTabPage.Name = "tab_error_checker1";
                    else if (gridControl_error_checker2.DataSource != null)
                        xtraTabControl2.SelectedTabPage.Name = "tab_error_checker2";
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void cbb_batchno_error_complete_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.StrRole == "CHECKER1 " || Global.StrRole == "CHECKER1 ADMIN")
                {
                    gridControl_error_cherker1.DataSource = Global.DataNencho.GetDataErrorDE_Complete(cbb_batchno_error_complete.Text, Global.StrUsername);
                    dgv_error_checker1.OptionsBehavior.ReadOnly = true;
                    btn_submit_error.Enabled = false;
                }
                else if (Global.StrRole == "CHECKER2 " || Global.StrRole == "CHECKER2 ADMIN")
                {
                    gridControl_error_checker2.DataSource = Global.DataNencho.GetDataErrorChecker_Complete(cbb_batchno_error_complete.Text, Global.StrUsername);
                    dgv_error_checker2.OptionsBehavior.ReadOnly = true;
                    btn_submit_error.Enabled = false;
                }
                else if (Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN")
                {
                    gridControl_error_cherker1.DataSource = Global.DataNencho.GetDataErrorDE_Complete(cbb_batchno_error_complete.Text, Global.StrUsername);
                    dgv_error_checker1.OptionsBehavior.ReadOnly = true;

                    gridControl_error_checker2.DataSource = Global.DataNencho.GetDataErrorChecker_Complete(cbb_batchno_error_complete.Text, Global.StrUsername);
                    dgv_error_checker2.OptionsBehavior.ReadOnly = true;
                    btn_submit_error.Enabled = false;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_error_checker1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                string truong58, truong59, cot_g;
                truong58 = dgv_error_checker1.GetRowCellValue(dgv_error_checker1.FocusedRowHandle, "Truong_58") != null ? dgv_error_checker1.GetRowCellValue(dgv_error_checker1.FocusedRowHandle, "Truong_58").ToString() : "";
                truong59 = dgv_error_checker1.GetRowCellValue(dgv_error_checker1.FocusedRowHandle, "Truong_59") != null ? dgv_error_checker1.GetRowCellValue(dgv_error_checker1.FocusedRowHandle, "Truong_59").ToString() : "";
                cot_g = dgv_error_checker1.GetRowCellValue(dgv_error_checker1.FocusedRowHandle, "Cot_G") != null ? dgv_error_checker1.GetRowCellValue(dgv_error_checker1.FocusedRowHandle, "Cot_G").ToString() : "";
                Global.DataNencho.Update_TableInput_Error(Global.StrUsername, cot_g, cbb_batchno_error.Text, truong58, truong59);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void dgv_error_checker2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                string truong65, truong66, cot_g;
                truong65 = dgv_error_checker2.GetRowCellValue(dgv_error_checker2.FocusedRowHandle, "Truong_65") != null ? dgv_error_checker2.GetRowCellValue(dgv_error_checker2.FocusedRowHandle, "Truong_65").ToString() : "";
                truong66 = dgv_error_checker2.GetRowCellValue(dgv_error_checker2.FocusedRowHandle, "Truong_66") != null ? dgv_error_checker2.GetRowCellValue(dgv_error_checker2.FocusedRowHandle, "Truong_66").ToString() : "";
                cot_g = dgv_error_checker2.GetRowCellValue(dgv_error_checker2.FocusedRowHandle, "Cot_G") != null ? dgv_error_checker2.GetRowCellValue(dgv_error_checker2.FocusedRowHandle, "Cot_G").ToString() : "";
                Global.DataNencho.Update_TableChecker_Error(Global.StrUsername, cot_g, cbb_batchno_error.Text, truong65, truong66);
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        private void btn_submit_error_Click(object sender, EventArgs e)
        {
            try
            {
                Global.DataNencho.UpdateTimeLastRequest(Global.Strtoken);
                if (Global.StrRole == "CHECKER1 " || Global.StrRole == "CHECKER1 ADMIN")
                {
                    int n = 0;
                    for (int i = 0; i < dgv_error_checker1.RowCount; i++)
                    {
                        if (string.IsNullOrEmpty(dgv_error_checker1.GetRowCellValue(i, "Truong_58") != null ? dgv_error_checker1.GetRowCellValue(i, "Truong_58").ToString() : "") ||
                            string.IsNullOrEmpty(dgv_error_checker1.GetRowCellValue(i, "Truong_59") != null ? dgv_error_checker1.GetRowCellValue(i, "Truong_59").ToString() : ""))
                        {
                            n += 1;
                        }
                    }
                    if (n <= 0)
                    {
                        for (int i = 0; i < dgv_error_checker1.RowCount; i++)
                        {
                            string cot_g = dgv_error_checker1.GetRowCellValue(i, "Cot_G") != null ? dgv_error_checker1.GetRowCellValue(i, "Cot_G").ToString() : "";
                            Global.DataNencho.Update_TableFile_Submit_ErrorChecker1(cbb_batchno_error.Text, cot_g);
                        }
                        cbb_batchno_error_complete.Text = "";
                        cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Input == true && w.SubmitFile_Input_2.Value && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                        cbb_batchno_error.Text = "";
                        cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Input == true && w.SubmitFile_Input_2.Value == false && w.Cot_AA == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                    }
                    else
                    {
                        MessageBox.Show("Unable to Submit, Section [原因] and Section [本人の対策] not finish typing. Please check again!");
                    }
                }
                else if (Global.StrRole == "CHECKER2 " || Global.StrRole == "CHECKER2 ADMIN")
                {
                    int m = 0;
                    for (int i = 0; i < dgv_error_checker2.RowCount; i++)
                    {
                        if (string.IsNullOrEmpty(dgv_error_checker2.GetRowCellValue(i, "Truong_65") != null ? dgv_error_checker2.GetRowCellValue(i, "Truong_65").ToString() : "") ||
                            string.IsNullOrEmpty(dgv_error_checker2.GetRowCellValue(i, "Truong_66") != null ? dgv_error_checker2.GetRowCellValue(i, "Truong_66").ToString() : ""))
                        {
                            m += 1;
                        }
                    }
                    if (m <= 0)
                    {
                        for (int i = 0; i < dgv_error_checker2.RowCount; i++)
                        {
                            string cot_g = dgv_error_checker2.GetRowCellValue(i, "Cot_G") != null ? dgv_error_checker2.GetRowCellValue(i, "Cot_G").ToString() : "";
                            Global.DataNencho.Update_TableFile_Submit_ErrorChecker2(cbb_batchno_error.Text, cot_g);
                        }
                        cbb_batchno_error_complete.Text = "";
                        cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Check == true && w.SubmitFile_Check_2.Value && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                        cbb_batchno_error.Text = "";
                        cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where w.Error_Check == true && w.SubmitFile_Check_2.Value == false && w.Cot_AB == Global.StrUsername group w by w.Cot_Z into g select g.Key;
                    }
                    else
                    {
                        MessageBox.Show("Unable to Submit, Section [原因] and Section [本人の対策] not finish typing. Please check again!!");
                    }
                }
                else if (Global.StrRole == "CHECKER1 CHECKER2 " || Global.StrRole == "CHECKER1 CHECKER2 ADMIN")
                {
                    if (xtraTabControl2.SelectedTabPage.Name == "tab_error_checker1")
                    {

                        int n = 0;
                        for (int i = 0; i < dgv_error_checker1.RowCount; i++)
                        {
                            if (string.IsNullOrEmpty(dgv_error_checker1.GetRowCellValue(i, "Truong_58") != null ? dgv_error_checker1.GetRowCellValue(i, "Truong_58").ToString() : "") ||
                                string.IsNullOrEmpty(dgv_error_checker1.GetRowCellValue(i, "Truong_59") != null ? dgv_error_checker1.GetRowCellValue(i, "Truong_59").ToString() : ""))
                            {
                                n += 1;
                            }
                        }
                        if (n <= 0)
                        {
                            for (int i = 0; i < dgv_error_checker1.RowCount; i++)
                            {
                                string cot_g = dgv_error_checker1.GetRowCellValue(i, "Cot_G") != null ? dgv_error_checker1.GetRowCellValue(i, "Cot_G").ToString() : "";
                                Global.DataNencho.Update_TableFile_Submit_ErrorChecker1(cbb_batchno_error.Text, cot_g);
                            }
                            cbb_batchno_error_complete.Text = "";
                            cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Check == true && w.SubmitFile_Check_2.Value && w.Cot_AB == Global.StrUsername) || (w.Error_Input == true && w.SubmitFile_Input_2.Value && w.Cot_AA == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                            cbb_batchno_error.Text = "";
                            cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Input == true && w.SubmitFile_Input_2.Value == false && w.Cot_AA == Global.StrUsername) || (w.Error_Check == true && w.SubmitFile_Check_2.Value == false && w.Cot_AB == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Submit, Section [原因] and Section [本人の対策] not finish typing. Please check again!");
                        }
                    }
                    else if (xtraTabControl2.SelectedTabPage.Name == "tab_error_checker2")
                    {
                        int m = 0;
                        for (int i = 0; i < dgv_error_checker2.RowCount; i++)
                        {
                            if (string.IsNullOrEmpty(dgv_error_checker2.GetRowCellValue(i, "Truong_65") != null ? dgv_error_checker2.GetRowCellValue(i, "Truong_65").ToString() : "") ||
                                string.IsNullOrEmpty(dgv_error_checker2.GetRowCellValue(i, "Truong_66") != null ? dgv_error_checker2.GetRowCellValue(i, "Truong_66").ToString() : ""))
                            {
                                m += 1;
                            }
                        }
                        if (m <= 0)
                        {
                            for (int i = 0; i < dgv_error_checker2.RowCount; i++)
                            {
                                string cot_g = dgv_error_checker2.GetRowCellValue(i, "Cot_G") != null ? dgv_error_checker2.GetRowCellValue(i, "Cot_G").ToString() : "";
                                Global.DataNencho.Update_TableFile_Submit_ErrorChecker2(cbb_batchno_error.Text, cot_g);
                            }
                            cbb_batchno_error_complete.Text = "";
                            cbb_batchno_error_complete.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Check == true && w.SubmitFile_Check_2.Value && w.Cot_AB == Global.StrUsername) || (w.Error_Input == true && w.SubmitFile_Input_2.Value && w.Cot_AA == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                            cbb_batchno_error.Text = "";
                            cbb_batchno_error.DataSource = from w in Global.DataNencho.tbl_Files where (w.Error_Input == true && w.SubmitFile_Input_2.Value == false && w.Cot_AA == Global.StrUsername) || (w.Error_Check == true && w.SubmitFile_Check_2.Value == false && w.Cot_AB == Global.StrUsername) group w by w.Cot_Z into g select g.Key;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Submit, Section [原因] and Section [本人の対策] not finish typing. Please check again!!");
                        }
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error : " + i);
            }
        }

        #endregion TabError

        private void TextEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Down)
            {
                if (dgv_de.FocusedRowHandle > 0)
                {
                    dgv_de.SetRowCellValue(dgv_de.FocusedRowHandle, "Truong_39", dgv_de.GetRowCellValue(dgv_de.FocusedRowHandle - 1, "Truong_39"));
                }
            }
        }

        private void TextEdit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Down)
            {
                if (dgv_checker.FocusedRowHandle > 0)
                {
                    dgv_checker.SetRowCellValue(dgv_checker.FocusedRowHandle, "Truong_39", dgv_checker.GetRowCellValue(dgv_checker.FocusedRowHandle - 1, "Truong_39"));
                }
            }
        }

        private void TextEdit4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Down)
            {
                if (dgv_admin.FocusedRowHandle > 0)
                {
                    if (dgv_admin.FocusedColumn.FieldName == "Truong_51")
                    {
                        string Truong_51 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_51") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_51").ToString() : "";
                        if (!string.IsNullOrEmpty(Truong_51))
                            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_51", Truong_51);
                        else
                        {
                            MessageBox.Show("Please enter the top line before copying");
                        }
                    }

                    if (dgv_admin.FocusedColumn.FieldName == "Truong_69")
                    {
                        string Truong_69 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_69") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_69").ToString() : "";
                        if (!string.IsNullOrEmpty(Truong_69))
                            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_69", Truong_69);
                        else
                        {
                            MessageBox.Show("Please enter the top line before copying");
                        }
                    }

                    if (dgv_admin.FocusedColumn.FieldName == "Truong_70")
                    {
                        string Truong_70 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_70") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_70").ToString() : "";
                        if (!string.IsNullOrEmpty(Truong_70))
                            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_70", Truong_70);
                        else
                        {
                            MessageBox.Show("Please enter the top line before copying");
                        }
                    }

                    if (dgv_admin.FocusedColumn.FieldName == "Truong_72")
                    {
                        string Truong_72 = dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_72") != null ? dgv_admin.GetRowCellValue(dgv_admin.FocusedRowHandle - 1, "Truong_72").ToString() : "";
                        if (!string.IsNullOrEmpty(Truong_72))
                            dgv_admin.SetRowCellValue(dgv_admin.FocusedRowHandle, "Truong_72", Truong_72);
                        else
                        {
                            MessageBox.Show("Please enter the top line before copying");
                        }
                    }
                }
            }
        }

        private void TextEdit26_35_checker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || e.KeyChar == '1'))
            {
                e.Handled = true;
            }
        }

        private void TextEdit26_35_checker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || e.KeyChar == '1'))
            {
                e.Handled = true;
            }
        }

        private void TextEdit26_35_admin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || e.KeyChar == '1'))
            {
                e.Handled = true;
            }
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.DataNencho.UpdateTimeLastRequest(Global.Strtoken);
            Global.DataNencho.UpdateTimeLogout(Global.Strtoken);
            Global.DataNencho.ResetToken(Global.StrUsername, Global.StrIdProject, Global.Strtoken);
        }

        private void btn_tiendo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_TienDo().ShowDialog();}
    }
}