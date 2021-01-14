using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wizard
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public ObservableCollection<string> Labels { get; set; } = new ObservableCollection<string>(new List<string>() { "Item1", "Item2", "Item3", "Item4", "Item5" });
    }
}
