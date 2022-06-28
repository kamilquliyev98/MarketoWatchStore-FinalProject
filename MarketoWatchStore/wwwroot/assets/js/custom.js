$(document).ready(function () {

    $(document).on("click", "#quickViewBtn", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => response.text()).then(data => {

            $(".modal-content").html(data);

            /* Modal JS */
            $(".quick-view-slider").each(function (key, item) {
                var sliderIdName = "slider" + key;
                var sliderNavIdName = "sliderNav" + key;

                this.id = sliderIdName;
                $(".quick-nav")[key].id = sliderNavIdName;

                var sliderId = "#" + sliderIdName;
                var sliderNavId = "#" + sliderNavIdName;

                $(sliderId).slick({
                    dots: false,
                    infinite: true,
                    speed: 1500,
                    fade: true,
                    arrows: false,
                    autoplay: true,
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    asNavFor: sliderNavId,
                });

                $(sliderNavId).slick({
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    asNavFor: sliderId,
                    swipe: false,
                    vertical: true,
                    verticalScrolling: true,
                    arrows: false,
                    dots: false,
                    focusOnSelect: true,
                });
            });

            $("#quick-view").on("show.bs.modal", function (event) {
                $(window).trigger("resize");
                $(".quick-view-slider").slick("slickNext");
                $(".quick-nav").slick("slickNext");
            });

            /* Color Select JS */
            $(".color-variant li").on("click", function () {
                $(this).toggleClass("selected").siblings("li").removeClass("selected");
            });

            $("#quick-view").modal("show");

        });

    });

    $(document).on("click", ".addBasketBtn", function (e) {
        e.preventDefault();

        var url = $("#basketForm").attr("action");
        var count = $("#productCount").val();

        if (url == undefined) {
            var url = $(this).attr("href");
            var count = 1;
        }

        url = url + "?count=" + count;

        fetch(url).then(response => response.text()).then(data => $(".minicart-content-box").html(data)).then(data => {
            let url2 = "/product/GetBasketProductsCount";

            fetch(url2).then(response => response.text()).then(data => {
                data.toString();
                $(".notification").html(data);
            });
        });
    });

});