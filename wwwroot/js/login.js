$(function f() {
    let $checkbox = $('#showPassword')
    let $text = $('#Password')

    if ($checkbox.is(":checked")) {
        $text.attr("Type", "Text");
        alert("5");
    }
    else {
        $text.attr("Type", "Password");
        alert("Checkbox Is not checked");
    }
})