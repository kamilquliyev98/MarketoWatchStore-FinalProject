/* Document ready functions */
$(document).ready(function () {
    /* Dark/Light mode JS */
    let moonIcon = `<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-moon">
    <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"></path>
    </svg>`;

    let sunIcon = `<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-sun">
    <circle cx="12" cy="12" r="5"></circle>
    <line x1="12" y1="1" x2="12" y2="3"></line>
    <line x1="12" y1="21" x2="12" y2="23"></line>
    <line x1="4.22" y1="4.22" x2="5.64" y2="5.64"></line>
    <line x1="18.36" y1="18.36" x2="19.78" y2="19.78"></line>
    <line x1="1" y1="12" x2="3" y2="12"></line>
    <line x1="21" y1="12" x2="23" y2="12"></line>
    <line x1="4.22" y1="19.78" x2="5.64" y2="18.36">
    </line><line x1="18.36" y1="5.64" x2="19.78" y2="4.22"></line>
    </svg>`;

    var darkmode = localStorage.getItem("dark_mode");
    var mainCSS = $("#mainCSS").attr("href");

    if (!darkmode) {
        $("body").removeClass("dark");
        $("#darkButton").html(moonIcon);

        if (mainCSS.toLowerCase().indexOf("dark") >= 0) {
            $("#mainCSS").attr("href", "assets/css/style.css");
        }
    } else {
        $("body").addClass("dark");
        $("#darkButton").html(sunIcon);

        if (mainCSS.toLowerCase().indexOf("dark") < 0) {
            $("#mainCSS").attr("href", "assets/css/style_dark.css");
        }
    }

    $("#darkButton").on("click", function () {
        if ($("#mainCSS").attr("href").toLowerCase().indexOf("dark") >= 0) {
            $("#mainCSS").attr("href", "assets/css/style.css");
            $("body").removeClass("dark");
            $(this).html(moonIcon);
            localStorage.removeItem("dark_mode");
        } else {
            $("#mainCSS").attr("href", "assets/css/style_dark.css");
            $("body").addClass("dark");
            $(this).html(sunIcon);
            localStorage.setItem("dark_mode", "1");
        }
    });



    /* Feather JS */
    feather.replace();



    /* Tap to top JS*/
    $(window).on("scroll", function () {
        if ($(this).scrollTop() > 600) {
            $(".tap-to-top").addClass("show");
        } else {
            $(".tap-to-top").removeClass("show");
        }
    });

    $(".tap-to-top").on("click", function () {
        $("html, body").animate({
            scrollTop: 0
        }, 600);
    });



    /* Hide Header on scroll down JS */
    $(function () {
        var $window = $(window);
        var lastScrollTop = 0;
        var $header = $("header");
        var headerHeight = $header.outerHeight();

        $window.scroll(function () {
            var windowTop = $window.scrollTop();

            if (windowTop >= headerHeight) {
                $header.addClass("nav-down");
            } else {
                $header.removeClass("nav-down");
                $header.removeClass("nav-up");
            }

            if ($header.hasClass("nav-down")) {
                if (windowTop < lastScrollTop) {
                    $header.addClass("nav-up");
                } else {
                    $header.removeClass("nav-up");
                }
            }
            $("#lastscrolltop").text("LastscrollTop: " + lastScrollTop);

            lastScrollTop = windowTop;

            $("#windowtop").text("scrollTop: " + windowTop);
        });
    });



    /* Header Dropdown JS */
    $('.dropdown .dropdown-menu li').click(function () {
        $(this).parents('.dropdown').find('span').text($(this).text());
        $(this).parents('.dropdown').find('input').attr('value', $(this).attr('id'));
    });



    /* Image to background JS */
    $(".bg-top").parent().addClass("b-top");
    $(".bg-bottom").parent().addClass("b-bottom");
    $(".bg-center").parent().addClass("b-center");
    $(".bg-left").parent().addClass("b-left");
    $(".bg-right").parent().addClass("b-right");
    $(".bg_size_content").parent().addClass("b_size_content");
    $(".bg-img").parent().addClass("bg-size");
    $(".bg-img.blur-up").parent().addClass("blur-up lazyload");
    $(".bg-img").each(function () {
        var el = $(this);
        var src = el.attr("src");
        var parent = el.parent();

        parent.css({
            "background-image": "url(" + src + ")",
            "background-size": "cover",
            "background-position": "center",
            "background-repeat": "no-repeat",
            display: "block",
        });

        el.hide();
    });



    /* Menu JS */
    $(".toggle-nav, .sidebar-toggle").on("click", function () {
        $(".nav-menu").css("right", "0px");
        $(".mobile-poster").css("right", "0px");
        $(".bg-overlay").addClass("show");
    });
    $(".back-btn, .bg-overlay").on("click", function () {
        $(".nav-menu").css("right", "-410px");
        $(".mobile-poster").css("right", "-410px");
        $(".bg-overlay").removeClass("show");
    });

    var contentwidth = $(window).width();
    if (contentwidth < "1200") {
        $(".menu-title").append('<span class="according-menu">+</span>');
        $(".menu-title").on("click", function () {
            $(".menu-title")
                .removeClass("active")
                .find("span")
                .replaceWith('<span class="according-menu">+</span>');
            $(".menu-content").slideUp("normal");
            if ($(this).next().is(":hidden") == true) {
                $(this).addClass("active");
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">-</span>');
                $(this).next().slideDown("normal");
            } else {
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">+</span>');
            }
        });
        $(".menu-content").hide();
    }

    var contentwidth = $(window).width();
    if (contentwidth < "1200") {
        $(".menu-title-level1").append(
            '<span class="according-menu">+</span>'
        );
        $(".menu-title-level1").on("click", function () {
            $(".menu-title-level1")
                .removeClass("active")
                .find("span")
                .replaceWith('<span class="according-menu">+</span>');
            $(".level1").slideUp("normal");
            if ($(this).next().is(":hidden") == true) {
                $(this).addClass("active");
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">-</span>');
                $(this).next().slideDown("normal");
            } else {
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">+</span>');
            }
        });
        $(".nav-sub-childmenu .level1").hide();
    }

    var contentwidth = $(window).width();
    if (contentwidth < "1200") {
        $(".submenu-title").append('<span class="according-menu">+</span>');
        $(".submenu-title").on("click", function () {
            $(".submenu-title")
                .removeClass("active")
                .find("span")
                .replaceWith('<span class="according-menu">+</span>');
            $(".submenu-content").slideUp("normal");
            if ($(this).next().is(":hidden") == true) {
                $(this).addClass("active");
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">-</span>');
                $(this).next().slideDown("normal");
            } else {
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">+</span>');
            }
        });
        $(".submenu-content").hide();
    }



    /* Search Box JS */
    $(".search-box").on("click", function () {
        $(this).closest(".main-menu").find(".search-full").addClass("open");
    });

    $(window).on("load resize", function () {
        // open searchbox
        $(".search-type").on("click", function () {
            $(this).parents(".search-full").addClass("show");
        });

        // close seach
        $(".close-search").on("click", function () {
            $(this).closest(".main-menu").find(".search-full").removeClass("open");
        });
    });



    /* Color Select JS */
    $(".color-variant li").on("click", function () {
        $(this).toggleClass("selected").siblings("li").removeClass("selected");
    });



    /* Modal JS */
    $("#quick-view").on("show.bs.modal", function (event) {
        $(window).trigger("resize");
        $(".quick-view-slider").slick("slickNext");
        $(".quick-nav").slick("slickNext");
    });



    /* Category menu JS */
    $(".toggle-category").on("click", function () {
        $(".category-dropdown").addClass("open");
        $(".bg-overlay").addClass("show");
    });
    $(".back-category, .bg-overlay").on("click", function () {
        $(".category-dropdown").removeClass("open");
        $(".bg-overlay").removeClass("show");
    });
    var contentwidth = $(window).width();
    if (contentwidth < "1200") {
        $(".category-menu li.submenu >a").append(
            '<span class="according-menu">+</span>'
        );
        $(".category-menu li.submenu >a").on("click", function () {
            $(".category-menu li.submenu >a")
                .removeClass("active")
                .find("span")
                .replaceWith('<span class="according-menu">+</span>');
            $(".category-mega-menu").slideUp("normal");
            if ($(this).next().is(":hidden") == true) {
                $(this).addClass("active");
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">-</span>');
                $(this).next().slideDown("normal");
            } else {
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">+</span>');
            }
        });
        $(".category-mega-menu").hide();
    }

    var contentwidth = $(window).width();
    if (contentwidth < "1200") {
        $(".title-category").append('<span class="according-menu">+</span>');
        $(".title-category").on("click", function () {
            $(".title-category")
                .removeClass("active")
                .find("span")
                .replaceWith('<span class="according-menu">+</span>');
            $(".category-childmenu ul").slideUp("normal");
            if ($(this).next().is(":hidden") == true) {
                $(this).addClass("active");
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">-</span>');
                $(this).next().slideDown("normal");
            } else {
                $(this)
                    .find("span")
                    .replaceWith('<span class="according-menu">+</span>');
            }
        });
        $(".category-childmenu ul").hide();
    }



    /* Footer JS */
    var contentwidth = $(window).width();
    if (contentwidth < "576") {
        $(".footer-title h5").append(
            '<span class="according-menu"><i class="fas fa-chevron-down"></i></span>'
        );
        $(".footer-title").on("click", function () {
            $(".footer-title")
                .removeClass("active")
                .find("span")
                .replaceWith(
                    '<span class="according-menu"><i class="fas fa-chevron-down"></i></span>'
                );
            $(".footer-content").slideUp("normal");
            if ($(this).next().is(":hidden") == true) {
                $(this).addClass("active");
                $(this)
                    .find("span")
                    .replaceWith(
                        '<span class="according-menu"><i class="fas fa-chevron-up"></i></span>'
                    );
                $(this).next().slideDown("normal");
            } else {
                $(this)
                    .find("span")
                    .replaceWith(
                        '<span class="according-menu"><i class="fas fa-chevron-down"></i></span>'
                    );
            }
        });
        $(".footer-content").hide();
    } else {
        $(".footer-content").show();
    }



    /* Cart JS */
    $(".cart-dropdown .cart-media, .cart-dropdown > button").on("click", function () {
        $(".cart-dropdown").addClass("show");
        $("body").addClass("o-hidden");
    });

    $(".back-cart").on("click", function () {
        $(".cart-dropdown").removeClass("show");
        $("body").removeClass("o-hidden");
    });



    /* Login JS */
    $(function () {
        $(".input input")
            .focus(function () {
                $(this)
                    .parent(".input")
                    .each(function () {
                        $("label", this).css({
                            "line-height": "18px",
                            "font-weight": "100",
                            top: "0px",
                        });
                        $(".spin", this).css({
                            width: "100%",
                        });
                    });
            })
            .blur(function () {
                $(".spin").css({
                    width: "0px",
                });
                if ($(this).val() == "") {
                    $(this)
                        .parent(".input")
                        .each(function () {
                            $("label", this).css({
                                "line-height": "60px",
                                "font-weight": "300",
                                top: "10px",
                            });
                        });
                }
            });

        $(".button").click(function (e) {
            var pX = e.pageX,
                pY = e.pageY,
                oX = parseInt($(this).offset().left),
                oY = parseInt($(this).offset().top);
            $(".x-" + oX + ".y-" + oY + "").animate({
                    width: "500px",
                    height: "500px",
                    top: "-250px",
                    left: "-250px",
                },
                600
            );
            $("button", this).addClass("active");
        });

        $(".alt-2").on("click", function () {
            if (!$(this).hasClass("material-button")) {
                $(".shape").css({
                    width: "100%",
                    height: "100%",
                    transform: "rotate(0deg)",
                });

                setTimeout(function () {
                    $(".overbox").css({
                        overflow: "initial",
                    });
                }, 600);

                $(this).animate({
                        width: "140px",
                        height: "140px",
                    },
                    500,
                    function () {
                        $(".box").removeClass("back");

                        $(this).removeClass("active");
                    }
                );

                $(".overbox .title").fadeOut(300);
                $(".overbox .input").fadeOut(300);
                $(".overbox .button").fadeOut(300);

                $(".alt-2").addClass("material-buton");
            }
        });

        $(".material-button").on("click", function () {
            if ($(this).hasClass("material-button")) {
                setTimeout(function () {
                    $(".overbox").css({
                        overflow: "hidden",
                    });
                    $(".box").addClass("back");
                }, 200);
                $(this).addClass("active").animate({
                    width: "850px",
                    height: "850px",
                });

                setTimeout(function () {
                    $(".shape").css({
                        width: "50%",
                        height: "50%",
                        transform: "rotate(45deg)",
                    });

                    $(".overbox .title").fadeIn(300);
                    $(".overbox .input").fadeIn(300);
                    $(".overbox .button").fadeIn(300);
                }, 700);

                $(this).removeClass("material-button");
            }

            if ($(".alt-2").hasClass("material-buton")) {
                $(".alt-2").removeClass("material-buton");
                $(".alt-2").addClass("material-button");
            }
        });
    });



    /* Product Page Quantity Counter */
    $(".qty-box .quantity-right-plus").on("click", function () {
        var $qty = $(".qty-box .input-number");
        var currentVal = parseInt($qty.val(), 10);
        if (!isNaN(currentVal)) {
            $qty.val(currentVal + 1);
        }
    });

    $(".qty-box .quantity-left-minus").on("click", function () {
        var $qty = $(".qty-box .input-number");
        var currentVal = parseInt($qty.val(), 10);
        if (!isNaN(currentVal) && currentVal > 1) {
            $qty.val(currentVal - 1);
        }
    });



    /* Added to cart Toastr */
    $(document).on("click", ".addtocart-btn", function (e) {
        e.preventDefault();

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr.success("Item successfully added to your cart!");
    });



    /* Added to wishlist Toastr */
    $(document).on("click", ".addtowishlist-btn", function (e) {
        e.preventDefault();

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr.success("Item successfully added to your wishlist!");
    });



    /* Added to compare list Toastr */
    $(document).on("click", ".addtocompare-btn", function (e) {
        e.preventDefault();

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr.success("Item successfully added to your compare list!");
    });



    /* Cookie section JS */
    var cookieNotify = localStorage.getItem("cookie_notify");
    if (!cookieNotify) {
        $(window).on('load', function () {
            $(".cookie-bar-section").removeClass("hide");
        });
        localStorage.setItem("cookie_notify", "1");
    }

    $(".cookie-bar-section #button").on("click", function () {
        $(".cookie-bar-section").toggleClass("hide");
    });



    /* Active ul li JS */
    $(".image-section li").on("click", function () {
        $(".image-section li").removeClass("active");
        $(this).addClass("active");
    });



    /* Shop List-grid JS */
    $(".grid-options .grid-btn").on("click", function () {
        $(".product-list-section").removeClass("list-style");
    });

    $(".grid-options .list-btn").on("click", function () {
        $(".product-list-section").addClass("list-style");
    });

    $('.two-grid').on('click', function (e) {
        $(".product-list-section").removeClass("row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-2 list-style").addClass("row-cols-2");
    });

    $('.three-grid').on('click', function (e) {
        $(".product-list-section").removeClass("row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-2 list-style").addClass("row-cols-md-3 row-cols-2");
    });

    $('.grid-btn').on('click', function (e) {
        $(".product-list-section").removeClass("row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-2 list-style").addClass("row-cols-lg-4 row-cols-md-3 row-cols-2");
    });

    $('.five-grid').on('click', function (e) {
        $(".product-list-section").removeClass("list-style").addClass("row-cols-xl-5 row-cols-lg-4 row-cols-md-3 row-cols-2");
    });

    var contentwidth = $(window).width();
    if (contentwidth < "1199") {
        $(".grid-options .grid-btn").addClass("active");
    }
    if (contentwidth < "991") {
        $(".grid-options .three-grid").addClass("active");
    }
    if (contentwidth < "767") {
        $(".grid-options .two-grid").addClass("active");
    }

    $(".grid-options ul li").click(function () {
        $(".grid-options li.active").removeClass("active");
        $(this).addClass("active")
    });



    /* Other JS */
    $(".size-box ul li").on("click", function (e) {
        $(".size-box ul li").removeClass("active");
        $("#selectSize").removeClass("cartMove");
        $(this).addClass("active");
        $(this).parent().addClass("selected");
    });

    $("#cartEffect").on("click", function (e) {
        if ($("#selectSize .size-box ul").hasClass("selected")) {
            $("#cartEffect").text("Added to bag ");
            $(".added-notification").addClass("show");
            setTimeout(function () {
                $(".added-notification").removeClass("show");
            }, 5000);
        } else {
            $("#selectSize").addClass("cartMove");
        }
    });




    
    /* Rating Stars JS */
    var star_rating_width = $('.fill-ratings span').width();
    $('.star-ratings').width(star_rating_width);
});




/* Mouseup functions */
$(document).mouseup(function (e) {
    /* Searchbox */
    var searchbar = $(".search-full");
    if (!searchbar.is(e.target) && searchbar.has(e.target).length === 0) {
        $(".search-full").removeClass("show");
    }




    /* Menu sidebar */
    var navMenu = $(".nav-menu");
    if (!navMenu.is(e.target) && navMenu.has(e.target).length === 0) {
        $(".nav-menu").css("right", "-410px");
        $("body").removeClass("o-hidden");
    }



    /* Category menu */
    var categoryMenu = $(".category-dropdown");
    if (!categoryMenu.is(e.target) && categoryMenu.has(e.target).length === 0) {
        $(".category-dropdown").removeClass("open");
        $("body").removeClass("o-hidden");
    }

    var categoryMenu = $(".cart-dropdown");
    if (!categoryMenu.is(e.target) && categoryMenu.has(e.target).length === 0) {
        $(".cart-dropdown").removeClass("show");
        $("body").removeClass("o-hidden");
    }



    /* Top filter */
    var topFilter = $(".top-filter-section .onclick-title");
    if (!topFilter.is(e.target) && topFilter.has(e.target).length === 0) {
        $(".top-filter-section .onclick-title").removeClass("show");
    }
});