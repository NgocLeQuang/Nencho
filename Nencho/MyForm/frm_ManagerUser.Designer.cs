namespace Nencho.MyForm
{
    partial class frm_ManagerUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ManagerUser));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.cbb_role = new System.Windows.Forms.ComboBox();
            this.txt_nhanvien = new DevExpress.XtraEditors.TextEdit();
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.txt_username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dgv_listuser = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nhanvien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_Edit);
            this.panelControl1.Controls.Add(this.btn_them);
            this.panelControl1.Controls.Add(this.cbb_role);
            this.panelControl1.Controls.Add(this.txt_nhanvien);
            this.panelControl1.Controls.Add(this.txt_password);
            this.panelControl1.Controls.Add(this.txt_username);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 389);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(914, 131);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Edit.Location = new System.Drawing.Point(448, 95);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 4;
            this.btn_Edit.Text = "Edit User";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_them
            // 
            this.btn_them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_them.Location = new System.Drawing.Point(366, 95);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 3;
            this.btn_them.Text = "Add User";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // cbb_role
            // 
            this.cbb_role.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbb_role.FormattingEnabled = true;
            this.cbb_role.Location = new System.Drawing.Point(121, 67);
            this.cbb_role.Name = "cbb_role";
            this.cbb_role.Size = new System.Drawing.Size(204, 21);
            this.cbb_role.TabIndex = 2;
            // 
            // txt_nhanvien
            // 
            this.txt_nhanvien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_nhanvien.Location = new System.Drawing.Point(121, 97);
            this.txt_nhanvien.Name = "txt_nhanvien";
            this.txt_nhanvien.Size = new System.Drawing.Size(204, 20);
            this.txt_nhanvien.TabIndex = 1;
            // 
            // txt_password
            // 
            this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_password.Location = new System.Drawing.Point(121, 38);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(204, 20);
            this.txt_password.TabIndex = 1;
            // 
            // txt_username
            // 
            this.txt_username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_username.Location = new System.Drawing.Point(121, 10);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(204, 20);
            this.txt_username.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Location = new System.Drawing.Point(42, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Nhân Viên :";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Location = new System.Drawing.Point(42, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Role :";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(41, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Password :";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(41, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "UserName :";
            // 
            // dgv_listuser
            // 
            this.dgv_listuser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_listuser.Location = new System.Drawing.Point(0, 0);
            this.dgv_listuser.MainView = this.gridView1;
            this.dgv_listuser.Name = "dgv_listuser";
            this.dgv_listuser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btn_delete});
            this.dgv_listuser.Size = new System.Drawing.Size(914, 389);
            this.dgv_listuser.TabIndex = 1;
            this.dgv_listuser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.dgv_listuser;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellDefaultAlignment += new DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventHandler(this.gridView1_RowCellDefaultAlignment);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "UserName";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 179;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Password";
            this.gridColumn2.FieldName = "Password";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 179;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id Role";
            this.gridColumn3.FieldName = "IdRole";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 179;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nhân viên";
            this.gridColumn4.FieldName = "Nhanvien";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 179;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Xóa";
            this.gridColumn5.ColumnEdit = this.btn_delete;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 50;
            // 
            // btn_delete
            // 
            this.btn_delete.AutoHeight = false;
            this.btn_delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btn_delete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // frm_ManagerUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 520);
            this.Controls.Add(this.dgv_listuser);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_ManagerUser";
            this.Text = "Manager User";
            this.Load += new System.EventHandler(this.frm_ManagerUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nhanvien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgv_listuser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn_delete;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_them;
        private System.Windows.Forms.ComboBox cbb_role;
        private DevExpress.XtraEditors.TextEdit txt_nhanvien;
        private DevExpress.XtraEditors.TextEdit txt_password;
        private DevExpress.XtraEditors.TextEdit txt_username;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}