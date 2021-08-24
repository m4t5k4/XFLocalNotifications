using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFLocalNotifications
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NotificationCenter.Current.NotificationActionTapped += Current_NotificationTapped;
        }

        private void Current_NotificationTapped(NotificationActionEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Notification tapped", e.Request.Description, "ok");
            });
            
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Schedule = new NotificationRequestSchedule { NotifyTime = DateTime.Now.AddSeconds(5) }
            };

            await NotificationCenter.Current.Show(notification);
        }
    }
}
