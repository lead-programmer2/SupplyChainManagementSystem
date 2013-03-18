namespace SupplyChainManagementSystem
{
    partial class StockAdjustmentInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockAdjustmentInfoDialog));
            this.brStatus = new DevComponents.DotNetBar.Bar();
            this.btnSaveShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreviewShortcut = new DevComponents.DotNetBar.ButtonItem();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdDetails = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.brToolbar = new DevComponents.DotNetBar.Bar();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.exppnl = new DevComponents.DotNetBar.ExpandablePanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalCost = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSummary = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateClosed = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateCancelled = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateApproved = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDated = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brStatus)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).BeginInit();
            this.exppnl.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDated)).BeginInit();
            this.SuspendLayout();
            // 
            // brStatus
            // 
            this.brStatus.AntiAlias = true;
            this.brStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.brStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSaveShortcut,
            this.btnPreviewShortcut});
            this.brStatus.Location = new System.Drawing.Point(0, 482);
            this.brStatus.Name = "brStatus";
            this.brStatus.RoundCorners = false;
            this.brStatus.Size = new System.Drawing.Size(882, 25);
            this.brStatus.Stretch = true;
            this.brStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brStatus.TabIndex = 0;
            this.brStatus.TabStop = false;
            // 
            // btnSaveShortcut
            // 
            this.btnSaveShortcut.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnSaveShortcut.Name = "btnSaveShortcut";
            this.btnSaveShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSaveShortcut.Click += new System.EventHandler(this.btnSaveShortcut_Click);
            // 
            // btnPreviewShortcut
            // 
            this.btnPreviewShortcut.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnPreviewShortcut.Name = "btnPreviewShortcut";
            this.btnPreviewShortcut.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlP);
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
            this.btnSaveAndClose.Location = new System.Drawing.Point(574, 447);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 22);
            this.btnSaveAndClose.TabIndex = 12;
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
            this.btnCancel.Location = new System.Drawing.Point(781, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 22);
            this.btnCancel.TabIndex = 14;
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
            this.btnSave.Location = new System.Drawing.Point(689, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 22);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPreview.Location = new System.Drawing.Point(16, 447);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(84, 22);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApprove.BackColor = System.Drawing.Color.SeaGreen;
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnApprove.Location = new System.Drawing.Point(105, 447);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(84, 22);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "&Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoid.BackColor = System.Drawing.Color.Brown;
            this.btnVoid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoid.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoid.Location = new System.Drawing.Point(196, 447);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(84, 22);
            this.btnVoid.TabIndex = 10;
            this.btnVoid.Text = "&Void";
            this.btnVoid.UseVisualStyleBackColor = false;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // btnFinalize
            // 
            this.btnFinalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFinalize.BackColor = System.Drawing.Color.Goldenrod;
            this.btnFinalize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalize.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnFinalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFinalize.Location = new System.Drawing.Point(105, 447);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(84, 22);
            this.btnFinalize.TabIndex = 11;
            this.btnFinalize.Text = "&Finalize";
            this.btnFinalize.UseVisualStyleBackColor = false;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grdDetails);
            this.panel1.Controls.Add(this.brToolbar);
            this.panel1.Controls.Add(this.exppnl);
            this.panel1.Location = new System.Drawing.Point(16, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 419);
            this.panel1.TabIndex = 20;
            // 
            // grdDetails
            // 
            this.grdDetails.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.grdDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetails.Location = new System.Drawing.Point(0, 155);
            this.grdDetails.Name = "grdDetails";
            this.grdDetails.Rows.DefaultSize = 21;
            this.grdDetails.Size = new System.Drawing.Size(847, 237);
            this.grdDetails.StyleInfo = resources.GetString("grdDetails.StyleInfo");
            this.grdDetails.TabIndex = 7;
            this.grdDetails.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdDetails_AfterEdit);
            // 
            // brToolbar
            // 
            this.brToolbar.AntiAlias = true;
            this.brToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brToolbar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brToolbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDelete});
            this.brToolbar.Location = new System.Drawing.Point(0, 392);
            this.brToolbar.Name = "brToolbar";
            this.brToolbar.RoundCorners = false;
            this.brToolbar.Size = new System.Drawing.Size(847, 25);
            this.brToolbar.Stretch = true;
            this.brToolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.brToolbar.TabIndex = 1;
            this.brToolbar.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnDelete.Tooltip = "Removes the current selected entry.";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // exppnl
            // 
            this.exppnl.CanvasColor = System.Drawing.SystemColors.Control;
            this.exppnl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exppnl.Controls.Add(this.panel2);
            this.exppnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.exppnl.ExpandOnTitleClick = true;
            this.exppnl.Location = new System.Drawing.Point(0, 0);
            this.exppnl.Name = "exppnl";
            this.exppnl.Size = new System.Drawing.Size(847, 155);
            this.exppnl.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exppnl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnl.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnl.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exppnl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exppnl.Style.GradientAngle = 90;
            this.exppnl.TabIndex = 0;
            this.exppnl.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exppnl.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exppnl.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exppnl.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exppnl.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exppnl.TitleStyle.GradientAngle = 90;
            this.exppnl.TitleText = "   General Information";
            this.exppnl.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.exppnl_ExpandedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtTotalCost);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtSummary);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtDateClosed);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDateCancelled);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDateApproved);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpDated);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtReferenceNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 129);
            this.panel2.TabIndex = 1;
            // 
            // txtTotalCost
            // 
            // 
            // 
            // 
            this.txtTotalCost.Border.Class = "TextBoxBorder";
            this.txtTotalCost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalCost.Location = new System.Drawing.Point(672, 38);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(141, 22);
            this.txtTotalCost.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(669, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Total Adj. Cost (USD)";
            // 
            // txtSummary
            // 
            // 
            // 
            // 
            this.txtSummary.Border.Class = "TextBoxBorder";
            this.txtSummary.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSummary.Location = new System.Drawing.Point(182, 87);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(631, 22);
            this.txtSummary.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(179, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Summary / Description";
            // 
            // txtDateClosed
            // 
            // 
            // 
            // 
            this.txtDateClosed.Border.Class = "TextBoxBorder";
            this.txtDateClosed.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateClosed.Location = new System.Drawing.Point(511, 38);
            this.txtDateClosed.Name = "txtDateClosed";
            this.txtDateClosed.Size = new System.Drawing.Size(141, 22);
            this.txtDateClosed.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(508, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Date Closed";
            // 
            // txtDateCancelled
            // 
            // 
            // 
            // 
            this.txtDateCancelled.Border.Class = "TextBoxBorder";
            this.txtDateCancelled.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateCancelled.Location = new System.Drawing.Point(349, 38);
            this.txtDateCancelled.Name = "txtDateCancelled";
            this.txtDateCancelled.Size = new System.Drawing.Size(141, 22);
            this.txtDateCancelled.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(346, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Date Cancelled";
            // 
            // txtDateApproved
            // 
            // 
            // 
            // 
            this.txtDateApproved.Border.Class = "TextBoxBorder";
            this.txtDateApproved.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateApproved.Location = new System.Drawing.Point(182, 38);
            this.txtDateApproved.Name = "txtDateApproved";
            this.txtDateApproved.Size = new System.Drawing.Size(141, 22);
            this.txtDateApproved.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(179, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Date Approved";
            // 
            // dtpDated
            // 
            // 
            // 
            // 
            this.dtpDated.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpDated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDated.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpDated.ButtonDropDown.Visible = true;
            this.dtpDated.IsPopupCalendarOpen = false;
            this.dtpDated.Location = new System.Drawing.Point(27, 87);
            // 
            // 
            // 
            this.dtpDated.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDated.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtpDated.MonthCalendar.BackgroundStyle.Class = "";
            this.dtpDated.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDated.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtpDated.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDated.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.dtpDated.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpDated.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpDated.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpDated.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDated.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpDated.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtpDated.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDated.MonthCalendar.TodayButtonVisible = true;
            this.dtpDated.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpDated.Name = "dtpDated";
            this.dtpDated.Size = new System.Drawing.Size(130, 22);
            this.dtpDated.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpDated.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Date :";
            // 
            // txtReferenceNo
            // 
            // 
            // 
            // 
            this.txtReferenceNo.Border.Class = "TextBoxBorder";
            this.txtReferenceNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReferenceNo.Location = new System.Drawing.Point(27, 38);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(130, 22);
            this.txtReferenceNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Reference No.";
            // 
            // StockAdjustmentInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(882, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.brStatus);
            this.Controls.Add(this.btnFinalize);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockAdjustmentInfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Adjustment";
            this.Load += new System.EventHandler(this.StockAdjustmentInfoDialog_Load);
            this.Shown += new System.EventHandler(this.StockAdjustmentInfoDialog_Shown);
            this.Disposed += new System.EventHandler(this.StockAdjustmentInfoDialog_Disposed);
            ((System.ComponentModel.ISupportInitialize)(this.brStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brToolbar)).EndInit();
            this.exppnl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDated)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar brStatus;
        private DevComponents.DotNetBar.ButtonItem btnSaveShortcut;
        private DevComponents.DotNetBar.ButtonItem btnPreviewShortcut;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ExpandablePanel exppnl;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1FlexGrid.C1FlexGrid grdDetails;
        private DevComponents.DotNetBar.Bar brToolbar;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSummary;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDateClosed;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDateCancelled;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDateApproved;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpDated;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReferenceNo;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTotalCost;
        private System.Windows.Forms.Label label7;
    }
}