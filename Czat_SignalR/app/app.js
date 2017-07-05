var hub = $.connection.chatHub;
hub.client.message = function(msg) {
    $("#message").append("<li>"+msg+"</li>")
}

hub.client.user = function(msg) {
    $("#user").append("<li>"+msg+"</li>")
}

$.connection.hub.start(function() {
    $("#send").click(function() {
        hub.server.send($("#txt").val());
        $("#txt").val(" ");
    })
})
    $(document).ready(function () {
        var connection = $.hubConnection();
        var hub = connection.createHubProxy("hitCounter");
        hub.on("onRecordHit", function (i) {
            $("#hitCounter").text(i);
        });
        connection.start(function () {
            hub.invoke("recordHit");
        });
    });
