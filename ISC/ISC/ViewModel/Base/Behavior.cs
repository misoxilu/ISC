using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace ISC.ViewModel.StepContents
{
    public class Behavior : Behavior<UIElement>
    {
        public object ViewModel
        {
            get { return GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(object), typeof(Behavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();
            
            //this.AssociatedObject.mousedout
            //this.AssociatedObject.PreviewMouseMove += AssociatedObject_MouseMove;
            //this.AssociatedObject.PreviewMouseUp += AssociatedObject_MouseUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            //this.AssociatedObject.PreviewMouseDown -= AssociatedObject_MouseDown;
            //this.AssociatedObject.PreviewMouseMove -= AssociatedObject_MouseMove;
            //this.AssociatedObject.PreviewMouseUp -= AssociatedObject_MouseUp;
        }
    }
}
