document.getElementById('registerBtn').addEventListener('click', function (event) {
    var form = document.querySelector(".validate-form");

    if (isValidForm(form, event)) {
        // Capturar los valores de los campos de entrada

        const name = document.getElementById("name").value;
        const lastName = document.getElementById("lastname").value;
        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;
        const confirmPassword = document.getElementById("confirm-password").value;
        const username = document.getElementById("username").value;

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
                console.log('Response:', response);
                window.location.href = "/pages/HomeUserBusinessReclutator.html";
            })
            .catch(function (error) {
                console.error('Error:', error);
                if (error.response) {
                    console.error('Error response:', error.response.data);
                    alert('Error creating user: ' + error.response.data);
                } else {
                    console.error('Error:', error.message);
                    alert('Error creating user: ' + error.message);
                }
            });
    } else {
        event.preventDefault();
    }
});