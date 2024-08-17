var inputs = document.querySelectorAll(".ipt");

for (let input of inputs) {
    input.addEventListener("click", () => {
        var sibling = input.lastElementChild
        sibling.innerText = ""
    })
}
