namespace SupplyChainManagementSystem
{
    partial class PickListDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickListDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnInformation = new DevComponents.DotNetBar.ButtonItem();
            this.cboPickList = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            this.grdPickList = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnNew = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPickList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.bar2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnInformation});
            this.bar1.Location = new System.Drawing.Point(0, 408);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(447, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            // 
            // btnInformation
            // 
            this.btnInformation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnInformation.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnInformation.Image = ((System.Drawing.Image)(resources.GetObject("btnInformation.Image")));
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Text = " Ready";
            // 
            // cboPickList
            // 
            this.cboPickList.DisplayMember = "Text";
            this.cboPickList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPickList.FormattingEnabled = true;
            this.cboPickList.ItemHeight = 16;
            this.cboPickList.Location = new System.Drawing.Point(13, 12);
            this.cboPickList.Name = "cboPickList";
            this.cboPickList.Size = new System.Drawing.Size(425, 22);
            this.cboPickList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPickList.TabIndex = 1;
            this.cboPickList.SelectedIndexChanged += new System.EventHandler(this.cboPickList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pctLoad);
            this.panel1.Controls.Add(this.grdPickList);
            this.panel1.Controls.Add(this.bar2);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 362);
            this.panel1.TabIndex = 2;
            // 
            // pctLoad
            // 
            this.pctLoad.BackColor = System.Drawing.Color.White;
            this.pctLoad.ForeColor = System.Drawing.Color.Black;
            this.pctLoad.Image = global::SupplyChainManagementSystem.Properties.Resources.Loader;
            this.pctLoad.Location = new System.Drawing.Point(165, 180);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(102, 18);
            this.pctLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLoad.TabIndex = 15;
            this.pctLoad.TabStop = false;
            // 
            // grdPickList
            // 
            this.grdPickList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdPickList.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdPickList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPickList.Location = new System.Drawing.Point(0, 28);
            this.grdPickList.Name = "grdPickList";
            this.grdPickList.Rows.DefaultSize = 21;
            this.grdPickList.Size = new System.Drawing.Size(422, 332);
            this.grdPickList.StyleInfo = resources.GetString("grdPickList.StyleInfo");
            this.grdPickList.TabIndex = 1;
            this.grdPickList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdPickList_MouseDoubleClick);
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Controls.Add(this.txtSearch);
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.labelItem1,
            this.controlContainerItem1});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(422, 28);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 0;
            this.bar2.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(279, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 23);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "Search";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Name = "btnNew";
            this.btnNew.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN);
            this.btnNew.Tooltip = "Add a new item into the list.";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnEdit.Tooltip = "Modify the selected item.";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Tooltip = "Remove the selected item from the list.";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Tooltip = "Populate the list with items.";
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
            // PickListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(447, 433);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboPickList);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PickListDialog_FormClosing);
            this.Load += new System.EventHandler(this.PickListDialog_Load);
            this.Shown += new System.EventHandler(this.PickListDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPickList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.bar2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPickList;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGrid grdPickList;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnNew;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private System.Windows.Forms.PictureBox pctLoad;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ButtonItem btnInformation;
    }
}