using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using JournaList_PCL;

namespace JournaList_iOS
{
	partial class PostViewController : UIViewController
	{
		public PostViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            userNameLabel.Text = AppDelegate.user.Username;

            NSUrl url = new NSUrl(AppDelegate.user.PictureUrl);
            NSData data = NSData.FromUrl(url);
            userPictureImageView.Image = new UIImage(data);

            UIBarButtonItem cancelButton = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Plain, null);
            cancelButton.Clicked += CancelButton_Clicked;

            UIBarButtonItem postButton = new UIBarButtonItem("Post", UIBarButtonItemStyle.Done, null);
            postButton.Clicked += PostButton_Clicked;

            NavigationItem.SetLeftBarButtonItem(cancelButton, true);
            NavigationItem.SetRightBarButtonItem(postButton, true);
            NavigationItem.Title = string.Empty;

            userPictureImageView.Layer.CornerRadius = userPictureImageView.Frame.Size.Width / 2;
            userPictureImageView.ClipsToBounds = true;

            journalEntryTextView.Started += JournalEntryTextView_Started;
            journalEntryTextView.Ended += JournalEntryTextView_Ended;
        }

        void JournalEntryTextView_Ended (object sender, EventArgs e)
        {
            if (journalEntryTextView.Text == string.Empty)
            {
                journalEntryTextView.Text = "Journal entry...";
                journalEntryTextView.TextColor = UIColor.LightGray;
            }
        }

        void JournalEntryTextView_Started (object sender, EventArgs e)
        {
            if (journalEntryTextView.Text == "Journal entry...")
            {
                journalEntryTextView.Text = string.Empty;
                journalEntryTextView.TextColor = UIColor.Black;
            }
        }

        async void PostButton_Clicked (object sender, EventArgs e)
        {
            //TODO: Post item!
            Post post = new Post()
            {
                    Message = journalEntryTextView.Text,
                    PostToFacebook = postToFacebookSwitch.On,
                    DatePosted = DateTime.Now
            };
            await User.MobileService.GetTable<Post>().InsertAsync(post);

            this.NavigationController.PopViewController(true);
        }

        void CancelButton_Clicked (object sender, EventArgs e)
        {
            this.NavigationController.PopViewController(true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            this.NavigationController.SetNavigationBarHidden(false, true);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);


            this.NavigationController.SetNavigationBarHidden(true, true);
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            journalEntryTextView.ResignFirstResponder();
        }
	}
}
