using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SchoolOpenDays.ApiConnection;
using SchoolOpenDays.Models;

namespace SchoolOpenDays
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<ForcesModel> forces = Forces.GetForces();
        }
    }
}
