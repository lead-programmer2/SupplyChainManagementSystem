namespace SupplyChainManagementSystem
{
    partial class ScriptInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptInfoDialog));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReferenceNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSystemVersion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.lblAutoScript = new System.Windows.Forms.Label();
            this.lblExecuted = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkBackup = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkRestartApp = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkRestartPc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveShortcut});
            this.bar1.Location = new System.Drawing.Point(0, 503);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(451, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveShortcut.Click += new System.EventHandler(this.btnSaveShortcut_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAndClose.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAndClose.Location = new System.Drawing.Point(131, 465);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 11;
            this.btnSaveAndClose.Text = "Sa&ve and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(338, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(246, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReferenceNo
            // 
            // 
            // 
            // 
            this.txtReferenceNo.Border.Class = "TextBoxBorder";
            this.txtReferenceNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReferenceNo.Location = new System.Drawing.Point(29, 46);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(112, 22);
            this.txtReferenceNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Reference No.";
            // 
            // txtSystemVersion
            // 
            // 
            // 
            // 
            this.txtSystemVersion.Border.Class = "TextBoxBorder";
            this.txtSystemVersion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSystemVersion.Location = new System.Drawing.Point(162, 46);
            this.txtSystemVersion.Name = "txtSystemVersion";
            this.txtSystemVersion.Size = new System.Drawing.Size(93, 22);
            this.txtSystemVersion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(159, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "System Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(26, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Author";
            // 
            // txtAuthor
            // 
            // 
            // 
            // 
            this.txtAuthor.Border.Class = "TextBoxBorder";
            this.txtAuthor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAuthor.Location = new System.Drawing.Point(29, 109);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(393, 22);
            this.txtAuthor.TabIndex = 2;
            // 
            // txtTitle
            // 
            // 
            // 
            // 
            this.txtTitle.Border.Class = "TextBoxBorder";
            this.txtTitle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTitle.Location = new System.Drawing.Point(29, 159);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(393, 22);
            this.txtTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(26, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(26, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Script";
            // 
            // txtScript
            // 
            this.txtScript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScript.Location = new System.Drawing.Point(29, 212);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(393, 74);
            this.txtScript.TabIndex = 4;
            this.txtScript.Text = "";
            // 
            // lblAutoScript
            // 
            this.lblAutoScript.AutoSize = true;
            this.lblAutoScript.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoScript.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAutoScript.Location = new System.Drawing.Point(358, 24);
            this.lblAutoScript.Name = "lblAutoScript";
            this.lblAutoScript.Size = new System.Drawing.Size(64, 13);
            this.lblAutoScript.TabIndex = 32;
            this.lblAutoScript.Text = "Auto-script";
            // 
            // lblExecuted
            // 
            this.lblExecuted.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblExecuted.Location = new System.Drawing.Point(261, 51);
            this.lblExecuted.Name = "lblExecuted";
            this.lblExecuted.Size = new System.Drawing.Size(161, 13);
            this.lblExecuted.TabIndex = 33;
            this.lblExecuted.Text = "Date Executed : ";
            this.lblExecuted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(29, 323);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(183, 92);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(26, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Description";
            // 
            // chkBackup
            // 
            this.chkBackup.AutoSize = true;
            // 
            // 
            // 
            this.chkBackup.BackgroundStyle.Class = "";
            this.chkBackup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkBackup.Location = new System.Drawing.Point(230, 335);
            this.chkBackup.Name = "chkBackup";
            this.chkBackup.Size = new System.Drawing.Size(183, 17);
            this.chkBackup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkBackup.TabIndex = 6;
            this.chkBackup.Text = "Require backup before execution";
            // 
            // chkRestartApp
            // 
            this.chkRestartApp.AutoSize = true;
            // 
            // 
            // 
            this.chkRestartApp.BackgroundStyle.Class = "";
            this.chkRestartApp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkRestartApp.Location = new System.Drawing.Point(230, 358);
            this.chkRestartApp.Name = "chkRestartApp";
            this.chkRestartApp.Size = new System.Drawing.Size(192, 17);
            this.chkRestartApp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkRestartApp.TabIndex = 7;
            this.chkRestartApp.Text = "Require App restart after execution";
            // 
            // chkRestartPc
            // 
            this.chkRestartPc.AutoSize = true;
            // 
            // 
            // 
            this.chkRestartPc.BackgroundStyle.Class = "";
            this.chkRestartPc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkRestartPc.Location = new System.Drawing.Point(230, 381);
            this.chkRestartPc.Name = "chkRestartPc";
            this.chkRestartPc.Size = new System.Drawing.Size(185, 17);
            this.chkRestartPc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkRestartPc.TabIndex = 8;
            this.chkRestartPc.Text = "Require PC restart after execution";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(29, 465);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 22);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.BackColor = System.Drawing.Color.Goldenrod;
            this.btnExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecute.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecute.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExecute.Location = new System.Drawing.Point(29, 437);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(84, 22);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "E&xecute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // ScriptInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(451, 528);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chkRestartPc);
            this.Controls.Add(this.chkRestartApp);
            this.Controls.Add(this.chkBackup);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblExecuted);
            this.Controls.Add(this.lblAutoScript);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSystemVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptInfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Script";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScriptInfoDialog_FormClosing);
            this.Load += new System.EventHandler(this.ScriptInfoDialog_Load);
            this.Shown += new System.EventHandler(this.ScriptInfoDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnSaveShortcut;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReferenceNo;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSystemVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAuthor;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.Label lblAutoScript;
        private System.Windows.Forms.Label lblExecuted;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkBackup;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkRestartPc;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkRestartApp;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExecute;
    }
}