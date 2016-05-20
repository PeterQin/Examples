using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationPanelSample
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:NavigationPanelSample"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:NavigationPanelSample;assembly=NavigationPanelSample"
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
    ///     <MyNamespace:ContainerControl/>
    ///
    /// </summary>
    public class ContainerControl : Border
    {
        static ContainerControl()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(ContainerControl), new FrameworkPropertyMetadata(typeof(ContainerControl)));
        }

        public ContainerControl()
        {
            this.MouseEnter += ContainerControl_MouseEnter;
            this.MouseLeave += ContainerControl_MouseLeave;
        }

        void ContainerControl_MouseLeave(object sender, MouseEventArgs e)
        {
            IsMouseOverDependency = false;
        }

        void ContainerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            IsMouseOverDependency = true;
           
            
        }

        public bool IsMouseOverDependency
        {
            get { return (bool)GetValue(IsMouseOverDependencyProperty); }
            set { SetValue(IsMouseOverDependencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMouseOverDependency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMouseOverDependencyProperty =
            DependencyProperty.Register("IsMouseOverDependency", typeof(bool), typeof(ContainerControl), new PropertyMetadata(false));

        
    }

    public static class MouseOverCapturedExtansion
    {
        public static bool GetIsMouseOver(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseOverProperty);
        }

        public static void SetIsMouseOver(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMouseOverProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsMouseOver.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMouseOverProperty =
            DependencyProperty.RegisterAttached("IsMouseOver", typeof(bool), typeof(MouseOverCapturedExtansion), new PropertyMetadata(false));


        public static bool GetIsMouseOverCapture(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseOverCapturedProperty);
        }

        public static void SetIsMouseOverCapture(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMouseOverCapturedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsMouseOverCapture.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMouseOverCapturedProperty =
            DependencyProperty.RegisterAttached("IsMouseOverCaptured", typeof(bool), typeof(MouseOverCapturedExtansion), new PropertyMetadata(false, IsMouseOverCaptured_PropertyChanged));


        private static void IsMouseOverCaptured_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            if (element == null)
            {
                return;
            }
            if ((bool)e.NewValue == false)
            {
                EventActuator mouseEnter = GetMouseEnterEventActuator(element);
                mouseEnter.Dispose();
                mouseEnter = null;

                EventActuator mouseLeave = GetMouseLeaveEventActuator(element);
                mouseLeave.Dispose();
                mouseLeave = null;
            }
            else
            {
                if ((bool)e.OldValue == false)
                {
                    EventActuator mouseEnter = new EventActuator();
                    mouseEnter.BindEvent(element, "MouseEnter", () => { SetIsMouseOver(element, true); });
                    SetMouseEnterEventActuator(element, mouseEnter);

                    EventActuator mouseLeave = new EventActuator();
                    mouseLeave.BindEvent(element, "MouseLeave", () => { SetIsMouseOver(element, false); });
                    SetMouseEnterEventActuator(element, mouseLeave);
                }
            }
        }

        private static EventActuator GetMouseEnterEventActuator(DependencyObject obj)
        {
            return (EventActuator)obj.GetValue(MouseEnterEventActuatorProperty);
        }

        private static void SetMouseEnterEventActuator(DependencyObject obj, EventActuator value)
        {
            obj.SetValue(MouseEnterEventActuatorProperty, value);
        }

        // Using a DependencyProperty as the backing store for MouseEnterEventActuator.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty MouseEnterEventActuatorProperty =
            DependencyProperty.RegisterAttached("MouseEnterEventActuator", typeof(EventActuator), typeof(MouseOverCapturedExtansion), new PropertyMetadata((EventActuator)null));



        private static EventActuator GetMouseLeaveEventActuator(DependencyObject obj)
        {
            return (EventActuator)obj.GetValue(MouseLeaveEventActuatorProperty);
        }

        private static void SetMouseLeaveEventActuator(DependencyObject obj, EventActuator value)
        {
            obj.SetValue(MouseLeaveEventActuatorProperty, value);
        }

        // Using a DependencyProperty as the backing store for MouseLeaveEventActuator.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty MouseLeaveEventActuatorProperty =
            DependencyProperty.RegisterAttached("MouseLeaveEventActuator", typeof(EventActuator), typeof(MouseOverCapturedExtansion), new PropertyMetadata((EventActuator)null));



    }

    /// <summary>
    /// Listen to the control's event.
    /// And Navigate to the help topic when event fire
    /// </summary>
    internal class EventActuator : IDisposable
    {
        #region Properties
        /// <summary>
        /// The event name to hook up to
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public string EventName { get; private set; }
        private Action DoEvent { get; set; }

        #region Execution
        /// <summary>
        /// Get the owner of the event binding ex: a Button
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public object Owner { get; private set; }

        /// <summary>
        /// The event info of the event
        /// </summary>
        public EventInfo Event { get; private set; }

        /// <summary>
        /// Gets the EventHandler for the binding with the event
        /// </summary>
        public Delegate EventHandler { get; private set; }
        #endregion Execution

        #endregion Property

        public void BindEvent(object aOwner,string aEventName, Action aDoEvent)
        {
            if (aOwner == null)
            {
                throw new ArgumentNullException("aOwner");
            }
            if (string.IsNullOrWhiteSpace(aEventName))
            {
                throw new ArgumentNullException("aEventName");
            }
            if (aDoEvent == null)
            {
                throw new ArgumentNullException("aDoEvent");
            }

            this.Owner = aOwner;
            this.DoEvent = aDoEvent;
            this.EventName = aEventName;
            try
            {
                //  Get the event info from the event name.
                EventInfo eventInfo = aOwner.GetType().GetEvent(EventName);

                //  Get the method info for the event proxy.
                MethodInfo methodInfo = GetType().GetMethod("EventProxy", BindingFlags.NonPublic | BindingFlags.Instance);

                //  Create a delegate for the event to the event proxy.
                Delegate del = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);

                //  Add the event handler. (Removing it first if it already exists!)
                eventInfo.RemoveEventHandler(aOwner, del);
                eventInfo.AddEventHandler(aOwner, del);

                this.Event = eventInfo;
                this.EventHandler = del;
            }
            catch (Exception e)
            {
                e.ToString(); // Avoid warning. :)
#if DEBUG
                throw e;
#endif
            }
        }

        /// <summary>
        /// Proxy to actually fire the event.
        /// </summary>
        /// <param name="o">The object.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EventProxy(object o, EventArgs e)
        {
            DoEvent();
        }

        

        #region IDisposable Members
        bool disposed = false;
        /// <summary>
        /// Unregisters the EventHandler from the Event
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                if (Event != null)
                {
                    Event.RemoveEventHandler(Owner, EventHandler);
                }
                disposed = true;
            }
        }

        #endregion


    }
}
