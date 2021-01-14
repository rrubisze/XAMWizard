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

        public ObservableCollection<string> Labels { get; set; } = new ObservableCollection<string>(new List<string>() { "Label33", "Label333", "Label12345", "Label12", "Label123", "DosLabel" });
    }
}
