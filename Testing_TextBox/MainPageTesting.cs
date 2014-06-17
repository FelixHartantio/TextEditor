using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Phone.Shell;


namespace Testing_TextBox
{
    [TestClass]
    public class MainPageTesting : SilverlightTest
    {
        [TestMethod]
        public void alwaysTrue()
        {
            Assert.IsTrue(true, "This Method Always Pass");
        }
        [TestMethod]
        [Description("Check Apakah MainPage dibuat tanpa adanya problem")]
        public void CheckMainPage()
        {
            TextEditor.MainPage VPage = new TextEditor.MainPage();
            Assert.IsNotNull(VPage);
        }

    }
}
