using C1.Win.C1FlexGrid;
using Development.Materia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// ListView derived from a C1FlexGrid.
    /// </summary>
    [Description("ListView derived from a C1FlexGrid."), DefaultProperty("SelectedListItemChanged")]
    public class ListViewGrid : C1FlexGrid
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ListViewGrid. 
        /// </summary>
        public ListViewGrid()
        {
            InitializeComponent();
            this.InitializeAppearance();
            _listitems = new ListViewGridItemCollection(this);
        }


        #endregion

        #region Events

        /// <summary>
        /// Occurs when a list view item has been mouse-clicked.
        /// </summary>
        public event ListViewGridSelectionEventHandler ListViewItemClick;

        protected virtual void OnListViewItemClick(ListViewGridSelectionEventArgs e)
        {
            if (ListViewItemClick != null) ListViewItemClick(this, e);
        }

        /// <summary>
        /// Occurs when a list view item has been mouse-double-clicked.
        /// </summary>
        public event ListViewGridSelectionEventHandler ListViewItemDoubleClick;

        protected virtual void OnListViewItemDoubleClick(ListViewGridSelectionEventArgs e)
        {
            if (ListViewItemDoubleClick != null) ListViewItemDoubleClick(this, e);
        }

        /// <summary>
        /// Occurs when 'Enter' key has been pressed into a selected list view item.
        /// </summary>
        public event ListViewGridSelectionEventHandler ListViewItemEnterKeyPressed;

        protected virtual void OnListViewItemEnterKeyPressed(ListViewGridSelectionEventArgs e)
        {
            if (ListViewItemEnterKeyPressed != null) ListViewItemEnterKeyPressed(this, e);
        }

        /// <summary>
        /// Occurs when a list view item has been selected either thru mouse or the arrow keys.
        /// </summary>
        public event ListViewGridSelectionEventHandler SelectedListItemChanged;

        protected virtual void OnSelectedListItemChanged(ListViewGridSelectionEventArgs e)
        {
            if (SelectedListItemChanged != null) SelectedListItemChanged(this, e);
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ImageList _imagelist = null;

        /// <summary>
        /// Gets or sets the image list used by the grid's thumbnails.
        /// </summary>
        public ImageList ImageList
        {
            get { return _imagelist; }
            set { _imagelist = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ListViewGridItemCollection _listitems = null;

        /// <summary>
        /// Gets the collection of list view items.
        /// </summary>
        [Browsable(false)]
        public ListViewGridItemCollection ListItems
        {
            get { return _listitems; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ListViewGridItem _selectedlistitem = null;

        /// <summary>
        /// Gets the current selected list view item.
        /// </summary>
        public ListViewGridItem SelectedListItem
        {
            get { return _selectedlistitem; }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Size _defaulttilesize = new Size(100, 80);

        #endregion

        #region Methods

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ListViewGrid
            // 
            this.Rows.DefaultSize = 19;
            this.BeforeSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.ListViewGrid_BeforeSelChange);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListViewGrid_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewGrid_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewGrid_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListViewGrid_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitializeListViewItems()
        {
            this.ClearRowsAndColumns();

            KeyActionTab = KeyActionEnum.MoveAcross;
            KeyActionEnter = KeyActionEnum.None;
            SelectionMode = SelectionModeEnum.Cell;
            Styles.Focus.BackgroundImage = Properties.Resources.GridTile;
            Styles.Focus.BackgroundImageLayout = ImageAlignEnum.Stretch;
            Styles.Highlight.BackgroundImage = Properties.Resources.GridTile;
            Styles.Highlight.BackgroundImageLayout = ImageAlignEnum.Stretch;
            Styles.Normal.Border.Style = BorderStyleEnum.None;
            Styles.Normal.Border.Color = Color.Transparent;
            Styles.Normal.ImageAlign = ImageAlignEnum.CenterTop;
            Styles.Normal.TextAlign = TextAlignEnum.CenterCenter;
            Styles.Editor.Border.Style = BorderStyleEnum.None;
            Styles.Editor.Border.Color = Color.Transparent;

            int _colcounts = (Size.Width / _defaulttilesize.Width);
            int _rowcounts = (Size.Height / _defaulttilesize.Height);
            ColumnCollection _cols = Cols;
            RowCollection _rows = Rows;

            _cols.Fixed = 1; _cols.Count = _colcounts;
            _rows.Fixed = 1; _rows.Count = _rowcounts;

            _cols[_cols.Fixed - 1].Visible = false;
            _rows[_rows.Fixed - 1].Visible = false;

            int _currow = _rows.Fixed; int _curcol = _cols.Fixed;

            for (int i = 0; i <= (ListItems.Count - 1); i++)
            {
                ListViewGridItem _item = ListItems[i];

                if (_imagelist != null)
                {
                    if (_imagelist.Images.ContainsKey(_item.ImageKey))
                    {
                        Image _image = _imagelist.Images[_item.ImageKey].ResizeImage(32, 32);
                        SetCellImage(_currow, _curcol, _image);
                    }
                }

                SetData(_currow, _curcol, _item.Text);
                SetUserData(_currow, _curcol, _item);
                if ((_curcol + 1) < _colcounts) _curcol += 1;
                else
                {
                    _currow += 1; _curcol = _cols.Fixed;
                }
            }

            for (int i = _cols.Fixed; i <= (_cols.Count - 1); i++) _cols[i].Width = _defaulttilesize.Width;
            for (int i = _rows.Fixed; i <= (_rows.Count - 1); i++) _rows[i].Height = _defaulttilesize.Height;
        }

        #endregion

        #region BaseEvents

        private void ListViewGrid_BeforeSelChange(object sender, RangeEventArgs e)
        {
            if (!Redraw) return;
            
            try
            {
                int _row = e.NewRange.BottomRow;
                int _col = e.NewRange.RightCol;

                if (_row >= Rows.Fixed &&
                    _row <= (Rows.Count -1))
                {
                    if (_col >= Cols.Fixed &&
                        _col <= (Cols.Count - 1))
                    {
                        object _userdata = GetUserData(_row, _col);
                        if (Materia.IsNullOrNothing(_userdata)) e.Cancel = true;
                        else
                        {
                            if (!(_userdata is ListViewGridItem)) e.Cancel = true;
                            else
                            {
                                _selectedlistitem = (ListViewGridItem)_userdata;
                                ListViewGridSelectionEventArgs _args = new ListViewGridSelectionEventArgs(_selectedlistitem);
                                OnSelectedListItemChanged(_args);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void ListViewGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == VisualBasic.Chr(13))
            {
                int _row = RowSel; int _col = ColSel;

                try
                {
                    if (_row >= Rows.Fixed &&
                    _row <= (Rows.Count - 1))
                    {
                        if (_col >= Cols.Fixed &&
                            _col <= (Cols.Count - 1))
                        {
                            object _userdata = GetUserData(_row, _col);
                            if (!Materia.IsNullOrNothing(_userdata))
                            {
                                if (_userdata is ListViewGridItem)
                                {
                                    ListViewGridItem _item = (ListViewGridItem)_userdata;
                                    ListViewGridSelectionEventArgs _args = new ListViewGridSelectionEventArgs(_item);
                                    OnListViewItemEnterKeyPressed(_args);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void ListViewGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Redraw) return;
            HitTestInfo _test = HitTest(e.Location);
            int _row = _test.Row; int _col = _test.Column;

            try
            {
                if (_row >= Rows.Fixed &&
                    _row <= (Rows.Count - 1))
                {
                    if (_col >= Cols.Fixed &&
                        _col <= (Cols.Count - 1))
                    {
                        object _userdata = GetUserData(_row, _col);
                        if (!Materia.IsNullOrNothing(_userdata))
                        {
                            if (_userdata is ListViewGridItem)
                            {
                                ListViewGridItem _item = (ListViewGridItem)_userdata;
                                ListViewGridSelectionEventArgs _args = new ListViewGridSelectionEventArgs(_item);
                                OnListViewItemClick(_args);
                            }
                        }
                    }
                }

            }
            catch { }
        }

        private void ListViewGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Redraw) return;
            HitTestInfo _test = HitTest(e.Location);
            int _row = _test.Row; int _col = _test.Column;

            try
            {
                if (_row >= Rows.Fixed &&
                    _row <= (Rows.Count - 1))
                {
                    if (_col >= Cols.Fixed &&
                        _col <= (Cols.Count - 1))
                    {
                        object _userdata = GetUserData(_row, _col);
                        if (!Materia.IsNullOrNothing(_userdata))
                        {
                            if (_userdata is ListViewGridItem)
                            {
                                ListViewGridItem _item = (ListViewGridItem)_userdata;
                                ListViewGridSelectionEventArgs _args = new ListViewGridSelectionEventArgs(_item);
                                OnListViewItemDoubleClick(_args);
                            }
                        }
                    }
                }

            }
            catch { }
        }

        private void ListViewGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Redraw) return;
            HitTestInfo _test = HitTest(e.Location);
            int _row = _test.Row; int _col = _test.Column;

            Cursor = Cursors.Default;

            try
            {
                if (_row >= Rows.Fixed &&
                    _row <= (Rows.Count - 1))
                {
                    if (_col >= Cols.Fixed &&
                        _col <= (Cols.Count - 1))
                    {
                        object _userdata = GetUserData(_row, _col);
                        if (!Materia.IsNullOrNothing(_userdata))
                        {
                            if (_userdata is ListViewGridItem) Cursor = Cursors.Hand;
                        }
                    }
                }

            }
            catch { }
        }

        #endregion

    }

    /// <summary>
    /// ListViewGrid item member information.
    /// </summary>
    public class ListViewGridItem
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ListViewGridItem.
        /// </summary>
        public ListViewGridItem()
        { }

        /// <summary>
        /// Creates a new instance of ListViewGridItem.
        /// </summary>
        /// <param name="itemname"></param>
        public ListViewGridItem(string itemname) : this(itemname, "")
        { }

        /// <summary>
        /// Creates a new instance of ListViewGridItem.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="itemtext"></param>
        public ListViewGridItem(string itemname, string itemtext) : this(itemname, itemtext, "")
        {  }

        /// <summary>
        /// Creates a new instance of ListViewGridItem.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="itemtext"></param>
        /// <param name="imagelistkey"></param>
        public ListViewGridItem(string itemname, string itemtext, string imagelistkey)
        { _name = itemname; _text = itemtext; _imagekey = imagelistkey; }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ListViewGrid _listview = null;

        /// <summary>
        /// Gets the current owner list view for this list view item.
        /// </summary>
        public ListViewGrid ListView
        {
            get { return _listview; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _name = "";

        /// <summary>
        /// Gets or sets the name of the current list item.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _imagekey = "";

        /// <summary>
        /// Gets or sets the image key from the current parent list view's image list.
        /// </summary>
        public string ImageKey
        {
            get { return _imagekey; }
            set 
            {
                _imagekey = value;
                if (_listview != null) _listview.InitializeListViewItems();
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object _tag = null;

        /// <summary>
        /// Gets or sets the information stored in this list view grid item.
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _text = "";

        /// <summary>
        /// Gets or sets the text to be displayed by this item in the list view.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                if (_listview != null) _listview.InitializeListViewItems();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the owner of the current list view item.
        /// </summary>
        /// <param name="listview"></param>
        public void SetOwner(ListViewGrid listview)
        {
            if (_listview == null) _listview = listview;
            else
            {
                if (_listview != listview) throw new InvalidOperationException("Cannot switch listview item's owner.");
            }
        }

        public override string ToString()
        { return _text + " {" + _name + "}"; }

        #endregion

    }

    /// <summary>
    /// Collection of ListViewGrid items.
    /// </summary>
    public class ListViewGridItemCollection : CollectionBase
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ListViewGridItemCollection.
        /// </summary>
        /// <param name="owner"></param>
        public ListViewGridItemCollection(ListViewGrid owner)
        { _listview = owner; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list view item at the specified index of the collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ListViewGridItem this[int index]
        {
            get { return (ListViewGridItem)List[index]; }
        }

        /// <summary>
        /// Gets the item with the specified name from the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ListViewGridItem this[string name]
        {
            get { return GetItemByName(name); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ListViewGrid _listview = null;

        /// <summary>
        /// Gets the owner of the current collection.
        /// </summary>
        public ListViewGrid ListView
        {
            get { return _listview; }
        }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Hashtable _collectiontable = new Hashtable();

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new item into the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(ListViewGridItem item)
        {
            if (_collectiontable.ContainsKey(item.Name)) throw new InvalidOperationException("Item names should not match existing names within the collection.");
            _collectiontable.Add(item.Name, item);
            int _index = List.Add(item);
            if (_listview != null) _listview.InitializeListViewItems();
            return _index;
        }

        /// <summary>
        /// Adds a new item into the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ListViewGridItem Add(string name)
        { return Add(name, ""); }

        /// <summary>
        /// Adds a new item into the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public ListViewGridItem Add(string name, string text)
        { return Add(name, text, ""); }

        /// <summary>
        /// Adds a new item into the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <param name="imagekey"></param>
        /// <returns></returns>
        public ListViewGridItem Add(string name, string text, string imagekey)
        {
            if (_collectiontable.ContainsKey(name)) throw new InvalidOperationException("Item names should not match existing names within the collection.");

            ListViewGridItem _item = new ListViewGridItem(name, text, imagekey);
            _item.SetOwner(_listview); int _index = List.Add(_item);
            _collectiontable.Add(name, _item);
            if (_listview != null) _listview.InitializeListViewItems();

            return (ListViewGridItem)List[_index];
        }

        /// <summary>
        /// Validates whether the specified item already exists within the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ListViewGridItem item)
        { return List.Contains(item); }

        /// <summary>
        /// Validates whether an item with the specified name already exists within the collection or not.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name)
        { return _collectiontable.ContainsKey(name); }

        private ListViewGridItem GetItemByName(string name)
        {
            ListViewGridItem _item = null;

            if (_collectiontable.ContainsKey(name)) _item = (ListViewGridItem)_collectiontable[name];
           
            return _item;
       }

        protected override void OnClear()
        {
            _collectiontable.Clear();
            if (_listview != null) _listview.InitializeListViewItems();
            Materia.RefreshAndManageCurrentProcess();
            base.OnClear();
        }

        protected override void OnRemove(int index, object value)
        {
            ListViewGridItem _item = (ListViewGridItem)List[index];
            if (Contains(_item.Name)) _collectiontable.Remove(_item.Name);
            base.OnRemove(index, value);
        }

        /// <summary>
        /// Removes the specified item from the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(ListViewGridItem item)
        {
            if (Contains(item.Name)) _collectiontable.Remove(item.Name);
            if (Contains(item)) List.Remove(item);
            if (_listview != null) _listview.InitializeListViewItems();
        }

        /// <summary>
        /// Removes an item with the specified name from the collection.
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            ListViewGridItem _item = GetItemByName(name);
            if (_item != null) Remove(_item);
        }

        #endregion

    }

    /// <summary>
    /// ListViewGrid list view item selection event arguments.
    /// </summary>
    public class ListViewGridSelectionEventArgs : EventArgs
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ListViewGridSelectionEventArgs.
        /// </summary>
        public ListViewGridSelectionEventArgs()
        { }

        /// <summary>
        /// Creates a new instance of ListViewGridSelectionEventArgs.
        /// </summary>
        /// <param name="item"></param>
        public ListViewGridSelectionEventArgs(ListViewGridItem item)
        { _listitem = item; }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ListViewGridItem _listitem = null;

        /// <summary>
        /// Gets the involved list view item invoking the current event.
        /// </summary>
        public ListViewGridItem ListItem
        {
            get { return _listitem; }
        }

        #endregion

    }

    /// <summary>
    /// Delegate associated to the ListViewGrid events that calls on ListViewGridSelectionEventArgs.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ListViewGridSelectionEventHandler(object sender, ListViewGridSelectionEventArgs e);

}
