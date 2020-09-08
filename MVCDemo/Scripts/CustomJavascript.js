//We want to change the backgroundColor of "Save" button on "Edit" view to "Red" on MouseOver and to "Green" on MouseOut.

$(function () {
    $("#btnSubmit").mouseover(function () {
        $("#btnSubmit").css("background-color", "red");
    });

    $("#btnSubmit").mouseout(function () {
        $("#btnSubmit").css("background-color", "green");
    });
});