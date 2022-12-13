$(function f()
{
    let $removeButton = $(".removeButtons");

    $removeButton.on("click", (e) => {
        $.ajax(
            {
                url: `/Homework/Remove`,
                contentType: "application/json",
                type: "POST",
                data:
                    JSON.stringify({
                        Id: $(e.target).attr("data-id")
                }),
                success: (data) => {
                    alert("Homework was deleted");
                    $(e.target).parents('div').eq(1).remove();
                }
            });
    });
})