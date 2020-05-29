(function (t, a, l, k, j, s) {
        s = a.createElement('script'); s.async = 1; s.src = "https://cdn.talkjs.com/talk.js"; a.getElementsByTagName('head')[0].appendChild(s); k = t.Promise
        t.Talk = {ready: {then: function (f) { if (k) return new k(function (r, e) {l.push([f, r, e])}); l.push([f]) }, catch: function () { return k && new k() }, c: l } }
})(window, document, []);


Talk.ready.then(function () {
        // The core TalkJS lib has loaded, so let's identify the current user to TalkJS.
        var firstName = document.getElementById("userFirstName").value;
        var lastName = document.getElementById("userLastName").value;
        var userId = document.getElementById("userID").value;
        var me = new Talk.User({
            // must be any value that uniquely identifies this user
            id: userId,
        name: firstName + " " + lastName,
        email: "george@looney.net",
        photoUrl: "https://talkjs.com/docs/img/george.jpg"
    });
    // TODO: add a "configuration" field to the user object so your
    // user can get email notifications.
    // See https://talkjs.com/docs/Emails_and_Configurations.html for more
    // info.

        window.talkSession = new Talk.Session({
        appId: chatID,
        me: me
    });

    // Let's show the chatbox.
    // First, we need to define who we want to talk to.
    //
    // In this case, it's always the operator. The code below is identical
    // to the `var me =` declaration in operator.html


    //var firstName2 = document.getElementById("userFirstName2").value;   // using these for direct chat. 
    //var lastName2 = document.getElementById("userLastName2").value;
    //var userId2 = document.getElementById("userID2").value;
        var operator = new Talk.User({
            // just hardcode any user id, as long as your real users don't have this id
            id: "99976",
            name: "Admin",
            email: "teambitbreakers@gmail.com",
            photoUrl: "/Photos/favicon-32x32.png",
            welcomeMessage: "Welcome to Simply Seniors, chat away!"
});

// Now, let's start or continue the conversation with the operator and
// show the chatbox.

// You control the ID of a conversation. In this example, we use the item ID as
// the conversation ID in order to tie this conversation to this item.
var conversation = window.talkSession.getOrCreateConversation("Second_group_chat");
conversation.setParticipant(me);
conversation.setParticipant(operator);
var chatbox = window.talkSession.createChatbox(conversation);
chatbox.mount(document.getElementById("talkjs-container"));


// Below is code for direct chat between two users. 
//var conversation = talkSession.getOrCreateConversation(Talk.oneOnOneId(me, other));
//conversation.setParticipant(me);
//conversation.setParticipant(other);
//var inbox = talkSession.createInbox({selected: conversation });
//inbox.mount(document.getElementById("talkjs-container"));

});





