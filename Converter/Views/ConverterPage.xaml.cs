using Converter.Classes;
using Converter.Classes.Enums;
using Extensions;
using Extensions.DataTypeHelpers;
using Extensions.Enums;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Converter.Views
{
    /// <summary>Interaction logic for ConverterPage.xaml</summary>
    public partial class ConverterPage : Page
    {
        #region Display

        /// <summary>Displays Volume conversion units.</summary>
        private void DisplayDistance()
        {
            TxtConvertFrom.Text = "";
            CmbConvertFrom.Items.Clear();
            CmbConvertTo.Items.Clear();
            CmbConvertFrom.Items.Add("Millimeter");
            CmbConvertFrom.Items.Add("Centimeter");
            CmbConvertFrom.Items.Add("Inch");
            CmbConvertFrom.Items.Add("Foot");
            CmbConvertFrom.Items.Add("Yard");
            CmbConvertFrom.Items.Add("Meter");
            CmbConvertFrom.Items.Add("Kilometer");
            CmbConvertFrom.Items.Add("Mile");
            CmbConvertTo.Items.Add("Millimeter");
            CmbConvertTo.Items.Add("Centimeter");
            CmbConvertTo.Items.Add("Inch");
            CmbConvertTo.Items.Add("Foot");
            CmbConvertTo.Items.Add("Yard");
            CmbConvertTo.Items.Add("Meter");
            CmbConvertTo.Items.Add("Kilometer");
            CmbConvertTo.Items.Add("Mile");
            CmbConvertFrom.SelectedIndex = 0;
            CmbConvertTo.SelectedIndex = 0;
        }

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
                    TxtConvertTo.Text = TxtConvertFrom.Text.Length > 0 ? Math.Round(decimal.Multiply(DecimalHelper.Parse(TxtConvertFrom.Text), ConvertMass(EnumHelper.Parse<Mass>(CmbConvertFrom.SelectedItem.ToString()), EnumHelper.Parse<Mass>(CmbConvertTo.SelectedItem.ToString()))), 9, MidpointRounding.AwayFromZero).ToString() : "0";
                    break;

                case Types.Volume:
                    TxtConvertTo.Text = TxtConvertFrom.Text.Length > 0 ? Math.Round(decimal.Multiply(DecimalHelper.Parse(TxtConvertFrom.Text), ConvertVolume(EnumHelper.Parse<Volume>(CmbConvertFrom.SelectedItem.ToString().Replace(" ", "")), EnumHelper.Parse<Volume>(CmbConvertTo.SelectedItem.ToString().Replace(" ", "")))), 9, MidpointRounding.AwayFromZero).ToString() : "0";
                    break;

                case Types.Distance:
                    TxtConvertTo.Text = TxtConvertFrom.Text.Length > 0 ?
                      Math.Round(decimal.Multiply(DecimalHelper.Parse(TxtConvertFrom.Text), ConvertDistance(EnumHelper.Parse<Distance>(CmbConvertFrom.SelectedItem.ToString()), EnumHelper.Parse<Distance>(CmbConvertTo.SelectedItem.ToString()))), 9, MidpointRounding.AwayFromZero).ToString() : "0";
                    break;
            }
        }

        /// <summary>Converts distance units.</summary>
        /// <param name="from">Unit of distance being converted from</param>
        /// <param name="to">Unit of distance being converted to</param>
        /// <returns></returns>
        private decimal ConvertDistance(Distance from, Distance to)
        {
            switch (from)
            {
                case Distance.Millimeter:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 1;

                        case Distance.Centimeter:
                            return 0.1M;

                        case Distance.Inch:
                            return Decimal.Divide(1, 25.4M);

                        case Distance.Foot:
                            return Decimal.Divide(1, 304.8M);

                        case Distance.Yard:
                            return decimal.Divide(1, 914.4M);

                        case Distance.Meter:
                            return 0.001M;

                        case Distance.Kilometer:
                            return 0.000001M;

                        case Distance.Mile:
                            return decimal.Divide(1, 1609344);

                        default:
                            return 0;
                    }

                case Distance.Centimeter:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 10;

                        case Distance.Centimeter:
                            return 1;

                        case Distance.Inch:
                            return decimal.Divide(1, 2.54M);

                        case Distance.Foot:
                            return decimal.Divide(1, 30.48M);

                        case Distance.Yard:
                            return decimal.Divide(1, 91.44M);

                        case Distance.Meter:
                            return 0.01M;

                        case Distance.Kilometer:
                            return 0.00001M;

                        case Distance.Mile:
                            return decimal.Divide(1, 160934.4M);

                        default:
                            return 0;
                    }

                case Distance.Inch:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 25.4M;

                        case Distance.Centimeter:
                            return 2.54M;

                        case Distance.Inch:
                            return 1;

                        case Distance.Foot:
                            return decimal.Divide(1, 12);

                        case Distance.Yard:
                            return decimal.Divide(1, 36);

                        case Distance.Meter:
                            return 0.0254M;

                        case Distance.Kilometer:
                            return 0.0000254M;

                        case Distance.Mile:
                            return decimal.Divide(1, 63360);

                        default:
                            return 0;
                    }

                case Distance.Foot:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 304.8M;

                        case Distance.Centimeter:
                            return 30.48M;

                        case Distance.Inch:
                            return 12;

                        case Distance.Foot:
                            return 1;

                        case Distance.Yard:
                            return decimal.Divide(1, 3);

                        case Distance.Meter:
                            return 0.3048M;

                        case Distance.Kilometer:
                            return 0.0003048M;

                        case Distance.Mile:
                            return decimal.Divide(1, 5280);

                        default:
                            return 0;
                    }

                case Distance.Yard:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 914.4M;

                        case Distance.Centimeter:
                            return 91.44M;

                        case Distance.Inch:
                            return 36;

                        case Distance.Foot:
                            return 3;

                        case Distance.Yard:
                            return 1;

                        case Distance.Meter:
                            return 0.9144M;

                        case Distance.Kilometer:
                            return 0.0009144M;

                        case Distance.Mile:
                            return decimal.Divide(1, 1760);

                        default:
                            return 0;
                    }

                case Distance.Meter:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 1000;

                        case Distance.Centimeter:
                            return 100;

                        case Distance.Inch:
                            return decimal.Divide(1, 0.0254M);

                        case Distance.Foot:
                            return decimal.Divide(1, 0.3048M);

                        case Distance.Yard:
                            return decimal.Divide(1, 0.9144M);

                        case Distance.Meter:
                            return 1;

                        case Distance.Kilometer:
                            return 0.001M;

                        case Distance.Mile:
                            return decimal.Divide(1, 1609.344M);

                        default:
                            return 0;
                    }

                case Distance.Kilometer:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 1000000;

                        case Distance.Centimeter:
                            return 100000;

                        case Distance.Inch:
                            return decimal.Divide(1, 0.0000254M);

                        case Distance.Foot:
                            return decimal.Divide(1, 0.0003048M);

                        case Distance.Yard:
                            return decimal.Divide(1, 0.0009144M);

                        case Distance.Meter:
                            return 1000;

                        case Distance.Kilometer:
                            return 1;

                        case Distance.Mile:
                            return decimal.Divide(1, 1.609344M);

                        default:
                            return 0;
                    }

                case Distance.Mile:
                    switch (to)
                    {
                        case Distance.Millimeter:
                            return 1609344;

                        case Distance.Centimeter:
                            return 160934.4M;

                        case Distance.Inch:
                            return 63360;

                        case Distance.Foot:
                            return 5280;

                        case Distance.Yard:
                            return 1760;

                        case Distance.Meter:
                            return 1609.344M;

                        case Distance.Kilometer:
                            return 1.609344M;

                        case Distance.Mile:
                            return 1;

                        default:
                            return 0;
                    }
                default:
                    return 0;
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
                            return decimal.Divide(1, 28.349523125M);

                        case Mass.Pound:
                            return Decimal.Divide(1, 453.59237M);

                        case Mass.Kilogram:
                            return 0.001M;

                        default:
                            return 0;
                    }
                case Mass.Ounce:
                    switch (to)
                    {
                        case Mass.Gram:
                            return 28.349523125M;

                        case Mass.Ounce:
                            return 1;

                        case Mass.Pound:
                            return decimal.Divide(1, 16);

                        case Mass.Kilogram:
                            return 0.028349523125M;

                        default:
                            return 0;
                    }
                case Mass.Pound:
                    switch (to)
                    {
                        case Mass.Gram:
                            return 453.59237M;

                        case Mass.Ounce:
                            return 16;

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
                            return 1000;

                        case Mass.Ounce:
                            return decimal.Divide(1, 0.028349523125M);

                        case Mass.Pound:
                            return decimal.Divide(1, 0.45359237M);

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

        private void BtnSwap_Click(object sender, RoutedEventArgs e)
        {
            string to = TxtConvertTo.Text;
            int indexFrom = CmbConvertFrom.SelectedIndex;
            CmbConvertFrom.SelectedIndex = CmbConvertTo.SelectedIndex;
            CmbConvertTo.SelectedIndex = indexFrom;
            TxtConvertFrom.Text = to;
        }

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
                    DisplayDistance();
                    break;
            }
        }

        private void TxtConvertFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            Functions.TextBoxTextChanged(sender, KeyType.Decimals);
            Convert();
        }

        private void TxtConvertFrom_PreviewKeyDown(object sender, KeyEventArgs e) => Functions.PreviewKeyDown(e, KeyType.Decimals);

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