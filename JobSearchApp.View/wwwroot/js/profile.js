function enableEditing() {
    var buttonEdit = document.getElementById("button-edit");

    buttonEdit.style.display = "none";

    const editButtons = document.getElementById('edit-buttons');
    if (editButtons.style.display === 'none' || editButtons.style.display === '') {
        editButtons.style.display = 'flex';  // Muestra el div
    } else {
        editButtons.style.display = 'none';  // Oculta el div
    }

    const fields = ['UserName','FirstName', 'LastName', 'GenderIdentity', 'Location', 'LinkedInUrl', 'Headline', 'MobileNumber'];
    fields.forEach(field => {
        const element = document.getElementById(field);
        const currentValue = element.innerText;
        const nameId = element.id;
        element.innerHTML = `<input name="${nameId}"  class="form-control" type="text" value="${currentValue}" style="width: 100%;">`;
    });
}