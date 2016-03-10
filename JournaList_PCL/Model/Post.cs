using System;

namespace JournaList_PCL
{
    public class Post
    {
        private string id;
        public string Id
        {
            get{ return id; }
            set{ id = value; }
        }

        private bool postToFacebook;
        public bool PostToFacebook
        {
            get{ return postToFacebook; }
            set{ postToFacebook = value; }
        }

        private DateTime datePosted;
        public DateTime DatePosted
        {
            get{ return datePosted; }
            set{ datePosted = value; }
        }

        private string message;
        public string Message
        {
            get{ return message; }
            set{ message = value; }
        }

        public Post()
        {
        }
    }
}

/*
 function insert(item, user, request) {

    item.FacebookPostId = "<unknown>";
    item.userId = user.userId;
    if(item.PostToFacebook === true)
    {
        console.log("Post to facebook");
        user.getIdentities({
            success: function (identities) {
                var req = require('request');
                if (identities.facebook) {
                    var userId = user.userId.substring(user.userId.indexOf(':') + 1);
                    var fbAccessToken = identities.facebook.accessToken;
                    var message = item.Message;
                    var url = 'https://graph.facebook.com/me/feed?access_token=' + fbAccessToken + "&message=" + message;
                    req({url: url, method: 'POST'}, function (err, resp, body) {
                        if (err || resp.statusCode !== 200) {
                            console.error('Error sending data to FB Graph API: ', err);
                            request.respond(statusCodes.INTERNAL_SERVER_ERROR, body);
                        } else {
                            try {
                                var userData = JSON.parse(body);
                                console.log("Body of response (has to have id!) '%j'.", body);
                                if(userData.id !== undefined)
                                {
                                    item.FacebookPostId = userData.id;
                                }
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
    else
    {
        console.log("Don't post to facebook");
        request.excecute();
    }
}
*/