using System;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;

namespace JournaList_PCL
{
    public class Posts : ObservableCollection<Post>
    {
        public Posts()
        {
            GetPosts();
        }

        public async void GetPosts()
        {
            MobileServiceClient MobileService = new MobileServiceClient(
                "https://xamarin-journalist.azure-mobile.net/",
                "RCTEQgZFepZafXjMkDeJnCADgffLhn75"
            );

            var posts = await MobileService.GetTable<Post>().ToListAsync();

            foreach (var post in posts)
            {
                Add(post);
            }
        }
    }
}

