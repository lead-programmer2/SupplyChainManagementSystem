using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Validator;
using Development.Materia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    /// <summary>
    /// Validator control derived from DevComponents.DotNetBar.Validator.SuperValidator.
    /// </summary>
    [ToolboxItem(false)]
    public class Validator : SuperValidator
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of Validator.
        /// </summary>
        /// <param name="control"></param>
        public Validator(ContainerControl control)
        {
           ErrorProvider _errorprovider = new ErrorProvider(control);
           Highlighter _highlighter = new Highlighter();

            _errorprovider.BlinkRate = 250;
            _errorprovider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _errorprovider.Icon = Properties.Resources.ValidatorIcon;

            _highlighter.ContainerControl = control;
            _highlighter.FocusHighlightColor = eHighlightColor.Blue;

            this.ErrorProvider = _errorprovider;
            this.Highlighter = _highlighter;

            if (control != null) control.Disposed += new EventHandler(Control_Disposed);
            this.Disposed += new EventHandler(Validator_Disposed);

            SetHighlightSupport(control);
        }

        #endregion

        #region Methods

        private void Control_Disposed(object sender, EventArgs e)
        {
            try { this.Dispose(); }
            catch { }

            Materia.RefreshAndManageCurrentProcess();
        }

        private void SetHighlightSupport(Control control)
        {
            if (control != null)
            {
                if (control.Controls.Count > 0)
                {
                    foreach (Control ctrl in control.Controls) SetHighlightSupport(ctrl);
                }
                else
                {
                    if (control.GetType().Name == typeof(TextBox).Name ||
                        control.GetType().Name == typeof(ComboBox).Name ||
                        control.GetType().Name == typeof(RichTextBox).Name ||
                        control.GetType().Name == typeof(CheckBox).Name ||
                        control.GetType().Name == typeof(TextBoxX).Name ||
                        control.GetType().Name == typeof(ComboBoxEx).Name ||
                        control.GetType().Name == typeof(CheckBoxX).Name ||
                        control.GetType().BaseType.Name == typeof(TextBox).Name ||
                        control.GetType().BaseType.Name == typeof(ComboBox).Name ||
                        control.GetType().BaseType.Name == typeof(RichTextBox).Name ||
                        control.GetType().BaseType.Name == typeof(CheckBox).Name ||
                        control.GetType().BaseType.Name == typeof(TextBoxX).Name ||
                        control.GetType().BaseType.Name == typeof(ComboBoxEx).Name ||
                        control.GetType().BaseType.Name == typeof(CheckBoxX).Name) this.Highlighter.SetHighlightOnFocus(control, true);
                }
            }
        }

        private void Validator_Disposed(object sender, EventArgs e)
        {
            if (this.ErrorProvider != null)
            {
                try { this.ErrorProvider.Dispose(); }
                catch { }

                Materia.RefreshAndManageCurrentProcess();
            }

            if (this.Highlighter != null)
            {
                try { this.Highlighter.Dispose(); }
                catch { }

                Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

    }

    /// <summary>
    /// Collection of Validator controls.
    /// </summary>
    public class ValidatorCollection : CollectionBase, IDisposable
    {

        #region Constructors

        /// <summary>
        /// Creates a new instance of ValidatorCollection.
        /// </summary>
        public ValidatorCollection()
        { }

        #endregion

        #region Variables

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Hashtable _validatortable = new Hashtable();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Validator control at the specified index of the collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Validator this[int index]
        {
            get { return (Validator) List[index]; }
        }

        /// <summary>
        /// Gets the validator with the specified owner control within the collection.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public Validator this[ContainerControl control]
        {
            get { return GetValidator(control); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new Validator control into the collection.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public Validator Add(ContainerControl control)
        {
            Validator _validator = GetValidator(control);

            if (_validator == null)
            {
               Validator _newvalidator = new Validator(control);
               int _index = Add(_newvalidator);
               _validator = (Validator)List[_index]; 
            }

            return _validator;
        }

        /// <summary>
        /// Adds a new Validator control into the collection.
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public int Add(Validator validator)
        {
            _validatortable.Add(validator.ErrorProvider.ContainerControl, validator);
            return List.Add(validator); 
        }

        /// <summary>
        /// Validates whether the specified validator already exists within the collection.
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public bool Contains(Validator validator)
        { return List.Contains(validator); }

        /// <summary>
        /// Validates whether a Validator control with the specified owner exists within the collection or not.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Contains(ContainerControl control)
        {
            if (_validatortable != null) return _validatortable.ContainsKey(control);
            else return false;
        }

        private Validator GetValidator(ContainerControl control)
        {
            Validator _validator = null;

            if (_validatortable != null &&
                control != null)
            {
                if (_validatortable.ContainsKey(control)) _validator = (Validator)_validatortable[control];
            }

            return _validator;
        }

        protected override void OnClear()
        {
            _validatortable.Clear(); base.OnClear();
        }

        /// <summary>
        /// Removes the specified Validator control from the collection.
        /// </summary>
        /// <param name="validator"></param>
        public void Remove(Validator validator)
        {
            if (Contains(validator))
            {
                if (_validatortable.ContainsKey(validator.ContainerControl)) _validatortable.Remove(validator.ContainerControl);
                List.Remove(validator);
               Materia.RefreshAndManageCurrentProcess();
            }
        }

        /// <summary>
        /// Removes a Validator control with the specified owner from the collection.
        /// </summary>
        /// <param name="control"></param>
        public void Remove(ContainerControl control)
        {
            Validator _validator = GetValidator(control);
            if (_validator != null) Remove(_validator);
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Dispose off any resources used by the class to free up memory space.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose off any resources used by the class to free up memory space.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (Validator _validator in List)
                {
                    if (_validator != null)
                    {
                        try { _validator.Dispose(); }
                        catch { }
                    }  
                }

                Materia.RefreshAndManageCurrentProcess();
            }
        }

        #endregion

    }

}
