// URL de la API
const apiUrl = 'https://localhost:7056/api/question';

// Función para obtener las preguntas desde la API y llenar el select
async function fetchAndPopulateSelect() {
    try {
        // Realizar la solicitud a la API
        const response = await fetch(apiUrl);
        if (!response.ok) {
            throw new Error('Error al obtener los datos de la API');
        }

        // Convertir la respuesta a JSON
        const questions = await response.json();

        // Llamar a la función SelectList con los datos obtenidos
        const options = questions.map(question => question.questionText); // Cambiar 'QuestionText' a 'questionText'
        options.sort;
        options.unshift("Selecciona una pregunta");
        SelectList(options);
    } catch (error) {
        console.error('Error:', error);
    }
}

// Llamar a la función para obtener los datos y llenar el select cuando la página se carga
document.addEventListener('DOMContentLoaded', fetchAndPopulateSelect); // Asegurarse de que la función se llame al cargar el DOM

// Función para generar dinámicamente las opciones en el select
function SelectList(options) {
    const selectElement = document.getElementById('dynamicSelect');

    // Limpia cualquier opción previa para evitar duplicados si se llama varias veces
    selectElement.innerHTML = '';

    // Genera dinámicamente las options basadas en la lista
    options.forEach((option, index) => {
        const optionElement = document.createElement('option');
        optionElement.value = index + 1; // Puedes ajustar el valor según sea necesario
        optionElement.textContent = option;
        selectElement.appendChild(optionElement);
    });
}
