function validateText(inputElement, errorMessageElement) {
    if (inputElement.value.trim() === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateNumber(inputElement, errorMessageElement) {
    if (inputElement.value.trim() === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else if (isNaN(parseFloat(inputElement.value.trim()))) {
        errorMessageElement.textContent = "Please enter a valid number!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateEmail(emailElement, errorMessageElement) {
    var value = emailElement.value.trim();

    var allowedDomains = ['com', 'net', 'org', 'es', 'mx', 'ar', 'cl', 'co.uk', 'fr',
        'de', 'it', 'jp', 'cn', 'in', 'br', 'ca', 'au', 'ru'];

    var emailPattern = new RegExp('^[^\\s@]+@[^\\s@]+\\.(' + allowedDomains.join('|') + ')$');

    if (value === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else if (!emailPattern.test(value)) {
        errorMessageElement.textContent = "Please enter a valid email address!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validatePassword(passwordElement, errorMessageElement) {
    var value = passwordElement.value.trim();

    const hasUpperCase = /[A-Z]/;
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/;

    if (value === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else if (value.length < 8) {
        errorMessageElement.textContent = "The password must be 8 characters minimum";
        return false;
    } else if (!hasUpperCase.test(value)) {
        errorMessageElement.textContent = "The password must contain one uppercase letter!";
        return false;
    } else if (!hasSpecialChar.test(value)) {
        errorMessageElement.textContent = "The password must contain one special character!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateConfirmPassword(passwordElement, confirmPasswordElement, errorMessageElement) {
    if (confirmPasswordElement.value.trim() === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else if (passwordElement.value.trim() !== confirmPasswordElement.value.trim()) {
        errorMessageElement.textContent = "Passwords do not match!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateSalary(salaryElement, errorMessageElement) {
    var value = salaryElement.value.trim();

    var numericValue = parseFloat(value);

    if (value === "" || isNaN(numericValue) || numericValue <= 0) {
        errorMessageElement.textContent = "Salary must be greater than 0 and cannot be empty!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateSalaryRange(minSalaryElement, maxSalaryElement, errorMessageElement) {
    var minSalary = parseFloat(minSalaryElement.value.trim());
    var maxSalary = parseFloat(maxSalaryElement.value.trim());

    if (maxSalary <= minSalary) {
        errorMessageElement.textContent = "Max Salary must be greater than Min Salary!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateGithubUrl(inputElement, errorMessageElement) {
    const value = inputElement.value.trim();
    const githubUrlPattern = /^https?:\/\/(?:www\.)?github\.com\/[a-zA-Z0-9_-]+\/?$/;

    if (value === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else if (!githubUrlPattern.test(value)) {
        errorMessageElement.textContent = "Please enter a valid GitHub profile URL!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function validateLinkedinUrl(inputElement, errorMessageElement) {
    const value = inputElement.value.trim();
    const linkedinUrlPattern = /^https?:\/\/(?:www\.)?linkedin\.com\/in\/[a-zA-Z0-9_-]+\/?$/;

    if (value === "") {
        errorMessageElement.textContent = "This field cannot be empty!";
        return false;
    } else if (!linkedinUrlPattern.test(value)) {
        errorMessageElement.textContent = "Please enter a valid LinkedIn profile URL!";
        return false;
    } else {
        errorMessageElement.textContent = "";
        return true;
    }
}

function isValidForm(form, event) {
    var isValid = true;

    var inputs = form.querySelectorAll(".validate-input");
    var errorMessages = form.querySelectorAll(".error-message");

    inputs.forEach(function (input, index) {
        var errorMessage = errorMessages[index];

        switch (input.type) {
            case "email":
                if (!validateEmail(input, errorMessage)) isValid = false;
                break;
            case "password":
                if (input.id === "confirm-password") {
                    var passwordInput = document.querySelector("#password");
                    if (!validateConfirmPassword(passwordInput, input, errorMessage)) isValid = false;
                } else {
                    if (!validatePassword(input, errorMessage)) isValid = false;
                }
                break;
            case "number":
                if (input.id === "min-salary" || input.id === "max-salary") {
                    if (!validateSalary(input, errorMessage)) isValid = false;
                    if (input.id === "max-salary") {
                        var minSalaryInput = document.querySelector("#min-salary");
                        if (!validateSalaryRange(minSalaryInput, input, errorMessage)) isValid = false;
                    }
                } else {
                    if (!validateNumber(input, errorMessage)) isValid = false;
                }
                break;
            case "url":
                if (input.id === "github-url") {
                    if (!validateGithubUrl(input, errorMessage)) isValid = false;
                } else if (input.id === "linkedin-url") {
                    if (!validateLinkedinUrl(input, errorMessage)) isValid = false;
                } else {
                }
                break;
            default:
                if (!validateText(input, errorMessage)) isValid = false;
        }
    });

    return isValid;
}