$(document).ready(function () {
    $('#CreateAcc').on('click', function accInfo() {
        document.getElementById("description").remove();
        $('#descriptionOutside').append($('<div id="description"></div> '));
        $('#description').append($('<p>Stuff about account stuff</p>'));
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
        $('#description').append($('<p>Stuff about messaging</p>'));
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
        $('#description').append($('<p>Stuff about FAQ... Bulletin list???</p>'));
    });
});