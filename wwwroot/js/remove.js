$(function f()
{
    let $removeButton = $("#removeButton");
    let $hw = $(".hwItem");

    $removeButton.on("click", () => {
        //$.post(
        //    {
        //        url: `/Homework/Remove?id=${$removeButton.data("id")}`,
        //        success: (data) => {
        //            alert("Homework was deleted");
        //           //$hw.remove();
        //        }
        //    });

        //$.ajax(
        //    {
        //        url: `/Homework/Remove`,
        //        contentType: "application/json",
        //        type: "POST",
        //        data: id = $removeButton.data("id"),
        //        success: (data) => {
        //            alert("Homework was deleted");
        //        }
        //    });
    });
})