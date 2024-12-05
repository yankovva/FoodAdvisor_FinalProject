function filterUsers() {
	const searchValue = document.getElementById('searchBox').value.toLowerCase();
	const rows = document.querySelectorAll('#userTable tr');
	rows.forEach(row => {
		const username = row.cells[0].textContent.toLowerCase();
		const email = row.cells[1].textContent.toLowerCase();
		row.style.display = (username.includes(searchValue) || email.includes(searchValue)) ? '' : 'none';
	});
}

const showFormButtons = document.getElementsByClassName("showFormButton");
const managerModals = document.getElementsByClassName("managerModal");
const closeModals = document.getElementsByClassName("closeModal");
const managerForms = document.getElementsByClassName("managerForm");

if (showFormButtons.length > 0 && managerModals.length > 0 && closeModals.length > 0) {
	for (let i = 0; i < showFormButtons.length; i++) {
		showFormButtons[i].addEventListener("click", () => {
			managerModals[i].style.display = "block"; 
		});
	}

	for (let i = 0; i < closeModals.length; i++) {
		closeModals[i].addEventListener("click", () => {
			managerModals[i].style.display = "none";
		});
	}

	// AJAX Form submission
	for (let i = 0; i < managerForms.length; i++) {
		managerForms[i].addEventListener("submit", function (event) {
			event.preventDefault();

			const formData = new FormData(event.target);

			fetch('AdminManage/CreateManager', {
				method: 'POST',
				body: formData
			})
				.then(response => response.json())
				.then(data => {
					if (data.success) {
						alert('Manager was added successfully!');
						managerModals[0].style.display = "none";
						location.reload();
					} else {
						alert('Error: ' + data.message);
					}
				})
				.catch(error => console.error('Error:', error));
		});
	}
}

