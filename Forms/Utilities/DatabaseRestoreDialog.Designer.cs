namespace SupplyChainManagementSystem
{
    partial class DatabaseRestoreDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseRestoreDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnBrowseDrive = new System.Windows.Forms.Button();
            this.lblPath = new DevComponents.DotNetBar.LabelX();
            this.btnRestore = new System.Windows.Forms.Button();
            this.grdStatus = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            this.chkCreateRestorePoint = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnBrowseRestorePoint = new System.Windows.Forms.Button();
            this._eventimages = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Location = new System.Drawing.Point(0, 285);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(460, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            // 
            // btnBrowseDrive
            // 
            this.btnBrowseDrive.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBrowseDrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseDrive.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnBrowseDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDrive.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDrive.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrowseDrive.Location = new System.Drawing.Point(12, 44);
            this.btnBrowseDrive.Name = "btnBrowseDrive";
            this.btnBrowseDrive.Size = new System.Drawing.Size(172, 22);
            this.btnBrowseDrive.TabIndex = 16;
            this.btnBrowseDrive.Text = "Select &Backup from Drive";
            this.btnBrowseDrive.UseVisualStyleBackColor = false;
            this.btnBrowseDrive.Click += new System.EventHandler(this.btnBrowseDrive_Click);
            // 
            // lblPath
            // 
            // 
            // 
            // 
            this.lblPath.BackgroundStyle.Class = "";
            this.lblPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPath.Location = new System.Drawing.Point(12, 7);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(436, 34);
            this.lblPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPath.TabIndex = 17;
            this.lblPath.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestore.Location = new System.Drawing.Point(350, 67);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(98, 22);
            this.btnRestore.TabIndex = 18;
            this.btnRestore.Text = "&Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // grdStatus
            // 
            this.grdStatus.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdStatus.Location = new System.Drawing.Point(12, 95);
            this.grdStatus.Name = "grdStatus";
            this.grdStatus.Rows.DefaultSize = 21;
            this.grdStatus.Size = new System.Drawing.Size(436, 160);
            this.grdStatus.StyleInfo = resources.GetString("grdStatus.StyleInfo");
            this.grdStatus.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(350, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 22);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(181, 144);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 22);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pctLoad
            // 
            this.pctLoad.BackColor = System.Drawing.Color.Transparent;
            this.pctLoad.ForeColor = System.Drawing.Color.Black;
            this.pctLoad.Image = ((System.Drawing.Image)(resources.GetObject("pctLoad.Image")));
            this.pctLoad.Location = new System.Drawing.Point(177, 261);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(102, 18);
            this.pctLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLoad.TabIndex = 23;
            this.pctLoad.TabStop = false;
            // 
            // chkCreateRestorePoint
            // 
            this.chkCreateRestorePoint.AutoSize = true;
            this.chkCreateRestorePoint.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkCreateRestorePoint.BackgroundStyle.Class = "";
            this.chkCreateRestorePoint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkCreateRestorePoint.Location = new System.Drawing.Point(206, 45);
            this.chkCreateRestorePoint.Name = "chkCreateRestorePoint";
            this.chkCreateRestorePoint.Size = new System.Drawing.Size(242, 17);
            this.chkCreateRestorePoint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkCreateRestorePoint.TabIndex = 24;
            this.chkCreateRestorePoint.Text = "Create restore point for the current database.";
            // 
            // btnBrowseRestorePoint
            // 
            this.btnBrowseRestorePoint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBrowseRestorePoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseRestorePoint.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnBrowseRestorePoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseRestorePoint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseRestorePoint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrowseRestorePoint.Location = new System.Drawing.Point(12, 68);
            this.btnBrowseRestorePoint.Name = "btnBrowseRestorePoint";
            this.btnBrowseRestorePoint.Size = new System.Drawing.Size(172, 22);
            this.btnBrowseRestorePoint.TabIndex = 25;
            this.btnBrowseRestorePoint.Text = "Select &Restore Point";
            this.btnBrowseRestorePoint.UseVisualStyleBackColor = false;
            this.btnBrowseRestorePoint.Click += new System.EventHandler(this.btnBrowseRestorePoint_Click);
            // 
            // _eventimages
            // 
            this._eventimages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_eventimages.ImageStream")));
            this._eventimages.TransparentColor = System.Drawing.Color.Transparent;
            this._eventimages.Images.SetKeyName(0, "information");
            this._eventimages.Images.SetKeyName(1, "exclamation");
            this._eventimages.Images.SetKeyName(2, "good");
            this._eventimages.Images.SetKeyName(3, "error");
            // 
            // DatabaseRestoreDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(460, 310);
            this.Controls.Add(this.btnBrowseRestorePoint);
            this.Controls.Add(this.chkCreateRestorePoint);
            this.Controls.Add(this.pctLoad);
            this.Controls.Add(this.grdStatus);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnBrowseDrive);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseRestoreDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseRestoreDialog_FormClosing);
            this.Load += new System.EventHandler(this.DatabaseRestoreDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.Button btnBrowseDrive;
        private DevComponents.DotNetBar.LabelX lblPath;
        private System.Windows.Forms.Button btnRestore;
        private C1.Win.C1FlexGrid.C1FlexGrid grdStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pctLoad;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkCreateRestorePoint;
        private System.Windows.Forms.Button btnBrowseRestorePoint;
        private System.Windows.Forms.ImageList _eventimages;
    }
}