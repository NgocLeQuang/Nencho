using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Nencho.MyForm
{
    public partial class frm_CreateFile : DevExpress.XtraEditors.XtraForm
    {
        private OleDbConnection _oleDbcon;

        public frm_CreateFile()
        {
            InitializeComponent();
        }

        private void frm_CreateFile_Load(object sender, EventArgs e)
        {
            labelControl6.Visible = false;
            cbb_ChonSheet.Visible = false;
            txt_UserName.Text = Global.StrUsername; txt_NgayTao.Text = DateTime.Now.ToShortDateString();
        }

        private string MyTrim(string strInput)
        {
            string kq = strInput;

            kq = kq.Replace("\n", "");
            kq = kq.Replace(" ", "");

            return kq;

        }
        private void cbb_ChonSheet_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_FileExcel.Text))
            {
                labelControl6.Visible = true;
                cbb_ChonSheet.Visible = true;
            }
            else
            {
                labelControl6.Visible = false;
                cbb_ChonSheet.Visible = false;
            }
        }

        private void btn_HuyBo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ChonFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Excel Files|*.xls;*.xlsx";

                openFileDialog.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialog.FileName))

                {
                    _oleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openFileDialog.FileName + ";Extended Properties=Excel 12.0;");
                    txt_fBatchName.Text = openFileDialog.SafeFileName;
                    _oleDbcon.Open();
                    txt_FileExcel.Text = openFileDialog.FileName;
                    DataTable dt = _oleDbcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    _oleDbcon.Close();

                    cbb_ChonSheet.EditValue = null;
                    List<string> temp = new List<string>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sheetName = dt.Rows[i]["TABLE_NAME"].ToString();

                        //sheetName = sheetName.Substring(0, sheetName.Length - 1);

                        temp.Add(sheetName);
                    }
                    cbb_ChonSheet.Properties.DataSource = temp;
                    cbb_ChonSheet.ItemIndex = 0;
                }
            }
        }

        private void btn_TaoBatch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_FileExcel.Text))
            {
                MessageBox.Show("Excel files can not be empty!");
            }
            else
            {
                var fbatchname =
                (from w in Global.DataNencho.tbl_Batches
                    where w.fBatchName == txt_fBatchName.Text
                    select w.fBatchName).FirstOrDefault();
                if (!string.IsNullOrEmpty(fbatchname))
                {
                    MessageBox.Show("BatchName already exists, please enter the name of the BatchName");
                    return;
                }
                else
                {
                    var dbExcel = new OleDbDataAdapter("Select * from [" + cbb_ChonSheet.Text + "]", _oleDbcon);
                    DataTable dt = new DataTable();
                    dbExcel.Fill(dt);
                    int k = 1;
                    bool filechuan = false;
                    foreach (DataRow Row in dt.Rows)
                    {
                        if (k == 5)
                        {
                            if (MyTrim(Row[1].ToString()) != MyTrim("Ｎｏ") ||
                                MyTrim(Row[2].ToString()) != MyTrim("店舗名") ||
                                MyTrim(Row[5].ToString()) != MyTrim("ファイル名") ||
                                MyTrim(Row[8].ToString()) != MyTrim("PDFページ数") ||
                                MyTrim(Row[9].ToString()) != MyTrim("属性") ||
                                MyTrim(Row[11].ToString()) != MyTrim("送付物") ||
                                MyTrim(Row[20].ToString()) != MyTrim("前回UP日") ||
                                MyTrim(Row[21].ToString()) != MyTrim("備考") ||
                                MyTrim(Row[22].ToString()) != MyTrim("会社名") ||
                                MyTrim(Row[23].ToString()) != MyTrim("受付者") ||
                                MyTrim(Row[24].ToString()) != MyTrim("Batch NO") ||
                                MyTrim(Row[25].ToString()) != MyTrim("チェック①") ||
                                MyTrim(Row[26].ToString()) != MyTrim("チェック②") ||
                                MyTrim(Row[27].ToString()) != MyTrim("チェック①予定日") ||
                                MyTrim(Row[28].ToString()) != MyTrim("チェック②予定日") ||
                                MyTrim(Row[29].ToString()) != MyTrim("承認者") ||
                                MyTrim(Row[30].ToString()) != MyTrim("承認予定日") ||
                                MyTrim(Row[31].ToString()) != MyTrim("納品日"))
                            {
                                filechuan = false;
                            }
                            else
                            {
                                filechuan = true;
                            }
                        }
                        if (k == 6)
                        {
                            if (MyTrim(Row[9].ToString()) != MyTrim("ＩＤ") ||
                                MyTrim(Row[10].ToString()) != MyTrim("氏名") ||
                                MyTrim(Row[11].ToString()) != MyTrim("扶養控除申告書") ||
                                MyTrim(Row[12].ToString()) != MyTrim("保険料控除申告書") ||
                                MyTrim(Row[13].ToString()) != MyTrim("保険料証書") ||
                                MyTrim(Row[17].ToString()) != MyTrim("その他"))
                            {
                                filechuan = false;
                            }
                            else
                            {
                                filechuan = true;
                            }
                        }
                        if (k == 7)
                        {
                            if (MyTrim(Row[13].ToString()) != MyTrim("生命") ||
                                 MyTrim(Row[14].ToString()) != MyTrim("地震") ||
                                 MyTrim(Row[15].ToString()) != MyTrim("社会") ||
                                 MyTrim(Row[16].ToString()) != MyTrim("小規模企業共済") ||
                                 MyTrim(Row[17].ToString()) != MyTrim("源泉徴収票") ||
                                 MyTrim(Row[18].ToString()) != MyTrim("障害者証明") ||
                                 MyTrim(Row[19].ToString()) != MyTrim("学生証明"))
                            {
                                filechuan = false;
                            }
                            else
                            {
                                filechuan = true;
                            }
                        }
                        k++;
                    }
                    if (filechuan)
                    {
                        Global.DataNencho.CreateBatch(txt_fBatchName.Text, txt_UserName.Text, txt_FileExcel.Text);
                        int n = 1;
                        foreach (DataRow dataRow in dt.Rows)
                        {
                            if (n > 7 && n < dt.Rows.Count)
                            {
                                Global.DataNencho.CreateFile_New(txt_fBatchName.Text,
                                    dataRow[1].ToString(),
                                    dataRow[2].ToString(),
                                    dataRow[3].ToString(),
                                    dataRow[4].ToString(),
                                    dataRow[5].ToString(),
                                    dataRow[6].ToString(),
                                    dataRow[7].ToString(),
                                    dataRow[8].ToString(),
                                    dataRow[9].ToString(),
                                    dataRow[10].ToString(),
                                    dataRow[11].ToString(),
                                    dataRow[12].ToString(),
                                    dataRow[13].ToString(),
                                    dataRow[14].ToString(),
                                    dataRow[15].ToString(),
                                    dataRow[16].ToString(),
                                    dataRow[17].ToString(),
                                    dataRow[18].ToString(),
                                    dataRow[19].ToString(),
                                    dataRow[20].ToString(),
                                    dataRow[21].ToString(),
                                    dataRow[22].ToString(),
                                    dataRow[23].ToString(),
                                    dataRow[24].ToString(),
                                    dataRow[25].ToString(),
                                    dataRow[26].ToString(),
                                    dataRow[27].ToString(),
                                    dataRow[28].ToString(),
                                    dataRow[29].ToString(),
                                    dataRow[30].ToString(),
                                    dataRow[31].ToString());
                            }
                            n++;
                        }
                        if (
                            MessageBox.Show("Batch was successfully created! \n Do you want to continue to create another batch?",
                                "Notification!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            txt_fBatchName.Text = "";
                            txt_FileExcel.Text = "";
                            cbb_ChonSheet.SelectedText = null;
                        }
                        else
                        {
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your file is not included in the standard file !, Please open the template file view!");
                    }
                }
            }
        }
    }
}