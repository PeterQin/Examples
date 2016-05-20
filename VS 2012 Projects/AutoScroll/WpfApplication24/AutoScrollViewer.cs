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

namespace WpfApplication24
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfApplication24"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfApplication24;assembly=WpfApplication24"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:AutoScrollViewer/>
    ///
    /// </summary>
    public class AutoScrollViewer : ScrollViewer
    {

        public object ActaulContent
        {
            get { return (object)GetValue(ActaulContentProperty); }
            set { SetValue(ActaulContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActaulContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActaulContentProperty =
            DependencyProperty.Register("ActaulContent", typeof(object), typeof(AutoScrollViewer), new UIPropertyMetadata(null, ContentPropertyChanged));

        private static void ContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                FrameworkElement OldContentObj = e.OldValue as FrameworkElement;
                ClearClientSizeBinding(OldContentObj);
            }
            if (e.NewValue != e.OldValue && e.NewValue != null)
            {
                FrameworkElement ContentObj = e.NewValue as FrameworkElement;
                SetClientSizeBinding(ContentObj, d);
            }
        }

        public double ContentMinSize
        {
            get { return (double)GetValue(ContentMinSizeProperty); }
            set { SetValue(ContentMinSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentMinSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentMinSizeProperty =
            DependencyProperty.Register("ContentMinSize", typeof(double), typeof(AutoScrollViewer), new UIPropertyMetadata(ContentMinSizeChanged));

        private static void ContentMinSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutoScrollViewer view = d as AutoScrollViewer;
            if (view != null)
            {
                view.OnRenderSizeChanged(new SizeChangedInfo(view, view.DesiredSize, true, true));
            }
        }

        public AutoScrollViewer()
        {
            this.SetBinding(ActaulContentProperty, new Binding("Content") { Mode = BindingMode.OneWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = this });

            AutoScroll(SizeType.Height, false);
            AutoScroll(SizeType.Width, false);

        }

        internal void AutoScroll(SizeType aType, bool aVisible)
        {
            ScrollBarVisibility visible = aVisible ? ScrollBarVisibility.Visible : ScrollBarVisibility.Hidden;
            switch (aType)
            {
                case SizeType.Height:
                    if (this.VerticalScrollBarVisibility != visible)
                    {
                        this.VerticalScrollBarVisibility = visible;
                        OnRenderSizeChanged(new SizeChangedInfo(this, this.DesiredSize, true, true));
                    }

                    break;
                case SizeType.Width:
                    if (this.HorizontalScrollBarVisibility != visible)
                    {
                        this.HorizontalScrollBarVisibility = visible;
                        OnRenderSizeChanged(new SizeChangedInfo(this, this.DesiredSize, true, true));
                    }
                    break;
            }
        }

        ~AutoScrollViewer()
        {
            if (this.Dispatcher.CheckAccess() == false)
            {
                Dispatcher.BeginInvoke(new Action(Dispose));
            }
            else
            {
                Dispose();
            }

        }

        private void Dispose()
        {
            FrameworkElement ContentObj = this.Content as FrameworkElement;
            ClearClientSizeBinding(ContentObj);
            BindingOperations.ClearAllBindings(this);
        }

        protected static void ClearClientSizeBinding(FrameworkElement aContentObj)
        {
            if (aContentObj != null)
            {
                BindingOperations.ClearBinding(aContentObj, FrameworkElement.MaxWidthProperty);
                BindingOperations.ClearBinding(aContentObj, FrameworkElement.MaxHeightProperty);
            }
        }

        protected static void SetClientSizeBinding(FrameworkElement aContentObj, DependencyObject d)
        {
            if (aContentObj != null)
            {
                SizeConverterHelper heightPara = new SizeConverterHelper(SizeType.Height, aContentObj, d);
                SizeConverterHelper widthPara = new SizeConverterHelper(SizeType.Width, aContentObj, d);
                ScollViewerSizeConverter SizeConver = new ScollViewerSizeConverter();
                aContentObj.SetBinding(FrameworkElement.MaxWidthProperty, new Binding("ActualWidth") { Mode = BindingMode.OneWay, Source = d, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Converter = SizeConver, ConverterParameter = widthPara });
                aContentObj.SetBinding(FrameworkElement.MaxHeightProperty, new Binding("ActualHeight") { Mode = BindingMode.OneWay, Source = d, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Converter = SizeConver, ConverterParameter = heightPara });
                AutoScrollViewer view = d as AutoScrollViewer;
                if (view != null)
                {
                    view.SetBinding(AutoScrollViewer.ContentMinSizeProperty, new Binding("MinWidth") { Mode = BindingMode.OneWay, Source = aContentObj, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
                    view.SetBinding(AutoScrollViewer.ContentMinSizeProperty, new Binding("MinHeight") { Mode = BindingMode.OneWay, Source = aContentObj, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
                }
            }
        }

    }

    enum SizeType
    {
        Height,
        Width,
    }

    public class SizeConverterHelper
    {
        private SizeType FSizeType;

        internal SizeType CurrentSizeType
        {
            get { return FSizeType; }
            set { FSizeType = value; }
        }

        private FrameworkElement FContentObj;

        public FrameworkElement ContentObj
        {
            get { return FContentObj; }
            set { FContentObj = value; }
        }

        private DependencyObject FControl;

        public DependencyObject Control
        {
            get { return FControl; }
            set { FControl = value; }
        }


        internal SizeConverterHelper() { }
        internal SizeConverterHelper(SizeType aType, FrameworkElement aContent, DependencyObject aControl)
        {
            CurrentSizeType = aType;
            ContentObj = aContent;
            Control = aControl;
        }

        private double GetBarSize()
        {
            double barSize = 0;
            AutoScrollViewer view = Control as AutoScrollViewer;
            if (view != null)
            {
                if (CurrentSizeType == SizeType.Height && view.HorizontalScrollBarVisibility == ScrollBarVisibility.Visible)
                {
                    barSize = SystemParameters.HorizontalScrollBarHeight;
                }
                else if (CurrentSizeType == SizeType.Width && view.VerticalScrollBarVisibility == ScrollBarVisibility.Visible)
                {
                    barSize = SystemParameters.VerticalScrollBarWidth;
                }
            }
            return barSize;
        }

        internal double GetOffsetSize()
        {
            double result = 0;
            double barSize = GetBarSize();
            switch (CurrentSizeType)
            {
                case SizeType.Height:
                    result = ContentObj.Margin.Top + ContentObj.Margin.Bottom + barSize;
                    break;
                case SizeType.Width:
                    result = ContentObj.Margin.Left + ContentObj.Margin.Right + barSize;
                    break;
            }
            return result;
        }

        internal void AutoScroll(double aSize)
        {
            bool shouldScroll = false;
            switch (CurrentSizeType)
            {
                case SizeType.Height:
                    shouldScroll = aSize < ContentObj.MinHeight;
                    break;
                case SizeType.Width:
                    shouldScroll = aSize < ContentObj.MinWidth;
                    break;
            }
            AutoScrollViewer view = Control as AutoScrollViewer;
            if (view != null)
            {
                view.AutoScroll(CurrentSizeType, shouldScroll);
            }
        }

    }

    public class ScollViewerSizeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double size = 0;
            SizeConverterHelper para = parameter as SizeConverterHelper;
            if (value != null && para != null)
            {
                size = (double)value - para.GetOffsetSize();
                para.AutoScroll(size);
            }
            return size;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
