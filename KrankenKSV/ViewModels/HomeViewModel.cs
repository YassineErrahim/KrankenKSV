using KrankenKSV.Models;
using KrankenKSV.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KrankenKSV.ViewModels
{
    public class HomeViewModel : ViewModelBase , ICommand
    {
        private string _searchbox = "";

        private List<KrankenkasseViewModel> _originalValues = new List<KrankenkasseViewModel>();

        private ObservableCollection<KrankenkasseViewModel> _krankenkassen;

        public event EventHandler CanExecuteChanged;

        public string Search
        {
            get { return _searchbox; }
            set { 
                _searchbox = value; 
                OnPropertyChanged(nameof(Search)); 
            }
        }

        public ObservableCollection<KrankenkasseViewModel> Krankenkassen
        {
            get { return _krankenkassen; }
            set { _krankenkassen = value; OnPropertyChanged(nameof(Krankenkassen)); }
        }

        public HomeViewModel() {
            _krankenkassen = new ObservableCollection<KrankenkasseViewModel>();
            
        }

        protected void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            OnSearchChanged();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void OnSearchChanged()
        {
            _krankenkassen.Clear();
            if (Search == "") {
                foreach (var kk in _originalValues) {
                    _krankenkassen.Add(kk);
                }
            }
            else {
                _krankenkassen.Clear();
                //the other option that we have here is to split search string (string.split(" ")) and get each
                //entred string and compare it with each property of Krakenkenkasse but the 
                //complexity will be too much because we have a lot of properties
                //the best way is to use a filter where we filter as per property but lets make it 
                //simple here
                var result = this._originalValues.AsQueryable().Where(kk =>
                    Search.Trim().Contains(kk.IK.ToString()) ||
                    Search.Trim().Contains(kk.VerweisIK.ToString()) ||
                    Search.Trim().Contains(kk.Name.Trim()) && !String.IsNullOrWhiteSpace(kk.Name) ||
                    Search.Trim().Contains(kk.UnkNumber.Trim()) && !String.IsNullOrWhiteSpace(kk.UnkNumber) ||
                    Search.Trim().Contains(kk.Email.Trim()) && !String.IsNullOrWhiteSpace(kk.Email) ||

                    Search.Trim().Contains(kk.Hausanschrift.StreetName.Trim()) && !String.IsNullOrWhiteSpace(kk.Hausanschrift.StreetName) ||
                    Search.Trim().Contains(kk.Hausanschrift.City.Trim()) && !String.IsNullOrWhiteSpace(kk.Hausanschrift.City) ||
                    Search.Trim().Contains(kk.Hausanschrift.PostCode.Trim()) && !String.IsNullOrWhiteSpace(kk.Hausanschrift.PostCode) ||

                    Search.Trim().Contains(kk.Postanschrift.StreetName.Trim()) && !String.IsNullOrWhiteSpace(kk.Postanschrift.StreetName) ||
                    Search.Trim().Contains(kk.Postanschrift.City.Trim()) && !String.IsNullOrWhiteSpace(kk.Postanschrift.City) ||
                    Search.Trim().Contains(kk.Postanschrift.PostCode.Trim()) && !String.IsNullOrWhiteSpace(kk.Postanschrift.PostCode) ||

                    Search.Trim().Contains(kk.Anschrift.StreetName.Trim()) && !String.IsNullOrWhiteSpace(kk.Anschrift.StreetName) ||
                    Search.Trim().Contains(kk.Anschrift.City.Trim()) && !String.IsNullOrWhiteSpace(kk.Anschrift.City) ||
                    Search.Trim().Contains(kk.Anschrift.PostCode.Trim()) && !String.IsNullOrWhiteSpace(kk.Anschrift.PostCode)


                    );
                foreach (var kk in result) {
                    _krankenkassen.Add(kk);
                }
            }
        }

        public async void Execute(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";


            bool? response = openFile.ShowDialog();

            if (response == true) {
                string filePath = openFile.FileName;
                byte[] fileByteArray = File.ReadAllBytes(filePath);
                var result = await CSVReaderService.ParseData(fileByteArray);
                if (result.IsSuccess) {
                    Krankenkassen.Clear();
                    _originalValues.Clear();
                    foreach (var kk in result.Value) {
                        //for the performance and complexity
                        var vv = new KrankenkasseViewModel(kk);
                        _krankenkassen.Add(vv);
                        _originalValues.Add(vv);
                    }
                }
                else {
                    MessageBox.Show($"Error Occured : {result.Error}");
                }
                
            }

        }
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }


    }
}
