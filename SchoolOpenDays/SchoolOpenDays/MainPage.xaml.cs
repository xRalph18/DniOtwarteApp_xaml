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

namespace SchoolOpenDays
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<ForcesModel> forces = Forces.GetForces();
            List<ForceDetailModel> detailedForces = new List<ForceDetailModel>();

            foreach (var item in forces)
            {
                detailedForces.Add(Forces.GetForceDetail($"{item.id}"));
            }

            listView.ItemsSource = detailedForces;
        }
    }
}
