document.addEventListener('DOMContentLoaded', function () {
    // Handle the edit icon click
    document.querySelectorAll('.edit-icon').forEach(function (icon) {
        icon.addEventListener('click', function () {
            var parent = this.closest('.tag');
            parent.querySelector('.interest-text').style.display = 'none';
            parent.querySelector('.edit-form').style.display = 'inline';
            parent.querySelector('.edit-form input[type=text]').focus();
        });
    });

    // Handle the form submit
    document.querySelectorAll('.edit-form').forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault(); // Prevent the default form submission
            var parent = this.closest('.tag');
            var input = this.querySelector('input[name=InterestText]');
            var text = parent.querySelector('.interest-text');

            // Send AJAX request to update interest
            fetch(this.action, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'X-Requested-With': 'XMLHttpRequest'
                },
                body: new URLSearchParams(new FormData(this)).toString()
            })
                .then(response => response.text())
                .then(() => {
                    // Update the text and hide the form
                    text.textContent = input.value;
                    text.style.display = 'inline';
                    this.style.display = 'none';
                })
                .catch(error => console.error('Error:', error));
        });
    });
});