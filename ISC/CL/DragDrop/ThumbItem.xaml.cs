using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CL.DragDrop
{
    /// <summary>
    /// ThumbItem.xaml 的交互逻辑
    /// </summary>
    public partial class ThumbItem : ContentControl
    {
        public ThumbItem()
        {
            InitializeComponent();
        }

        public Cursor TopCursor
        {
            get { return (Cursor)GetValue(TopCursorProperty); }
            set { SetValue(TopCursorProperty, value); }
        }
        public static readonly DependencyProperty TopCursorProperty =
            DependencyProperty.Register(nameof(TopCursor), typeof(Cursor), typeof(ThumbItem), new PropertyMetadata(Cursors.SizeNS));



        public Cursor LeftCursor
        {
            get { return (Cursor)GetValue(LeftCursorProperty); }
            set { SetValue(LeftCursorProperty, value); }
        }
        public static readonly DependencyProperty LeftCursorProperty =
            DependencyProperty.Register(nameof(LeftCursor), typeof(Cursor), typeof(ThumbItem), new PropertyMetadata(Cursors.SizeWE));




    }
}
