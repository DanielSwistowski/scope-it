$('#btnSubmit').click(function (e) {
    if ($('#emailForm').valid()) {
        e.preventDefault();
        var token = $('[name=__RequestVerificationToken]').val();
        var url = $('#sendMessageUrl').val();

        $('#sendMessageLoader').show();

        $('#btnSubmit').prop('disabled', true);
        $('#btnSubmit').addClass('disabled');

        $.ajax({
            url: url,
            headers: { '__RequestVerificationToken': token },
            data: $('#emailForm').serialize(),
            type: 'POST',
            success: function (result) {
                $('#resultMessage').css('color', 'green');
                $('#resultMessage').html(result.message);
                $('#sendMessageLoader').hide();
                clearForm();
                $('#btnSubmit').prop('disabled', false);
                $('#btnSubmit').removeClass('disabled');
            },
            error: function (result) {
                $('#resultMessage').css('color', 'red');
                $('#resultMessage').html(result.message);
                $('#sendMessageLoader').hide();
                $('#btnSubmit').prop('disabled', false);
                $('#btnSubmit').removeClass('disabled');
            }
        });
    } else {
        e.preventDefault();
    }
});

//$('#emailForm').change(function () {
//    if ($('#emailForm').valid()) {
//        $('#btnSubmit').prop('disabled', false);
//        $('#btnSubmit').removeClass('disabled');
//    } else {
//        $('#btnSubmit').prop('disabled', true);
//        $('#btnSubmit').addClass('disabled');
//    }
//});

function clearForm() {
    $('#emailForm')[0].reset();
}