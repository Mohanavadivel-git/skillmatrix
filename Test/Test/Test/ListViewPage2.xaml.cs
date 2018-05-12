using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage2 : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        //private const string Url = "http://skillmatrixws.azurewebsites.net/api/Todo/Mohan"; //This url is a free public api intended for demos
        private string Url = "http://skillmatrixws.azurewebsites.net/api/Todo/"; //This url is a free public api intended for demos
        private readonly HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)
        public List<string> skills = new List<string>();

        public ListViewPage2(List V)
        {
            InitializeComponent();
            Url = Url+V.Name;
    }    
        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            List posts = JsonConvert.DeserializeObject<List>(content); //Deserializes or converts JSON String into a collection of Post
            
            skills.Add("Name  :" + posts.Name.ToString());
            skills.Add("CSharpDotnet:" + coverter(posts.CSharpDotnet));
            skills.Add("Java    :" + coverter(posts.Java));
            skills.Add("Azure   :" + coverter(posts.Azure));
            skills.Add("PCF     :" + coverter(posts.PCF));
            skills.Add("ServiceFabric     :" + coverter(posts.ServiceFabric));
            skills.Add("Microservices     :" + coverter(posts.Microservices));
            skills.Add("DocumentDB     :" + coverter(posts.DocumentDB));
            skills.Add("VSDNFunctional     :" + coverter(posts.VSDNFunctional));
            skills.Add("AutomationTesting     :" + coverter(posts.AutomationTesting));
            skills.Add("ExploratoryTesting     :" + coverter(posts.ExploratoryTesting));
            skills.Add("IntegrationTesting     :" + coverter(posts.IntegrationTesting));
            skills.Add("Agile     :" + coverter(posts.Agile));
            skills.Add("BusinessAnalytics     :" + coverter(posts.BusinessAnalytics));

            Items = new ObservableCollection<string>();

            for (int i = 0; i < skills.Count; i++)
            {
                Items.Add(skills[i]);
            }

            MyListView.ItemsSource = Items;
            base.OnAppearing();
        }

        public string coverter(decimal value)
        {
            if (value == 0.0m)
            {
                return "NO KNOWLEDGE";
            }
            if (value == 1.0m)
            {
                return "BEGINNER";
            }
            else if (value == 2.0m)
            {
                return "INTERMIDIATE";
            }
            else
            {
                return "EXPERT";
            }
        }
        public decimal reversecoverter(string value)
        {
            if (value == "NO KNOWLEDGE")
            {
                return 0.0m;
            }
            if (value == "BEGINNER")
            {
                return 1.0m;
            }
            else if (value == "INTERMIDIATE")
            {
                return 2.0m;
            }
            else
            {
                return 3.0m;
            }
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            List posts = JsonConvert.DeserializeObject<List>(content); //Deserializes or converts JSON String into a collection of Post
            string content2 = content;
            string currentitem;
            currentitem = e.Item.ToString();
            var jObject = JObject.Parse(content);
            int value12 = currentitem.IndexOf(':');
            string content3 = currentitem.Substring(0, value12).Trim();

            //JArray experiencesArrary = (JArray)jObject["PCF"];
            if (e.Item == null || content3 == "Name")
            {
                Debug.WriteLine("Action: " +"Name Clicked");
            }                
            else
            {
                var action = await DisplayActionSheet(e.Item.ToString(), "CANCEL", "UPDATE", "BEGINNER", "INTERMIDIATE", "EXPERT");


                jObject[content3] = reversecoverter(action);
                // create the request content and define Json  
                var json = JsonConvert.SerializeObject(jObject);
                var content_1 = new StringContent(json, Encoding.UTF8, "application/json");

                //  send a POST request
                var result = await _client.PutAsync(Url, content_1);

                // on error throw a exception  
                result.EnsureSuccessStatusCode();

                // handling the answer  
                //var resultString = await result.Content.ReadAsStringAsync();
                //List posts = JsonConvert.DeserializeObject<List>(resultString);


                //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
                Debug.WriteLine("Action: " + action);
                //Deselect Item
                ((ListView)sender).SelectedItem = null;
            }
            
        }
    }
}
