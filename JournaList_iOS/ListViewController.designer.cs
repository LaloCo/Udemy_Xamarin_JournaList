// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace JournaList_iOS
{
	[Register ("ListViewController")]
	partial class ListViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView postsTableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel userNameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView userPictureImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton writeNewPostButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (postsTableView != null) {
				postsTableView.Dispose ();
				postsTableView = null;
			}
			if (userNameLabel != null) {
				userNameLabel.Dispose ();
				userNameLabel = null;
			}
			if (userPictureImageView != null) {
				userPictureImageView.Dispose ();
				userPictureImageView = null;
			}
			if (writeNewPostButton != null) {
				writeNewPostButton.Dispose ();
				writeNewPostButton = null;
			}
		}
	}
}
