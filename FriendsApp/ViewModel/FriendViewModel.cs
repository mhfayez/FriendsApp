using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Contacts;
using Windows.Storage;
using FriendsApp.Common;
using FriendsApp.Model;
using JetBrains.Annotations;


namespace FriendsApp.ViewModel
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        private readonly FriendCatalog _friendCatalog;
        private readonly DeleteCommand _deletionCommand;
        private string _imageSource;

        public FriendViewModel()
        {
            _friendCatalog =  new FriendCatalog();

            //use when FriendsCatalog is Singleton
           // _friendCatalog = FriendCatalog.Instance;

            AddContactCommand = new RelayCommand(AddFriend);
            _deletionCommand = new DeleteCommand(_friendCatalog, this);
        }

        public ICommand AddContactCommand { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        
        public string ImageSource
        {
            get => _imageSource;
            set => _imageSource = "..\\Assets\\" + value;
            
        }

        public Friend SelectedFriend
        {
            get => _friendCatalog.SelectedItem;
            set
            {
                _friendCatalog.SelectedItem = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }
        
        public DeleteCommand DeletionCommand => _deletionCommand;

        public ObservableCollection<Friend> FriendsCollection => _friendCatalog.Friends;

        public void AddFriend()
        {
            _friendCatalog.AddFriend(new Friend(Name, Phone, Country, ImageSource));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
