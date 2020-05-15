(function (t, a, l, k, j, s) {
    s = a.createElement('script'); s.async = 1; s.src = "https://cdn.talkjs.com/talk.js"; a.head.appendChild(s)
        ; k = t.Promise; t.Talk = {
        v: 3, ready: {
            then: function (f) {
                if (k) return new k(function (r, e) { l.push([f, r, e]) }); l
                    .push([f])
            }, catch: function () { return k && new k() }, c: l
        }
    };
})(window, document, []);


Talk.ready.then(function () {

    var me = new Talk.User({
        id: "1",
        name: "Sender",
        email: "origkid22@hotmail.com",
        photoUrl: "https://demo.talkjs.com/img/alice.jpg",
        welcomeMessage: "Hey there! How are you? :-)"
    });
    var appID = System.Web.Configuration.WebConfigurationManager.AppSettings["chatApiKey"];

    window.talkSession = new Talk.Session({
        appId: appID,
        me: me
    });

    var other = new Talk.User({
        id: "2",
        name: "Test User 2",
        email: " ",
        photoUrl: "https://demo.talkjs.com/img/sebastian.jpg",
        welcomeMessage: "Thanks, i'll be with you in a sec."
    });

    var conversation = talkSession.getOrCreateConversation(Talk.oneOnOneId(me, other));
    conversation.setParticipant(me);
    conversation.setParticipant(other);
    var inbox = talkSession.createInbox({ selected: conversation });
    inbox.mount(document.getElementById("talkjs-container"));
});

