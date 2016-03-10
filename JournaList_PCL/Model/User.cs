using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JournaList_PCL
{
    public class User
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://xamarin-journalist.azure-mobile.net/",
            "RCTEQgZFepZafXjMkDeJnCADgffLhn75"
        );

        private string id;
        public string Id
        {
            get{ return id; }
            set{ id = value; }
        }

        private string username;
        public string Username
        {
            get{ return username; }
            set{ username = value; }
        }

        private string userId;
        public string UserId
        {
            get{ return userId; }
            set{ userId = value; }
        }

        private string pictureUrl;
        public string PictureUrl
        {
            get{ return pictureUrl; }
            set{ pictureUrl = value; }
        }

        public User()
        {
            
        }

        public async Task<bool> GetUser()
        {
            try
            {
                List<User> users = await MobileService.GetTable<User>().ToListAsync();
                foreach (var user in users)
                {
                    this.Id = user.Id;
                    this.Username = user.Username;
                    this.PictureUrl = user.PictureUrl;
                    this.UserId = user.UserId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }
    }
}

/*
 * INSERT FUNCTION IN BACKEND
function insert(item, user, request) {
    
    item.Username = "<unknown>"; // default
    item.UserId = user.userId;
    item.PictureUrl = "";
    
    var usersTable = tables.getTable('User');
    usersTable.where({ UserId: user.userId }).read({
        success: function(results){
            if(results.length > 0)
            {
                console.log("Ok");
                request.respond(statusCodes.CREATED);
            }
            else
            {
                getUserData();
            }
        }
    });
    
    function getUserData(){
        user.getIdentities({
            success: function (identities) {
                var req = require('request');
                if (identities.facebook) {
                    var fbAccessToken = identities.facebook.accessToken;
                    var url = 'https://graph.facebook.com/me?access_token=' + fbAccessToken;
                    req(url, function (err, resp, body) {
                        if (err || resp.statusCode !== 200) {
                            console.error('Error sending data to FB Graph API: ', err);
                            request.respond(statusCodes.INTERNAL_SERVER_ERROR, body);
                        } else {
                            try {
                                var userData = JSON.parse(body);
                                console.log("Body of response '%j'.", body);
                                item.Username = userData.name;
                                request.execute();
                            } catch (ex) {
                                console.error('Error parsing response from FB Graph API: ', ex);
                                request.respond(statusCodes.INTERNAL_SERVER_ERROR, ex);
                            }
                        }
                    });
                } else {
                    // Insert with default user name
                    request.execute();
                }
            }
        });
    }

}
 */