$(document).ready(function () {
    if (window.location.hash == "#AccountHelp") {
        accInfo();
    }
    if (window.location.hash == "#EventHelp") {
        eventInfo();
    }
});

function accInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Register</h3><br /><p>Select "Register" on the navigation bar at the top of this webpage or <a href="/Account/Register">Click here</a>. You will then be prompted to type in your email address, which you will use to login to your account later. You will also be prompted to type in a password, which consists of at least 6 characters (with at least one character being a digit or non-letter, and at least one uppercase letter). You should then be able to register by selecting "Register". You will then be prompted to verify your email address. Simply do this by going to your email and clicking the confirmation link sent to your email address. You will need to have your account confirmed in order to recover your password if you later forget it. </p><br /><h3 id="descTitle">How to Log In</h3><br /><p>Select "Log in" on the navigation bar at the top of this webpage or <a href="/Account/Login">Click here</a>. You will then be prompted to type in your email address (the email address you used to register with). You will then be prompted to type in your password (the password you used to register with). Selecting "Remember me?" will let your computer remember your username and password, so anytime you enter the login page on <i>that computer,</i> your username and password will be remembered, so logging in will be as easy as clicking "Log in". </p> <br /><h3 id="descTitle">Recover your Password</h3><br /><p>If you ever forget your password, select "Log In" at the top of the navigation bar, and then select "Forgot your Password?". You will then be prompted to type in your email address (the one you registered with), and then click "Email Link". You will then be sent an email from us with a link you need to click on in able to reset your password. After the reset is completed, the new password you entered will now be your current password unless you forget it in the future. Tip: Write this password down so future you will remember! </p>'));
};

function homeInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">About Your Home Page</h3><br /><p>*Update when homepage feature gets added*</p>'));
};

function profInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">About Your Profile Page</h3><br /><p>*Update when profile feature gets added*</p> <br/> <h3 id="descTitle">Searching For Other Profile Pages</h3><br /><p>To search for a profile page, <a href="/Profiles">Click here</a>. You can search by first name, last name, or parts of a name. Once you find someone you know, or someone you would like to know, select "See Profile" and you will be redirected to their profile page. </p>'));
};

function friendInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Add Friends</h3><br /><p>*Update when Friends feature gets added*</p>'));
};

function messageInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Send Messages</h3><br /><p>*Update when Message feature gets added*</p>'));
};

function serviceInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">About Services Page</h3><br /><p>Our Services Page consists of many different types of services that may benefit you or those around you. To learn about what services may benefit you, <a href="/Home/Services">Click here</a>.</p>'));
};

function eventInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">About Events Page</h3><br /><p>*Update when Events feature/page gets added*</p>'));
};

function FAQInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">Frequently Asked Questions</h3> <br /> <ol id="FAQList"> <li> How much does this service cost? </li > <p>This service is, and always will be, completely free for the benefit of our users. We may eventually have advertisements displayed, but those will also be beneficial to you and your experience with our website, as they will be advertisements about helpful things that pertain to you or your location. </p> <li>How does "Find Friends" work and how does it suggest friends to me?</li> <p>As of right now, the "Find Friends" feature is not currently implemented, so we are unsure of how you will find friends. </p> <li>How do I change my privacy settings, and who can see my posts and profile information?</li> <p>As of right now, anyone can see your profile information just by searching for you on the website. In the future, we will add security features so that you can choose who can see your profile and your posts.</p> <li>How can I change my notification settings?</li><p>As of right now, we do not have notifications up, this will be added later.</p> <li>How long are my messages available when I am messaging friends?</li><p>As of right now, we do not have messaging implemented. Please check back later.</p> </ol >  '));
};


function contactInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
    $('#description').append($('<h3 id="descTitle">Contact Us</h3><br /><p> Send us a message </p> <textarea id="MyText" rows="4" cols="50"> </textarea>  <p> <span id="wordcount"> 255 </span> Characters Left </p> <button id="saveRedirect" onclick="sendemail()">Send</button>'));
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

function itworked(message) {
    $("MyText").empty();
    alert("Email sent! Thank you for your feedback!");
};

function failure() {
    alert("Sorry! it looks as though something went wrong");
}