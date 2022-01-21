$(document).ready(() => {
    $("#btnRefreshTable").on("click", function() {
        fetchCustomerTable();
    });
});

window.onload = function() {
    fetchCustomerTable();
};

function fetchCustomerTable() {
    $.ajax({
        url: "FetchCustomerTableData",
        success: function (data) {
            $("tbody").empty();
            for (let i = 0; i < data.length; i++) {
                $("tbody").append(
                    `<tr><td>${data[i].id}</td><td>${data[i].firstName}</td><td>${data[i].lastName}</td><td>${data[i].fullName}</td></tr>`);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
};