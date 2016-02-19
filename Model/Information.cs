using System.ComponentModel;

namespace TipCalculator.Model
{
    class Information : INotifyPropertyChanged
    {
        //Bill Amount
        //Slider
        //TipAmount
        //Split
        //total

        private double mTipAmount;
        public double TipAmount
        {
            get
            {
                return mTipAmount;
            }
            set
            {
                mTipAmount = value;
                CalculateTotal();
                RaisePropertyChanged("TipAmount");
            }
        }

        private void CalculateTotal()
        {
            Total = (mBillAmount + mTipAmount) / mSplit;
        }

        public void SetTipAmount()
        {
            TipAmount = mSliderValue * mBillAmount;
        }

        private double mSliderValue = .05;
        public double SliderValue
        {
            get
            {
                return mSliderValue;
            }
            set
            {
                mSliderValue = value;
                SetTipAmount();
                RaisePropertyChanged("SliderValue");
            }
        }

        private double mBillAmount;
        public double BillAmount
        {
            get
            {
                return mBillAmount;
            }
            set
            {
                mBillAmount = value;
                SetTipAmount();
                CalculateTotal();
                RaisePropertyChanged("BillAmount");
            }
        }

        private double mTotal;
        public double Total
        {
            get
            {
                return mTotal;
            }
            set
            {
                mTotal = value;
                RaisePropertyChanged("Total");
            }
        }

        private int mSplit = 1;
        public int Split
        {
            get
            {
                return mSplit;
            }
            set
            {
                mSplit = value;
                CalculateTotal();
                RaisePropertyChanged("Split");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
