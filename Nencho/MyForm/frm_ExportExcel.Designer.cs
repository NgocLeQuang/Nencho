namespace Nencho.MyForm
{
    partial class frm_ExportExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExportExcel));
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DatePicker_NgayTruoc = new System.Windows.Forms.DateTimePicker();
            this.DatePicker_NgaySau = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbb_filename_exportexcel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chlb_batchno = new System.Windows.Forms.CheckedListBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ExportExcel
            // 
            resources.ApplyResources(this.btn_ExportExcel, "btn_ExportExcel");
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // DatePicker_NgayTruoc
            // 
            resources.ApplyResources(this.DatePicker_NgayTruoc, "DatePicker_NgayTruoc");
            this.DatePicker_NgayTruoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePicker_NgayTruoc.Name = "DatePicker_NgayTruoc";
            this.DatePicker_NgayTruoc.Value = new System.DateTime(2017, 1, 11, 0, 0, 0, 0);
            this.DatePicker_NgayTruoc.ValueChanged += new System.EventHandler(this.DatePicker_NgayTruoc_ValueChanged);
            // 
            // DatePicker_NgaySau
            // 
            resources.ApplyResources(this.DatePicker_NgaySau, "DatePicker_NgaySau");
            this.DatePicker_NgaySau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePicker_NgaySau.Name = "DatePicker_NgaySau";
            this.DatePicker_NgaySau.Value = new System.DateTime(3999, 12, 31, 0, 0, 0, 0);
            this.DatePicker_NgaySau.ValueChanged += new System.EventHandler(this.DatePicker_NgaySau_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // cbb_filename_exportexcel
            // 
            resources.ApplyResources(this.cbb_filename_exportexcel, "cbb_filename_exportexcel");
            this.cbb_filename_exportexcel.FormattingEnabled = true;
            this.cbb_filename_exportexcel.Name = "cbb_filename_exportexcel";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chlb_batchno);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chlb_batchno
            // 
            resources.ApplyResources(this.chlb_batchno, "chlb_batchno");
            this.chlb_batchno.FormattingEnabled = true;
            this.chlb_batchno.Name = "chlb_batchno";
            // 
            // dgv_data
            // 
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgv_data, "dgv_data");
            this.dgv_data.Name = "dgv_data";
            // 
            // frm_ExportExcel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DatePicker_NgaySau);
            this.Controls.Add(this.DatePicker_NgayTruoc);
            this.Controls.Add(this.cbb_filename_exportexcel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_ExportExcel);
            this.MaximizeBox = false;
            this.Name = "frm_ExportExcel";
            this.Load += new System.EventHandler(this.frm_ExportExcel_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DateTimePicker DatePicker_NgayTruoc;
        private System.Windows.Forms.DateTimePicker DatePicker_NgaySau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbb_filename_exportexcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chlb_batchno;
        private System.Windows.Forms.DataGridView dgv_data;
    }
}