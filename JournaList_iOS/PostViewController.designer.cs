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
	[Register ("PostViewController")]
	partial class PostViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView journalEntryTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch postToFacebookSwitch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel userNameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView userPictureImageView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (journalEntryTextView != null) {
				journalEntryTextView.Dispose ();
				journalEntryTextView = null;
			}
			if (postToFacebookSwitch != null) {
				postToFacebookSwitch.Dispose ();
				postToFacebookSwitch = null;
			}
			if (userNameLabel != null) {
				userNameLabel.Dispose ();
				userNameLabel = null;
			}
			if (userPictureImageView != null) {
				userPictureImageView.Dispose ();
				userPictureImageView = null;
			}
		}
	}
}
