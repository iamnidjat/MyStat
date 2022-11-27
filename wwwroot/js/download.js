$(function f()
{
    let $downloadButton = $("#downloadButton");
    let $forContent = $(".forContent");
    let $hw = $(".hwItem");

    $downloadButton.on("click", () => {
        $.post(
            {
                url: `/Homework/Download?path=${$forContent.attr("data-title")}&item=${$hw.attr("data-item")}`,
                success: (data) => {
                    alert("Homework was downloaded");
                }
            });
    });
})