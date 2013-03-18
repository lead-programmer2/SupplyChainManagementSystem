namespace SupplyChainManagementSystem
{
    partial class StockAdjustmentListDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockAdjustmentListDialog));
            this.brStatus = new DevComponents.DotNetBar.Bar();
            this.btnInfo = new DevComponents.DotNetBar.ButtonItem();
            this.brToolbar = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnNew = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.grdStockAdjustments = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.brStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).BeginInit();
            this.brToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockAdjustments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // brStatus
            // 
            this.brStatus.AntiAlias = true;
            this.brStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.brStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnInfo});
            this.brStatus.Location = new System.Drawing.Point(0, 382);
            this.brStatus.Name = "brStatus";
            this.brStatus.RoundCorners = false;
            this.brStatus.Size = new System.Drawing.Size(753, 25);
            this.brStatus.Stretch = true;
            this.brStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brStatus.TabIndex = 0;
            this.brStatus.TabStop = false;
            // 
            // btnInfo
            // 
            this.btnInfo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Text = " Ready";
            // 
            // brToolbar
            // 
            this.brToolbar.AntiAlias = true;
            this.brToolbar.Controls.Add(this.txtSearch);
            this.brToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.brToolbar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brToolbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.labelItem1,
            this.controlContainerItem1});
            this.brToolbar.Location = new System.Drawing.Point(0, 0);
            this.brToolbar.Name = "brToolbar";
            this.brToolbar.RoundCorners = false;
            this.brToolbar.Size = new System.Drawing.Size(753, 27);
            this.brToolbar.Stretch = true;
            this.brToolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brToolbar.TabIndex = 1;
            this.brToolbar.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(601, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "<i>Search</i>";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Name = "btnNew";
            this.btnNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN);
            this.btnNew.Text = "&New";
            this.btnNew.Tooltip = "Create a new stock adjustment.";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Tooltip = "Update the selected stock adjustment\'s information.";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Tooltip = "Permanently deletes the selected stock adjustment from the list.";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Tooltip = "Reloads the list of stock adjustments.";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Stretch = true;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.txtSearch;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // grdStockAdjustments
            // 
            this.grdStockAdjustments.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdStockAdjustments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockAdjustments.Location = new System.Drawing.Point(0, 27);
            this.grdStockAdjustments.Name = "grdStockAdjustments";
            this.grdStockAdjustments.Rows.DefaultSize = 21;
            this.grdStockAdjustments.Size = new System.Drawing.Size(753, 355);
            this.grdStockAdjustments.StyleInfo = resources.GetString("grdStockAdjustments.StyleInfo");
            this.grdStockAdjustments.TabIndex = 2;
            this.grdStockAdjustments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdStockAdjustments_MouseDoubleClick);
            // 
            // pctLoad
            // 
            this.pctLoad.BackColor = System.Drawing.Color.White;
            this.pctLoad.ForeColor = System.Drawing.Color.Black;
            this.pctLoad.Image = global::SupplyChainManagementSystem.Properties.Resources.Loader;
            this.pctLoad.Location = new System.Drawing.Point(337, 188);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(102, 18);
            this.pctLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLoad.TabIndex = 16;
            this.pctLoad.TabStop = false;
            // 
            // StockAdjustmentListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 407);
            this.Controls.Add(this.pctLoad);
            this.Controls.Add(this.grdStockAdjustments);
            this.Controls.Add(this.brToolbar);
            this.Controls.Add(this.brStatus);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockAdjustmentListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Adjustments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockAdjustmentListDialog_FormClosing);
            this.Load += new System.EventHandler(this.StockAdjustmentListDialog_Load);
            this.Shown += new System.EventHandler(this.StockAdjustmentListDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.brStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).EndInit();
            this.brToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockAdjustments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar brStatus;
        private DevComponents.DotNetBar.ButtonItem btnInfo;
        private DevComponents.DotNetBar.Bar brToolbar;
        private DevComponents.DotNetBar.ButtonItem btnNew;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private C1.Win.C1FlexGrid.C1FlexGrid grdStockAdjustments;
        private System.Windows.Forms.PictureBox pctLoad;
    }
}