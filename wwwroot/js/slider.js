var swiper = new Swiper(".mySwiper-1", {
    slidesPerView: 'auto',
    centeredSlides: true,
    grabCursor: true,
    loop: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    autoplay: {
        delay: 5000,
    },
    speed: 500,
    navigation: {
        nextEl: ".arrow-right-1",
        prevEl: ".arrow-left-1",
    },
});

var swiper = new Swiper(".mySwiper-2", {
    slidesPerView: 'auto',
    centeredSlides: false,
    grabCursor: true,
    loop: true,
    autoplay: {
        delay: 5000,
    },
    speed: 500,
    navigation: {
        nextEl: ".arrow-right-2",
        prevEl: ".arrow-left-2",
    },
});
