using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using JournaList_PCL;

namespace JournaList_iOS
{
	partial class PostTableViewCell : UITableViewCell
	{
        private Post postData;
        public Post PostData
        {
            get{ return postData; }
            set
            {
                postData = value;
                messageLabel.Text = postData.Message;
                dateLabel.Text = string.Format("{0:d}", postData.DatePosted);
            }
        }

		public PostTableViewCell (IntPtr handle) : base (handle)
		{
		}
	}
}
