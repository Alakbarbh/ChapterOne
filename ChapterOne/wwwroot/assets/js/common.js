$(document).ready(function () {

    //Navbar fixed
    $(window).scroll(function () {
        var header = $('#navbar'),
            scroll = $(window).scrollTop();
        let logoImg = $(".logo img")
        let loginRegister = $(".login-register")
        if (scroll >= 150) {
            header.css({
                'position': 'fixed',
                'top': '0',
                'left': '0',
                'right': '0',
                'z-index': '99999',
                'background-color': 'white',
                'box-shadow': 'rgba(149, 157, 165, 0.2) 0px 8px 24px',
                'backdrop-filter': 'blur(10px)',
                'background': 'transparent'
            });
            logoImg.css({
                'margin-top': '26px'
            })
            loginRegister.css({
                'background-color': 'white'
            })
        } else {
            header.css({
                'position': 'relative',
                'box-shadow': 'none'
            });
            logoImg.css({
                'margin-top': '40px'
            })
        }
    });


    let search = document.querySelector(".search i")
    search.addEventListener("click", function () {
        document.querySelector(".search-input").classList.toggle("d-none")
    })

    let login = document.querySelector(".user i")
    login.addEventListener("click", function () {
        document.querySelector(".login-register").classList.toggle("d-none")
    })

    //login-registerdə body-ə vuranda işləməsi üçün js
    document.addEventListener("click", function (e) {
        if (!!!e.target.closest(".user")) {
            if (!$(".login-register").hasClass("d-none")) {
                $(".login-register").addClass("d-none")
            }
        }
    })

    //Bir-başa headerə qaytarn icon
    $('#topbtn').click(function () {
        $('html').animate({
            scrollTop: 0
        }, 100)

    })

    //Phone-tablet navbars search
    let searchPhone = document.querySelector("#navbar-phone .icons ul li .search")
    searchPhone.addEventListener("click", function () {
        document.querySelector("#navbar-phone .search-input").classList.toggle("d-none")
    })

    //Phone-tablet navbars menu
    let hamburgerMenu = document.querySelector("#navbar-phone .nav .hamburger-icon i")
    hamburgerMenu.addEventListener("click", function () {
        document.querySelector("#navbar-phone .hamburger-menu").classList.toggle("d-none")
    })


    //Active menu navbar
    var menuItems = document.querySelectorAll("#pages ul li a");

    menuItems.forEach(function (item) {
        item.addEventListener("click", function (event) {

            menuItems.forEach(function (item) {
                item.classList.remove("active-menu");
            });

            event.target.classList.add("active-menu");
        });
    });


    //MAIN SEARCH

    $(document).on("submit", ".hm-searchbox", function (e) {
        e.preventDefault();
        let value = $(".input-search").val();
        let url = `/shop/MainSearch?searchText=${value}`;

        window.location.assign(url);

    })



    $(function () {

        //add cart

        $(document).on("click", ".cart-add", function (e) {
            let id = $(this).attr("data-id");
            let data = { id: id };
            let count = (".basket-count");
            $.ajax({
                type: "Post",
                url: "/Shop/AddToCart",
                data: data,
                success: function (res) {
                    $(count).text(res);
                }
            })
            return false;
        })


        //delete product from basket
        $(document).on("click", ".delete-cart", function () {
            let id = $(this).parent().parent().attr("data-id");
            let prod = $(this).parent().parent();
            let tbody = $(".table-body").children();
            let data = { id: id };

            $.ajax({
                type: "Post",
                url: `Cart/DeleteDataFromBasket`,
                data: data,
                success: function (res) {
                    if ($(tbody).length == 1) {
                        $(".basket-products").addClass("d-none");
                        $(".show-alert").removeClass("d-none")
                    }
                    $(prod).remove();
                    res--;
                    $(".basket-count").text(res)
                    grandTotal();
                    //$(".show-alert").removeClass("d-none")

                }

            })
            return false;
        })

        function grandTotal() {
            let tbody = $(".table-body").children()

            let sum = 0;
            for (var prod of tbody) {
                let price = parseFloat($(prod).children().eq(4).children().eq(1).text())
                console.log(price)
                sum += price
            }
            $(".grand-total").text(sum + ".00");
        }

    })
})