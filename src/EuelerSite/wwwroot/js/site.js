// Write your Javascript code.
$(document).ready(function () {
    $(".executable").click(function () {
        var problemId = $(this).attr("problem-id");
        var containerElement = ".problem-container[problem-id*='" + problemId + "']";
        $(containerElement).removeClass("panel-info").addClass("panel-warning");
        var data = { "problemId": problemId };
        $.post("/Home/ExecuteProblem", data, function(result) {
            if (result) {
                $(containerElement).removeClass("panel-warning").addClass("panel-success");
            } else {
                $(containerElement).removeClass("panel-warning").addClass("panel-danger");
            }
        }).fail(function() {
            alert("error while executing: " + problemId);
            $(containerElement).removeClass("panel-warning").addClass("panel-danger");
        });
    });

    $(".view-code").click(function () {
        var problemId = $(this).attr("problem-id");
        var data = { "fileName": problemId };
        $.post("/Home/ViewCode", data, function (result) {
            $("#problem-modal-body").html(result);
            $("#problem-modal-title").html(problemId);
        }).fail(function () {
            alert("error while viewing: " + problemId);
        });
    });

    $(".problem-title").click(function () {
        $(this).parent().find(".panel-body").toggle();
    });

});