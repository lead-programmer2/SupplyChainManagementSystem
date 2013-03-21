using Development.Materia;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class MainWindow : Office2007RibbonForm
    {

        /// <summary>
        /// Creates a new instance of MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            AttachPickListMenuHandlers();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isclosing = false;

        /// <summary>
        /// Gets whether the current form is closing or not.
        /// </summary>
        public bool IsClosing
        {
            get { return _isclosing; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Module _selectedmodule = Module.None;

        /// <summary>
        /// Gets the current selected application module.
        /// </summary>
        public Module SelectedModule
        {
            get { return _selectedmodule; }
        }

        private ModuleGroup _selectedmodulegroup = ModuleGroup.None;

        /// <summary>
        /// Gets the current selected application module group.
        /// </summary>
        public ModuleGroup SelectedModuleGroup
        {
            get { return _selectedmodulegroup; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Timer _clocktimer = new Timer();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _refreshcounter = 0;

        private void AttachPickListMenuHandlers()
        {
            mnuAdditionalCharges.Click += new EventHandler(mnuPickList_Click);
            mnuBankingCompanies.Click += new EventHandler(mnuPickList_Click);
            mnuBankMisc.Click += new EventHandler(mnuPickList_Click);
            mnuCurrencies.Click += new EventHandler(mnuPickList_Click);
            mnuCurrencyDenominations.Click += new EventHandler(mnuPickList_Click);
            mnuCustomerGroups.Click += new EventHandler(mnuPickList_Click);
            mnuDepartments.Click += new EventHandler(mnuPickList_Click);
            mnuBrands.Click += new EventHandler(mnuPickList_Click);
            mnuLocations.Click += new EventHandler(mnuPickList_Click);
            mnuMeasurements.Click += new EventHandler(mnuPickList_Click);
            mnuModels.Click += new EventHandler(mnuPickList_Click);
            mnuPartNames.Click += new EventHandler(mnuPickList_Click);
            mnuPartsCategory.Click += new EventHandler(mnuPickList_Click);
            mnuPaymentTerms.Click += new EventHandler(mnuPickList_Click);
            mnuPositions.Click += new EventHandler(mnuPickList_Click);
            mnuSignatories.Click += new EventHandler(mnuPickList_Click);
        }

        private void InitializeBackground()
        {
            foreach (Control _client in Controls)
            {
                if (_client.GetType() == typeof(MdiClient)) _client.BackColor = Color.WhiteSmoke;
            }

            ((Office2007Renderer)GlobalManager.Renderer).ColorTable.Form.MdiClientBackgroundImage = Properties.Resources.SCMSFaded;
            BackgroundImage = Properties.Resources.SCMSFaded; BackgroundImageLayout = ImageLayout.Center;
        }

        private void InitializeHeading()
        {
            pctCompanyLogo.Image = GlobalSettings.CompanyLogo;
            lblCompanyName.Text = GlobalSettings.Company.Name;
            lblCompanyAddress.Text = GlobalSettings.Address.Replace("\n", " ").RLTrim() + " " + GlobalSettings.Country;
        }

        private void InitializeModules(ModuleGroup modules)
        {
            string _path = Application.StartupPath + "\\Xml\\modules.xml";
            DataTable _table = SCMS.XmlToTable(_path);

            if (_table != null)
            {
                DataRow[] _rows  = _table.Select("[Group] = " + VisualBasic.CInt(modules).ToString(), "[Order]");
                if (_rows != null)
                {
                    if (_rows.Length > 0)
                    {
                        brModules.Items.Clear();

                        for (int i = 0; i <= (_rows.Length - 1); i++)
                        {
                            DataRow _row = _rows[i];
                            Image _image = (Image) Properties.Resources.Brick.Clone();
                            bool _begingroup = VisualBasic.CBool(brModules.Items.Count > 0);

                            ButtonItem _button = new ButtonItem("btnModule" + _row["Id"].ToString(), _row["Text"].ToString());
                            _button.ButtonStyle = eButtonStyle.ImageAndText;
                            if (_moduleimages.Images.ContainsKey(_row["ImageKey"].ToString())) _image = _moduleimages.Images[_row["ImageKey"].ToString()];
                            _button.Image = _image; _button.ImageFixedSize = new Size(32, 32);
                            _button.ImagePosition = eImagePosition.Top;
                            _button.Tag = _row["Id"]; _button.FixedSize = new Size(120, 75);
                            _button.BeginGroup = _begingroup; _button.Cursor = Cursors.Hand;
                            _button.Click += new EventHandler(_button_Click);
                            brModules.Items.Add(_button);
                        }

                        _selectedmodulegroup = modules;
                    }
                }
                
                _table.Dispose(); _table = null;
                Materia.RefreshAndManageCurrentProcess();
            }

            ButtonItem _modulebutton = null;
            Image _modulebuttonimage = (Image) Properties.Resources.Brick.Clone();

            switch (modules)
            {
                case ModuleGroup.Operations:
                    _modulebutton = new ButtonItem("btnFinance", "Finance");
                    if (_moduleimages.Images.ContainsKey("Finance")) _modulebuttonimage = _moduleimages.Images["Finance"];
                    _modulebutton.Image = _modulebuttonimage;
                    _modulebutton.Tag = ModuleGroup.Finance;
                    break;
                case ModuleGroup.Finance:
                     _modulebutton = new ButtonItem("btnOperations", "Operations");
                     if (_moduleimages.Images.ContainsKey("Operations")) _modulebuttonimage = _moduleimages.Images["Operations"];
                    _modulebutton.Image = _modulebuttonimage;
                    _modulebutton.Tag = ModuleGroup.Operations;
                    break;

                default: break;
            }

            if (_modulebutton != null)
            {
                _modulebutton.ButtonStyle = eButtonStyle.ImageAndText;
                _modulebutton.ImageFixedSize = new Size(32, 32);
                _modulebutton.FixedSize = new Size(120, 75);
                _modulebutton.ImagePosition = eImagePosition.Top;
                bool _begingroup = VisualBasic.CBool(brModules.Items.Count > 0);
                _modulebutton.BeginGroup = _begingroup;
                _modulebutton.Click += new EventHandler(_button_Click);
                _modulebutton.Cursor = Cursors.Hand;
                brModules.Items.Add(_modulebutton);
            }

            brModules.RecalcSize();
            brModules.Refresh(); brModules.Update();

            Materia.RefreshAndManageCurrentProcess();
        }

        private void InitializeStatusBarDisplays()
        {
            btnStatus.Text = " Ready";
            btnCompany.Text = " " + SCMS.CurrentCompany.Company;
            btnConnection.Text = " Connected to : " + SCMS.ServerConnection.Server + "\\" + SCMS.ServerConnection.Database;
            btnCursor.Text = ""; btnUser.Text = " " + SCMS.CurrentSystemUser.FullName + " (" + SCMS.CurrentSystemUser.Username + ")";
        }

        private void InitializeTimeAndKeyboardInfo()
        {
            btnDate.Text = " " + VisualBasic.Format(DateTime.Now, "dd-MMM-yyyy");
            btnTime.Text = " " + VisualBasic.Format(DateTime.Now, "hh:mm:ss tt");
            btnCaps.Enabled = Control.IsKeyLocked(Keys.CapsLock);
            btnNum.Enabled = Control.IsKeyLocked(Keys.NumLock);
            btnScrl.Enabled = Control.IsKeyLocked(Keys.Scroll);
        }

        /// <summary>
        /// Renders the main window to select the specified module.
        /// </summary>
        /// <param name="module"></param>
        public void SelectModule(Module module)
        {
            if (module == Module.None) return;

            switch (module)
            {
                case Module.Bank:
                case Module.CashPosition:
                case Module.Customers:
                case Module.GeneralLedger:
                case Module.JournalEntries:
                case Module.Suppliers:
                   if (_selectedmodulegroup != ModuleGroup.Finance) InitializeModules(ModuleGroup.Finance); 
                   break;
                default:
                   if (_selectedmodulegroup != ModuleGroup.Operations) InitializeModules(ModuleGroup.Operations); 
                   break;
            }

            foreach (BaseItem _button in brModules.Items)
            {
                if (_button is ButtonItem)
                {
                    if (VisualBasic.IsNumeric(_button.Tag))
                    {
                        if (!(_button.Tag is ModuleGroup))
                        {
                            if (((Module)_button.Tag) == module)
                            {
                                _button_Click(_button, new EventArgs()); break;
                            }
                        }
                    }
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; this.ManageOnDispose();
            InitializeBackground(); InitializeStatusBarDisplays();
            InitializeHeading(); InitializeModules(ModuleGroup.Operations);
            InitializeTimeAndKeyboardInfo();
            if (_isclosing) _isclosing = false;

            _clocktimer.Tick += new EventHandler(_clocktimer_Tick);
            _clocktimer.Interval = 1000; _clocktimer.Enabled = true;
        }

        private void _button_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender.GetType() == typeof(ButtonItem))
                {
                    ButtonItem _button = (ButtonItem)sender;
                    if (!_button.Enabled) return;
       
                    foreach (BaseItem _control in brModules.Items)
                    {
                        if (_control.GetType() == typeof(ButtonItem)) ((ButtonItem)_control).Checked = false;
                    }

                    _button.Checked = true;

                    if (_button.Tag != null)
                    {
                        if (_button.Tag.GetType() == typeof(ModuleGroup))
                        {
                            ModuleGroup _tag = (ModuleGroup)_button.Tag;
                            switch (_tag)
                            {
                                case ModuleGroup.Finance: 
                                    InitializeModules(ModuleGroup.Finance); break;
                                case ModuleGroup.Operations:
                                    InitializeModules(ModuleGroup.Operations); break;
                                default: break;
                            }

                            _selectedmodulegroup = _tag;
                        }
                        else
                        {
                            if (VisualBasic.IsNumeric(_button.Tag))
                            {
                                ModuleWindow _modulewindow = null;
                                _selectedmodule = (Module)_button.Tag;

                                foreach (Form _form in MdiChildren)
                                {
                                    if (_form is ModuleWindow)
                                    {
                                        ModuleWindow _current = (ModuleWindow)_form;
                                        if (_current.SelectedModule == (Module)_button.Tag)
                                        {
                                            _modulewindow = _current; break;
                                        }
                                    }
                                }

                                if (_modulewindow == null) _modulewindow = new ModuleWindow((Module)_button.Tag);

                                _modulewindow.MdiParent = this; _modulewindow.WindowState = FormWindowState.Maximized;
                                _modulewindow.MinimizeBox = false; _modulewindow.MaximizeBox = false; 
                                _modulewindow.ControlBox = false; _modulewindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                                _modulewindow.Dock = DockStyle.Fill; _modulewindow.TopMost = true;
                                _modulewindow.Show();  _modulewindow.Activate();
                                _modulewindow.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                                _modulewindow.WindowState = FormWindowState.Normal;
                                _modulewindow.WindowState = FormWindowState.Maximized;
                            }
                        }
                    }
                }
            }
        }

        private void _clocktimer_Tick(object sender, EventArgs e)
        {
            InitializeTimeAndKeyboardInfo(); _refreshcounter += 1;
            if (_refreshcounter >= 10)
            {
                Materia.RefreshAndManageCurrentProcess(); _refreshcounter = 0;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SCMS.CurrentSystemUser != null)
            {
                if (SCMS.CurrentSystemUser.IsSignedIn) 
                {
                    e.Cancel = VisualBasic.CBool(MsgBoxEx.Ask("Quit from the application?", "Exit") != System.Windows.Forms.DialogResult.Yes);
                    if (!e.Cancel)
                    {
                        SCMS.CleanUp(); SCMS.CurrentSystemUser.LogOut();
                        SCMS.CurrentSystemUser = null; SCMS.Connection = null;
                        Application.Exit();
                    }
                    else _isclosing = false;
                }
                else Program.StartUpForm.Show();
            }
            else
            {
                if (!e.Cancel)
                {  SCMS.CleanUp();   SCMS.Connection = null; Application.Exit(); } 
            }            
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {  Update(); Refresh(); }

        private void mnuExit_Click(object sender, EventArgs e)
        { Close(); }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            SCMS.CleanUp(); SCMS.CurrentSystemUser.LogOut(); Close();
            SCMS.CurrentSystemUser = null; Materia.RefreshAndManageCurrentProcess(); 
        }

        private void mnuBackUp_Click(object sender, EventArgs e)
        {
            if (!mnuBackUp.Enabled) return;
            DatabaseBackupDialog _dialog = new DatabaseBackupDialog();
            _dialog.ShowDialog();
            try { _dialog.Dispose(); }
            catch { }
            finally { _dialog = null; }
            Materia.RefreshAndManageCurrentProcess();
        }

        private void mnuRestoreDatabase_Click(object sender, EventArgs e)
        {
            if (!mnuRestoreDatabase.Enabled) return;
            DatabaseRestoreDialog _dialog = new DatabaseRestoreDialog();
            System.Windows.Forms.DialogResult _result = _dialog.ShowDialog();
            try { _dialog.Dispose(); }
            catch { }
            finally { _dialog = null; }
            Materia.RefreshAndManageCurrentProcess();

            if (_result == System.Windows.Forms.DialogResult.OK) mnuLogout_Click(mnuLogout, new EventArgs());
        }

        private void mnuGlobalSettings_Click(object sender, EventArgs e)
        {
            if (!mnuGlobalSettings.Enabled) return;

            Cursor = Cursors.WaitCursor;

            IAsyncResult _sync1 = Cache.SyncTableAsync(SCMS.Connection, "settings");
            _sync1.WaitToFinish();

            IAsyncResult _sync2 = Cache.SyncTableAsync(SCMS.Connection, "accounts");
            _sync2.WaitToFinish();

            IAsyncResult _sync3 = Cache.SyncTableAsync(SCMS.Connection, "companies");
            _sync3.WaitToFinish();

            Cursor = Cursors.Default; Materia.RefreshAndManageCurrentProcess();

            GlobalSettingDialog _dialog = new GlobalSettingDialog();
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IAsyncResult _settingsync = GlobalSettings.RefreshAsync(SCMS.CurrentCompany.Company);
                _settingsync.WaitToFinish(); InitializeHeading();
            }
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void mnuUserManagement_Click(object sender, EventArgs e)
        {
            if (!mnuUserManagement.Enabled) return;

            Cursor = Cursors.WaitCursor;

            IAsyncResult _sync1 = Cache.SyncTableAsync(SCMS.Connection, "departments");
            _sync1.WaitToFinish();

            IAsyncResult _sync2 = Cache.SyncTableAsync(SCMS.Connection, "positions");
            _sync2.WaitToFinish();

            IAsyncResult _sync3 = Cache.SyncTableAsync(SCMS.Connection, "companies");
            _sync3.WaitToFinish();

            Cursor = Cursors.Default; Materia.RefreshAndManageCurrentProcess();

            UserManagementDialog _dialog = new UserManagementDialog();
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
            _dialog.Dispose(); _dialog = null; Materia.RefreshAndManageCurrentProcess();
        }

        private void mnuPickList_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            if (sender.GetType() != typeof(ButtonItem)) return;
            ButtonItem mnuButton = (ButtonItem)sender;
            if (!mnuButton.Enabled) return;

            PickList _list = PickList.None;

            if (mnuButton.Name == mnuDepartments.Name) _list = PickList.Departments;
            else if (mnuButton.Name == mnuPositions.Name) _list = PickList.Positions;
            else if (mnuButton.Name == mnuAdditionalCharges.Name) _list = PickList.AdditionalCharges;
            else if (mnuButton.Name == mnuBankingCompanies.Name) _list = PickList.Bank;
            else if (mnuButton.Name == mnuBankMisc.Name) _list = PickList.BankMiscellaneous;
            else if (mnuButton.Name == mnuBrands.Name) _list = PickList.Brands;
            else if (mnuButton.Name == mnuCurrencies.Name) _list = PickList.Currencies;
            else if (mnuButton.Name == mnuCurrencyDenominations.Name) _list = PickList.CurrencyDenominations;
            else if (mnuButton.Name == mnuCustomerGroups.Name) _list = PickList.CustomerGroups;
            else if (mnuButton.Name == mnuPaymentTerms.Name) _list = PickList.PaymentTerms;
            else if (mnuButton.Name == mnuSignatories.Name) _list = PickList.Signatories;
            else if (mnuButton.Name == mnuLocations.Name) _list = PickList.Locations;
            else if (mnuButton.Name == mnuMeasurements.Name) _list = PickList.Measurements;
            else if (mnuButton.Name == mnuModels.Name) _list = PickList.Models;
            else if (mnuButton.Name == mnuPartNames.Name) _list = PickList.PartNames;
            else if (mnuButton.Name == mnuPartsCategory.Name) _list = PickList.PartCategories;
            else { }

            if (_list != PickList.None)
            {
                PickListDialog _dialog = new PickListDialog(_list);
                _dialog.ShowDialog(); _dialog.Dispose(); _dialog = null;
                Materia.RefreshAndManageCurrentProcess();
            }
        }

        private void mnuBackup2_Click(object sender, EventArgs e)
        { mnuBackUp_Click(mnuBackUp, new EventArgs()); }

        private void mnuRestoreDatabase2_Click(object sender, EventArgs e)
        { mnuRestoreDatabase_Click(mnuRestoreDatabase, new EventArgs()); }

        private void mnuMaintainDatabase_Click(object sender, EventArgs e)
        {
            if (!mnuMaintainDatabase.Enabled) return;

            DatabaseMaintenanceDialog _dialog = new DatabaseMaintenanceDialog();
            _dialog.ShowDialog(); _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void mnuLogActivityViewer_Click(object sender, EventArgs e)
        {
            if (!mnuLogActivityViewer.Enabled) return;

            Cursor = Cursors.WaitCursor;
            
            IAsyncResult _sync1 = Cache.SyncTableAsync(SCMS.Connection, "users");
            _sync1.WaitToFinish();

            IAsyncResult _sync2 = Cache.SyncTableAsync(SCMS.Connection, "userlogs");
            _sync2.WaitToFinish();

            Cursor = Cursors.Default;

            LogActivityViewerDialog _dialog = new LogActivityViewerDialog();
            _dialog.ShowDialog(); _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void mnuScriptList_Click(object sender, EventArgs e)
        {
            if (!mnuScriptList.Enabled) return;
            ScriptListDialog _dialog = new ScriptListDialog();
            _dialog.ShowDialog(); _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }

        private void mnuExecuteScripts_Click(object sender, EventArgs e)
        {
            if (!mnuExecuteScripts.Enabled) return;

            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.CheckFileExists = true;
            _dialog.CheckPathExists = true;
            _dialog.DefaultExt = SCMS.ScriptFileExtension;
            _dialog.Filter = "SCMS Database Script Files (*." + SCMS.ScriptFileExtension + ")|*." + SCMS.ScriptFileExtension;
            _dialog.Title = "Browse Database Script File";

            string _filename = "";

            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) _filename = (_dialog.FileName);
            _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();

            if (!string.IsNullOrEmpty(_filename.RLTrim()))
            {
                if (File.Exists(_filename))
                {
                    string _tempdir = Application.StartupPath + "\\Temp";

                    if (!Directory.Exists(_tempdir))
                    {
                        try { Directory.CreateDirectory(_tempdir); }
                        catch { }
                    }

                    if (Directory.Exists(_tempdir))
                    {
                        FileInfo _file = new FileInfo(_filename);
                        string _decrypted = _file.Decrypt(SCMS.EncryptionKey);
                        string _tempfile = _tempdir + "\\" + Path.GetFileNameWithoutExtension(_filename) + ".xml";

                        FileInfo _xmlfile = Materia.WriteToFile(_tempfile, _decrypted, false);
                        if (_xmlfile != null)
                        {
                            DataTable _table = SCMS.XmlToTable(_xmlfile.FullName);
                            if (_table != null)
                            {
                                if (_table.TableName == "scripts")
                                {
                                    if (_table.Rows.Count > 0)
                                    {
                                        DatabaseScriptInfo _script = new DatabaseScriptInfo(_table);
                                        DatabaseScriptExecutionResult _result = _script.Execute();
                                    }
                                    else MsgBoxEx.Shout("The specified file does not contain anyt releveant database script information.", "Execute Database Script");
                                }
                                else MsgBoxEx.Shout("The specified file does not contain anyt releveant database script information.", "Execute Database Script");
                            }
                            else MsgBoxEx.Alert("Failed to extract script information from the specified file.", "Execute Database Script");
                        }
                        else MsgBoxEx.Alert("Failed to extract script information from the specified file.", "Execute Database Script");
                    }
                    else MsgBoxEx.Alert("Failed to extract script information from the specified file.", "Execute Database Script");
                }
            }
        }

        private void mnuStockAdjustments_Click(object sender, EventArgs e)
        {
            if (!mnuStockAdjustments.Enabled) return;
            StockAdjustmentListDialog _dialog = new StockAdjustmentListDialog();
            _dialog.ShowDialog(); _dialog.Dispose(); _dialog = null;
            Materia.RefreshAndManageCurrentProcess();
        }


    }
}
