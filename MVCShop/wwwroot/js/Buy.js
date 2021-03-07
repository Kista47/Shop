function buy(id) {
    $('.alert').removeClass("hide");
    $('.alert').addClass("animate__animated");
    $('.alert').addClass("animate__fadeInRight");

    $.ajax({
        url: "/Catalog/Buy",
        method: 'POST',
        data: {
            'id': id
        }
    })
}

$('.close-btn').on("click", function () {
    $('.alert').addClass("hide");
    $('.alert').removeClass("animate__animated");
    $('.alert').removeClass("animate__fadeInRight");
})

