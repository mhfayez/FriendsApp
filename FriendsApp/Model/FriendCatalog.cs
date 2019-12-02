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

        // if the Collection is not static then the list or SelectedFriend will not
        //be available when you navigate to another page in the view
        //In order to see the SelectedFriend or the Collection on a new page/view then the ObservableCollection and the SelectedFriend property should be static
        //add keyword static to preserve the list
        //remove static to show the difference i.e the list is not preserved
        public ObservableCollection<Friend> _friendsCollection = new ObservableCollection<Friend>
        {
            new Friend("allan", "123", "dk", "..\\Assets\\benny.jpg"),
            new Friend("Ann", "234", "us", "..\\Assets\\ann.jpg"),
            new Friend("Carol", "345", "Gb", "..\\Assets\\carol.jpg")
        };


        //remove when using singleton
        // public FriendCatalog() { }

        /*
         //singleton constructor and Instance property
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

            public static Friend SelectedFriend { get; set; }
         */

        public Friend SelectedFriend { get; set; }

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
