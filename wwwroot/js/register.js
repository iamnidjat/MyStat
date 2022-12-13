$(function f() {
    let $checkbox = $('#showPassword')
    let $text = $('#Password')
    let $text2 = $('#ConfirmPassword')

    if ($checkbox.is(':checked')) {
        $text.attr("Type", "Text");
        $text2.attr("Type", "Text");
    }
    else {
        $text.attr("Type", "Password");
        $text2.attr("Type", "Password");
    }
})