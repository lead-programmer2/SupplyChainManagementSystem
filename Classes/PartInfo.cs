using Development.Materia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SupplyChainManagementSystem
{

    /// <summary>
    /// Part status enumerations.
    /// </summary>
    public enum PartStatus
    {
        Active = 1,
        Inactive = 0
    }

    /// <summary>
    /// Parts stocking type enumerations.
    /// </summary>
    public enum PartStockingType
    {
        ForPhaseOut = 3,
        NonStocking = 2,
        Stocking = 1
    }

    /// <summary>
    /// Parts information class.
    /// </summary>
    public class PartInfo
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of PartInfo.
        /// </summary>
        public PartInfo(string code)
        { PartCode = code; }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _brand = "";

        /// <summary>
        /// Gets the brand of the current part.
        /// </summary>
        public string Brand
        {
            get { return _brand; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _category = "";

        /// <summary>
        /// Gets the category of the current part.
        /// </summary>
        public string Category
        {
            get { return _category; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _description = "";

        /// <summary>
        /// Gets the description of the current part.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _model;

        /// <summary>
        /// Gets the model of the current part.
        /// </summary>
        public string Model
        {
            get { return _model; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _partcode = "";

        /// <summary>
        /// Gets or sets the given code for the current part.
        /// </summary>
        public String PartCode
        {
            get { return _partcode; }
            set
            { _partcode = value; GetInfo(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _partname = "";

        /// <summary>
        /// Gets the name of the current part.
        /// </summary>
        public string PartName
        {
            get { return _partname; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _partno = "";

        /// <summary>
        /// Gets the part number of the current part.
        /// </summary>
        public string PartNo
        {
            get { return _partno; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PartStatus _status = PartStatus.Inactive;

        /// <summary>
        /// Gets the 
        /// </summary>
        public PartStatus Status
        {
            get { return _status; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PartStockingType _type = PartStockingType.NonStocking;

        /// <summary>
        /// Gets the stocking type of the current part.
        /// </summary>
        public PartStockingType Type
        {
            get { return _type; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _unit = "";

        /// <summary>
        /// Gets the unit of measurement of the current part.
        /// </summary>
        public string Unit
        {
            get { return _unit; }
        }

        #endregion

        #region Methods

        private void ClearInfo()
        {
            _brand = ""; _category = ""; _description = "";
            _model = ""; _partname = ""; _partno = "";
            _status = PartStatus.Inactive; _type = PartStockingType.NonStocking;
            _unit = "";
        }

        private void GetInfo(string code)
        {
            ClearInfo();
            DataTable _parts = Cache.GetCachedTable("parts");
            DataTable _partnames = Cache.GetCachedTable("partnames");
            DataTable _models = Cache.GetCachedTable("models");

            if (_parts != null &&
                _partnames != null)
            {
                var _query = from _part in _parts.AsEnumerable()
                             join _names in _partnames.AsEnumerable() on _part.Field<string>("PartName") equals _names.Field<string>("PartName")
                             join _mdl in _models.AsEnumerable() on _part.Field<string>("ModelCode") equals _mdl.Field<string>("ModelCode") into _m
                             where _part.Field<string>("PartCode") == _partcode
                             from _mdl in _m.DefaultIfEmpty(_models.NewRow())
                             select new
                             {
                                 PartNo = _part.Field<string>("PartNo"),
                                 PartName = _part.Field<string>("PartName"),
                                 Description = _part.Field<string>("Description"),
                                 Brand = _part.Field<string>("Brand"),
                                 Model = _mdl.Field<string>("Model"),
                                 Category = _names.Field<string>("PartCategory"),
                                 Unit = _part.Field<string>("Unit"),
                                 Status = _part.Field<Int16>("Active"),
                                 Type = _part.Field<int>("StockType")
                             };

                try
                {
                    foreach (var _row in _query)
                    {
                        if (!Materia.IsNullOrNothing(_row.PartNo)) _partno = _row.PartNo;
                        if (!Materia.IsNullOrNothing(_row.PartName)) _partname = _row.PartName;
                        if (!Materia.IsNullOrNothing(_row.Description)) _description = _row.Description;
                        if (!Materia.IsNullOrNothing(_row.Category)) _category = _row.Category;
                        if (!Materia.IsNullOrNothing(_row.Brand)) _brand = _row.Brand;
                        if (!Materia.IsNullOrNothing(_row.Model)) _model = _row.Model;
                        if (!Materia.IsNullOrNothing(_row.Unit)) _unit = _row.Unit;
                        if (VisualBasic.IsNumeric(_row.Status)) _status = (PartStatus) _row.Status;
                        if (VisualBasic.IsNumeric(_row.Type)) _type = (PartStockingType)_row.Type;
                    }
                }
                catch { }
            }
        }

        public override string ToString()
        {
            return _partcode;
        }

        #endregion

    }
}
