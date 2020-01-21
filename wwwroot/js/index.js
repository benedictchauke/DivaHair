$(document).ready(function () {
    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#Buy");
    button.on("click", function () {
        console.log("Buying Item");
    });

    var info = $(".prop li");
    info.on("click", function () {
        console.log("you clicked on" + $(this).text());
    });

    var $loggin = $("#loggin");
    var $popForm = $(".popForm");

    $loggin.on("click", function () {
        $popForm.toggle(1000);
    });
});