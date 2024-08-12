document.getElementById('registerBtn').addEventListener('click', function () {
    // Capturar los valores de los campos de entrada

    const name = document.getElementById("name").value;
    const lastName = document.getElementById("lastName").value;
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const confirmPassword = document.getElementById("confirmPassword").value;
    const username = document.getElementById("username").value;

    console.log(username);

    // Crear un objeto con los datos que se enviarán
    const data = {
        email: email,
        userName: username,
        passwordHash: password,
        userType: "string",
        firstName: name,
        lastName: lastName,
        headline: "string",
        summary: "string",
        location: "string",
        dateJoined: "2024-08-09T09:00:04.206Z",
        linkedInUrl: "string",
        genderIdentity: "string",
        pronoun: "string",
        ethnicity: "string",
        mobileNumber: "string",
        requireVisa: true,
        searchStage: "string",
        profilePicture: "string",
        profileUrl: "string",
        portfolioUrl: "string",
        roleId: 1,
        companyId: 1,
        isWorking: true
    };


    // Realizar la solicitud POST con Axios
    axios.post('https://localhost:7056/api/User', data)
        .then(function (response) {
            console.log('Respuesta:', response.data);
        })
        .catch(function (error) {
            // Manejar los errores
            console.error('Error en la solicitud:', error);
        });
});
