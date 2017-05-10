

function ()
{
$('#split-bar').mousedown(function (e) {
    e.preventDefault();
    $(document).mousemove(function (e) {
        e.preventDefault();
        var x = e.pageX - $('#sidebar').offset().left;
        if (x > min && x < max && e.pageX < ($(window).width() - mainmin)) {
            $('#sidebar').css("width", x);
            $('#editor').css("margin-left", x);
        }
    })
});
}
