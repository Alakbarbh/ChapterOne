$(document).ready(function () {
    //show-password
    const togglePassword = document.querySelector("#login-form .password-input .eyes");
    const password = document.querySelector("#login-form .password-input input");

    togglePassword.addEventListener("click", function () {
        const type = password.getAttribute("type") === "password" ? "text" : "password";
        password.setAttribute("type", type);

        this.classList.toggle("bi-eye");
    });

    const form = document.querySelector("form");
    form.addEventListener('submit', function (e) {
        e.preventDefault();
    });

    
})