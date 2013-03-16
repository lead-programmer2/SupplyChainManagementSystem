namespace SupplyChainManagementSystem
{
    partial class DataSourcedDropDown
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._grid = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.ColumnInfo = "10,1,0,0,0,95,Columns:";
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.Rows.DefaultSize = 19;
            this._grid.Size = new System.Drawing.Size(237, 235);
            this._grid.TabIndex = 0;
            this._grid.AfterSort += new C1.Win.C1FlexGrid.SortColEventHandler(this._grid_AfterSort);
            this._grid.MouseClick += new System.Windows.Forms.MouseEventHandler(this._grid_MouseClick);
            this._grid.MouseMove += new System.Windows.Forms.MouseEventHandler(this._grid_MouseMove);
            // 
            // DataSourcedDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._grid);
            this.Name = "DataSourcedDropDown";
            this.Size = new System.Drawing.Size(237, 235);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid _grid;
    }
}
