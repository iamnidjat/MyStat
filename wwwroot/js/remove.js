$(function f()
{
    let $removeButton = $("#removeButton");
    let $hw = $(".hwItem");

    $removeButton.on("click", (e) => {

        let $target = $(e.originalEvent.target);

        //if ($target.hasClass("container")) {
        //    alert("Ok");
        //}

        alert($("div").hasClass("container"));
        alert($target.hasClass("container"));

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
        //        }
        //    });
    });
})