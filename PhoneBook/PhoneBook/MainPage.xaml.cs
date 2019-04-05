using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
 

namespace PhoneBook
{
    public partial class MainPage : ContentPage
    {
        public List<Person> Persones { get; set; }
        public MainPage()
        {
            Persones = new List<Person>
            {
                new Person { Name = "Alex1", Image = "Alex1.jpg", Number = "+3753334350"},
                new Person { Name = "Alex2", Image = "Alex2.jpg", Number = "+3753334351" },
                new Person { Name = "Alex3", Image = "Alex3.jpg", Number = "+3753334352" },
                new Person { Name = "Alex4", Image = "Alex4.jpg", Number = "+3753334353" },
                new Person { Name = "Alex5", Image = "Alex5.jpg", Number = "+3753334354" },
                new Person { Name = "Alex6", Image = "Alex6.jpg", Number = "+3753334355" }

            };
            
            Label header = new Label
            {
                Text = "Список контактов",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = Persones,

                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Black, DetailColor = Color.Black };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    
                    Binding numberBinding = new Binding { Path = "Number" };
                    imageCell.SetBinding(ImageCell.DetailProperty, numberBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Image");
                    return imageCell;
                })
            };
            listView.ItemSelected += OnListViewItemSelected;
            this.Content = new StackLayout { Children = { header, listView } };


        }
        
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Person selectedPerson = args.SelectedItem as Person;
            if (selectedPerson != null)
            {
                
                await Navigation.PushAsync(new CallPage(selectedPerson));

            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Number { get; set; }
    }
}
