using Microsoft.Phone.Controls;
using System.Windows;
using TipCalculator.Model;
using Microsoft.Phone.Tasks;
using System;

namespace TipCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Information mInformation;
        private bool mSplitActive = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            mInformation = new Information();
            this.DataContext = mInformation;
            SplitStack.Visibility = System.Windows.Visibility.Collapsed;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private double mSavedBillAmount;
        private void uBillAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            string lBillAmount = uBillAmount.Text;
            lBillAmount = lBillAmount.Substring(1, lBillAmount.Length-1);
            mSavedBillAmount = double.Parse(lBillAmount);
            uBillAmount.Text = string.Empty;
        }

        
        private void uBillAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (uBillAmount.Text == string.Empty || uBillAmount.Text == ".")
            {
                uBillAmount.Text = mSavedBillAmount.ToString();
            }
        }

        private double mSavedSplitAmount;
        private void uSplit_GotFocus(object sender, RoutedEventArgs e)
        {
            mSavedSplitAmount = double.Parse(uSplit.Text);
            uSplit.Text = string.Empty;
        }

        private void uSplit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (uSplit.Text == string.Empty || uSplit.Text == (".") || uSplit.Text == (".."))
            {
                uSplit.Text = mSavedSplitAmount.ToString();
            }
            else if (double.Parse(uSplit.Text) < 1)
            {
                uSplit.Text = "1";
            }
            
            //else
            //{
            //    int lSplitAmount = int.Parse(uSplit.Text);
            //    uSplit.Text = lSplitAmount.ToString();
            //}
        }

        private void uRadio10_Checked(object sender, RoutedEventArgs e)
        {
            uSlider.Value = .10;
            uRadio10.IsChecked = false;
        }

        private void uRadio15_Checked(object sender, RoutedEventArgs e)
        {
            uSlider.Value = .15;
            uRadio15.IsChecked = false;
        }

        private void uRadio20_Checked(object sender, RoutedEventArgs e)
        {
            uSlider.Value = .20;
            uRadio20.IsChecked = false;
        }

        private void uRadio30_Checked(object sender, RoutedEventArgs e)
        {
            uSlider.Value = .30;
            uRadio30.IsChecked = false;
        }

        private void RateApp_Click(object sender, System.EventArgs e)
        {
            MarketplaceReviewTask lMarketPlaceReviewTask = new MarketplaceReviewTask();
            lMarketPlaceReviewTask.Show();
        }

        private void uBillAmount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string lStringText = uBillAmount.Text;
            string lDecimalPoint = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (lStringText.IndexOf(lDecimalPoint) != lStringText.LastIndexOf(lDecimalPoint))
            {
                uBillAmount.Text = string.Empty;
            }
        }

        private void SplitBill_Click(object sender, EventArgs e)
        {
            if (!mSplitActive)
            {
                SplitStack.Visibility = System.Windows.Visibility.Visible;
                mSplitActive = true;
            }
            else
            {
                SplitStack.Visibility = System.Windows.Visibility.Collapsed;
                mInformation.Split = 1;
                mSplitActive = false;
            }
            
        }

        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}