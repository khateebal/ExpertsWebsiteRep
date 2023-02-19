import Typed from 'typed.js';
const options = {
    strings: ["Tax Consulting ^2000", "Accounting  ^2000", "Auditing ^4000"],
    smartBackspace: false,
    loop: true,
    showCursor: true,
    cursorChar: "|",
    typeSpeed: 50,
    backSpeed: 30,
    startDelay: 800
}
const typed = new Typed('.typed', options);

console.log('The \'index\' bundle has been loaded!');