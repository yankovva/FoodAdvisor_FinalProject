window.onload = function () {
	toggleContent();
};
function toggleContent() {

	const selectedOption = document.querySelector('input[name="contentOption"]:checked').value;
	
		document.getElementById('content1').style.display = (selectedOption === "1") ? "flex" : "none";
		document.getElementById('content2').style.display = (selectedOption === "2") ? "flex" : "none";
}