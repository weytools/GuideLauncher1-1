using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductLauncher.Data;
using ProductLauncher.Logic;
using System.Diagnostics;

using System.IO;
using System.Collections.ObjectModel;

namespace ProductLauncher.VM
{
    public class GuideScreen : INotifyPropertyChanged
    {

        #region  Property Change Listener
        /// <summary>
        /// Firing this event will update all binded controls
        /// Fire using this code in the setter of the property
        /// <code>PropertyChanged(this, new PropertyChangedEventArgs(nameof(MyProp)));</code></summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        /// Make sure all properties are <public>!
        /// Make sure all properties have matching <private var>!
        #endregion

        #region Fields and Props
        // Fields
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();


        //Props
        public FormInput CurrentInput { get; set; } = new FormInput { };
        public ObservableCollection<Product> ProductList { get { return productList; } }
        public string TestText { get; set; } = "Test 1 hello";



        #endregion


        #region Methods
        /// <summary>
        /// Save the entered search string and clear the text box.
        /// </summary>
        public string SaveProductEntry()
        {
            CurrentInput.GradeSearched = CurrentInput.GradeEntry;
            CurrentInput.GradeEntry = String.Empty;
            return CurrentInput.GradeSearched;
        }

        /// <summary>
        /// determines if the string is 3 or 4 letters
        /// </summary>
        /// <param name="productInput">string from textbox</param>
        /// <returns></returns>
        public Boolean IsGrade(string productInput)
        {
            // if 3 or 4 letters, then it's just the grade already
            if (productInput.Length == 3 || productInput.Length == 4)
                return true;
            else
                return false;
        }



        #endregion

        #region Button Calls
        /// <summary>
        /// Begin the search - button call.
        /// </summary>
        public void ActivateGradeSearch()
        {

            Product CurrentProduct  = new Product();

            // save whats been entered
            CurrentProduct.SearchTerm = SaveProductEntry();

            // format check
            if (CurrentInput.GradeSearched.Length < 3)
            {
                ProductGuideLogic.ErrorTooShort();
                return;
            }


            // determine if it's a full product or a grade
            bool isGrade = IsGrade(CurrentInput.GradeSearched);

            // isolate the grade and save it
            if (!isGrade)
                CurrentProduct.Grade = ProductGuideLogic.ExtractGrade(CurrentInput.GradeSearched);
            else
                CurrentProduct.Grade = CurrentInput.GradeSearched;

            // save secondary grade if exists
            if (CurrentProduct.Grade.Length == 4)
                CurrentProduct.SecondGrade = CurrentProduct.Grade.Substring(1, 3);

            // search on network for matching guide
            string primaryPath = ProductGuideLogic.GetPath(CurrentProduct.Grade);

            // if none found
            if (primaryPath == string.Empty)
            {
                ProductGuideLogic.ErrorNoneFound();
                return;
            }

            CurrentProduct.ProductGuide = primaryPath;

            // get second guide path
            if (CurrentProduct.SecondGrade != null)
            {
                string secondaryPath = ProductGuideLogic.GetPath(CurrentProduct.SecondGrade);

                if (secondaryPath == string.Empty)
                    CurrentProduct.SecondGrade = string.Empty;

                CurrentProduct.SecondGuide = secondaryPath;
            }

            // add to list 
            productList.Add(CurrentProduct);
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(ProductList)));

            // return PDF link and associate with button


            // parse through PDF
            // return text to fields
            // if 4 letter grade, find secondary pdf
            // save in combo box
        }

        public void ClearProductList()
        {
            productList.Clear();
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(ProductList)));
        }
    }
    #endregion
}
