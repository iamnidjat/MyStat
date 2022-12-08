$(function f()
{
    let $removeButton = $(".removeButtons");
   // let $hw = $(".hwItem");
    let $hw = $("#hwItems");

    $removeButton.on("click", (e) => {

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
                    $hw.remove();
                }
            });
    });
})