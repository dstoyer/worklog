$(document).ready(function () {
	var text = document.getElementById("detailDescription").value,
		target = document.getElementById("detailDescription"),
		converter = new showdown.Converter(),
		html = converter.makeHtml(text);

	target.innerHTML = html;
});