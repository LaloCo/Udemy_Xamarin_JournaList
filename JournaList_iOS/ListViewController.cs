using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using JournaList_PCL;
using System.Collections.Generic;

namespace JournaList_iOS
{
	partial class ListViewController : UIViewController
	{
        List<Post> posts;

		public ListViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            posts = new List<Post>();

            this.NavigationController.SetNavigationBarHidden(true, false);

            userPictureImageView.Layer.CornerRadius = userPictureImageView.Frame.Size.Width / 2;
            userPictureImageView.ClipsToBounds = true;

            writeNewPostButton.Layer.CornerRadius = writeNewPostButton.Frame.Size.Width / 2;
            writeNewPostButton.ClipsToBounds = true;

            postsTableView.EstimatedRowHeight = 80.0f;
            postsTableView.RowHeight = UITableView.AutomaticDimension;

            GetUserData();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            GetPosts();
        }

        private async void GetUserData()
        {
            AppDelegate.user = new User();
            await AppDelegate.user.GetUser();
            userNameLabel.Text = AppDelegate.user.Username;

            NSUrl url = new NSUrl(AppDelegate.user.PictureUrl);
            NSData data = NSData.FromUrl(url);
            userPictureImageView.Image = new UIImage(data);

            GetPosts();
        }

        private async void GetPosts()
        {
            posts = await User.MobileService.GetTable<Post>().ToListAsync();

            postsTableView.Source = new TableSource(posts);

            postsTableView.ReloadData();
        }
	}
}
