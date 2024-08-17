var icons = document.querySelectorAll(".icon-eye")

for (let icon of icons) {
    icon.addEventListener("click", () => {
        var input = icon.previousElementSibling

        if (icon.classList.contains("fa-eye-slash")) {
            icon.classList.remove("fa-eye-slash")
            icon.classList.add("fa-eye")
            input.setAttribute("type", "text")
        }
        else {
            icon.classList.remove("fa-eye")
            icon.classList.add("fa-eye-slash")
            input.setAttribute("type", "password")
        }
    })
}

