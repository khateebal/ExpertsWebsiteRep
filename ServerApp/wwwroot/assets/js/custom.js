(function ($) {
    "use strict";
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner();

    document.addEventListener("DOMContentLoaded", function () {
        window.addEventListener('scroll', function () {
            if (window.scrollY > 0) {
                document.getElementById('navbar_top').classList.add('fixed-top');
                document.getElementById('navbar_top').classList.add('scroll');
                // add padding top to show content behind navbar
                var navbar_height = document.querySelector('.navbar').offsetHeight;
                document.body.style.paddingTop = navbar_height + 'px';
            } else {
                document.getElementById('navbar_top').classList.remove('fixed-top');
                document.getElementById('navbar_top').classList.remove('scroll');
                // remove padding top from body
                document.body.style.paddingTop = '0';
            }
        });

    });


    const scrollSpy = new bootstrap.ScrollSpy(document.body, {
        target: '#main_nav',
        offset: 140
    })






 
})(jQuery);




