using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        
        //private const string Url = "http://skillmatrixws.azurewebsites.net/api/Todo/Mohan"; //This url is a free public api intended for demos
        ////private const string Url = "http://jsonplaceholder.typicode.com/posts"; //This url is a free public api intended for demos
        //private readonly HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)
        ////private ObservableCollection<List> _posts; //Refreshing the state of the UI in realtime when updating the ListView's Collection


        //List<string> skills = new List<string>();

        public ListViewPage1()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
			
			MyListView.ItemsSource = Items;
        }
        //protected override async void OnAppearing()
        //{
        //    string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
        //    List posts = JsonConvert.DeserializeObject<List>(content); //Deserializes or converts JSON String into a collection of Post
        //    //_posts = new ObservableCollection<List>(posts); //Converting the List to ObservalbleCollection of Post
        //    //MyListView.ItemsSource = posts; //Assigning the ObservableCollection to MyListView in the XAML of this file
        //    //skills.Add("Name  :" + posts.name.ToString());
        //    //skills.Add("PCF     :"+posts.pcf.ToString());
        //    //skills.Add("C#.Net:" + posts.csharpdotnet.ToString());
        //    //skills.Add("Azure   :" + posts.azure.ToString());
        //    //skills.Add("Java    :" + posts.java.ToString())

        //    //skills.Add("Name  :" + posts.name.ToString());
        //    //skills.Add("PCF     :" + coverter(posts.pcf));
        //    //skills.Add("C#.Net:" + coverter(posts.csharpdotnet));
        //    //skills.Add("Azure   :" + coverter(posts.azure));
        //    //skills.Add("Java    :" + coverter(posts.java));



        //    Items = new ObservableCollection<string>()
        //    {
        //    "Item 1",
        //    "Item 2",
        //    "Item 3",
        //    "Item 4",
        //    "Item 5"
        //    };

        //    //for (int i = 0; i < skills.Count; i++)
        //    //{
        //    //    Items.Add(skills[i]);
        //    //}

        //    MyListView.ItemsSource = Items;
        //    //string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
        //    //List<List> posts = JsonConvert.DeserializeObject<List<List>>(content); //Deserializes or converts JSON String into a collection of Post
        //    //_posts = new ObservableCollection<List>(posts); //Converting the List to ObservalbleCollection of Post
        //    //MyListView.ItemsSource = posts; //Assigning the ObservableCollection to MyListView in the XAML of this file
        //    base.OnAppearing();
        //}

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
