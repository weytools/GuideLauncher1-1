using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProductLauncher.Data
{
    public class FormInput : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string gradeEntry = String.Empty;
        public string GradeEntry
        {
            get { return gradeEntry; }
            set
            {
                gradeEntry = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(GradeEntry)));
            }


        }


        private string gradeSearched = String.Empty;
        public string GradeSearched
        {
            get { return gradeSearched; }
            set { gradeSearched = value; }
        }


    }
}
