using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MsgBox
{
    public partial class MainWindow : Window
    {
        private List<string> allMessages = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageBoxTextBox.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                string formattedMessage = $"{DateTime.Now}: {message}";
                allMessages.Add(formattedMessage); // Add formatted message to the list
                UpdateMessagesListBox(); // Update ListBox with all messages
                MessageBoxTextBox.Text = ""; // Clear the message box after sending
            }
            else
            {
                MessageBox.Show("Please enter a message first.");
            }
        }

        private void DeleteMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessagesListBox.SelectedItem != null)
            {
                string selectedMessage = MessagesListBox.SelectedItem.ToString();
                allMessages.Remove(selectedMessage); // Remove selected message from the list
                UpdateMessagesListBox(); // Update ListBox with updated messages
            }
            else
            {
                MessageBox.Show("Please select a message to delete.");
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMessagesListBox();
        }

        private void UpdateMessagesListBox()
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredMessages = allMessages.Where(msg => msg.ToLower().Contains(searchText)).ToList();
            MessagesListBox.ItemsSource = null; // Clear ListBox items source
            MessagesListBox.ItemsSource = filteredMessages; // Update ListBox with filtered messages
        }
    }
}
