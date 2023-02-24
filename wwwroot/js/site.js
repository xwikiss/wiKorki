$(document).ready(function () {
    $(".left-hamburger").click(function () {
        $(".left-nav").toggleClass("active-left-nav");
        $(".recently-added").toggleClass("active-article");
    })
})
$(document).ready(function () {
    $(".right-hamburger").click(function () {
        $(".right-nav").toggleClass("active-right-nav");
        $(".counter").toggleClass("active-article");
        $(".articles-links").toggleClass("active-article");
    })
})