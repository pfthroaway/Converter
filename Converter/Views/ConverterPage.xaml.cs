using Converter.Classes;
using Converter.Classes.Enums;
using Extensions;
using Extensions.DataTypeHelpers;
using Extensions.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Converter.Views
{
    /// <summary>Interaction logic for ConverterPage.xaml</summary>
    public partial class ConverterPage : Page
    {
        #region Display

        /// <summary>Displays Mass conversion units.</summary>
        private void DisplayMass()
        {
            TxtConvertFrom.Text = "";
            CmbConvertFrom.Items.Clear();
            CmbConvertTo.Items.Clear();
            CmbConvertFrom.Items.Add("Gram");
            CmbConvertFrom.Items.Add("Ounce");
            CmbConvertFrom.Items.Add("Pound");
            CmbConvertFrom.Items.Add("Kilogram");
            CmbConvertTo.Items.Add("Gram");
            CmbConvertTo.Items.Add("Ounce");
            CmbConvertTo.Items.Add("Pound");
            CmbConvertTo.Items.Add("Kilogram");
            CmbConvertFrom.SelectedIndex = 0;
            CmbConvertTo.SelectedIndex = 0;
        }

        /// <summary>Displays Volume conversion units.</summary>
        private void DisplayVolume()
        {
            TxtConvertFrom.Text = "";
            CmbConvertFrom.Items.Clear();
            CmbConvertTo.Items.Clear();
            CmbConvertFrom.Items.Add("Milliliter");
            CmbConvertFrom.Items.Add("Teaspoon");
            CmbConvertFrom.Items.Add("Tablespoon");
            CmbConvertFrom.Items.Add("Fluid Ounce");
            CmbConvertFrom.Items.Add("Cup");
            CmbConvertFrom.Items.Add("Pint");
            CmbConvertFrom.Items.Add("Quart");
            CmbConvertFrom.Items.Add("Liter");
            CmbConvertFrom.Items.Add("Gallon");
            CmbConvertTo.Items.Add("Milliliter");
            CmbConvertTo.Items.Add("Teaspoon");
            CmbConvertTo.Items.Add("Tablespoon");
            CmbConvertTo.Items.Add("Fluid Ounce");
            CmbConvertTo.Items.Add("Cup");
            CmbConvertTo.Items.Add("Pint");
            CmbConvertTo.Items.Add("Quart");
            CmbConvertTo.Items.Add("Liter");
            CmbConvertTo.Items.Add("Gallon");
            CmbConvertFrom.SelectedIndex = 0;
            CmbConvertTo.SelectedIndex = 0;
        }

        #endregion Display

        #region Conversions

        /// <summary>Calls conversion methods based on currently selected conversion type.</summary>
        private void Convert()
        {
            switch (EnumHelper.Parse<Types>(CmbConversionType.SelectedItem.ToString()))
            {
                case Types.Mass:
                    TxtConvertTo.Text = TxtConvertFrom.Text.Length > 0 ? (DecimalHelper.Parse(TxtConvertFrom.Text) * ConvertMass(EnumHelper.Parse<Mass>(CmbConvertFrom.SelectedItem.ToString()), EnumHelper.Parse<Mass>(CmbConvertTo.SelectedItem.ToString()))).ToString() : "0";
                    break;

                case Types.Volume:
                    TxtConvertTo.Text = TxtConvertFrom.Text.Length > 0 ? (DecimalHelper.Parse(TxtConvertFrom.Text) * ConvertVolume(EnumHelper.Parse<Volume>(CmbConvertFrom.SelectedItem.ToString().Replace(" ", "")), EnumHelper.Parse<Volume>(CmbConvertTo.SelectedItem.ToString().Replace(" ", "")))).ToString() : "0";
                    break;

                case Types.Distance:
                    break;
            }
        }

        /// <summary>Converts mass units.</summary>
        /// <param name="from">Unit of mass being converted from</param>
        /// <param name="to">Unit of mass being converted to</param>
        /// <returns></returns>
        private decimal ConvertMass(Mass from, Mass to)
        {
            switch (from)
            {
                case Mass.Gram:
                    switch (to)
                    {
                        case Mass.Gram:
                            return 1;

                        case Mass.Ounce:
                            return 0.035273962M;

                        case Mass.Pound:
                            return 0.002204623M;

                        case Mass.Kilogram:
                            return 0.001M;

                        default:
                            return 0;
                    }
                case Mass.Ounce:
                    switch (to)
                    {
                        case Mass.Gram:
                            return 28.34952313M;

                        case Mass.Ounce:
                            return 1;

                        case Mass.Pound:
                            return 0.0625M;

                        case Mass.Kilogram:
                            return 0.028349523M;

                        default:
                            return 0;
                    }
                case Mass.Pound:
                    switch (to)
                    {
                        case Mass.Gram:
                            return 453.59237M;

                        case Mass.Ounce:
                            return 16M;

                        case Mass.Pound:
                            return 1;

                        case Mass.Kilogram:
                            return 0.45359237M;

                        default:
                            return 0;
                    }
                case Mass.Kilogram:
                    switch (to)
                    {
                        case Mass.Gram:
                            return 1000M;

                        case Mass.Ounce:
                            return 35.27396195M;

                        case Mass.Pound:
                            return 2.204622622M;

                        case Mass.Kilogram:
                            return 1;

                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }

        /// <summary>Converts volume units.</summary>
        /// <param name="from">Unit of volume being converted from</param>
        /// <param name="to">Unit of volume being converted to</param>
        /// <returns></returns>
        private decimal ConvertVolume(Volume from, Volume to)
        {
            switch (from)
            {
                case Volume.Milliliter:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 1;

                        case Volume.Teaspoon:
                            return 0.202884136M;

                        case Volume.Tablespoon:
                            return 0.067628045M;

                        case Volume.FluidOunce:
                            return 0.033814023M;

                        case Volume.Cup:
                            return 0.004226753M;

                        case Volume.Pint:
                            return 0.002113376M;

                        case Volume.Quart:
                            return 0.001056688M;

                        case Volume.Liter:
                            return 0.001M;

                        case Volume.Gallon:
                            return 0.000264172M;

                        default:
                            return 0;
                    }

                case Volume.Teaspoon:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 4.928921594M;

                        case Volume.Teaspoon:
                            return 1;

                        case Volume.Tablespoon:
                            return 0.333333333M;

                        case Volume.FluidOunce:
                            return 0.166666667M;

                        case Volume.Cup:
                            return 0.020833333M;

                        case Volume.Pint:
                            return 0.010416667M;

                        case Volume.Quart:
                            return 0.005208333M;

                        case Volume.Liter:
                            return 0.004928922M;

                        case Volume.Gallon:
                            return 0.001302083M;

                        default:
                            return 0;
                    }

                case Volume.Tablespoon:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 14.78676478M;

                        case Volume.Teaspoon:
                            return 3;

                        case Volume.Tablespoon:
                            return 1;

                        case Volume.FluidOunce:
                            return 0.5M;

                        case Volume.Cup:
                            return 0.0625M;

                        case Volume.Pint:
                            return 0.03125M;

                        case Volume.Quart:
                            return 0.015625M;

                        case Volume.Liter:
                            return 0.014786765M;

                        case Volume.Gallon:
                            return 0.00390625M;

                        default:
                            return 0;
                    }

                case Volume.FluidOunce:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 29.57352956M;

                        case Volume.Teaspoon:
                            return 6;

                        case Volume.Tablespoon:
                            return 2;

                        case Volume.FluidOunce:
                            return 1;

                        case Volume.Cup:
                            return 0.125M;

                        case Volume.Pint:
                            return 0.0625M;

                        case Volume.Quart:
                            return 0.03125M;

                        case Volume.Liter:
                            return 0.02957353M;

                        case Volume.Gallon:
                            return 0.0078125M;

                        default:
                            return 0;
                    }

                case Volume.Cup:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 236.5882365M;

                        case Volume.Teaspoon:
                            return 48;

                        case Volume.Tablespoon:
                            return 16;

                        case Volume.FluidOunce:
                            return 8;

                        case Volume.Cup:
                            return 1;

                        case Volume.Pint:
                            return 0.5M;

                        case Volume.Quart:
                            return 0.25M;

                        case Volume.Liter:
                            return 0.236588237M;

                        case Volume.Gallon:
                            return 0.0625M;

                        default:
                            return 0;
                    }

                case Volume.Pint:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 473.176473M;

                        case Volume.Teaspoon:
                            return 96;

                        case Volume.Tablespoon:
                            return 32;

                        case Volume.FluidOunce:
                            return 16;

                        case Volume.Cup:
                            return 8;

                        case Volume.Pint:
                            return 1;

                        case Volume.Quart:
                            return 0.5M;

                        case Volume.Liter:
                            return 0.473176473M;

                        case Volume.Gallon:
                            return 0.125M;

                        default:
                            return 0;
                    }

                case Volume.Quart:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 946.352946M;

                        case Volume.Teaspoon:
                            return 192;

                        case Volume.Tablespoon:
                            return 64;

                        case Volume.FluidOunce:
                            return 32;

                        case Volume.Cup:
                            return 4;

                        case Volume.Pint:
                            return 2;

                        case Volume.Quart:
                            return 1;

                        case Volume.Liter:
                            return 0.946352946M;

                        case Volume.Gallon:
                            return 0.25M;

                        default:
                            return 0;
                    }

                case Volume.Liter:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 1000;

                        case Volume.Teaspoon:
                            return 202.8841362M;

                        case Volume.Tablespoon:
                            return 67.6280454M;

                        case Volume.FluidOunce:
                            return 33.8140227M;

                        case Volume.Cup:
                            return 4.226752838M;

                        case Volume.Pint:
                            return 2.113376419M;

                        case Volume.Quart:
                            return 1.056688209M;

                        case Volume.Liter:
                            return 1;

                        case Volume.Gallon:
                            return 0.264172052M;

                        default:
                            return 0;
                    }
                case Volume.Gallon:
                    switch (to)
                    {
                        case Volume.Milliliter:
                            return 3785.411784M;

                        case Volume.Teaspoon:
                            return 768;

                        case Volume.Tablespoon:
                            return 256;

                        case Volume.FluidOunce:
                            return 128;

                        case Volume.Cup:
                            return 16;

                        case Volume.Pint:
                            return 8;

                        case Volume.Quart:
                            return 4;

                        case Volume.Liter:
                            return 3.785411784M;

                        case Volume.Gallon:
                            return 1;

                        default:
                            return 0;
                    }

                default:
                    return 0;
            }
        }

        #endregion Conversions

        #region Page-Manipulation Methods

        public ConverterPage() => InitializeComponent();

        private void TxtConvertFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            Functions.TextBoxTextChanged(sender, KeyType.Decimals);
            Convert();
        }

        private void TxtConvertFrom_PreviewKeyDown(object sender, KeyEventArgs e) => Functions.PreviewKeyDown(e, KeyType.Decimals);

        private void Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e) => Convert();

        private void CmbConversionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (EnumHelper.Parse<Types>(CmbConversionType.SelectedItem.ToString()))
            {
                case Types.Mass:
                    DisplayMass();
                    break;

                case Types.Volume:
                    DisplayVolume();
                    break;

                case Types.Distance:
                    //DisplayDistance();
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppState.CalculateScale(Grid);
            CmbConversionType.Items.Add("Mass");
            CmbConversionType.Items.Add("Volume");
            CmbConversionType.Items.Add("Distance");
            CmbConversionType.SelectedIndex = 0;
            TxtConvertFrom.Focus();
        }

        #endregion Page-Manipulation Methods
    }
}