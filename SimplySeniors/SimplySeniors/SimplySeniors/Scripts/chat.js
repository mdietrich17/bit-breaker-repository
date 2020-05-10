////Ajax call to get JSON information for page to be responsive.
//function AjaxCall(url, data, type) {
//    return $.ajax({
//        url: url,
//        type: type ? type : 'GET',
//        data: data,
//        contentType: 'application/json'
//    });
//}
////Throwing error if there was something wrong with the ajax call.
//function ajaxError() {
//    console.log('Error on AJAX return, check your scripts');
//}



$(function () {

    var a = document.getElementById("firstNameBox").value;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Chat/GetCurrentUser",
        data: {},
        success: displayMember,
        error: errorOnAjax
    });

    function displayMember() {

        $("#memberDDL").html("h");
        var selectOptions = "";
        selectOptions += '<option value="Select">Select</option>';
        for (var i = 0; i < response.length; i++) {
            selectOptions += '<option value="' + response[i] + '">' + response[i] + "</option>";
        }
        $("#memberDDL").append(selectOptions);

    }
});

//$(function () {
//    var url = "/Chat/GetAllProfiles";

//    AjaxCall(url, null).done(function(response) {
//        if (response.length > 0) {
//            $('#memberDDL').html('h');
//            var selectOptions = '';
//            selectOptions += '<option value="Select">Select</option>';
//            for (var i = 0; i < response.length; i++) {
//                selectOptions += '<option value="' + response[i] + '">' + response[i] + '</option>';
//            }
//            $('#memberDDL').append(selectOptions);
//        }
//    }).fail(function(error) {
//        alert("Get All Profiles() had an error check userHomePage controller");
//    });
//});


//$('#memberDDL').on("change", function () {
//    var teamName = $('#memberDDL').val();
//    var object = { team: teamName };
//    AjaxCall('/Chat/GetAllProfiles', JSON.stringify(object), 'POST').done(function (response) {
//        if (response.length > 0) {
//            $('#memberDDL').html('');
//            var selectOptions = '';
//            selectOptions += '<option value="Select">Select</option>';
//            for (var responseStart = 0; responseStart < response.length; responseStart++) {
//                selectOptions += '<option value="' + response[responseStart] + '">' + response[responseStart] + '</option>';
//            }
//            $('#memberDDL').append(selectOptions);
//        }
//    }).fail(function (error) {
//        alert("Error2, Contact your nearest Help Desk"); //error2 output
//    });
//});



(function (t, a, l, k, j, s) { // Adding talk.js dynamically via js so it doesn't delay page. 
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
        id: "123456",
        name: "Alice",
        email: "alice@example.com",
        photoUrl: "https://demo.talkjs.com/img/alice.jpg",
        welcomeMessage: "Hey there! How are you? :-)"
    });
    window.talkSession = new Talk.Session({
        appId: "tnDbD1Bo",
        me: me
    });

    var other = new Talk.User({
        id: "654321",
        name: "Sebastian",
        email: "Sebastian@example.com",
        photoUrl: "https://demo.talkjs.com/img/sebastian.jpg",
        welcomeMessage: "Hey, how can I help?"
    });

    
    var conversation = talkSession.getOrCreateConversation(Talk.oneOnOneId(me, other));
    conversation.setParticipant(me);
    conversation.setParticipant(other);
    var inbox = talkSession.createInbox({ selected: conversation });
    inbox.mount(document.getElementById("talkjs-container"));
});

