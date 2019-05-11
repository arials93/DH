$(document).ready(function () {
    delete_confirm();
    submit_form();
});

function delete_confirm() {
    $(document).delegate('.delete_confirm', 'click', function () {
        var url = $(this).attr('data-url');
        $('#delete_confirm').find('form').attr('action', url);
    });
}

function submit_form() {
    $(document).delegate('#submit_form', 'click', function () {
        var form = $(this).parents('.m-wrapper').find('form');
        form.submit();
    });
}