﻿$(document).ready(function () {

    $(document).on("click", ".deleteBtn", function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr("href");

                fetch(url).then(response => {
                    if (response.ok) {
                        Swal.fire(
                            'Deleted!',
                            '',
                            'success'
                        );

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

                        toastr.success("Item has been deleted!");
                    }

                    return response.text();
                }).then(data => {
                    $("#table").html(data);

                    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                        return new bootstrap.Tooltip(tooltipTriggerEl)
                    });
                })
            }
        })
    });

    $(document).on("click", ".restoreBtn", function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, restore it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr("href");

                fetch(url).then(response => {
                    if (response.ok) {
                        Swal.fire(
                            'Restored!',
                            '',
                            'success'
                        );

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

                        toastr.success("Item has been restored!");
                    }

                    return response.text();
                }).then(data => {
                    $("#table").html(data);

                    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
                    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                        return new bootstrap.Tooltip(tooltipTriggerEl)
                    });
                })
            }
        })
    });

    $(document).on("click", ".btn-delete", function (e) {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                let url = $(this).attr("href");

                fetch(url).then(response => {
                    if (response.ok) {
                        Swal.fire(
                            'Deleted!',
                            '',
                            'success'
                        );

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

                        toastr.success("Image has been deleted!");
                    }

                    return response.text();
                }).then(data => {
                    $(".product-update").html(data);

                })
            }
        });

    });

    $(document).on("click", ".btn-add", function (e) {
        e.preventDefault();

        let rowCount = $(".entry").children().length;
        let button = `<a href="javascript:void(0)" type="button" class="btn btn-outline-danger rounded-pill btn-remove">Remove last added</a>`;

        if (rowCount >= 1 && !$(".btn-remove").length) {
            $('.customButtons').append(button);
        }

        let url = $(this).attr("href");

        fetch(url).then(response => response.text()).then(data => $(".entry").append(data));
    });

    $(document).on("click", ".btn-remove", function (e) {
        e.preventDefault();

        let rowCount = $(".entry").children().length;

        if (rowCount <= 2 && $(".btn-remove").length) {
            $('.btn-remove').remove();
        }

        $('div.entry').children().last().remove();
    });

});