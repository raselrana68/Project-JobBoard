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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for UserOverviewUC.xaml
    /// </summary>
    public partial class JSUserOverviewUC : UserControl
    {
        User userRef;

        public JSUserOverviewUC(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
            PopulateUO();
        }

        private void SearchJob_Click(object sender, RoutedEventArgs e)
        {
            SearchJobWindow sj = new SearchJobWindow();
            sj.Show();
        }

        private void PopulateUO()
        {
            uwelcomeLabel.Content += userRef.FirstName;
            unameLabel.Content += userRef.UserName;
            uemailLabel.Content = userRef.Email;
            ulocationLabel.Content = userRef.Location;
            uphoneLabel.Content = userRef.PhoneNumber;
        }
    }
}
