// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.allowNumOnly').on('input', function (e) {
    this.value = this.value.replace(/[^0-9]/g, '');
});


$('.englishOnly').keypress(function (e) {
    var regex = new RegExp("^[a-zA-Z0-9 ]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;   
    }
    e.preventDefault();
    return false;
});

$(function () {
    $("#searchInput").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Restaurant/GetSearchValue",
                data: { SearchString: $("#searchInput").val() },
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data.data, function (item) {
                        console.log(item)
                        return {
                            label: item.name,
                            value: item.name
                        };
                    }))
                },
            });
        },
        minLength: 1
    });
});

$(function () {
    $("#searchInput2").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Food/searchResauot",
                data: { SearchString: $("#searchInput2").val() },
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data.data, function (item) {
                        console.log(item)
                        return {
                            label: item.name,
                            value: item.name
                        };
                    }))
                },
            });
        },
        minLength: 1
    });
});