// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function f() {

    let $removeButton = $("#removeButton");
    let $downloadButton = $("#downloadButton");

    $removeButton.on("click", () => {
        $.post(
            {
                url: `/Homework/Remove?id=${$removeButton.attr("data-id")}`,
                success: (data) => {
                    alert("Homework was deleted");
                }
        });
    });

    //$downloadButton.on("click", () => {
    //    $.ajax(
    //        {
    //            url: `/Homework/Remove?id=${$removeButton.attr("data-id")}`,
    //            success: (data) => {
    //                alert("Homework was deleted");
    //            }
    //        });
    //});
})
