clearIcon = document.querySelector(".clear-icon")
searchBox = document.querySelector("#search-box")

clearIcon.addEventListener("click", () => {
    searchBox.value = ""
})
