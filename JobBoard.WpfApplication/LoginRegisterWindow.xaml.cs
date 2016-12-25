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
using JobBoard.Core;
using JobBoard.Core.Control;
using JobBoard.Core.Entity;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginRegister : Window
    {
        DBConnectionControl connectionControl;
        LoginRegistrationControl loginRegistrationControl;


        public LoginRegister()
        {
            connectionControl = new DBConnectionControl();
            loginRegistrationControl = LoginRegistrationControl.getInstance();
            InitializeComponent();
        }


        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LoginRegisterWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LRProceed_Click(object sender, RoutedEventArgs e)
        {
            if (LRTabControl.SelectedIndex == 0)
            {
                if (loginRegistrationControl.login(LUsernameBox.Text, LPasswordBox.Password.ToString()))
                {
                    Profile jp = new Profile();
                    jp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username Password Mismatch");
                }
            }
            else if(LRTabControl.SelectedIndex == 1)
            {
                if (!loginRegistrationControl.checkUser(RUsernameBox.Text))
                {
                    if (RPassBox.Password.ToString() == RPassConfirmBox.Password.ToString())
                    {
                        loginRegistrationControl.register(RUsernameBox.Text, RPassBox.Password.ToString());
                        User.currentUser.UserName = RUsernameBox.Text.Trim();
                        ChooseProfile cp = new ChooseProfile();
                        cp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Passwords don't match");
                    }
                }
                else
                {
                    MessageBox.Show("An Account is already created with this Username");
                }
            }
        }
    }
}
