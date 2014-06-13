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
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace TextEditor
{
    [Table]
    public class Data1
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity")]
        public int id { get; set; }

        [Column]
        public string kata { get; set; }

    }
    public class Dcontext : DataContext
    {
        public Table<Data1> mhs;
        public Dcontext(string connectionstring) : base(connectionstring) { }

    }
}
