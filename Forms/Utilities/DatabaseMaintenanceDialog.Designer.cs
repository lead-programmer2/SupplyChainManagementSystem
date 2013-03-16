namespace SupplyChainManagementSystem
{
    partial class DatabaseMaintenanceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseMaintenanceDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.grdResult = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            this._images = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Location = new System.Drawing.Point(0, 320);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(680, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyze.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAnalyze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalyze.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyze.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnalyze.Location = new System.Drawing.Point(567, 47);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(98, 22);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "&Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCheck.Location = new System.Drawing.Point(567, 70);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(98, 22);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "&Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            // 
            // btnOptimize
            // 
            this.btnOptimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptimize.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOptimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOptimize.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnOptimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptimize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptimize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOptimize.Location = new System.Drawing.Point(567, 93);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(98, 22);
            this.btnOptimize.TabIndex = 3;
            this.btnOptimize.Text = "&Optimize";
            this.btnOptimize.UseVisualStyleBackColor = false;
            // 
            // btnRepair
            // 
            this.btnRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepair.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRepair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepair.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepair.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepair.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRepair.Location = new System.Drawing.Point(567, 116);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(98, 22);
            this.btnRepair.TabIndex = 4;
            this.btnRepair.Text = "&Repair";
            this.btnRepair.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(567, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.ForeColor = System.Drawing.Color.DimGray;
            this.lblDatabase.Location = new System.Drawing.Point(12, 20);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(61, 13);
            this.lblDatabase.TabIndex = 24;
            this.lblDatabase.Text = "Database: ";
            // 
            // grdResult
            // 
            this.grdResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.grdResult.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdResult.Location = new System.Drawing.Point(15, 47);
            this.grdResult.Name = "grdResult";
            this.grdResult.Rows.DefaultSize = 21;
            this.grdResult.Size = new System.Drawing.Size(546, 260);
            this.grdResult.StyleInfo = resources.GetString("grdResult.StyleInfo");
            this.grdResult.TabIndex = 0;
            // 
            // pctLoad
            // 
            this.pctLoad.BackColor = System.Drawing.Color.Transparent;
            this.pctLoad.ForeColor = System.Drawing.Color.Black;
            this.pctLoad.Image = ((System.Drawing.Image)(resources.GetObject("pctLoad.Image")));
            this.pctLoad.Location = new System.Drawing.Point(247, 166);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(102, 18);
            this.pctLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLoad.TabIndex = 25;
            this.pctLoad.TabStop = false;
            // 
            // _images
            // 
            this._images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_images.ImageStream")));
            this._images.TransparentColor = System.Drawing.Color.Transparent;
            this._images.Images.SetKeyName(0, "check");
            this._images.Images.SetKeyName(1, "warning");
            // 
            // DatabaseMaintenanceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(680, 345);
            this.Controls.Add(this.pctLoad);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnOptimize);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseMaintenanceDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseMaintenanceDialog_FormClosing);
            this.Load += new System.EventHandler(this.DatabaseMaintenanceDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDatabase;
        private C1.Win.C1FlexGrid.C1FlexGrid grdResult;
        private System.Windows.Forms.PictureBox pctLoad;
        private System.Windows.Forms.ImageList _images;
    }
}