$(function f()
{
    let $downloadButton = $("#downloadButton");
    let $forContent = $(".forContent");
    let $forDate = $(".forDate");
    let $hw = $(".hwItem");

    $downloadButton.on("click", (e) => {
        $.ajax({
            url: `/Homework/Download`,
            type: "GET",
            data:
            {
                Title: $forContent.data("title"),
                Content: $forContent.attr("data-content"),
                Sent: $forDate.attr("data-sent")
            },
            success: function () {
                alert("Homework was downloaded!");
            }
        });
    });
})