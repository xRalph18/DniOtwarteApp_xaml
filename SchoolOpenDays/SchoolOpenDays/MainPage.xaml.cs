using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SchoolOpenDays.ApiConnection;
using SchoolOpenDays.Models;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Collections;

namespace SchoolOpenDays
{
    public partial class MainPage : ContentPage
    {
        private List<ForceDetailModel> ForcesList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            List<ForcesModel> forces = Forces.GetForces();
            ForcesList = new List<ForceDetailModel>();

            foreach (var item in forces)
            {
                ForcesList.Add(Forces.GetForceDetail(item.id));
            }

            listView.ItemsSource = ForcesList;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = ForcesList.Where(s => s.name.ToLower().Replace(" ", "").Contains(e.NewTextValue.ToLower().Replace(" ", "")));
        }
    }
}
