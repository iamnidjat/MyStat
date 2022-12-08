$(function f()
{
    let $downloadButton = $(".downloadButtons");
    let $forContent = $(".forContent");
    let $forTitle = $(".forTitle");
    let $forDate = $(".forDate");

    $downloadButton.on("click", (e) => {
        $.ajax({
            url: `/Homework/Download`,
            type: "GET",
            data:
            {
                Title: $forTitle.attr("data-title"),
                Content: $forContent.attr("data-content"),
                Sent: $forDate.attr("data-sent")
            },
            success: function () {
                alert("Homework was downloaded to folder Downloads!");
            }
        });
    });
})