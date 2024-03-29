﻿using Caliburn.Micro;
using CaliburnPlayGround.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CaliburnPlayGround.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly DashboardViewModel _dashboardvm;
        private List<string> _items;

        private string outputText;

        public string OutputText
        {
            get { return outputText; }
            set
            {
                outputText = value;
                NotifyOfPropertyChange(() => OutputText);
            }
        }


        public BindableCollection<string> ComboboxOptions
        {
            get
            {
                return new BindableCollection<string>()
                {
                    "yes",
                    "no",
                    "may be",
                    "indetermined"
                };

            }
        }


        public List<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }


        public BindableCollection<Person> Persons
        {
            get
            {
                return new BindableCollection<Person>()
                {
                    new Person()
                    {
                        Name="Someone",
                        Age=22
                    },
                    new Person()
                    {
                        Name="Noone",
                        Age=22
                    },
                    new Person()
                    {
                        Name="Anyone",
                        Age=22
                    }

                };
            }
        }

        public record Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }



        public LoginViewModel(IEventAggregator eventAggregator, DashboardViewModel dashboardvm)
        {
            _eventAggregator = eventAggregator;
            _dashboardvm = dashboardvm;
        }

        public bool CanLogin(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        public void Login(string username, string password) //binds the 2 textboxes(Username, Password) automatically [case insensitive]
        {
            if (username.Length > 3 && !string.IsNullOrWhiteSpace(password))
                _eventAggregator.PublishOnUIThreadAsync(_dashboardvm);
        }

        public async Task StartAsync()
        {
            OutputText = "Entering into heavy task";
            await Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    OutputText = $"In the heavy task with thread {Thread.CurrentThread.ManagedThreadId} --${i}";
                    if (i == 99999)
                    {
                        OutputText = "Last iteration reached";
                    }
                }
            });
            OutputText = "About to exit StartAsync";
            OutputText = "---------------------------------------------------------------------------------------------";
            await Task.Delay(1000);
        }

        

        //public void Login(object view)
        //{
        //    var v = view as LoginView;
        //    //use event agregator to raise an event and handle it in main view model.
        //    if (v.Username.Text.Length > 3 && !string.IsNullOrWhiteSpace(v.Password.Text))
        //        _eventAggregator.PublishOnUIThreadAsync(_dashboardvm);
        //}

    }
}
