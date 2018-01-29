using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CL.DragDrop
{
    public class Rubber : Behavior<UIElement>
    {
        private SolidColorBrush fillColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4C0080FF"));

        private SolidColorBrush frameColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF35AAF7"));

        private Point firstPoint;

        private Rectangle rubber;

        bool isStart;

        public double Top { get; private set; }
        public double Left { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(Rubber), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(Rubber), new PropertyMetadata(null));

        public bool IsEnable
        {
            get { return (bool)GetValue(IsEnableProperty); }
            set { SetValue(IsEnableProperty, value); }
        }
        public static readonly DependencyProperty IsEnableProperty =
            DependencyProperty.Register(nameof(IsEnable), typeof(bool), typeof(Rubber), new PropertyMetadata(false));

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewMouseDown += AssociatedObject_MouseDown;
            this.AssociatedObject.PreviewMouseMove += AssociatedObject_MouseMove;
            this.AssociatedObject.PreviewMouseUp += AssociatedObject_MouseUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewMouseDown -= AssociatedObject_MouseDown;
            this.AssociatedObject.PreviewMouseMove -= AssociatedObject_MouseMove;
            this.AssociatedObject.PreviewMouseUp -= AssociatedObject_MouseUp;
        }

        private void AssociatedObject_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsEnable)
            {
                this.isStart = true;
                var canvas = (Canvas)sender;
                VisualCollection visualHost = new VisualCollection(canvas);
                this.rubber = new Rectangle();
                this.firstPoint = e.GetPosition((IInputElement)sender);
                Canvas.SetLeft(this.rubber, this.firstPoint.X);
                Canvas.SetTop(this.rubber, this.firstPoint.Y);
                this.rubber.Width = 0;
                this.rubber.Height = 0;
                this.rubber.Fill = this.fillColor;
                this.rubber.Stroke = this.frameColor;
                this.rubber.StrokeDashArray = new DoubleCollection() { 2 };
                this.rubber.StrokeThickness = 2;
                canvas.Children.Add(this.rubber);
            }
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isStart)
            {
                var oldPoint = e.GetPosition((IInputElement)sender);
                var width = oldPoint.X - this.firstPoint.X;
                var height = oldPoint.Y - this.firstPoint.Y;
                var startPoint = this.firstPoint;
                var endPoint = oldPoint;
                if (width > 0)
                {
                    if (height < 0)
                    {
                        startPoint = new Point(this.firstPoint.X, oldPoint.Y);
                        endPoint = new Point(oldPoint.X, this.firstPoint.Y);
                        Canvas.SetTop(rubber, oldPoint.Y);
                    }
                }
                else
                {
                    if (height > 0)
                    {
                        startPoint = new Point(oldPoint.X, this.firstPoint.Y);
                        endPoint = new Point(this.firstPoint.X, oldPoint.Y);
                        Canvas.SetLeft(rubber, oldPoint.X);
                    }
                    else
                    {
                        startPoint = new Point(oldPoint.X, oldPoint.Y);
                        endPoint = new Point(this.firstPoint.X, this.firstPoint.Y);
                        Canvas.SetLeft(rubber, oldPoint.X);
                        Canvas.SetTop(rubber, oldPoint.Y);
                    }
                }

                rubber.Width = Math.Abs(width);
                rubber.Height = Math.Abs(height);
            }
        }

        private void AssociatedObject_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.isStart)
            {
                this.Top = Canvas.GetTop(this.rubber);
                this.Left = Canvas.GetLeft(this.rubber);
                this.Width = this.rubber.ActualWidth;
                this.Height = this.rubber.ActualHeight;
                this.isStart = false;
                var canvas = ((Canvas)sender);
                canvas.Children.Remove(this.rubber);
                var secondPoint = e.GetPosition((IInputElement)sender);
                var deltaX = Math.Abs(this.firstPoint.X - secondPoint.X);
                var deltaY = Math.Abs(this.firstPoint.Y - secondPoint.Y);
                if (deltaX > 5 || deltaY > 5) e.Handled = true;
                
                Command.Execute(this.CommandParameter);
            }
        }
    }
}
