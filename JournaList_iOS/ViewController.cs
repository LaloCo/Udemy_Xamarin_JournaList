using System;
using JournaList_PCL;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;

namespace JournaList_iOS
{
    public partial class ViewController : UIViewController
    {
        private MobileServiceUser user;
        public MobileServiceUser User
        {
            get { return user; }
        }

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            this.NavigationController.SetNavigationBarHidden(true, false);

            enterWithFacebookButton.TouchUpInside += EnterWithFacebookButton_TouchUpInside;
        }

        async void EnterWithFacebookButton_TouchUpInside (object sender, EventArgs e)
        {
            try
            {
                user = await JournaList_PCL.User.MobileService.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                await JournaList_PCL.User.MobileService.GetTable<User>().InsertAsync(new User());
                this.PerformSegue("loginSegue", this);
            }
            catch(Exception ex)
            {
                if (ex.Message == "The server did not provide a response with the expected content.")
                {
                    this.PerformSegue("loginSegue", this);
                }
                else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                            Message = ex.Message,
                            Title = "Error"
                    };

                    alert.AddButton("Ok");
                    alert.Show();
                }
            }
        }

        public override bool ShouldPerformSegue(string segueIdentifier, Foundation.NSObject sender)
        {
            if (segueIdentifier == "loginSegue")
            {
                return false;
            }
            return true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

