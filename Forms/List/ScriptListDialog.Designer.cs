namespace SupplyChainManagementSystem
{
    partial class ScriptListDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptListDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnInformation = new DevComponents.DotNetBar.ButtonItem();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            this.btnExport = new DevComponents.DotNetBar.ButtonItem();
            this.btnExecuteScript = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.grdScripts = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.bar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScripts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
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
            this.bar1.Location = new System.Drawing.Point(0, 385);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(753, 25);
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
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Controls.Add(this.txtSearch);
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnImport,
            this.btnExport,
            this.btnExecuteScript,
            this.labelItem1,
            this.controlContainerItem1});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(753, 28);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(588, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(162, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.txtSearch.WatermarkText = "<i>Search</i>";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN);
            this.btnAdd.Tooltip = "Create a new database script file.";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE);
            this.btnEdit.Tooltip = "Update selected database script\'s information.";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Tooltip = "Delete the selected database script.";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Tooltip = "Refresh database script list.";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnImport
            // 
            this.btnImport.BeginGroup = true;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Name = "btnImport";
            this.btnImport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnImport.Tooltip = "Import database script information from existing file.";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Name = "btnExport";
            this.btnExport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnExport.Tooltip = "Export database script information into a script file.";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExecuteScript
            // 
            this.btnExecuteScript.BeginGroup = true;
            this.btnExecuteScript.Image = ((System.Drawing.Image)(resources.GetObject("btnExecuteScript.Image")));
            this.btnExecuteScript.Name = "btnExecuteScript";
            this.btnExecuteScript.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.btnExecuteScript.Tooltip = "Execute the current selected script file.";
            this.btnExecuteScript.Click += new System.EventHandler(this.btnExecuteScript_Click);
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
            // grdScripts
            // 
            this.grdScripts.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdScripts.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdScripts.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScripts.Location = new System.Drawing.Point(0, 28);
            this.grdScripts.Name = "grdScripts";
            this.grdScripts.Rows.DefaultSize = 21;
            this.grdScripts.Size = new System.Drawing.Size(753, 357);
            this.grdScripts.StyleInfo = resources.GetString("grdScripts.StyleInfo");
            this.grdScripts.TabIndex = 2;
            this.grdScripts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdScripts_MouseDoubleClick);
            // 
            // pctLoad
            // 
            this.pctLoad.BackColor = System.Drawing.Color.White;
            this.pctLoad.ForeColor = System.Drawing.Color.Black;
            this.pctLoad.Image = global::SupplyChainManagementSystem.Properties.Resources.Loader;
            this.pctLoad.Location = new System.Drawing.Point(340, 190);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(102, 18);
            this.pctLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLoad.TabIndex = 14;
            this.pctLoad.TabStop = false;
            // 
            // ScriptListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 410);
            this.Controls.Add(this.pctLoad);
            this.Controls.Add(this.grdScripts);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Script Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScriptListDialog_FormClosing);
            this.Load += new System.EventHandler(this.ScriptListDialog_Load);
            this.Shown += new System.EventHandler(this.ScriptListDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.bar2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScripts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private C1.Win.C1FlexGrid.C1FlexGrid grdScripts;
        private System.Windows.Forms.PictureBox pctLoad;
        private DevComponents.DotNetBar.ButtonItem btnInformation;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private DevComponents.DotNetBar.ButtonItem btnExport;
        private DevComponents.DotNetBar.ButtonItem btnExecuteScript;
    }
}