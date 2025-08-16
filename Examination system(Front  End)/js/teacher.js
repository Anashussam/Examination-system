
document.addEventListener("DOMContentLoaded", () => {

    const userString = localStorage.getItem("user");
    
    if (!userString) {
        window.location.href = "index.html";
        return;
    }

    const user = JSON.parse(userString);
    

    const userRole = (user.role || user.Role || "").toString().toLowerCase();
    
    if (userRole !== "teacher") {
        window.location.href = "index.html";
        return;
    }

 
    const userName = user.Name || user.name || "معلم";
    document.getElementById("teacher-name").textContent = `مرحبًا، ${userName}`;
});

