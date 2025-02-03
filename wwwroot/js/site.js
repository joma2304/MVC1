// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//För hamburgaremeny till nav
document.getElementById("hamburger-toggle").addEventListener("click", function() {
    const navList = document.getElementById("nav-ul");
    navList.classList.toggle("active");
});