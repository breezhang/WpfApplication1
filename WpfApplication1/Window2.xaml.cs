using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2
    {
      

         private DispatcherFrame _frame;
    private readonly ObservableCollection<string> _collection = 
            new ObservableCollection<string>();
    public Window2()
    {
        InitializeComponent();
        DataContext = _collection;
    }
 
    private void GetData(object sender, RoutedEventArgs e)
    {
        _collection.Clear();
        _frame = new DispatcherFrame();
        popupGrid.Visibility = Visibility.Visible;
        // blocks gui message pump & creates nested pump
        Dispatcher.PushFrame(_frame); 
        // after DispatcherFrame is cancelled, it continues
        var count = int.Parse(countText.Text); 
        for (int i = 0; i < count; i++)
            _collection.Add("Test Data " + i);
        popupGrid.Visibility = Visibility.Hidden;
    }
 
    private void DataCountEntered(object sender, RoutedEventArgs e)
    {
        _frame.Continue = false; // un-blocks gui message pump
    }
    }
}
