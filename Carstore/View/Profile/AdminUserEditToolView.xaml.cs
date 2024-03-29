﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Carstore.View;
using Carstore.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace Carstore.View.Profile
{
    /// <summary>
    /// Interaction logic for AdminUserEditToolView.xaml
    /// </summary>
    public partial class AdminUserEditToolView : UserControl
    {

        private CarstoreDBEntities _db;
        private DbContextTransaction _tran;
        private List<User> _users;

        public AdminUserEditToolView()
        {
            InitializeComponent();
            _db = new CarstoreDBEntities();
            if (_db.User.Find(MainWindow.SelectedUserId).UserType.Name != "userType_Admin")
            {
                MessageBox.Show("This is admin tool!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _db.Dispose();
                Application.Current.Shutdown();
            }
            _tran = _db.Database.BeginTransaction();
            ShowUsers();
        }

        private void ShowUsers()
        {
            _users = _db.User
                .Where(u => u.UserType.Name != "userType_Admin")
                .ToList();
            dg.ItemsSource = new Collection<UserRoleModel>(_users
                .Select(u => new UserRoleModel(u))
                .ToList());
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.SelectedItem is UserRoleModel user)
            {
                switch (user.Role)
                {
                    case "userType_User":
                        UserButton.IsEnabled = false;
                        ModeratorButton.IsEnabled = true;
                        break;
                    case "userType_Moderator":
                        UserButton.IsEnabled = true;
                        ModeratorButton.IsEnabled = false;
                        break;
                }
            }
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            UserButton.IsEnabled = false;
            try
            {
                User user = _db.User.Find((dg.SelectedItem as UserRoleModel).Id);
                if (user != null)
                {
                    user.TypeId = _db.UserType.FirstOrDefault(t => t.Name == "userType_User").Id;
                }
                _db.SaveChanges();
            }
            catch { }
            ShowUsers();
        }

        private void ModeratorButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            ModeratorButton.IsEnabled = false;
            try
            {
                User user = _db.User.Find((dg.SelectedItem as UserRoleModel).Id);
                if (user != null)
                {
                    user.TypeId = _db.UserType.FirstOrDefault(t => t.Name == "userType_Moderator").Id;
                }
                _db.SaveChanges();
            }
            catch { }
            ShowUsers();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _tran?.Rollback();
            _tran?.Dispose();
            _db?.Dispose();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _tran.Rollback();
            _tran.Dispose();
            _db.Dispose();
            _db = new CarstoreDBEntities();
            _tran = _db.Database.BeginTransaction();
            SaveButton.IsEnabled = false;
            ShowUsers();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _tran.Commit();
            _tran.Dispose();
            _tran = _db.Database.BeginTransaction();
            SaveButton.IsEnabled = false;
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dg.ItemsSource = new Collection<UserRoleModel>(_users
                .Where(x => string.IsNullOrWhiteSpace(NameBox.Text) || $"{x.Firstname} {x.Lastname}".Contains(NameBox.Text))
                .Select(u => new UserRoleModel(u))
                .ToList());
        }
    }
}
