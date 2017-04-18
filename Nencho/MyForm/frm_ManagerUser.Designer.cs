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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_delete_user = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.txt_nhanvien = new DevExpress.XtraEditors.TextEdit();
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.txt_username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dgv_listuser = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nhanvien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.btn_delete_user);
            this.panelControl1.Controls.Add(this.btn_Edit);
            this.panelControl1.Controls.Add(this.btn_them);
            this.panelControl1.Controls.Add(this.txt_nhanvien);
            this.panelControl1.Controls.Add(this.txt_password);
            this.panelControl1.Controls.Add(this.txt_username);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Name = "panelControl1";
            // 
            // btn_delete_user
            // 
            resources.ApplyResources(this.btn_delete_user, "btn_delete_user");
            this.btn_delete_user.Name = "btn_delete_user";
            this.btn_delete_user.Click += new System.EventHandler(this.btn_delete_user_Click);
            // 
            // btn_Edit
            // 
            resources.ApplyResources(this.btn_Edit, "btn_Edit");
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_them
            // 
            resources.ApplyResources(this.btn_them, "btn_them");
            this.btn_them.Name = "btn_them";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txt_nhanvien
            // 
            resources.ApplyResources(this.txt_nhanvien, "txt_nhanvien");
            this.txt_nhanvien.Name = "txt_nhanvien";
            this.txt_nhanvien.Properties.AccessibleDescription = resources.GetString("txt_nhanvien.Properties.AccessibleDescription");
            this.txt_nhanvien.Properties.AccessibleName = resources.GetString("txt_nhanvien.Properties.AccessibleName");
            this.txt_nhanvien.Properties.AutoHeight = ((bool)(resources.GetObject("txt_nhanvien.Properties.AutoHeight")));
            this.txt_nhanvien.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txt_nhanvien.Properties.Mask.AutoComplete")));
            this.txt_nhanvien.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txt_nhanvien.Properties.Mask.BeepOnError")));
            this.txt_nhanvien.Properties.Mask.EditMask = resources.GetString("txt_nhanvien.Properties.Mask.EditMask");
            this.txt_nhanvien.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txt_nhanvien.Properties.Mask.IgnoreMaskBlank")));
            this.txt_nhanvien.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txt_nhanvien.Properties.Mask.MaskType")));
            this.txt_nhanvien.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txt_nhanvien.Properties.Mask.PlaceHolder")));
            this.txt_nhanvien.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txt_nhanvien.Properties.Mask.SaveLiteral")));
            this.txt_nhanvien.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txt_nhanvien.Properties.Mask.ShowPlaceHolders")));
            this.txt_nhanvien.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txt_nhanvien.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txt_nhanvien.Properties.NullValuePrompt = resources.GetString("txt_nhanvien.Properties.NullValuePrompt");
            this.txt_nhanvien.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txt_nhanvien.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txt_password
            // 
            resources.ApplyResources(this.txt_password, "txt_password");
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.AccessibleDescription = resources.GetString("txt_password.Properties.AccessibleDescription");
            this.txt_password.Properties.AccessibleName = resources.GetString("txt_password.Properties.AccessibleName");
            this.txt_password.Properties.AutoHeight = ((bool)(resources.GetObject("txt_password.Properties.AutoHeight")));
            this.txt_password.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txt_password.Properties.Mask.AutoComplete")));
            this.txt_password.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txt_password.Properties.Mask.BeepOnError")));
            this.txt_password.Properties.Mask.EditMask = resources.GetString("txt_password.Properties.Mask.EditMask");
            this.txt_password.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txt_password.Properties.Mask.IgnoreMaskBlank")));
            this.txt_password.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txt_password.Properties.Mask.MaskType")));
            this.txt_password.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txt_password.Properties.Mask.PlaceHolder")));
            this.txt_password.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txt_password.Properties.Mask.SaveLiteral")));
            this.txt_password.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txt_password.Properties.Mask.ShowPlaceHolders")));
            this.txt_password.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txt_password.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txt_password.Properties.NullValuePrompt = resources.GetString("txt_password.Properties.NullValuePrompt");
            this.txt_password.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txt_password.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // txt_username
            // 
            resources.ApplyResources(this.txt_username, "txt_username");
            this.txt_username.Name = "txt_username";
            this.txt_username.Properties.AccessibleDescription = resources.GetString("txt_username.Properties.AccessibleDescription");
            this.txt_username.Properties.AccessibleName = resources.GetString("txt_username.Properties.AccessibleName");
            this.txt_username.Properties.AutoHeight = ((bool)(resources.GetObject("txt_username.Properties.AutoHeight")));
            this.txt_username.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txt_username.Properties.Mask.AutoComplete")));
            this.txt_username.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txt_username.Properties.Mask.BeepOnError")));
            this.txt_username.Properties.Mask.EditMask = resources.GetString("txt_username.Properties.Mask.EditMask");
            this.txt_username.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txt_username.Properties.Mask.IgnoreMaskBlank")));
            this.txt_username.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txt_username.Properties.Mask.MaskType")));
            this.txt_username.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txt_username.Properties.Mask.PlaceHolder")));
            this.txt_username.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txt_username.Properties.Mask.SaveLiteral")));
            this.txt_username.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txt_username.Properties.Mask.ShowPlaceHolders")));
            this.txt_username.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txt_username.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txt_username.Properties.NullValuePrompt = resources.GetString("txt_username.Properties.NullValuePrompt");
            this.txt_username.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txt_username.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // labelControl4
            // 
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Name = "labelControl4";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // dgv_listuser
            // 
            resources.ApplyResources(this.dgv_listuser, "dgv_listuser");
            this.dgv_listuser.EmbeddedNavigator.AccessibleDescription = resources.GetString("dgv_listuser.EmbeddedNavigator.AccessibleDescription");
            this.dgv_listuser.EmbeddedNavigator.AccessibleName = resources.GetString("dgv_listuser.EmbeddedNavigator.AccessibleName");
            this.dgv_listuser.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("dgv_listuser.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.dgv_listuser.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("dgv_listuser.EmbeddedNavigator.Anchor")));
            this.dgv_listuser.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dgv_listuser.EmbeddedNavigator.BackgroundImage")));
            this.dgv_listuser.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("dgv_listuser.EmbeddedNavigator.BackgroundImageLayout")));
            this.dgv_listuser.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("dgv_listuser.EmbeddedNavigator.ImeMode")));
            this.dgv_listuser.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("dgv_listuser.EmbeddedNavigator.MaximumSize")));
            this.dgv_listuser.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("dgv_listuser.EmbeddedNavigator.TextLocation")));
            this.dgv_listuser.EmbeddedNavigator.ToolTip = resources.GetString("dgv_listuser.EmbeddedNavigator.ToolTip");
            this.dgv_listuser.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("dgv_listuser.EmbeddedNavigator.ToolTipIconType")));
            this.dgv_listuser.EmbeddedNavigator.ToolTipTitle = resources.GetString("dgv_listuser.EmbeddedNavigator.ToolTipTitle");
            this.dgv_listuser.MainView = this.gridView1;
            this.dgv_listuser.Name = "dgv_listuser";
            this.dgv_listuser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4});
            this.gridView1.GridControl = this.dgv_listuser;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellDefaultAlignment += new DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventHandler(this.gridView1_RowCellDefaultAlignment);
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "Password";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumn4
            // 
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.FieldName = "Nhanvien";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // frm_ManagerUser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_listuser);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_ManagerUser";
            this.Load += new System.EventHandler(this.frm_ManagerUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nhanvien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgv_listuser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_them;
        private DevExpress.XtraEditors.TextEdit txt_nhanvien;
        private DevExpress.XtraEditors.TextEdit txt_password;
        private DevExpress.XtraEditors.TextEdit txt_username;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_delete_user;
    }
}