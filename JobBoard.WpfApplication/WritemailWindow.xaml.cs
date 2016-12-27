﻿using JobBoard.Core;
using JobBoard.Core.Control;
using JobBoard.Core.Entity;
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

namespace JobBoard.WpfApplication
{
    /// <summary>
    /// Interaction logic for WritemailWindow.xaml
    /// </summary>
    public partial class WritemailWindow : Window
    {
        User userRef;
        MailboxControl mbc = new MailboxControl();

        public WritemailWindow(User usr)
        {
            InitializeComponent();
            this.userRef = usr;
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            //save message to draft.
            this.Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            string body = new TextRange(msgbodyRTBox.Document.ContentStart, msgbodyRTBox.Document.ContentEnd).Text;
            Mail newmail = new Mail(subjBox.Text, body, userRef.UserName, recipientBox.Text, DateTime.Now, 0);
            mbc.NewMail(newmail);
            this.Close();
        }

        private void draftBtn_Click(object sender, RoutedEventArgs e)
        {
            string body = new TextRange(msgbodyRTBox.Document.ContentStart, msgbodyRTBox.Document.ContentEnd).Text;
            Mail newmail = new Mail(subjBox.Text, body, userRef.UserName, recipientBox.Text, DateTime.Now, 1);
            mbc.NewMail(newmail);
            this.Close();
        }
    }
}
