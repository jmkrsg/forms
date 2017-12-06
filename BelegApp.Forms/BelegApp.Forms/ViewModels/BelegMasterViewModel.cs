﻿using BelegApp.Forms.Models;
using BelegApp.Forms.Services;
using BelegApp.Forms.Utils;
using BelegApp.Forms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static BelegApp.Forms.Models.Beleg;

namespace BelegApp.Forms.ViewModels
{
    public class BelegMasterViewModel : BaseViewModel
    {
        private ObservableCollection<BelegDetailsViewModel> _belege;
        public BelegMasterViewModel(INavigation navigation) : this(navigation, null)
        {
        }

        public BelegMasterViewModel(INavigation navigation, Beleg[] belegList)
        {
            AddNewBelegCommand = new Command(() =>
            {
                navigation.PushAsync(new DetailPage(null, navigation));
            });
            
            Belege = new ObservableCollection<BelegDetailsViewModel>(); // Ladeoperation von Service

            if (belegList != null)
            {
                foreach (Beleg beleg in belegList)
                {
                    _belege.Add(new BelegDetailsViewModel(beleg));
                }
            }
        }

        public ObservableCollection<BelegDetailsViewModel> Belege
        {
            get
            {
                return _belege;
            }
            set
            {
                if (Equals(_belege, value)) return;
                _belege = value;
                OnPropertyChanged(nameof(Belege));
            }
        }

        public ICommand AddNewBelegCommand { get; private set; }
        public ICommand ExportBelegeCommand { get; private set; }
        public ICommand SelectBelegeCommand { get; private set; }
        public ICommand DeleteBelegeCommand { get; private set; }
    }
}
