$(document).ready(function () {
    delete_confirm();
    submit_form();
    censored_confirm();
    account_status_confirm();
});

var t;
    t = mUtil.isRTL() ? {
        leftArrow: '<i class="la la-angle-right"></i>', rightArrow: '<i class="la la-angle-left"></i>'
    }
    : {
    leftArrow: '<i class="la la-angle-left"></i>', rightArrow: '<i class="la la-angle-right"></i>'
    }
    ;

function delete_confirm() {
    $(document).delegate('.delete_confirm', 'click', function () {
        var url = $(this).attr('data-url');
        $('#delete_confirm').find('form').attr('action', url);
    });
}

function account_status_confirm() {
    $(document).delegate('.acc_status_confirm', 'click', function () {
        var url = $(this).attr('data-url');
        $('#acc_status_confirm').find('form').attr('action', url);
    });
}

function censored_confirm() {
    $(document).delegate('.censored_confirm', 'click', function () {
        var url = $(this).attr('data-url');
        $('#censored_confirm').find('form').attr('action', url);
    });
}

function submit_form() {
    $(document).delegate('#submit_form', 'click', function () {
        var form = $(this).parents('.m-wrapper').find('#trigger_submit');
        form.click();
    });
}