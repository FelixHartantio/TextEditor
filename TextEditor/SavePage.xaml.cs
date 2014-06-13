using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace TextEditor
{
    public partial class SavePage : PhoneApplicationPage
    {
        public App app = (App)Application.Current;
        public SavePage()
        {
            InitializeComponent();
            ApplicationTitle.Text = "TEXT EDITOR";
            PageTitle.Text = "save";
            Loaded += (object sender, RoutedEventArgs e) =>
            {
                if (app.Filename == "")
                {
                    nama.Text = "untitled.txt";
                    //Filename.Text = "untitled.txt";
                }
                else
                {
                    nama.Text = app.Filename;
                    //Filename.Text = app.Filename;
                }
            };
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (nama.Text != "")
            {
                try
                {
                    app.Filename = nama.Text.Trim().ToLower();
                    using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        IsolatedStorageFileStream location = new IsolatedStorageFileStream(app.Filename,
                        System.IO.FileMode.Create, storage);
                        System.IO.StreamWriter file = new System.IO.StreamWriter(location);
                        file.Write(app.Content);
                        file.Dispose();
                        location.Dispose();
                    }
                    NavigationService.GoBack();
                }
                catch
                {
                    // Ignore Errors
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}