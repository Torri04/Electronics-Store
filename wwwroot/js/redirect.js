var text = document.querySelector(".second").innerText
var a_tag = document.querySelector(".re-href")
var href = a_tag.getAttribute("href");

var sc_reverse = document.querySelector(".sc-reverse")

if (sc_reverse != null && text != "0") {
    sc_int = parseInt(sc_reverse.innerText)

    const interval = setInterval(function () {
        if (sc_int == 0) {
            clearInterval(interval);
            window.location.href = href;
        }
        else {
            sc_int = sc_int - 1
            sc_reverse.innerText = sc_int
        }
    }, 1000)
}



