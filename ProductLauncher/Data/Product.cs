using System;
using System.ComponentModel;
using System.Windows;

namespace ProductLauncher.Data
{
    public class Product //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

            // Props
        // Grade, SecondGrade, ProductGuide, SecondGuide


        private string grade;
        public string Grade
        {
            get { return grade.ToUpper(); ; }
            set { grade = value; }
        }

        private string secondGrade;
        public string SecondGrade 
        {
            get { return secondGrade; }
            set { secondGrade = value; }
        }

        private string productGuide;
        public string ProductGuide
        {
            get { return productGuide; }
            set { productGuide = value; }
        }

        private string secondGuide;
        public string SecondGuide
        {
            get { return secondGuide; }
            set { secondGuide = value; }
        }

        public string GuideTitle
        {
            get
            {
                string workingTitle = System.IO.Path.GetFileName(productGuide);

                // get rid of .pdf
                return workingTitle.Substring(0, (workingTitle.Length - 4));
            }
        }

        public string SecondaryGuideTitle
        {
            get
            {
                string workingTitle = System.IO.Path.GetFileName(secondGuide);

                // get rid of .pdf
                return workingTitle.Substring(0, (workingTitle.Length - 4));
            }
        }


        private string searchTerm;
        public string SearchTerm
        {
            get { return searchTerm; }
            set { searchTerm = value; }
        }

        public Visibility SecondaryVisibility
        {
            get { return (SecondGrade == string.Empty || SecondGrade == null ? Visibility.Hidden : Visibility.Visible); }
        }

        public void LaunchPrimaryGuide()
        {
            System.Diagnostics.Process.Start(productGuide);
        }
    }
}
