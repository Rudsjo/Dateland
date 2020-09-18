// Select element function
const selectElement = function (element) {
    return document.querySelector(element);
};

let menuToggler = selectElement('.menu-toggle');
let body = selectElement('body');

menuToggler.addEventListener('click', function () {
    body.classList.toggle('open');
});

// Scroll reveal
window.sr = ScrollReveal();

sr.reveal('.animate-left', {
    origin: 'left',
    duration: 1000,
    distance: '25rem',
    delay: 300
});

sr.reveal('.animate-right', {
    origin: 'right',
    duration: 1000,
    distance: '25rem',
    delay: 600
});

sr.reveal('.animate-top', {
    origin: 'top',
    duration: 1000,
    distance: '25rem',
    delay: 600
});

sr.reveal('.animate-bottom', {
    origin: 'bottom',
    duration: 1000,
    distance: '25rem',
    delay: 600
});


// Pop ups

let friendsList = selectElement('.friends-list');
let friendsModal = selectElement('.friends-modal');

var div = document.getElementsByClassName("close")[0];

// opens the modal
friendsList.addEventListener('click', function () {
    friendsModal.style.display = "block";
});

// closing the modal
div.onclick = function () {
    friendsModal.style.display = "none";
}