using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendsApp.Model;
using FriendsApp.ViewModel;

namespace FriendsApp.Common
{
    public class DeleteCommand : ICommand
    {

        private FriendCatalog _catalog;
        private FriendViewModel _viewModel;

        public DeleteCommand(FriendCatalog catalog, FriendViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedFriend != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.Delete(_viewModel.SelectedFriend.Phone);
            // Set selection to null
            _viewModel.SelectedFriend = null;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
