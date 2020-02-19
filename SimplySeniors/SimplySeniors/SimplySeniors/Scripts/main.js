$(document).ready(function () {
    $('#CreateAcc').on('click', function accInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Register</h3><br /><p>Select "Register" on the navigation bar at the top of this webpage, on the right-hand side. You will then be prompted to type in your email address, which you will use to login to your account later. You will also be prompted to type in a password, which consists of at least 6 characters (with at least one character being a digit or non-letter, and at least one uppercase letter). You should then be able to register by selecting "Register". </p><br /><h3 id="descTitle">How to Log In</h3><br /><p>Select "Log in" on the navigation bar at the top of this webpage, on the right-hand side. You will then be prompted to type in your email address (the email address you used to register with). You will then be prompted to type in your password (the password you used to register with). Selecting "Remember me?" will let your computer remember your username and password, so anytime you enter the login page on <i>that computer,</i> your username and password will be remembered, so logging in will be as easy as clicking "Log in". </p>'));
    });
    $('#HomePage').on('click', function homeInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>About Your Home Page</h3><p>*Update when homepage feature gets added*</p>'));
    });
    $('#ProfilePage').on('click', function profInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>About Your Profile Page</h3><p>*Update when profile feature gets added*</p>'));
    });
    $('#Friend').on('click', function friendInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>How to Add Friends</h3><p>*Update when Friends feature gets added*</p>'));
    });
    $('#Messaging').on('click', function messageInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($("<h3>How to Send Messages</h3><p>*Update when Message feature gets added*</p>"));
    });
    $('#Services').on('click', function serviceInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>About Services Page</h3><p>*Update when Service page gets added*</p>'));
    });
    $('#Events').on('click', function eventInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>About Events Page</h3><p>*Update when Events feature/page gets added*</p>'));
    });
    $('#FAQ').on('click', function FAQInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<ol id="FAQList"> <li> Question 1? </li > <p>Answer</p> <li>Question 2?</li> <p>Another Answer</p> <li>Question 3?</li> <p>A Third Answer</p> </ol >  '));
    });
    $('#Contact').on('click', function contactInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>Contact Us</h3><p>*Update when Contact feature gets added. Add email box here*</p>'));
    });
    $('#Vids').on('click', function vidInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3>Help Videos</h3><p>*Update when we find helpful videos*</p>'));
    });
});