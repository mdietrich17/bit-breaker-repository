$(document).ready(function () {
    $('#CreateAcc').on('click', function accInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<h3 id="descTitle">How to Register</h3><br /><p>Select "Register" on the navigation bar at the top of this webpage, on the right-hand side. You will then be prompted to type in your email address, which you will use to login to your account later. You will also be prompted to type in a password, which consists of at least 6 characters (with at least one character being a digit or non-letter, and at least one uppercase letter). You should then be able to register by selecting "Register". </p><br /><h3 id="descTitle">How to Log In</h3><br /><p>Select "Log in" on the navigation bar at the top of this webpage, on the right-hand side. You will then be prompted to type in your email address (the email address you used to register with). You will then be prompted to type in your password (the password you used to register with). Selecting "Remember me?" will let your computer remember your username and password, so anytime you enter the login page on <i> that computer </i>, your username and password will be remembered, so logging in will be as easy as clicking "Log in". </p>'));
    });
    $('#HomePage').on('click', function homeInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Stuff about home pages</p>'));
    });
    $('#Friend').on('click', function friendInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Stuff about friends</p>'));
    });
    $('#Messaging').on('click', function messageInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($("<p>Stuff about messaging let's message</p>"));
    });
    $('#Services').on('click', function serviceInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Stuff about services</p>'));
    });
    $('#Events').on('click', function eventInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Stuff about events...LINK TO EVENT PAGE</p>'));
    });
    $('#FAQ').on('click', function FAQInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<ol id="FAQList"> <li> Coffee </li > <p>stuff</p> <li>Tea</li> <li>Milk</li> </ol >  '));
    });
    $('#Contact').on('click', function contactInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Contact us at.... something gmail.com idk or implement an email box here that says to leave your email or something</p>'));
    });
    $('#Vids').on('click', function vidInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Put videos here</p>'));
    });
});