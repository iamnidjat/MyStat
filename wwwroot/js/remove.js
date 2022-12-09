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
                        Id: $(e.target).attr("data-id")
                }),
                success: (data) => {
                    alert("Homework was deleted");
                  //  $hw.closest('div').find('div:nth').remove();
                   // alert($hw.closest('.hwItem').val());
                   // alert($hw);
                   // $(e.target).attr("data-id").closest('.hwItem').remove();
                   // alert($(e.target).attr("data-id").val);
                    //$(this).parent().remove();
                }
            });
    });
})