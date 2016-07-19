$(document).ready(function () {
    /*POST*/
    $.ajax({
        url: '/User/Create',
        dataType: "json",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ user: { name: 'Rintu', email: 'Rintu@gmial.com' } }),
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