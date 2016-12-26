namespace Nencho.MyForm
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btn_logout = new DevExpress.XtraBars.BarButtonItem();
            this.btn_exit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btn_quanlyuser = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tab_phanquyen = new DevExpress.XtraTab.XtraTabPage();
            this.tab_checker1 = new DevExpress.XtraTab.XtraTabPage();
            this.tab_checker2 = new DevExpress.XtraTab.XtraTabPage();
            this.tab_admin = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.btn_logout,
            this.btn_exit,
            this.barSubItem2,
            this.barSubItem3,
            this.btn_quanlyuser});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // barSubItem1
            // 
            resources.ApplyResources(this.barSubItem1, "barSubItem1");
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_logout),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_exit)});
            this.barSubItem1.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("barSubItem1.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.barSubItem1.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barSubItem1.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.barSubItem1.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barSubItem1.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.barSubItem1.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.MenuAppearance.HeaderItemAppearance.Image")));
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btn_logout
            // 
            resources.ApplyResources(this.btn_logout, "btn_logout");
            this.btn_logout.Id = 1;
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_logout_ItemClick);
            // 
            // btn_exit
            // 
            resources.ApplyResources(this.btn_exit, "btn_exit");
            this.btn_exit.Id = 2;
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_exit_ItemClick);
            // 
            // barSubItem2
            // 
            resources.ApplyResources(this.barSubItem2, "barSubItem2");
            this.barSubItem2.Id = 3;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_quanlyuser)});
            this.barSubItem2.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("barSubItem2.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.barSubItem2.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barSubItem2.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.barSubItem2.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barSubItem2.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.barSubItem2.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.MenuAppearance.HeaderItemAppearance.Image")));
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btn_quanlyuser
            // 
            resources.ApplyResources(this.btn_quanlyuser, "btn_quanlyuser");
            this.btn_quanlyuser.Id = 5;
            this.btn_quanlyuser.Name = "btn_quanlyuser";
            this.btn_quanlyuser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_quanlyuser_ItemClick);
            // 
            // barSubItem3
            // 
            resources.ApplyResources(this.barSubItem3, "barSubItem3");
            this.barSubItem3.Id = 4;
            this.barSubItem3.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("barSubItem3.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.barSubItem3.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barSubItem3.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.barSubItem3.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barSubItem3.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.barSubItem3.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem3.MenuAppearance.HeaderItemAppearance.Image")));
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlTop.Appearance.FontSizeDelta")));
            this.barDockControlTop.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlTop.Appearance.FontStyleDelta")));
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlTop.Appearance.Image")));
            this.barDockControlTop.CausesValidation = false;
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlBottom.Appearance.FontSizeDelta")));
            this.barDockControlBottom.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlBottom.Appearance.FontStyleDelta")));
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlBottom.Appearance.Image")));
            this.barDockControlBottom.CausesValidation = false;
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlLeft.Appearance.FontSizeDelta")));
            this.barDockControlLeft.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlLeft.Appearance.FontStyleDelta")));
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlLeft.Appearance.Image")));
            this.barDockControlLeft.CausesValidation = false;
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlRight.Appearance.FontSizeDelta")));
            this.barDockControlRight.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlRight.Appearance.FontStyleDelta")));
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlRight.Appearance.Image")));
            this.barDockControlRight.CausesValidation = false;
            // 
            // xtraTabControl1
            // 
            resources.ApplyResources(this.xtraTabControl1, "xtraTabControl1");
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tab_phanquyen;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tab_phanquyen,
            this.tab_checker1,
            this.tab_checker2,
            this.tab_admin});
            // 
            // tab_phanquyen
            // 
            resources.ApplyResources(this.tab_phanquyen, "tab_phanquyen");
            this.tab_phanquyen.Name = "tab_phanquyen";
            // 
            // tab_checker1
            // 
            resources.ApplyResources(this.tab_checker1, "tab_checker1");
            this.tab_checker1.Name = "tab_checker1";
            // 
            // tab_checker2
            // 
            resources.ApplyResources(this.tab_checker2, "tab_checker2");
            this.tab_checker2.Name = "tab_checker2";
            // 
            // tab_admin
            // 
            resources.ApplyResources(this.tab_admin, "tab_admin");
            this.tab_admin.Name = "tab_admin";
            // 
            // frm_Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btn_logout;
        private DevExpress.XtraBars.BarButtonItem btn_exit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btn_quanlyuser;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tab_phanquyen;
        private DevExpress.XtraTab.XtraTabPage tab_checker1;
        private DevExpress.XtraTab.XtraTabPage tab_checker2;
        private DevExpress.XtraTab.XtraTabPage tab_admin;
    }
}