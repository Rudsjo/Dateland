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

function updateSelMovie() {
    var e = document.getElementById("movielist");
    var str = e.options[e.selectedIndex].value;

    $(document).ready(function () {
        val1 = str;

        $.ajax({
            type: "POST",
            url: '/Account/ChangeFavoriteMovie',
            data: { movieName: val1 },
            dataType: "text",
            success: function (msg) {
                console.log(msg);
            },
            error: function (req, status, error) {
                console.log(msg);
            }
        });
    });
}

function updateSelFood() {
    var e = document.getElementById("foodlist");
    var str = e.options[e.selectedIndex].value;

    $(document).ready(function () {
        val1 = str;

        $.ajax({
            type: "POST",
            url: '/Account/ChangeFavoriteFood',
            data: { foodName: val1 },
            dataType: "text",
            success: function (msg) {
                console.log(msg);
            },
            error: function (req, status, error) {
                console.log(msg);
            }
        });
    });
}

function updateSelMusic() {
    var e = document.getElementById("musiclist");
    var str = e.options[e.selectedIndex].value;

    $(document).ready(function () {
        val1 = str;

        $.ajax({
            type: "POST",
            url: '/Account/ChangeFavoriteMusic',
            data: { musicName: val1 },
            dataType: "text",
            success: function (msg) {
                console.log(msg);
            },
            error: function (req, status, error) {
                console.log(msg);
            }
        });
    });
}

function updateInterests(id) {
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: '/Account/ChangeInterestStatus',
            data: { id: id },
            dataType: "text",
            success: function (msg) {
                console.log(msg);
            },
            error: function (req, status, error) {
                console.log(msg);
            }
        });
    });
}


