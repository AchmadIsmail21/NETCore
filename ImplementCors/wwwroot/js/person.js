$.ajax({
    url: "https://localhost:44316/api/Persons/GetAllProfile"
}).done(result => {
    console.log(result);
});

$(document).ready(function () {
    $('#tableClient').DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4]
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4]
                }
            }
        ],
        "filter": true,
        "ajax": {
            "url": "/person/getalldata",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                "data": null, "sortable": true,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
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
                    return `<button type="button" class="btn btn-primary" onclick="detail('${row['nik']}')" data-toggle="modal" data-target="#exampleModal">Detail</button >
                            `
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

    if ($("#inputNIK").val() == "") {
        document.getElementById("inputNIK").className = "form-control is-invalid";
        $("#msgNIK").html("NIK tidak Boleh Kosong");
    } else {
        document.getElementById("inputNIK").className = "form-control is-valid";
        obj.NIK = $("#inputNIK").val();
    }

    if ($("#inputFirstName").val() == "") {
        document.getElementById("inputFirstName").className = "form-control is-invalid";
        $("#msgFirstName").html("First Name tidak boleh kosong");
    } else {
        document.getElementById("inputFirstName").className = "form-control is-valid";
        obj.FirstName = $("#inputFirstName").val();
    }

    if ($("#inputLastName").val() == "") {
        document.getElementById("inputLastName").className = "form-control is-invalid";
        $("#msgLastName").html("Last Name tidak boleh kosong");
    } else {
        document.getElementById("inputLastName").className = "form-control is-valid";
        obj.LastName = $("#inputLastName").val();
    }

    if ($("#inputPhone").val() == "") {
        document.getElementById("inputPhone").className = "form-control is-invalid";
        $("#msgPhone").html("Phone number tidak boleh kosong");
    } else {
        document.getElementById("inputPhone").className = "form-control is-valid";
        obj.Phone = parseInt($("#inputPhone").val());
    }

    if ($("#inputBirthDate").val() == "") {
        document.getElementById("inputBirthDate").className = "form-control is-invalid";
        $("#msgBirthDate").html("Birth Date tidak boleh kosong");
    } else {
        document.getElementById("inputBirthDate").className = "form-control is-valid";
        obj.BirthDate = $("#inputBirthDate").val();
    }

    if ($("#inputGender").val() == "") {
        document.getElementById("inputGender").className = "form-control is-invalid";
        $("#msgGender").html("Gender tidak boleh kosong");
    } else {
        document.getElementById("inputGender").className = "form-control is-valid";
        obj.Gender = parseInt($("#inputGender").val());
    }

    if ($("#inputSalary").val() == "") {
        document.getElementById("inputSalary").className = "form-control is-invalid";
        $("#msgSalary").html("Salary tidak boleh kosong");
    } else {
        document.getElementById("inputSalary").className = "form-control is-valid";
        obj.Salary = parseInt($("#inputSalary").val());
    }

    if ($("#inputEmail").val() == "") {
        document.getElementById("inputEmail").className = "form-control is-invalid";
        $("#msgEmail").html("Email tidak boleh kosong");
    } else {
        document.getElementById("inputEmail").className = "form-control is-valid";
        obj.Email = $("#inputEmail").val();
    }

    if ($("#inputPassword").val() == "") {
        document.getElementById("inputPassword").className = "form-control is-invalid";
        $("#msgPassword").html("Password tidak boleh kosong");
    } else {
        document.getElementById("inputPassword").className = "form-control is-valid";
        obj.Password = $("#inputPassword").val();
    }

    if ($("#inputDegree").val() == "") {
        document.getElementById("inputDegree").className = "form-control is-invalid";
        $("#msgDegree").html("Degree tidak boleh kosong");
    } else {
        document.getElementById("inputDegree").className = "form-control is-valid";
        obj.Degree = $("#inputDegree").val();
    }

    if ($("#inputGPA").val() == "") {
        document.getElementById("inputGPA").className = "form-control is-invalid";
        $("#msgGPA").html("Gender tidak boleh kosong");
    } else {
        document.getElementById("inputGPA").className = "form-control is-valid";
        obj.GPA = $("#inputGPA").val();
    }

    if ($("#inputUniversity").val() == "") {
        document.getElementById("inputUniversity").className = "form-control is-invalid";
        $("#msgUniversity").html("Gender tidak boleh kosong");
    } else {
        document.getElementById("inputUniversity").className = "form-control is-valid";
        obj.UniversityId = parseInt($("#inputUniversity").val());
    }

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
    Swal.fire({
        title: 'Anda ingin menghapus data ?',
        text : "Pastikan dulu yaa",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Delete',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `https://localhost:44316/API/Persons/${nik}`,
                type: "DELETE",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            }).done((result) => {
                Swal.fire({
                    title: 'Success!',
                    text: 'Data Has Been Deleted',
                    icon: 'success',
                    confirmButtonText: 'Next'
                })
                $('#tableClient').DataTable().ajax.reload();
            }).fail((error) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Data Cannot Deleted',
                    icon: 'Error',
                    confirmButtonText: 'Next'
                })
            });
        }
    })
    
}
