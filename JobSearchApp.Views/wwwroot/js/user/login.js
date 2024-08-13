document.getElementById('loginBtn').addEventListener('click', function (event) {
    // Capturar los valores de los campos de entrada
    var form = document.querySelector(".validate-form");

    if (isValidForm(form, event)) {
        const username = document.getElementById("email").value;
        const password = document.getElementById("password").value;

        // Crear un objeto con los datos que se enviarán
        const data = {
            username: username,
            password: password
        };

        // Realizar la solicitud POST con Axios
        axios.post('https://localhost:7056/api/User/authenticate', data)
            .then(function (response) {
                window.location.href = "/pages/home/HomeUserBusinessReclutator.html";
            })
            .catch(function (error) {
                // Manejar los errores
                console.error('Error en la solicitud:', error.response.data);
            });
    } else {
        event.preventDefault();
    }
});
