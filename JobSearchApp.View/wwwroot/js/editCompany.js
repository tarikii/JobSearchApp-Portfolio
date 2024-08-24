function showEditOptions() {
    document.getElementById('editButton').classList.add('d-none');
    document.getElementById('editOptions').classList.remove('d-none');

    // Mostrar inputs y ocultar textos
    document.querySelectorAll('p').forEach(p => p.classList.add('d-none'));
    document.querySelectorAll('input, textarea').forEach(input => input.classList.remove('d-none'));
}

function confirmEdit() {
    // Ocultar inputs y mostrar textos
    document.querySelectorAll('input, textarea').forEach(input => input.classList.add('d-none'));
    document.querySelectorAll('p').forEach(p => p.classList.remove('d-none'));

    document.getElementById('editButton').classList.remove('d-none');
    document.getElementById('editOptions').classList.add('d-none');

    // Aquí puedes agregar lógica para manejar la confirmación, como enviar el formulario
}

function cancelEdit() {
    // Ocultar inputs y mostrar textos
    document.querySelectorAll('input, textarea').forEach(input => input.classList.add('d-none'));
    document.querySelectorAll('p').forEach(p => p.classList.remove('d-none'));

    document.getElementById('editButton').classList.remove('d-none');
    document.getElementById('editOptions').classList.add('d-none');
}