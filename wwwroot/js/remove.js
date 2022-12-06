$(function f()
{
    let $removeButton = $("#removeButton");
    let $hw = $(".hwItem");

    $removeButton.on("click", () => {
        $.ajax(
            {
                url: `/Homework/Remove`,
                contentType: "application/json",
                type: "POST",
                data:
                    JSON.stringify({
                    Id: $removeButton.data("id")
                }),
                success: (data) => {
                    alert("Homework was deleted");
                }
            });
    });
})