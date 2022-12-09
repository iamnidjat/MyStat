$(function f()
{
    let $removeButton = $(".removeButtons");
    let $hw = $("[data-id]");

    $removeButton.on("click", (e) => {
        $.ajax(
            {
                url: `/Homework/Remove`,
                contentType: "application/json",
                type: "POST",
                data:
                    JSON.stringify({
                   // Id: $removeButton.data("id")
                     Id: $(e.target).attr("data-id")
                }),
                success: (data) => {
                    alert("Homework was deleted");
                    //$('div').remove("[data-id]");
                   // $hw.closest('div').closest('div').closest('div').remove();
                    $hw.closest('.hwItem').remove();
                }
            });
    });
})