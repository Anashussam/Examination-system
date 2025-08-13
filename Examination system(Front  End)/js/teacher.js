
document.addEventListener("DOMContentLoaded", () => {
    // استرجاع بيانات المستخدم مع معالجة حالة الأحرف
    const userString = localStorage.getItem("user");
    
    if (!userString) {
        window.location.href = "index.html";
        return;
    }

    const user = JSON.parse(userString);
    
    // تحقق من الصلاحية مع مراعاة حالة الأحرف
    const userRole = (user.role || user.Role || "").toString().toLowerCase();
    
    if (userRole !== "teacher") {
        window.location.href = "index.html";
        return;
    }

    // عرض اسم المستخدم (معالجة حالة الأحرف للاسم أيضًا)
    const userName = user.Name || user.name || "معلم";
    document.getElementById("teacher-name").textContent = `مرحبًا، ${userName}`;
});

function logout() {
    localStorage.removeItem("user");
    window.location.href = "index.html";
}