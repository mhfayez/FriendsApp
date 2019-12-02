using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FriendsApp.Model
{
    public class Friend
    {

        public Friend(string name, string phone, string country, string image)
        {
            Name = name;
            Phone = phone;
            Country = country;
            ImageLink = image;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string ImageLink { get; set; }
    }
}
