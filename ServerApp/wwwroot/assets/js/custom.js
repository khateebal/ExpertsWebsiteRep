
// jQuery
jQuery(document).ready(function ($) {
  if ($('.isotop-section').length) {
        $('.item-details').isotope({
            // options
            itemSelector: '.item',
            layoutMode: 'fitRows'
        });

        $('.item-details').isotope({
            filter: $('.item-menu .active').data('filter')
        });

        $(document).on('click', '.item-menu li', function () {
            $('.item-menu li').removeClass('active');
            $(this).addClass('active');


            // filter items on button click
            var selector = $(this).data('filter');
            $('.item-details').isotope({
                filter: $(this).data('filter')
            });
        });

    }

    // Animated hr line
    setTimeout(function () {
        $('.trans--grow').addClass('grow');
    }, 275);



});




// back to top

//Get the button
var mybutton = document.getElementById("scrollUp");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}


// Header 

document.addEventListener("DOMContentLoaded", function () {
    window.addEventListener('scroll', function () {
        if (window.scrollY > 0) {
            document.getElementById('navbar_top').classList.add('fixed-top');
            document.getElementById('navbar_top').classList.add('scroll');
            // add padding top to show content behind navbar
            navbar_height = document.querySelector('.navbar').offsetHeight;
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



// SwiperSlide 


var mySwiper = document.querySelectorAll('.mySwiper');
if (mySwiper.length) {

    var swiper = new Swiper(".mySwiper", {
        slidesPerView: 3,
        spaceBetween: 30,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },

        navigation: {
            enabled: false,
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        breakpoints: {
            // when window width is >= 300px
            320: {
                slidesPerView: 1
            },
            // when window width is >= 480px
            768: {
                slidesPerView: 2,
            },
            // when window width is >= 768px
            900: {
                slidesPerView: 3,
            },
            // when window width is >= 768px
            // 1100: {
            //     slidesPerView: 4,
            // }
        }
    });
}