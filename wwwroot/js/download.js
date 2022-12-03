$(function f()
{
    let $downloadButton = $("#downloadButton");
    let $forContent = $(".forContent");
    let $forDate = $(".forDate");
    let $hw = $(".hwItem");

    $downloadButton.on("click", () => {
        $.ajax({
            url: `/Homework/Download?path=${$forContent.attr("data-title") }`,
            contentType: "application/json",
            type: "POST",
            data: JSON.stringify({
                Title: $forContent.data("title"),
                Content: $forContent.attr("data-content"),
                Sent: $forDate.attr("data-sent")
            }),
            success: function () {
                //alert("Homework was downloaded!");
                alert($forContent.data("title"));
            }
        });
    });
})