$(function f()
{
    let $downloadButton = $(".downloadButtons");

    $downloadButton.on("click", (e) => {
        $.ajax({
            url: `/Homework/Download`,
            type: "GET",
            data:
            {
                Title: $(e.target).attr("data-title"),
                Content: $(e.target).attr("data-content"),
                Sent: $(e.target).attr("data-sent")
            },
            success: function () {
                alert("Homework was downloaded to folder Downloads!");
            }
        });
    });
})