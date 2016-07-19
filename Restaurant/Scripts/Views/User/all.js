$(document).ready(function () {

    $('#btnGrid').click(function() {
        /*GET*/
        $.ajax({
            url: '/User/Find/3/5',
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            //pageNo: 2, pageSize: 20 would not be posted to the action, 
            //it would be 3 and 5 as we specified it at ajax url 
            //and user would be null
            data: { pageNo: 2, pageSize: 20, user: { name: 'Rintu', email: 'Rintu@gmial.com' } },       
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


    $('#btnSearch').click(function () {
        /*GET*/
        $.ajax({
            url: '/User/Contains',
            dataType: "json",
            type: "GET",
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',    //replace /json to the urlenoded
            data: { name: 'Rintu', email: 'Rintu@gmial.com' },                  // data is not json
            async: true,
            processData: true,                                                  //important to use it as true
            cache: false,
            success: function (data) {
                alert(data);
            },
            error: function (xhr) {
                alert('error');
            }
        });
        
        /*Great work: http://forums.asp.net/t/1934913.aspx?jquery+get+usage+with+mvc+action+method*/
        //$.get('/User/Contains',
        //    { name: 'Rintu', email: 'Rintu@gmial.com' },
        //    function (data) {
        //        alert(data);
        //    });
    });
    
    $('#btnSearchByObject').click(function () {
        /*GET*/
        $.ajax({
            url: '/User/Find',
            dataType: "json",
            type: "GET",
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: { pageNo: 2, pageSize: 20, user: { name: 'Rintu', email: 'Rintu@gmial.com' } },
            async: true,
            processData: true,
            cache: false,
            success: function (data) {
                alert(data);
            },
            error: function (xhr) {
                alert('error');
            }
        });
    });

    $('#btnDelete').click(function() {
        /*DELETE*/
        $.ajax({
            url: '/User/Delete',
            dataType: "json",
            type: "DELETE",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({id: 20}),
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

});