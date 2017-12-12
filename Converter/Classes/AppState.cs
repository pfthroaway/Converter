using Converter.Views;
using System.Windows;
using System.Windows.Controls;

namespace Converter.Classes
{
    /// <summary>Represents the current state of the application.</summary>
    internal static class AppState
    {
        #region Navigation

        /// <summary>Instance of MainWindow currently loaded</summary>
        internal static MainWindow MainWindow { get; set; }

        /// <summary>Width of the Page currently being displayed in the MainWindow</summary>
        internal static double CurrentPageWidth { get; set; }

        /// <summary>Height of the Page currently being displayed in the MainWindow</summary>
        internal static double CurrentPageHeight { get; set; }

        /// <summary>Calculates the scale needed for the MainWindow.</summary>
        /// <param name="grid">Grid of current Page</param>
        internal static void CalculateScale(Grid grid)
        {
            CurrentPageHeight = grid.ActualHeight;
            CurrentPageWidth = grid.ActualWidth;
            MainWindow.CalculateScale();

            Page newPage = MainWindow.MainFrame.Content as Page;
            if (newPage != null)
                newPage.Style = (Style)MainWindow.FindResource("PageStyle");
        }

        /// <summary>Navigates to selected Page.</summary>
        /// <param name="newPage">Page to navigate to.</param>
        internal static void Navigate(Page newPage) => MainWindow.MainFrame.Navigate(newPage);

        /// <summary>Navigates to the previous Page.</summary>
        internal static void GoBack()
        {
            if (MainWindow.MainFrame.CanGoBack)
                MainWindow.MainFrame.GoBack();
        }

        #endregion Navigation
    }
}