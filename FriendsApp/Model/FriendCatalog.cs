using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsApp.Model
{
    public class FriendCatalog
    {
         // use with singleton example
        // private static FriendCatalog _instance = null;

        //add keyword static to preserve the list
        //remove static to show the difference i.e the list is not preserved
        public ObservableCollection<Friend> _friendsCollection = new ObservableCollection<Friend>
        {
            new Friend("allan", "123", "dk", "..\\Assets\\benny.jpg"),
            new Friend("Ann", "234", "us", "..\\Assets\\ann.jpg"),
            new Friend("Carol", "345", "Gb", "..\\Assets\\carol.jpg")
        };

        public FriendCatalog() { }

       /*
        //use to create singleton
        private FriendCatalog() { }

            //use to return the only instance of the singleton 
        public static FriendCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FriendCatalog();
                }
                return _instance;
            }
        }
        */

        public  Friend SelectedItem { get; set; }

        public ObservableCollection<Friend> Friends => _friendsCollection;

        public void AddFriend(Friend f)
        {
            _friendsCollection.Add(f);
        }

        public void Delete(string phone)
        {
            var contact = _friendsCollection.FirstOrDefault(c => c.Phone == phone);
            _friendsCollection.Remove(contact);
        }

    }
}
