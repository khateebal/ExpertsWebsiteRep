
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
                var navbar_height = document.querySelector('.navbar').offsetHeight;
                document.body.style.paddingTop = navbar_height + 'px';
            } else {
                document.getElementById('navbar_top').classList.remove('fixed-top');
                document.getElementById('navbar_top').classList.remove('scroll');
                document.body.style.paddingTop = '0';
            }
        });
    });


 jQuery(document).ready(function ($) {
    const navbar = document.querySelector('.navbar');
    const navbarOffset = navbar.offsetTop;
    window.addEventListener('scroll', function () {
        if (window.pageYOffset >= navbarOffset) {
            navbar.classList.add('fixed-top');
        } else {
            navbar.classList.remove('fixed-top');
        }
    });
    const mobileMenuButton = document.querySelector('.navbar-toggler');
    mobileMenuButton.addEventListener('click', function () {
        const offcanvas = document.querySelector('.offcanvas');
        offcanvas.classList.toggle('show');
    });
     const dropdownToggle = document.querySelector('.nav-item.dropdown .dropdown-toggle');
     const dropdownMenu = document.querySelector('.nav-item.dropdown .dropdown-menu');

     dropdownToggle.addEventListener('click', function (e) {
         e.preventDefault();
         if (dropdownMenu.style.display === 'block') {
             dropdownMenu.style.display = 'none';
         } else {
             dropdownMenu.style.display = 'block';
         }
     });
     var dropdowns = document.querySelectorAll('.dropdown-submenu > .dropdown-toggle');
     for (var i = 0; i < dropdowns.length; i++) {
         dropdowns[i].addEventListener('click', function (e) {
             var dropdown = this.parentElement.querySelector('.dropdown-menu');
             if (dropdown) {
                 e.preventDefault();
                 dropdown.classList.toggle('show');
                 dropdown.parentElement.classList.toggle('show');
             }
         });
     }
     const closeButton = document.querySelector('.btn-close');
     closeButton.addEventListener('click', function () {
         document.getElementById("main_nav").classList.remove("show");
     });
  

     (function () {
         'use strict'
         var forms = document.querySelectorAll('.app-form')
         Array.prototype.slice.call(forms)
             .forEach(function (form) {
                 form.addEventListener('submit', function (event) {
                     if (!form.checkValidity()) {
                         event.preventDefault()
                         event.stopPropagation()
                     }

                     form.classList.add('was-validated')
                 }, false)
             })

         var contact_form = document.querySelectorAll('.contact-form')
         Array.prototype.slice.call(contact_form)
             .forEach(function (contact_form) {
                 form.addEventListener('submit', function (event) {
                     if (!contact_form.checkValidity()) {
                         event.preventDefault()
                         event.stopPropagation()
                    }

                     contact_form.classList.add('was-validated')
                 }, false)
             })
     })()
});





