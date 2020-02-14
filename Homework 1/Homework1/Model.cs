using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.ComponentModel;

using System.Threading.Tasks;

using System.Windows.Media;

using MyIntegerSet;



namespace Homework1

{

    class Model : INotifyPropertyChanged
    {
        IntegerSet set1 = new IntegerSet();
        IntegerSet set2 = new IntegerSet();

        private string _topBoxTextInput;

        public string TopBoxTextInput

        {

            get { return _topBoxTextInput; }

            set

            {

                _topBoxTextInput = value;

                OnPropertyChanged("TopBoxTextInput");

            }

        }



        private string _bottomBoxTextInput;

        public string BottomBoxTextInput

        {

            get { return _bottomBoxTextInput; }

            set

            {

                _bottomBoxTextInput = value;

                OnPropertyChanged("BottomBoxTextInput");

            }

        }

        private string _bottomBoxTextOutput;
        public string BottomBoxTextOutput

        {

            get { return _bottomBoxTextOutput; }

            set

            {

                _bottomBoxTextOutput = value;

                OnPropertyChanged("BottomBoxTextOutput");

            }

        }

        private string _topBoxTextOutput;
        public string TopBoxTextOutput

        {

            get { return _topBoxTextOutput; }

            set

            {

                _topBoxTextOutput = value;

                OnPropertyChanged("TopBoxTextOutput");

            }

        }

        private string _errorTextOutput;
        public string ErrorTextOutput

        {

            get { return _errorTextOutput; }

            set

            {

                _errorTextOutput = value;

                OnPropertyChanged("ErrorTextOutput");

            }

        }

        public void Calculate()
        {
            set1.Clear();
            set2.Clear();
            try
            {
                ErrorTextOutput = "";
                TopBoxTextOutput = "";
                BottomBoxTextOutput = "";

                string[] input1String = _topBoxTextInput.Split(',');
                string[] input2String = _bottomBoxTextInput.Split(',');
                int size1 = input1String.Length;
                int size2 = input2String.Length;
                int[] input1 = new int[size1];
                int[] input2 = new int[size2];

                for (int i = 0; i < size1; i++)
                {
                        input1[i] = Int32.Parse(input1String[i]);
                }

                for (int i = 0; i < size2; i++)
                {
                    input2[i] = Int32.Parse(input2String[i]);
                }   

                foreach (int i in input1)
                {
                    try{
                        set1.InsertElement(i);
                        ErrorTextOutput = "";
                    }catch (Exception e){
                        ErrorTextOutput = e.Message;
                        TopBoxTextOutput = "";
                        BottomBoxTextOutput = "";
                    }
                }

                foreach (int i in input2)
                {
                    try {
                        set2.InsertElement(i);
                        ErrorTextOutput = "";
                    }catch (Exception e){
                        ErrorTextOutput = e.Message;
                        TopBoxTextOutput = "";
                        BottomBoxTextOutput = "";
                    }
                }

            }
            catch(Exception e){
                ErrorTextOutput = e.Message;
                TopBoxTextOutput = "";
                BottomBoxTextOutput = "";
            }
            if (ErrorTextOutput == ""){
                TopBoxTextOutput = "";
                BottomBoxTextOutput = "";
                IntegerSet intersection = set1.Intersection(set2);
                IntegerSet union = set1.Union(set2);
                TopBoxTextOutput = union.ToString();
                BottomBoxTextOutput = intersection.ToString();
            }
        }

        public Model()

        {


        }




        #region Data Binding Stuff

        // define out property chane event handler, part of the data binding

        public event PropertyChangedEventHandler PropertyChanged;



        //implemets method for data binding to any and all properties

        private void OnPropertyChanged(string propertyName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }

        }

        #endregion

    }

}