$(document).ready(function () {
    if (window.location.hash == "#AccountHelp") {
        accInfo();
    }
    if (window.location.hash == "#EventHelp") {
        eventInfo();
    }
    if (window.location.hash == "#HomeHelp") {
        homeInfo();
    }
    if (window.location.hash == "#ProfileHelp") {
        profInfo();
    }
    if (window.location.hash == "#MessageHelp") {
        messageInfo();
    }
    if (window.location.hash == "#FriendHelp") {
        friendInfo();
    }
    if (window.location.hash == "#ServiceHelp") {
        serviceInfo();
    }
});

//Searching for external events via AJAX call based on location and/or keyword

function searchNow() {
    $a = document.getElementById("location").value;
    $b = document.getElementById("keyword").value;

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Events/SearchExternalEvents',
        data: { 'location': $a, 'keyword': $b },
        success: displayEvents,
        error: errorOnAjax
    });

}


//Displaying events near you based on your current location entered in profile
$.ajax({
    type: "GET",
    dataType: "json",
    url: "/Events/ExternalEvents",
    success: displayEvents,
    error: errorOnAjax
});


function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

//Putting user data on home page
function displayEvents(data) {

    document.getElementById("tablePlacement").remove();
    $('#bigTable').append($('<table id=\"tablePlacement\">'));
    $('#tablePlacement').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<td id=\"tdName\"> <strong> Name </td>'));
    $('#tableTr').append($('<td id=\"tdCity\"> <strong> Location </td>'));
    $('#tableTr').append($('<td id=\"tdStart\"> <strong> Start Date </td>'));
    $('#tableTr').append($('<td id=\"tdEnd\"> <strong> End Date </td>'));
    $('#tableTr').append($('<td id=\"tdPrice\"> <strong> Price </td>'));
    $('#tableTr').append($('<td id=\"tdDesc\"> <strong> Description </td>'));
    $('#tableTr').append($('<td id=\"tdImage\"> <strong> Image </td>'));
    $('#tablePlacement').append($('</tr>'));
    $('#bigTable').append($('</table>'));

    //Putting items in table starting from the last element to output in descending order (latest commits show at top)
    for (var i = 0; i < data.length; ++i) {
        var rowCount = 1;
        var table = document.getElementById("tablePlacement");
        var row = table.insertRow(rowCount); //Insert at new row
        //Add all 7 cells at a time
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);
        var cell5 = row.insertCell(4);
        var cell6 = row.insertCell(5);
        var cell7 = row.insertCell(6);
        //Update all 7 cells data
        cell1.innerHTML = data[i].Title;
        cell2.innerHTML = data[i].City + ", " + data[i].State;
        cell3.innerHTML = data[i].StartTime;
        cell4.innerHTML = data[i].StopTime;
        cell5.innerHTML = data[i].Price;
        cell6.innerHTML = data[i].Description + "<a href=\"" + data[i].LinkURL + "\" > <br /> Click here </a> for more information about this event. ";
        cell7.innerHTML = "<img src=\"" +  data[i].ImageURL + "\" width=\"100px\" height=\"100px\">";
        rowCount++; //Increment rowCount so we can add new row

    }
};


function accInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Register</h3><br /><p>Select "Register" on the navigation bar at the top of this webpage or <a href="/Account/Register">Click here</a>. You will then be prompted to type in your email address, which you will use to login to your account later. You will also be prompted to type in a password, which consists of at least 8 characters. You then must select the checkbox "I\'m not a robot" to indicate that you are a human. You should then be able to register by selecting "Register". You will be sent an email and be prompted to verify your email address. Simply do this by going to your email and clicking the confirmation link sent to your email address. You will need to have your account confirmed in order to recover your password if you later forget it. After creating an account with your email and password, you will be redirected to the Account Creation page, in which you need to fill out in order to participate in our website. </p><br /><h3 id="descTitle">How to Log In</h3><br /><p>Select "Log in" on the navigation bar at the top of this webpage or <a href="/Account/Login">Click here</a>. You will then be prompted to type in your email address (the email address you used to register with). You will then be prompted to type in your password (the password you used to register with). Selecting "Remember me?" will let your computer remember your username and password, so anytime you enter the login page on <i>that computer,</i> your username and password will be remembered, so logging in will be as easy as clicking "Log in". </p> <br /><h3 id="descTitle">Recover your Password</h3><br /><p>If you ever forget your password, select "Log In" at the top of the navigation bar, and then select "Forgot your Password?". You will then be prompted to type in your email address (the one you registered with), and then click "Email Link". You will then be sent an email from us with a link you need to click on in able to reset your password. After the reset is completed, the new password you entered will now be your current password unless you forget it in the future. Tip: Write this password down so future you will remember! </p>'));
};

function homeInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">About Your Home Page</h3><br /><p>Select "Home" on the navigation bar at the top of this webpage or <a href="/Home">Click here</a> to check out your personalized Home page! Your Home page consists of your name, profile picture, the weather near you, a map of your general location, posts of those who you choose to follow, and your list of people that you choose to follow. Posts will not show up on your Home page until you choose to follow people. To do so, select the button on your home page titled "Find User to Follow" and select the user you would like to follow. Once you follow people, their posts will appear on your Home page! To go to your personal profile page, click on the "View Profile" button on your Home page. To create a post, click "Create Post" and type in your message. </p>'));
};

function profInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">About Your Profile Page</h3><br /><p>To go to your Profile page, select "Profile" on the navigation bar at the top of this webpage or <a href="/Profiles/MyProfile">Click here</a>. Your Profile displays the information you inputted when you registered, such as your name, birthday, biography, occupation, location, etc, as well as all of your posts that you created. Your Profile page also consists of a list of those that you follow, and a Veteran indicator if you have served. This page is available for anyone to see once they search for you in the "Search" page. To create a post, simply click "Create Post" and share your message with the world. To edit or delete a post, you can simply find the post you wish to edit or delete, and select "Edit" or "Delete". </p> <br/> <h3 id="descTitle">Searching For Other Profile Pages</h3><br /><p>To search for a Profile page, <a href="/Profiles">Click here</a>. You can search by first name, last name, or parts of a name. Once you find someone you know, or someone you would like to know, select "See Profile" and you will be redirected to their Profile page. </p></br><h3 id="descTitle">Creating Your Profile</h3></br><p>You will create your profile after you register for your account. You will need to create this profile by filling out this form to enjoy the features of our Simply Seniors site. If you still need to register, <a href="/Account/Register">Click here</a>. </p><p> You will need to fill out some information about yourself. This will allow the community to know who you are. It is important to remember you must be over 65 years of age, otherwise you will not be allowed to create your account. This form also include a "browse" button for photo uploading. This will allow you to have a profile photo, please upload a single image. After you choose your photo from your computer, you will want to click on "UPLOAD NOW" button. You will get a success message that tells you that your photo was uploaded. If it is not accepted you will get a message indicating the problem. Then you may continue to add your hobbies to your profile, this is done by clicking the main button in the form. </p> '));
};

function friendInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">How to Follow</h3><br /><p>*Update when Friends feature gets added*</p> <br /> <h3 id="descTitle">Suggested Friends</h3><br /><p>*Update when Suggested Friends feature gets added*</p>'));
};

function messageInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Send Messages</h3><br /><p>*Update when Message feature gets added*</p>'));
};

function serviceInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">About Services Page</h3><br /><p>Our Services page consists of many different types of services that may benefit you or those around you, including information about free food benefits, federal reverse mortgage programs, nonprofit, and other organizations and programs designed to help you. To learn about what services may benefit you, <a href="/Home/Services">Click here</a>.</p>'));
};

function eventInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">About Events Page</h3><br /><p> Our Events page is designed to bring you all of the details on the latest events near you! To view the Events page, <a href="/Events">Click here</a>. This page consists of internal events that you may choose to participate in. To view more information about an event, select "Details" on the event you wish to know more about. To search for events based on the name of the event or the location, click on "Search for Events", type in whatever you would like, and click "Search Now". To see more details about a certain event (such as the location, description, and time of the event), select "See Details". To search for another event, simply type in your new search and click "Search Now". To create an event, go back to the <a href="/Events">Events</a> page and click "Create New Event". You will then be redirected to a new page to fill out information about your event. Once everything looks good, double check it and hit "Create"! Your event will now appear in searches and on the main Events page. </p>'));
};

function FAQInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">Frequently Asked Questions</h3> <br /> <ol id="FAQList"> <li> How much does this service cost? </li > <p>This service is, and always will be, completely free for the benefit of our users. We may eventually have advertisements displayed, but those will also be beneficial to you and your experience with our website, as they will be advertisements about helpful things that pertain to you or your location. </p> <li>How does "Find Friends" work and how does it suggest friends to me?</li> <p>As of right now, the "Find Friends" feature is not currently implemented, check back later to find additional details on this feature. </p> <li>How do I change my privacy settings, and who can see my posts and profile information?</li> <p>As of right now, anyone can see your profile information just by searching for you on the website. In the future, we will add security features so that you can choose who can see your profile and your posts.</p> <li>How can I change my notification settings?</li><p>As of right now, we do not have notifications up, this will be added later.</p> <li>How long are my messages available when I am messaging friends?</li><p>As of right now, we do not have messaging implemented. Please check back later.</p> <li>I still have unanswered questions, how do I find the answers?</li><p>You can send us (the developers of the website) an email by clicking on the "Contact Us" tab on the left-hand side. We will get back to you with an answer as soon as we can. </p> </ol >  '));
};


function contactInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">Contact Us</h3><br /><p> Send us a message </p> <textarea maxlength="255" type="text" id="MyText" rows="4" cols="50"> </textarea>  <p> <span id="wordcount"> 255 </span> Characters Left </p> <button class="btn btn-outline-primary" id="saveRedirect" onclick="sendemail()">Send</button>'));
    var MyText = document.getElementById("MyText");
    var wordcount = document.getElementById("wordcount");

    MyText.addEventListener("keyup", function () {
        var characters = MyText.value.split('');
        wordcount.innerText = 255 - characters.length;
    });
};

function vidInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">Help Videos</h3><br /><a href="https://www.youtube.com/watch?v=QBBzE6PITks">Self Defense for Seniors and How to Keep Yourself Safe</a><br/> <a href="https://www.youtube.com/watch?v=MWoS9oFJIzY">How to Create a Life of Purpose for Seniors</a><br/>  <a href="https://www.youtube.com/watch?v=JejTelL05Qw">Strength Training for Seniors</a><br/> '));
};

function sendemail() {
    var string = $("#MyText").val();
    console.log(string);
    console.log(string.length);
    if (string.replace(/\s/g, "") === "") {
        console.log(string);
        alert("Please put in a message!");
    }
    else {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Home/emailservice?message=" + string,
            data: { 'messages': string },
            success: itworked,
            error: failure
        });
    }
    

};

function follow(id) {
    var token = $('[name=__RequestVerificationToken]').val();
    var headers = {};
    headers["__RequestVerificationToken"] = token;
    $.ajax({
        headers: headers,
        type: "POST",
        dataType: "json",
        url: "/FollowLists/AjaxCreate",
        data: { 'userid': id },
        success: function (data) {
            alert("Successful!");
        },
        error: function () {
            alert("error");
        }
    })
}

function itworked(message) {
    $("#MyText").empty();
    alert("Email sent! Thank you for your feedback!");
};

function failure() {
    alert("Sorry! it looks as though something went wrong");
}