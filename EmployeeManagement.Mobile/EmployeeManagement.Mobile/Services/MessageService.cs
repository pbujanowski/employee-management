using EmployeeManagement.Mobile.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EmployeeManagement.Mobile.Services
{
    public static class MessageService
    {
        public static void DisplayAlert(object sender, string message)
        {
            MessagingCenter.Send(sender, Message.DisplayAlert, message);
        }
    }
}
