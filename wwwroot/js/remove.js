$(function f()
{
    let $removeButton = $("#removeButton");
   // let $hw = $(".hwItem");
   // let $hw = $("@item.Id");

    $removeButton.on("click", (e) => {

        let $target = $(e.target).attr('class');

        if (!$target.hasClass("hwItem")) {
            alert("Ok");
        }


        //$.ajax(
        //    {
        //        url: `/Homework/Remove`,
        //        contentType: "application/json",
        //        type: "POST",
        //        data:
        //            JSON.stringify({
        //            Id: $removeButton.data("id")
        //        }),
        //        success: (data) => {
        //            alert("Homework was deleted");
        //           // $hw.not(':last-child').remove();
        //           // $hw.removeClass('remove');
        //          //  $(this).addClass('remove');
        //          //  $(this).remove();
        //          //  $hw.remove();
        //        }
        //    });
    });
})