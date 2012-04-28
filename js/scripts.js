$(function () {
    $('[data-confirm]').live('click', function () {
        if ($(this).parent().hasClass('modal-footer')) {
            return;
        }
        $('.modal-body').text($(this).attr('data-confirm'));
        $('.modal-footer>:not(:contains("Close"))').remove();
        $(this)
        .clone(true)
        .prependTo('.modal-footer')
        .removeClass('btn-mini')
        .append($('<span></span>').text($(this).attr('data-original-title')));
        $('#myModal').modal();
        return false;
    });
    if ($('.brand').css('color').substring(4, 7) != '255') {
        $('.nav i').removeClass('icon-white');
    }
});