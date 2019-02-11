$(document).ready(function () {
	if(document.getElementById("detailDescription") !== null) {
		var text = document.getElementById("detailDescription").textContent,
			target = document.getElementById("detailDescription"),
			converter = new showdown.Converter(),
			html = converter.makeHtml(text);

		target.innerHTML = html;
	}

});