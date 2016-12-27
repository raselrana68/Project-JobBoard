﻿using JobBoard.Core;
using System;
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
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for RecruiterRegistrationWindow.xaml
    /// </summary>
    public partial class JobSeekerRegistration : Window
    {
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();
        User currentUser = User.getInstance();
        ChooseProfile cpWindow;
        System.Drawing.Image profilePhoto = System.Drawing.Image.FromFile("profileimage.png");

        public JobSeekerRegistration(ChooseProfile cp)
        {
            InitializeComponent();
            this.cpWindow = cp;

            List<string> skillList = lrControl.getAvailableSkills();
            comboBox.ItemsSource = skillList;

            SetProfileimage();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RecruiterRegWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void JSRegProceed_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(bdyearBox.Text + "-" + bdmonthBox.Text + "-" + bddateBox.Text);

            List<string> skillList = new List<string>();
            foreach (Button skillButton in slctskillsPanel.Children)
            {
                currentUser.setSkill(skillButton.Content.ToString());
            }

            currentUser.addUser(firstnameBox.Text, lastnameBox.Text, emailBox.Text, phoneBox.Text, profilePhoto, date, locationBox.Text, skillList);
            lrControl.register(currentUser);
            Profile jp = new Profile(currentUser);
            jp.Show();
            this.Hide();
        }

        //If skill is selected from combo box
        bool alreadyAdded = false;
        private void JobSeekerRegWindow_LostFocus(object sender, RoutedEventArgs e)
        {
            Button skill = new Button();
            try
            {
                skill.Content = comboBox.SelectedItem.ToString();
                foreach (Button button in slctskillsPanel.Children)
                {
                    if (button.Content.ToString() == skill.Content.ToString())
                    {
                        alreadyAdded = true;
                    }
                        
                }
                if(alreadyAdded == false)
                {
                    slctskillsPanel.Children.Add(skill);
                }
                alreadyAdded = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void SetProfileimage()
        {
            using (Bitmap bmp = new Bitmap(profilePhoto))
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();

                profileImage.Source = bi;
            }
        }
    }
}
