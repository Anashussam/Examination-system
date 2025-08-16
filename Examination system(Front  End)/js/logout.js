
function logout() {
    localStorage.removeItem("user");
    window.location.href = "index.html";
}