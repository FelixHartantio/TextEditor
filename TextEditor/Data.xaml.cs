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

namespace TextEditor
{
    public partial class Data : PhoneApplicationPage
    {
        public Data()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Data_Loaded);
        }

        Dcontext db;
        void Data_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Dcontext("isostore:/Data.sdf");
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            RefreshData();
        }

        private void btn_del(object sender, RoutedEventArgs e)
        {
            using (Dcontext dd = new Dcontext("isostore:/Data.sdf"))
            {
                IQueryable<Data1> DQuery = from ddc in dd.mhs where ddc.kata == textBox1.Text select ddc;
                Data1 DRemove = DQuery.FirstOrDefault();
                dd.mhs.DeleteOnSubmit(DRemove);
                dd.SubmitChanges();
            }
            NavigationService.GoBack();
        }
        private void Back_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Data1 n = new Data1 { kata = textBox1.Text};
            db.mhs.InsertOnSubmit(n);
            db.SubmitChanges();
            textBox1.Text = "";
            RefreshData();
        }
        public void RefreshData()
        {
            MainListBox.ItemsSource = db.mhs.ToList();
        }
    }
}