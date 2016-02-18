$(function () {
    $("#getpeople-button").on('click', function () {
        var amt = $("#pplAmount").val();
        $.post("/home/getpeople", { peopleAmount: amt }, function (people) {
            people.forEach(function (person) {
                var row = $("<tr><td>" + person.FirstName +
                    "</td><td>" + person.LastName + "</td><td>" + person.Age +
                    "</td><td><button class='btn btn-success show'>Show</button></td></tr>");
                $("table").append(row);
            });
        });
    });

    $("#clear-button").on('click', function () {
        $("table tr:gt(0)").remove();
    });

    $("table").on('click', '.show', function () {
        var row = $(this).parent().parent();
        var name = row.find("td:eq(0)").text();
        alert(name);
    });
});