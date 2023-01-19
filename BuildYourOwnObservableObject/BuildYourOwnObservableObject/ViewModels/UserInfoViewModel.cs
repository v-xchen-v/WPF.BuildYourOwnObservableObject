﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildYourOwnObservableObject.ViewModels
{
    internal class UserInfoViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstName)));
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(LastName)));
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public UserInfoViewModel()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    //FirstName = new Random().Next(1, 1000).ToString();
                    Debug.WriteLine($"FirstName: {FirstName}");
                    Debug.WriteLine($"LastName: {LastName}");
                    Debug.WriteLine($"FullName: {FullName}");
                    Thread.Sleep(500);
                }
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(sender, e);
            }
        }
    }
}
