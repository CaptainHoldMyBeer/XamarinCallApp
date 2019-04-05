using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Essentials;
namespace PhoneBook
{
    public class CallPage : ContentPage
    {
        public Person Person { get; set; }

        public CallPage(Person person)
        {
            Person = person;
            string str = person.Image;


            Label label = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = person.Name.ToString(),
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Image img = new Image
            {
                
                Source = str
            };

            Label label2 = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = person.Number.ToString(),
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Button callButton = new Button
            {
                Text = "Call",
                BackgroundColor = Color.Green,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            this.Content = new StackLayout { Children = { label, img, label2, callButton } };


            callButton.Clicked += async (o, e) =>
              {
                  PhoneDialer.Open(person.Number);
              };

        }

    }
}