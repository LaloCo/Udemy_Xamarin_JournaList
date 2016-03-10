using System;
using UIKit;
using JournaList_PCL;
using System.Collections.Generic;

namespace JournaList_iOS
{
    public class TableSource : UITableViewSource
    {
        private string cellReuseIdentifier = "postCell";
        List<Post> posts;

        public TableSource(List<Post> posts, string cellReuseIdentifier = "postCell")
        {
            this.cellReuseIdentifier = cellReuseIdentifier;
            this.posts = posts;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return posts.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            PostTableViewCell cell = tableView.DequeueReusableCell(cellReuseIdentifier) as PostTableViewCell;

            var post = posts[indexPath.Row];

            cell.PostData = post;

            return cell;
        }
    }
}

