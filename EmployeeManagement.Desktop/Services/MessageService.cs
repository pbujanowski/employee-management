using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EmployeeManagement.Desktop.Services
{
    public static class MessageService
    {
        public static MessageBoxResult ShowError(string message)
        {
            return MessageBox.Show(message, "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
