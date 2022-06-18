$(document).ready(function () {

    $('.header-level').click(function () {
        $(this).next('.sub-level').find('table').toggle();
    });

});