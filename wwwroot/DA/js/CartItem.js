$(document).ready(function ()
{
    $('body').on('click', '.btnAddToCart', function (e) {
        e.prevenDefault();
        var id = $(this).data('id');
        alert(id);
    });
}