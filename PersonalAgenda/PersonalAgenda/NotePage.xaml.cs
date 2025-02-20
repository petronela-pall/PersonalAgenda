﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAgenda.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAgenda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        async void OnSaveButtonClicked(object sender, EventArgs e) 
        { 
            var note = (Agenda)BindingContext; 
            note.Date = DateTime.UtcNow; await App.Database.SaveNoteAsync(note); 
            await Navigation.PopAsync(); 
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e) 
        { 
            var note = (Agenda)BindingContext; 
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync(); 
        }
        public NotePage()
        {
            InitializeComponent();
        }
    }
}