using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ISC.ViewModel.Base
{
    public class MyBehavior : Behavior<UIElement>
    {
        public DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T)) source = VisualTreeHelper.GetParent(source);
            return source;
        }
    }

    public class RightClickBehavior :MyBehavior
    {
        public object ViewModel
        {
            get { return GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(object), typeof(RightClickBehavior), new PropertyMetadata(null));

        public RightClickTarget RightClickTarget
        {
            get { return (RightClickTarget)GetValue(RightClickTargetProperty); }
            set { SetValue(RightClickTargetProperty, value); }
        }
        public static readonly DependencyProperty RightClickTargetProperty =
            DependencyProperty.Register(nameof(RightClickTarget), typeof(RightClickTarget), typeof(RightClickBehavior), new PropertyMetadata(RightClickTarget.ListBoxItem));

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewMouseRightButtonDown += AssociatedObject_PreviewMouseRightButtonDown;
        }

        private void AssociatedObject_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (this.RightClickTarget)
            {
                case RightClickTarget.ListBoxItem:
                {
                    var viewModel = this.ViewModel as FileViewmodel;
                    if (this.VisualUpwardSearch<ListBoxItem>(e.OriginalSource as DependencyObject) is ListBoxItem listBoxItem)
                    {
                        var model = (Model.Entity.Working.Item)listBoxItem.DataContext;
                        if (model.Name.Contains('.'))
                        {
                            if (model.Name.Split('.')[1] == "txt")
                            {
                                viewModel.ChangeContextMenu(true);
                            }
                            else
                            {
                                viewModel.ChangeContextMenu(false);
                            }
                        }
                        else
                        {
                            viewModel.ChangeContextMenu();
                        }
                    }
                    break;
                }
                case RightClickTarget.TreeViewItem:
                {
                    if (this.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) is TreeViewItem treeViewItem)
                    {
                        treeViewItem.Focus();
                        e.Handled = true;
                    }
                    break;
                }
            }
        }

        

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewMouseRightButtonDown -= this.AssociatedObject_PreviewMouseRightButtonDown;
        }
    }

    public class LeftClickBehavior : MyBehavior
    {
        public object ViewModel
        {
            get { return GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(object), typeof(LeftClickBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewMouseLeftButtonDown += LeftClick;
        }

        private void LeftClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var viewModel = this.ViewModel as NetworkViewmodel;
            if (this.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) is TreeViewItem listBoxItem)
            {
                var model = (Model.Entity.Working.Item)listBoxItem.DataContext;
                viewModel.LeftClick(model);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewMouseRightButtonDown -= this.LeftClick;
        }
    }
}
