$.ajax({
    url: "https://localhost:44316/api/Persons/GetAllProfile"
}).done(result => {
    console.log(result);
});

$(document).ready(function () {
    $('#tableClient').DataTable({
        "filter": true,
        "ajax": {
            "url": "https://localhost:44316/api/Persons/GetAllProfile",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                "data": "nik"
            },
            {
                "data": null,
                "render": function (data, type, row) {

                    return row["firstName"] + row["lastName"];
                },
                "autoWidth": true
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row["email"];
                },
                "autoWidth": true
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    if (row['phone'].startsWith('0')) {
                        return `+62${row['phone'].substr(1)}`
                    }
                    return `+62${row["phone"]}`
                },
                "autoWidth": true
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detail('${row['nik']}')" data-toggle="modal" data-target="#exampleModal">Detail</button >`
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-danger" onclick="deleted('${row['nik']}')">Delete</button > `
                }
            }
        ]
    });
});

function detail(nik) {
    $.ajax({
        url: `https://localhost:44316/api/Persons/GetById/${nik}`
    }).done((result) => {
        text = ` <table class="table table-bordered">
                <tbody>
                    <tr>
                        <td><b>NIK :</b> ${result.nik}</td>
                    </tr>
                    <tr>
                        <td><b>Name :</b> ${result.firstName + result.lastName}</td>
                    </tr>
                    <tr>
                        <td><b>Gender :</b> ${result.gender}</td>
                    </tr>
                    <tr>
                        <td><b>Phone Number :</b> ${result.phone.startsWith('0') ? '+62' + result.phone.substr(1) : '+62' + result.phone}</td>
                    </tr>
                   
                    <tr>
                        <td><b>Degree :</b> ${result.degree}</td>
                    </tr>
                    <tr>
                        <td><b>GPA :</b> ${result.gpa}</td>
                    </tr>
                    <tr>
                        <td><b>Salary :</b> Rp. ${result.salary}</td>
                    </tr>
                    <tr>
                        <td><b>Birth Date : </b> ${result.birthDate}</td>
                    </tr>
                    <tr>
                        <td><b>University Id : </b> ${result.universityId}</td>
                    </tr>
                </tbody>
            </table>
               `;
        $("#bodyModal").html(text);
    }).fail((error) => {
        console.log(error);
    });
}

$.ajax({
    url: "https://localhost:44316/API/Universities/",

}).done(result => {
    text = ''
    $.each(result.data, function (key, val) {
        console.log(val.id)
        text += `<option value= "${val.id}">${val.name}</option>`
    })
    $('#inputUniversity').html(text)
}).fail(result => {
    console.log(result)
});

$("#registerBtn").click(function (event) {
    event.preventDefault();

    bootstrapValidate('#inputFirstName', 'required');
    bootstrapValidate('#inputLastName', 'required');
    bootstrapValidate('#inputPhone', 'required');
    bootstrapValidate('#inputBirthdate', 'required');
    bootstrapValidate('#inputSalary', 'required');
    bootstrapValidate('#inputEmail', 'required');
    bootstrapValidate('#inputPassword', 'required');
    bootstrapValidate('#inputDegree', 'required');
    bootstrapValidate('#inputGpa', 'required');
    bootstrapValidate('#inputUniversity', 'required');

    var obj = new Object();
    var element = document.getElementsByName('inputGender');

    for (var i = 0; i < element.lenght; i++) {
        if (element[i].checked) {
            var gender = element[i].value;
        }
    }
    console.log(gender);

    obj.NIK = $('#inputNIK').val();
    obj.FirstName = $("#inputFirstName").val();
    obj.LastName = $("#inputLastName").val();
    obj.Phone = parseInt($("#inputPhone").val());
    obj.BirthDate = $("#inputBirthDate").val();
    obj.Gender = parseInt($("#inputGender").val());
    obj.Salary = parseInt($("#inputSalary").val());
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    obj.Degree = $("#inputDegree").val();
    obj.GPA = $("#inputGPA").val();
    obj.UniversityId = parseInt($("#inputUniversity").val());
    console.log(obj);

    $.ajax({
        url: 'https://localhost:44316/API/Persons/Register',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        $('#tableClient').DataTable().ajax.reload();
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Registered',
            icon: 'success',
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Register',
            icon: 'error',
            confirmButtonText: 'Back'
        })
        console.log(error);
    });
})

function deleted(nik) {
    $.ajax({
        url: `https://localhost:44316/API/Persons/${nik}`,
        type: "DELETE",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).done((result) => {
        $('#tableClient').DataTable().ajax.reload();
        Swal.fire({
            title: 'Success!',
            text: 'Data Has Been Deleted',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
}
