

$(document).ready(function () {
    /*PUT*/
    $.ajax({
        url: '/User/Edit',
        dataType: "json",
        type: "PUT",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ id: 100, user: {name: 'Rintu', email: 'Rintu@gmial.com'} }),
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            alert(data);
        },
        error: function (xhr) {
            alert('error');
        }
    });
});