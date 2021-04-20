using System;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Windows;
using System.Windows.Input;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // set the customized GridSelectionControllserExt to SfDataGrid.SelectionController when RowSelection applied in SfDataGrid
            //this.sfDataGrid.SelectionController = new GridSelectionControllerExt(sfDataGrid);

            // set the customized GridCellSelectionControllserExt to SfDataGrid.SelectionController when CellSelection applied in SfDataGrid
            this.sfDataGrid.SelectionController = new GridCellSelectionControllerExt(sfDataGrid);
        }

    }

    //Inherits the GridSelectionController Class
    public class GridSelectionControllerExt : GridSelectionController
    {
        public GridSelectionControllerExt(SfDataGrid datagrid)
          : base(datagrid)
        {
        }

        //overriding the ProcessKeyDown Event from GridSelectionController base class
        protected override void ProcessKeyDown(KeyEventArgs args)
        {
            if (args.Key == Key.PageUp || args.Key == Key.PageDown)
            {
                //Key based Customization 
                KeyEventArgs arguments = new KeyEventArgs(args.KeyboardDevice, args.InputSource, args.Timestamp, Key.Tab) { RoutedEvent = args.RoutedEvent };
                base.ProcessKeyDown(arguments);
                //assigning the state of Tab key Event handling to PageUp and PageDown key
                args.Handled = arguments.Handled;
                return;
            }
            base.ProcessKeyDown(args);
        }
    }

    //Inherits the GridCellSelectionController Class
    public class GridCellSelectionControllerExt : GridCellSelectionController
    {
        public GridCellSelectionControllerExt(SfDataGrid datagrid)
          : base(datagrid)
        {
        }

        //overriding the ProcessKeyDown Event from GridCellSelectionController base class
        protected override void ProcessKeyDown(KeyEventArgs args)
        {
            if (args.Key == Key.PageUp || args.Key == Key.PageDown)
            {
                //Key based Customization 
                KeyEventArgs arguments = new KeyEventArgs(args.KeyboardDevice, args.InputSource, args.Timestamp, Key.Tab) { RoutedEvent = args.RoutedEvent };
                base.ProcessKeyDown(arguments);
                //assigning the state of Tab key Event handling to PageUp and PageDown key
                args.Handled = arguments.Handled;
                return;
            }
            base.ProcessKeyDown(args);
        }
    }
}
         
   

