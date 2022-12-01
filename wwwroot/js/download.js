$(function f()
{
    let $downloadButton = $("#downloadButton");
    let $forContent = $(".forContent");
    let $forDate = $(".forDate");
    let $hw = $(".hwItem");

    $downloadButton.on("click", () => {
        //$.post(
        //    {
        //        url: `/Homework/Download?path=${$forContent.attr("data-title")}&item=${$hw.attr("data-item")}`,
        //        success: (data) => {
        //            alert("Homework was downloaded");
        //        }
        //    });

        $.ajax({
            url: "/Homework/Download",
            contentType: "application/json",
            type: "POST",
            data: JSON.stringify({
                Title: $forContent.attr("data-title"),
                Content: $forContent.attr("data-content"),
                Sent: $forDate.attr("data-sent")
              //  path: $forContent.attr("data-title")
            }),
            success: function () {
                alert("Homework was downloaded!");
            }
        });
    });
})