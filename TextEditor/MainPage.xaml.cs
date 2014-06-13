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
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
using System.Text;
using System.IO;
using System.Windows.Data;

namespace TextEditor
{

    public partial class MainPage : PhoneApplicationPage
    {

        //string xxx = "";
        private Popup popup;
        private BackgroundWorker backroungWorker;
        public List<string> words;
        Dcontext db;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Dcontext("isostore:/Data.sdf");
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            words = new List<string>();
            foreach (Data1 a in db.mhs)
            {
                words.Add(a.kata.ToString());
            }
            //words.Add("Study");
            //words.Add("Don't Give Up!");
            //words.Add("Nothing is useless");
            //words.Add("Fighting!");
            //words.Add("Thank you");
            //words.Add("Arigatou Goshaimas");
            //words.Add("Mathur Nuwun");
            //words.Add("I'm still Standing in Here");
            //words.Add("Fear is Nothing");
            //words.Add("We are born to do something");
            //words.Add("Friendship is ");
            //words.Add("Sometimes let the storm begone, and you'll see the beautifull rainbow");
            //words.Add("I will become ");

            autotxt.ItemsSource = words;
            //autotxt.ItemsSource = words;
            if (app.Content != null)
            {
                Editor.Text = (string)app.Content;
                autotxt.Text = "";
            }
            if (app.Filename != "")
            {
                PageTitle.Text = app.Filename;
            }
            else
            {
                PageTitle.Text = "untitled.txt";
            }
            //FeedbackOverlay.VisibilityChanged += FeedbackOverlay_VisibilityChanged;
        }

        /*void FeedbackOverlay_VisibilityChanged(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = (FeedbackOverlay.Visibility != Visibility.Visible);
        }*/

        //protected override void  OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    var askforReview = (bool)IsolatedStorageSettings.ApplicationSettings["askforreview"];
        //    if (askforReview)
        //    {
        //        //make sure we only ask once!
        //        IsolatedStorageSettings.ApplicationSettings["askforreview"] = false;
        //        var returnvalue = MessageBox.Show("Thank you for using TextLight for a while now, would you like to review this app?", "Please review my app", MessageBoxButton.OKCancel);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }
        //        else
        //        {
        //            var last = MessageBox.Show("Sorry To Hear You didn't want to rate TextLight.","Tells us about your experience or suggest how we can make it even better.", MessageBoxButton.OKCancel);
        //            if (last == MessageBoxResult.OK)
        //            {
                        
        //            }
        //        }
        //    }
        //}
        public App app = (App)Application.Current;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ShowSplash();
            ApplicationTitle.Text = "TEXT EDITOR";
            PageTitle.Text = "untitled.txt";
            this.autotxt.SelectionChanged += new SelectionChangedEventHandler(autotxt_SelectionChanged);
            
            Loaded += PhoneApplicationPage_Loaded;
            
        }

        //private void BSave(object sender, RoutedEventArgs e)
        //{
        //    Data1 n = new Data1 { kata = textBox1.Text };
        //    db.mhs.InsertOnSubmit(n);
        //    db.SubmitChanges();
        //    textBox1.Text = "";
        //    autotxt.ItemsSource = db.mhs.ToList();
        //}

        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new SplashScreenControl();
            this.popup.IsOpen = true;
            StartLoadingData();
        }

        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
            }
            );
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //here we can load data
            Thread.Sleep(7000);
        }
        


        void autotxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autotxt.SelectedItem != null && autotxt.SelectedItem.ToString() != string.Empty)
           {
               Editor.Text += autotxt.SelectedItem + " ";
               autotxt.SelectedItem = "";
               Editor.Focus();
           }

        }
        private void New_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Start a new Document?", "Text Editor",
            MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                PageTitle.Text = "untitled.txt";
                Editor.Text = "";
                app.Filename = PageTitle.Text;
                app.Content = Editor.Text;
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            app.Content = Editor.Text;
            NavigationService.Navigate(new Uri("/OpenPage.xaml", UriKind.Relative));
        }

        private void Data_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Data.xaml", UriKind.Relative));
        }

        private void Send_Click(object sender, EventArgs e)
        {
            ShareStatusTask n = new ShareStatusTask();
            n.Status = Editor.Text;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            app.Content = Editor.Text;
            NavigationService.Navigate(new Uri("/SavePage.xaml", UriKind.Relative));
        }

        private void Help_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Caption = "Apakah anda yakin",
                Message = "Anda akan keluar dari aplikasi ini",
                LeftButtonContent = "yes",
                RightButtonContent = "no",
                IsFullScreen = false
            };
            messageBox.Dismissed += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        MessageBox.Show("Anda memilih Yes");
                        break;
                    case CustomMessageBoxResult.RightButton:
                        MessageBox.Show("Anda memilih No");
                        break;
                    case CustomMessageBoxResult.None:
                        // Do something.
                        break;
                    default:
                        break;
                }
            };
            messageBox.Show();
        }*/
    }
}