using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WpfApplication1
{
    public class Class1
    {
        [STAThread]
        public static void Main()
        {
            var window = new M();
            new Application().Run(window);
        }
    }

    public sealed class M : Window
    {
        public M()
        {
            var button = new Button() {Name = "hi", Content = "OK",Width = 100,Height = 35};
            var button2 = new Button() {Name = "hix", Content = "OK",Width = 100,Height = 35};
            button.Click += button_Click;
            button2.Click += button_Click2;
            var stackPanel = new StackPanel() {FlowDirection = FlowDirection.LeftToRight};
            stackPanel.Children.Add(button);
            stackPanel.Children.Add(button2);
            AddChild(stackPanel);
            
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
        } 
        void button_Click2(object sender, RoutedEventArgs e)
        {
           new Window2().Show();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            base.OnSourceInitialized(e);
            var source = PresentationSource.FromVisual(this) as HwndSource;
            if (source != null) source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg == 0x201)
            {
                using (TextWriter a = new StreamWriter(File.OpenWrite(@"c:\click.txt")))
                {
                    a.WriteLine("hi");
                }
               
            }
            return IntPtr.Zero;
        }


    }

    //public class Xxx : Behavior<Window>
    //{

    //    private HwndSourceHook _hook;

    //    private void WireUpWndProc()
    //    {
    //        var source = PresentationSource.FromVisual(AssociatedObject) as HwndSource;

    //        if (source != null)
    //        {
    //            _hook = WndProc;
    //            source.AddHook(_hook);
    //        }
    //    }

       

    //    private void RemoveWndProc()
    //    {
    //        var source = PresentationSource.FromVisual(AssociatedObject) as HwndSource;

    //        if (source != null)
    //        {
    //            source.RemoveHook(_hook);
    //        }
    //    }
    //    protected override void OnAttached()
    //    {
    //        base.OnAttached();
    //        AssociatedObject.Loaded += (s, e) => WireUpWndProc();
    //    }

       

    //    protected override void OnDetaching()
    //    {
    //        RemoveWndProc();
    //        base.OnDetaching();
    //    }

    //    private const Int32 WM_EXITSIZEMOVE = 0x0232;
    //    private const Int32 WM_SIZING = 0x0214;
    //    private const Int32 WM_SIZE = 0x0005;

    //    private const Int32 SIZE_RESTORED = 0x0000;
    //    private const Int32 SIZE_MINIMIZED = 0x0001;
    //    private const Int32 SIZE_MAXIMIZED = 0x0002;
    //    private const Int32 SIZE_MAXSHOW = 0x0003;
    //    private const Int32 SIZE_MAXHIDE = 0x0004;

    //    private IntPtr WndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
    //    {
    //        IntPtr result = IntPtr.Zero;

    //        switch (msg)
    //        {
    //            case WM_SIZING:             // sizing gets interactive resize
    //                OnResizing();
    //                break;

    //            case WM_SIZE:               // size gets minimize/maximize as well as final size
    //                {
    //                    int param = wParam.ToInt32();

    //                    switch (param)
    //                    {
    //                        case SIZE_RESTORED:
    //                            OnRestored();
    //                            break;
    //                        case SIZE_MINIMIZED:
    //                            OnMinimized();
    //                            break;
    //                        case SIZE_MAXIMIZED:
    //                            OnMaximized();
    //                            break;
    //                        case SIZE_MAXSHOW:
    //                            break;
    //                        case SIZE_MAXHIDE:
    //                            break;
    //                    }
    //                }
    //                break;

    //            case WM_EXITSIZEMOVE:
    //                OnResized();
    //                break;
    //        }

    //        return result;
    //    }

    //    private void OnResizing()
    //    {
          
    //        if (Resizing != null)
    //            Resizing(AssociatedObject, EventArgs.Empty);
    //    }

    //    private void OnResized()
    //    {
    //        if (Resized != null)
    //            Resized(AssociatedObject, EventArgs.Empty);
    //    }

    //    private void OnRestored()
    //    {
    //        if (Restored != null)
    //            Restored(AssociatedObject, EventArgs.Empty);
    //    }

    //    private void OnMinimized()
    //    {
    //        if (Minimized != null)
    //            Minimized(AssociatedObject, EventArgs.Empty);
    //    }

    //    private void OnMaximized()
    //    {
    //        if (Maximized != null)
    //            Maximized(AssociatedObject, EventArgs.Empty);
    //    }
    //}
}