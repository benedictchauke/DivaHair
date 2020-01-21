var theForm = document.getElementById("theForm");
theForm.hidden = true;

var button = document.getElementById("Buy");
button.addEventListener("click", function () {
    alert("Buying Item");
});

var info = document.getElementByClassName("prop");
var listItems = info.item[0].children;