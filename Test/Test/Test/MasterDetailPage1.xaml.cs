using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public MasterDetailPage1()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage1MenuItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;
            if (item.Id == 0)
            {
                Detail = new NavigationPage(new MainPage());
                IsPresented = false;
            }
            if (item.Id == 1)
            {
                Detail = new NavigationPage(new ListViewPage1());
                IsPresented = false;
            }
            if (item.Id == 2)
            {
                Detail = new NavigationPage(new ApplyLeaves());
                IsPresented = false;
            }
            if (item.Id == 3) 
            {
                Detail = new NavigationPage(new Rally());
                IsPresented = false;
            }
            if (item.Id == 4)
            {
                Detail = new NavigationPage(new SkillChart());
                IsPresented = false;
            }



            MasterPage.ListView.SelectedItem = null;
        }
    }
}