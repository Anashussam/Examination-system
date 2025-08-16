
function protectPage(allowedRoles) {
    const user = JSON.parse(localStorage.getItem("user"));

    if (!user || !user.role) {
        window.location.href = "login.html";
        return;
    }

   
    const role = user.role.toString().toLowerCase().trim();

    
    if (!allowedRoles.map(r => r.toLowerCase()).includes(role)) {
        alert("غير مسموح لك بالدخول إلى هذه الصفحة");
        window.location.href = "login.html";
    }
}
