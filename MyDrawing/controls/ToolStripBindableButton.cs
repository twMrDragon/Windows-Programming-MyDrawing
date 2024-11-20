﻿using System.Windows.Forms;

namespace MyDrawing.controls
{
    public class ToolStripBindableButton : ToolStripButton, IBindableComponent
    {
        private ControlBindingsCollection dataBindings;

        private BindingContext bindingContext;

        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null) dataBindings = new ControlBindingsCollection(this);
                return dataBindings;
            }
        }

        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null) bindingContext = new BindingContext();
                return bindingContext;
            }
            set { bindingContext = value; }
        }
    }
}
