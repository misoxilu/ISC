using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CL.DragDrop
{
    public class ResizeThumb : Thumb
    {
        public ResizeThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control item = this.DataContext as Control;


            //RotateTransform rotateTransform = item.RenderTransform as RotateTransform;
            //var a = rotateTransform.Angle;

            if (item != null)
            {
                double deltaVertical, deltaHorizontal;

                switch (VerticalAlignment)
                {
                    case System.Windows.VerticalAlignment.Bottom:
                    {

                        deltaVertical = Math.Min(-e.VerticalChange, item.ActualHeight - item.MinHeight);
                        item.Height -= deltaVertical;
                        break;
                    }
                    case System.Windows.VerticalAlignment.Top:
                    {
                        deltaVertical = Math.Min(e.VerticalChange, item.ActualHeight - item.MinHeight);
                        Canvas.SetTop(item, Canvas.GetTop(item) + deltaVertical);
                        item.Height -= deltaVertical;
                        break;
                    }
                    default: { break; }
                }

                switch (HorizontalAlignment)
                {
                    case System.Windows.HorizontalAlignment.Left:
                    {
                        deltaHorizontal = Math.Min(e.HorizontalChange, item.ActualWidth - item.MinWidth);
                        Canvas.SetLeft(item, Canvas.GetLeft(item) + deltaHorizontal);
                        item.Width -= deltaHorizontal;
                        break;
                    }
                    case System.Windows.HorizontalAlignment.Right:
                    {
                        deltaHorizontal = Math.Min(-e.HorizontalChange, item.ActualWidth - item.MinWidth);
                        item.Width -= deltaHorizontal;
                        break;
                    }
                    default: break;
                }
            }

            e.Handled = true;
        }
    }
}
