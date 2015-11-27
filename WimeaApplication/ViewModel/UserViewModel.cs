using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WimeaApplication.Helpers;
using WimeaLibrary;

namespace WimeaApplication.ViewModel
{

    public class UserViewModel : ObservableObject
    {
        private ObservableCollection<User> _UsersList;
        private User _currentUser;
      
        private ICommand _saveCommand;
        private ICommand _addCommand;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private bool IsNew;
       

        public ObservableCollection<User> Users { get { return _UsersList; } }

        public UserViewModel()
        {
            RefreshUserList();          
        }

        private void RefreshUserList()
        {
            _UsersList = new ObservableCollection<User>(App.WimeaApp.Users);    
        }
        
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (value != _currentUser)
                {
                    _currentUser = value;
                    OnPropertyChanged("CurrentUser");
                }
            }
        }       
      
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => SaveUser()
                      
                    );
                }
                return _saveCommand;
            }
        }

        private void SaveUser()
        {
           
                CurrentUser.Save();
              //  RefreshUserList();
                _UsersList.Add(CurrentUser);
                IsNew = false;
        }  

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        param => AddUser()
                       
                    );
                }
                return _addCommand;
            }
        }       

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(
                        param => UpdateUser()
                       
                    );
                }
                return _updateCommand;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => DeleteUser()
                              
                    );
                }
              //  _UsersList = App.WimeaApp.Users;

                return _deleteCommand;
            }
        
        }

        private void DeleteUser()
        {

            try
            {
                CurrentUser.Delete();
                _UsersList.Remove(CurrentUser);
                //  RefreshUserList();
            }
            catch { 
            
            }
               
            
          
        }

        private void UpdateUser()
        {
           // CurrentUser.Update();
        }
        private void AddUser()
        {

            if (!IsNew)
            {
                IsNew = true;

                CurrentUser = App.WimeaApp.Users.Add();

            }
        }
       
        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }
}
