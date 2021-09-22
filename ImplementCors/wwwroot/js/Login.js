$("#loginForm").on("submit", function () {
    let data = document.querySelector('#loginForm');
    let email = $('#inputEmail').val();
    let password = $("#inputPassword").val();
    //event.preventDefault();
    console.log(email);
    console.log(password)

   /* $.ajax({
        url: "https://localhost:44316/API/Accounts/Login",
        *//*dataType : "JSON",*//*
        type: "POST"
    }).done((result) => {
        console.log(result)
    }).fail((error) => {
        console.log(error)
    });*/
})
    