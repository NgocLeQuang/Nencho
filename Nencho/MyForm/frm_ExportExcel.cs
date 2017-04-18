using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace Nencho.MyForm
{
    
    public partial class frm_ExportExcel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ExportExcel()
        {
            InitializeComponent();
        }

        private string ngaybatdau, ngayketthuc;
        private List<String> lRowerror = new List<String>();
        private void Load_CheckListBatchNo(string ngaytruoc, string ngaysau)
        {
            if (!string.IsNullOrEmpty(ngaytruoc.ToString()) && !string.IsNullOrEmpty(ngaysau.ToString()))
            {
                if (DateTime.Compare(Convert.ToDateTime(ngaytruoc) , Convert.ToDateTime(ngaysau)) > 0)
                {
                    chlb_batchno.Items.Clear();
                    MessageBox.Show("The start date is not greater than the end date, Please reselect");
                }
                else
                {
                    chlb_batchno.Items.Clear();
                    var countBatchno = Global.DataNencho.GetBatchNO_ExportExcel(ngaytruoc, ngaysau).Count();
                    var cot_z = (from w in Global.DataNencho.GetBatchNO_ExportExcel(ngaytruoc, ngaysau) select w.Cot_Z).ToList();
                    for (int i = 0; i < countBatchno; i++)
                    {
                        chlb_batchno.Items.Insert(i, cot_z[i]);
                    }for (int i = 0; i < chlb_batchno.Items.Count; i++)
                    {
                        chlb_batchno.SetItemChecked(i, true);
                    }

                    if (chlb_batchno.Items.Count >= 1)
                    {
                        cbb_filename_exportexcel.Items.Clear();
                        cbb_filename_exportexcel.Items.Add("File Special Data From " + ngaytruoc.ToString().Substring(0, 10) + "To " + ngaysau.ToString().Substring(0, 10));
                        cbb_filename_exportexcel.Items.Add("File History From " + ngaytruoc.ToString().Substring(0, 10) + "To " + ngaysau.ToString().Substring(0, 10));
                        cbb_filename_exportexcel.Items.Add("File Data Total From " + ngaytruoc.ToString().Substring(0, 10) + "To " + ngaysau.ToString().Substring(0, 10));
                        cbb_filename_exportexcel.Text = "File Special Data From " + ngaytruoc.ToString().Substring(0, 10) + "To " + ngaysau.ToString().Substring(0, 10);
                    }
                }
            }
        }

        private void frm_ExportExcel_Load(object sender, EventArgs e)
        {
            DatePicker_NgayTruoc.Value = DateTime.Now;
            DatePicker_NgaySau.Value = DateTime.Now;
            
            ngaybatdau= DatePicker_NgayTruoc.Text+" 00:00:00";
            ngayketthuc = DatePicker_NgaySau.Text + " 23:59:59";

            Load_CheckListBatchNo(ngaybatdau, ngayketthuc);
        }

        private void DatePicker_NgayTruoc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ngaybatdau = DatePicker_NgayTruoc.Text + " 00:00:00";
                ngayketthuc = DatePicker_NgaySau.Text + " 23:59:59";
                Load_CheckListBatchNo(ngaybatdau, ngayketthuc);
            }
            catch { }
        }

        private void DatePicker_NgaySau_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ngaybatdau = DatePicker_NgayTruoc.Text + " 00:00:00";
                ngayketthuc = DatePicker_NgaySau.Text + " 23:59:59";
                Load_CheckListBatchNo(ngaybatdau,ngayketthuc);}
            catch { }
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            dgv_data.DataSource = null;
            if (cbb_filename_exportexcel.Text == "File Special Data From " + ngaybatdau.ToString().Substring(0, 10) + "To " +ngayketthuc.ToString().Substring(0, 10))
            {
                try
                {
                    string a =
                        "select c.IDFile,c.Cot_G,Truong_26,Truong_27,Truong_28,Truong_29,Truong_30,Truong_31,Truong_32,Truong_33,Truong_34,Truong_35,Truong_36 " +
                        " from(tbl_Admin a inner join tbl_File f on a.Cot_Z = f.Cot_Z and a.Cot_G = f.Cot_G and a.fBatchName = f.fBatchName)inner join tbl_Checker c on a.Cot_Z = c.Cot_Z and a.Cot_G = c.Cot_G and a.fBatchName = c.fBatchName" +
                        " where SubmitFile_Input = 1 and SubmitFile_Check = 1 and SubmitFile_Admin = 1 and((Error_Input = 1 and SubmitFile_Input_2 = 1)or(Error_Input = 0 and SubmitFile_Input_2 = 0)) and " +
                        " ((Error_Check = 1 and SubmitFile_Check_2 = 1) or (Error_Check = 0 and SubmitFile_Check_2 = 0)) and " +
                        " ((Truong_26 is not null and Truong_26 <> '') or (Truong_27 is not null and Truong_27 <> '') or (Truong_28 is not null and Truong_28 <> '') or (Truong_29 is not null and Truong_29 <> '') or (Truong_30 is not null and Truong_30 <> '') or " +
                        " (Truong_31 is not null and Truong_31 <> '') or (Truong_32 is not null and Truong_32 <> '') or (Truong_33 is not null and Truong_33 <> '') or (Truong_34 is not null and Truong_34 <> '') or (Truong_35 is not null and Truong_35 <> '') or (Truong_36 is not null and Truong_36 <> '')) " +
                        " and (Truong_51 Between '" + ngaybatdau +"'  and '" +ngayketthuc+"') and (";
                    List<string> listChecked = new List<string>();
                    for (int i = 0; i < chlb_batchno.Items.Count; i++)
                    {
                        if (chlb_batchno.GetItemChecked(i))
                            listChecked.Add(chlb_batchno.Items[i].ToString());
                    }
                    for (int j = 0; j < listChecked.Count; j++)
                    {
                        if (j == listChecked.Count - 1)
                        {
                            a += " c.Cot_Z ='" + listChecked[j] + "')";
                            break;
                        }
                        a += " c.Cot_Z ='" + listChecked[j] + "' or ";
                    }
                    IEnumerable<CLDuLieuDacBiet> results = Global.DataNencho.ExecuteQuery<CLDuLieuDacBiet>(a);
                    dgv_data.DataSource = results.ToList();
                    if (
                        File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "\\DuLieuDacBiet.xls"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "\\DuLieuDacBiet.xls");
                        File.WriteAllBytes(
                            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DuLieuDacBiet.xls"),
                            Properties.Resources.DuLieuDacBiet);
                    }
                    else
                    {
                        File.WriteAllBytes(
                            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DuLieuDacBiet.xls"),
                            Properties.Resources.DuLieuDacBiet);
                    }
                    TableToExcel_DuLieuDacBiet(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                               "\\DuLieuDacBiet.xls");
                }
                catch (Exception i)
                {
                    MessageBox.Show("Error :" + i);
                }
            }
            else if (cbb_filename_exportexcel.Text == "File History From " + ngaybatdau.ToString().Substring(0, 10) + "To " +ngayketthuc.ToString().Substring(0, 10))
            {
                try
                {
                    string a =
                        "Select c.IDFile,c.Cot_G,Truong_37,Truong_38 " +
                        " from(tbl_Admin a inner join tbl_File f on a.Cot_Z = f.Cot_Z and a.Cot_G = f.Cot_G and a.fBatchName = f.fBatchName)inner join tbl_Checker c on a.Cot_Z = c.Cot_Z and a.Cot_G = c.Cot_G and a.fBatchName = c.fBatchName " +
                        " where SubmitFile_Input = 1 and SubmitFile_Check = 1 and SubmitFile_Admin = 1 and((Error_Input = 1 and SubmitFile_Input_2 = 1)or(Error_Input = 0 and SubmitFile_Input_2 = 0)) and" +
                        "((Error_Check = 1 and SubmitFile_Check_2 = 1) or(Error_Check = 0 and SubmitFile_Check_2 = 0))and" +
                        "((Truong_37 is not null and Truong_37 <> '') or(Truong_38 is not null and Truong_38 <> '')) and" +
                        "(Truong_51 Between '" + ngaybatdau+ "' and '" +ngayketthuc+ "')and (";
                    List<string> listChecked = new List<string>();
                    for (int i = 0; i < chlb_batchno.Items.Count; i++)
                    {
                        if (chlb_batchno.GetItemChecked(i))
                            listChecked.Add(chlb_batchno.Items[i].ToString());
                    }
                    for (int j = 0; j < listChecked.Count; j++)
                    {
                        if (j == listChecked.Count - 1)
                        {
                            a += " c.Cot_Z ='" + listChecked[j] + "')";
                            break;
                        }

                        a += " c.Cot_Z ='" + listChecked[j] + "' or ";
                    }

                    IEnumerable<CLDuLieuLichSu> results = Global.DataNencho.ExecuteQuery<CLDuLieuLichSu>(a);
                    dgv_data.DataSource = results.ToList();
                    if (
                        File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "\\ListLichSu.xls"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "\\ListLichSu.xls");
                        File.WriteAllBytes(
                            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ListLichSu.xls"),
                            Properties.Resources.ListLichSu);
                    }
                    else
                    {
                        File.WriteAllBytes(
                            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ListLichSu.xls"),
                            Properties.Resources.ListLichSu);
                    }
                    TableToExcel_ListLichSu(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                            "\\ListLichSu.xls");
                }
                catch (Exception i)
                {
                    MessageBox.Show("Error :" + i);
                }
            }
            else if (cbb_filename_exportexcel.Text == "File Data Total From " + ngaybatdau.ToString().Substring(0, 10) + "To " +ngayketthuc.ToString().Substring(0, 10)){
                try
                {
                    string a = "Select  Cot_G, Cot_J, Cot_K, Cot_M, Cot_N, Cot_O, Cot_P, Cot_Q, Cot_R, Cot_S, Cot_T, Cot_U, Cot_X, DateCreate, Cot_Y, Cot_V, X.Cot_Z,Soluong, " +
                                        "Cot_AA ,Cot_AB ,Cot_AE ,Cot_AA as Cot_AA1,Cot_AC,Truong_39,Truong_40,Truong_41,Truong_42,Truong_43,Cot_AB as Cot_AB1," +
                                        "Cot_AD,Truong_39 as Truong_391,Truong_40 as Truong_401,Truong_41 as Truong_411,Truong_42 as Truong_421, Truong_43 as Truong_431," +
                                        "Cot_AE as Cot_AE1,Cot_AF,Truong_51,Truong_52,Truong_53,Truong_54,Truong_55,Truong_56,Truong_57,Truong_58,Truong_59," +
                                        "Truong_60,Truong_61,Truong_62,Truong_63,Truong_64,Truong_65,Truong_66,Truong_67,Truong_68,Truong_69,Truong_70," +
                                        "Truong_71,Truong_72,Truong_73,Truong_74 " +
                                "from(  select  f.Cot_G, f.Cot_J, f.Cot_K, f.Cot_M, f.Cot_N, f.Cot_O, f.Cot_P, f.Cot_Q, f.Cot_R, f.Cot_S, f.Cot_T, f.Cot_U, f.Cot_X, b.DateCreate, f.Cot_Y, f.Cot_V, f.Cot_Z," +
                                           "  f.Cot_AA, f.Cot_AB, f.Cot_AE, f.Cot_AA as Cot_AA1, f.Cot_AC, i.Truong_39, i.Truong_40, i.Truong_41, i.Truong_42, i.Truong_43, f.Cot_AB as Cot_AB1," +
                                            " f.Cot_AD, c.Truong_39 as Truong_391, c.Truong_40 as Truong_401, c.Truong_41 as Truong_411, c.Truong_42 as Truong_421, c.Truong_43 as Truong_431," +
                                            " f.Cot_AE as Cot_AE1, f.Cot_AF, a.Truong_51, a.Truong_52, a.Truong_53, a.Truong_54, a.Truong_55, a.Truong_56, a.Truong_57, i.Truong_58, i.Truong_59," +
                                            " a.Truong_60, a.Truong_61, a.Truong_62, a.Truong_63, a.Truong_64, c.Truong_65, c.Truong_66, a.Truong_67, a.Truong_68, a.Truong_69, a.Truong_70," +
                                            " a.Truong_71, a.Truong_72, a.Truong_73, a.Truong_74, f.fBatchName" +
                                        " from(((tbl_File f inner join tbl_Input i on f.fbatchName = i.fBatchName and f.Cot_Z = i.Cot_Z and f.Cot_G = i.Cot_G) inner join tbl_Checker c " +
                                                " on f.fbatchName = c.fBatchName and f.Cot_Z = c.Cot_Z and f.Cot_G = c.Cot_G)  inner join tbl_Admin a" +
                                                " on f.fbatchName = a.fBatchName and f.Cot_Z = a.Cot_Z and f.Cot_G = a.Cot_G)  inner join tbl_Batch b " +
                                                " on f.fbatchName = b.fBatchName " +
                                        " where SubmitFile_Input = 1 and SubmitFile_Check = 1 and SubmitFile_Admin = 1 and((Error_Input = 1 and SubmitFile_Input_2 = 1)or(Error_Input = 0 and " +
                                                " SubmitFile_Input_2 = 0)) and((Error_Check = 1 and SubmitFile_Check_2 = 1) or(Error_Check = 0 and SubmitFile_Check_2 = 0)) ) as X ," +
                                        " (select  Soluong =cast( count(cot_z)  as nvarchar(255)), fbatchname,cot_z from tbl_file where cot_z is not null and cot_z<> '' and cot_z<> ' All' group by cot_z,fbatchname) as Y " +
                                "where X.fBatchName = Y.fBatchName and X.cot_z = Y.cot_z and "+
                                "(Truong_51 Between '" + ngaybatdau + "' and '" + ngayketthuc + "')and (";
                    List<string> listChecked = new List<string>();
                    for (int i = 0; i < chlb_batchno.Items.Count; i++)
                    {
                        if (chlb_batchno.GetItemChecked(i))
                            listChecked.Add(chlb_batchno.Items[i].ToString());
                    }
                    for (int j = 0; j < listChecked.Count; j++)
                    {
                        if (j == listChecked.Count - 1)
                        {
                            a += " X.Cot_Z ='" + listChecked[j] + "')";
                            break;
                        }

                        a += " X.Cot_Z ='" + listChecked[j] + "' or ";
                    }

                    IEnumerable<CLDuLieuTong> results = Global.DataNencho.ExecuteQuery<CLDuLieuTong>(a);
                    dgv_data.DataSource = results.ToList();
                    if (
                        File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "\\FileXuatTong.xls"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "\\FileXuatTong.xls");
                        File.WriteAllBytes(
                            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/FileXuatTong.xls"),
                            Properties.Resources.FileXuatTong);
                    }
                    else
                    {
                        File.WriteAllBytes(
                            (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/FileXuatTong.xls"),
                            Properties.Resources.FileXuatTong);
                    }
                    TableToExcel_FileXuatTong(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                              "\\FileXuatTong.xls");
                }
                catch (Exception i)
                {
                    MessageBox.Show("Error :" + i);
                }
            }
        }
        public bool fillcolor(Workbook book, string cells, Color color)
        {
            
            try
            {
                Sheets _sheet;
                Worksheet wrksheet;
                _sheet = book.Sheets;
                wrksheet = (Worksheet)book.ActiveSheet;
                Range chartRange;
                chartRange = wrksheet.get_Range(cells);
                chartRange.Interior.Color = ColorTranslator.ToOle(color);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }

            return true;
        }
        public bool TableToExcel_DuLieuDacBiet(String strfilename)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Sheets _sheet = book.Sheets;
                Worksheet wrksheet = (Worksheet)book.ActiveSheet;
                int h = 5;
                int stt = 1;
                foreach (DataGridViewRow dr in dgv_data.Rows)
                {
                    for (int i = 0; i < 13; i++)
                    {                        wrksheet.Cells[h, 1] = stt.ToString();
                        wrksheet.Cells[h, 2] = DateTime.Now.ToString("yyyy/MM/dd");
                        var value = dr.Cells[i].Value;
                        if (value != null) wrksheet.Cells[h, i + 3] = dr.Cells[i].Value.ToString();
                    }
                    Range rowHead = wrksheet.get_Range("A5", "T" + h);
                    rowHead.Borders.LineStyle = Constants.xlSolid;
                    h++; stt++;
                }
                
                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.FileName = "File Special Data";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    App.Quit();
                }
                else
                {
                    MessageBox.Show("Export excel error!");
                    return false;
                }
                Process.Start(savePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool TableToExcel_ListLichSu(String strfilename)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false,XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Sheets _sheet = book.Sheets;
                Worksheet wrksheet = (Worksheet)book.ActiveSheet;
                int h = 2;
                int stt = 1;
                foreach (DataGridViewRow dr in dgv_data.Rows)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        wrksheet.Cells[h, 1] = stt.ToString();
                        wrksheet.Cells[h, 2] = DateTime.Now.ToString("yyyy/MM/dd");
                        var value = dr.Cells[i].Value;
                        if (value != null) wrksheet.Cells[h, i + 3] = value.ToString();
                    }
                    Range rowHead = wrksheet.get_Range("A2", "G" + h);
                    rowHead.Borders.LineStyle = Constants.xlSolid;
                    h++; stt++;
                }
                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.FileName = "File History";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    App.Quit();
                }
                else
                {
                    MessageBox.Show("Export excel error!");
                    return false;
                }
                Process.Start(savePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        public bool TableToExcel_FileXuatTong(String strfilename)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                Workbook book = App.Workbooks.Open(strfilename, 0, true, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Sheets _sheet = book.Sheets;
                Worksheet wrksheet = (Worksheet)book.ActiveSheet;

                int h = 3;
                int stt = 1;
                foreach (DataGridViewRow dr in dgv_data.Rows)
                {
                    for (int i = 0; i < 61; i++)
                    {
                        wrksheet.Cells[h, 1] = stt.ToString();
                        if (i == 13)
                        {
                            var value15 = dr.Cells[i].Value;
                            if (!string.IsNullOrEmpty(value15.ToString()))
                                wrksheet.Cells[h, i + 2] = DateTime.Parse(value15.ToString()).ToString("yyyy-MM-dd");
                        }
                        var value = dr.Cells[i].Value;
                        if (value != null) wrksheet.Cells[h, i + 2] = value.ToString();

                        if (i == 3 && dr.Cells[3].Value.ToString() == "0")
                        {
                            fillcolor(book, "E" + h, Color.Red);
                        }
                        if (i == 4 && dr.Cells[4].Value.ToString() == "0")
                        {
                            fillcolor(book, "F" + h, Color.Red);
                        }
                        if (i == 9 && dr.Cells[9].Value.ToString() != "0")
                        {
                            fillcolor(book, "K" + h, Color.Red);
                        }
                        if (i == 10 && dr.Cells[10].Value.ToString() != "0")
                        {
                            fillcolor(book, "L" + h, Color.Red);
                        }
                        if (i == 11 && dr.Cells[11].Value.ToString() != "0")
                        {
                            fillcolor(book, "M" + h, Color.Red);
                        }
                        string truong67 = dr.Cells[53].Value != null ? dr.Cells[53].Value.ToString() : "";
                        int truong_67 = 0;
                        if (!string.IsNullOrEmpty(truong67))
                            truong_67 = Convert.ToInt32(truong67);
                        if (i == 53 && truong_67 <= 2 && truong_67!=0)
                        {
                            fillcolor(book, "BC" + h, Color.Blue);
                        }
                        if (i == 53 && truong_67 == 3 || i == 53 && truong_67 == 4)
                        {
                            fillcolor(book, "BC" + h, Color.Orange);
                        }
                        if (i == 53 && truong_67 >= 5)
                        {
                            fillcolor(book, "BC" + h, Color.Red);
                        }

                        if (i == 39)
                            fillcolor(book, "AO" + h, Color.FromArgb(253, 233, 217));
                        if (i == 40)
                            fillcolor(book, "AP" + h, Color.FromArgb(253,233,217));
                        if (i == 41)
                            fillcolor(book, "AQ" + h, Color.FromArgb(253, 233, 217));
                        if (i == 42)
                            fillcolor(book, "AR" + h, Color.FromArgb(253, 233, 217));
                        if (i == 43)
                            fillcolor(book, "AS" + h, Color.FromArgb(253, 233, 217));
                        if (i == 44)
                            fillcolor(book, "AT" + h, Color.FromArgb(253, 233, 217));
                        if (i == 45)
                            fillcolor(book, "AU" + h, Color.FromArgb(253, 233, 217));

                        if (i == 46)
                            fillcolor(book, "AV" + h, Color.FromArgb(252, 213, 180));
                        if (i == 47)
                            fillcolor(book, "AW" + h, Color.FromArgb(252, 213, 180));
                        if (i == 48)
                            fillcolor(book, "AX" + h, Color.FromArgb(252, 213, 180));
                        if (i == 59)
                            fillcolor(book, "AY" + h, Color.FromArgb(252, 213, 180));
                        if (i == 50)
                            fillcolor(book, "AZ" + h, Color.FromArgb(252, 213, 180));
                        if (i == 51)
                            fillcolor(book, "BA" + h, Color.FromArgb(252, 213, 180));
                        if (i == 52)
                            fillcolor(book, "BB" + h, Color.FromArgb(252, 213, 180));}
                    Range rowHead = wrksheet.get_Range("A3", "BJ" + h);
                    rowHead.Borders.LineStyle = Constants.xlSolid;
                    h++; stt++;
                }

                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.FileName = "File Data Total";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    App.Quit();
                }
                else
                {
                    MessageBox.Show("Export excel error!");
                    return false;
                }
                Process.Start(savePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}