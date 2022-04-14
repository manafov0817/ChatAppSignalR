"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chats").build();

var messageTextToSend = '';

connection.on("ReceiveMessage", function (message) {

    if (message == messageTextToSend) {
        insertChat("you", message, Date.now);
    }
    else {
        insertChat("me", message, Date.now);
    }

})

connection.on("ReceiveMessageToServer", function (message) {

    insertChat("you", message, Date.now);

})

connection.start().catch(function (err) {
    return console.log(err.message);
});

connection.on("UserConnected", function (connectionId) {
    var groupElement = document.getElementById("group");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
});

connection.on("UserDisconnected", function (connectionId) {
    var groupElement = document.getElementById("group");

    for (var i = 0; i < groupElement.length; i++) {
        if (groupElement.options[i].value == connectionId) {
            groupElement.remove(i);
        }
    }
});

var me = {};
me.avatar = "https://lh6.googleusercontent.com/-lr2nyjhhjXw/AAAAAAAAAAI/AAAAAAAARmE/MdtfUmC0M4s/photo.jpg?sz=48";

var you = {};
you.avatar = "https://a11.t26.net/taringa/avatares/9/1/2/F/7/8/Demon_King1/48x48_5C5.jpg";

function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}

//-- No use time. It is a javaScript effect.
function insertChat(who, text, time) {
    if (time === undefined) {
        time = 0;
    }
    var control = "";
    var date = formatAMPM(new Date());

    if (who == "me") {
        control = '<li style="width:100%">' +
            '<div class="msj macro">' +
            '<div class="avatar"><img class="img-circle" style="width:100%;" src="' + me.avatar + '" /></div>' +
            '<div class="text text-l">' +
            '<p>' + text + '</p>' +
            '<p><small>' + date + '</small></p>' +
            '</div>' +
            '</div>' +
            '</li>';
    } else {
        control = '<li style="width:100%;">' +
            '<div class="msj-rta macro">' +
            '<div class="text text-r">' +
            '<p>' + text + '</p>' +
            '<p><small>' + date + '</small></p>' +
            '</div>' +
            '<div class="avatar" style="padding:0px 0px 0px 10px !important"><img class="img-circle" style="width:100%;" src="' + you.avatar + '" /></div>' +
            '</li>';
    }
    setTimeout(
        function () {
            $("ul").append(control).scrollTop($("ul").prop('scrollHeight'));
        }, time);

}

function resetChat() {
    $("ul").empty();
}

$(".mytext").on("keydown", function (e) {
    if (e.which == 13) {

        event.preventDefault();

        messageTextToSend = $(this).val();

        var groupElement = document.getElementById("group");

        var groupValue = groupElement.options[groupElement.selectedIndex].value;

        if (groupValue == "MySelf" || groupValue == "All") {

            var method = groupValue == "MySelf" ? "SendMessageToCaller" : "SendMessageToAll";

            connection.invoke(method, messageTextToSend).catch(function (err) {
                console.log(err);
            })
        }
        else if (groupValue == "PrivateGroup") {
            connection.invoke("SendMessageToGroup", "PrivateGroup", messageTextToSend).catch(function (err) {
                return console.log(err.string);
            });
        }
        else {
            connection.invoke("SendMessageToUser", groupValue, messageTextToSend).catch(function (err) {
                console.log(err);
            })
        }
        $(this).val('');
    }
});

$('body > div > div > div:nth-child(2) > span').click(function () {
    $(".mytext").trigger({ type: 'keydown', which: 13, keyCode: 13 });
})

resetChat();