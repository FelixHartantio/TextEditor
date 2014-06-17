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
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();
            textBox1.Text = "Hello! Welcome to this Apps.\n This Apps have 6 features: New, Open, Save, and Help. You can choose one of that features. All of Features is simple.\n1.Open\n Choose the file You want to Open.\n2.Save\nTo Save Your Text.\n3.New\nTo make new Project\n4.Help\nTo Explain All Features.\n5.Send\n To Share in user social Media status.\n6.Data\nTo Save data in local database.";
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}