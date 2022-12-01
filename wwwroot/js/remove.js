$(function f()
{
    let $removeButton = $("#removeButton");
    let $hw = $(".hwItem");

    $removeButton.on("click", () => {
        $.post(
            {
                url: `/Homework/Remove?id=${$removeButton.attr("data-id")}`,
                success: (data) => {
                    alert("Homework was deleted");
                   //$hw.remove();
                }
            });
    });
})