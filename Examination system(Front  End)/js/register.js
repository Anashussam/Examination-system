

async function register() {
    const name = document.getElementById("name").value.trim();
    const age = parseInt(document.getElementById("age").value);
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();
    const phone = document.getElementById("phone").value.trim();
    const roleID = parseInt(document.getElementById("roleID").value);
    const message = document.getElementById("register-message");

    message.textContent = "";
    message.className = "message";

    if (!name || !age || !email || !password || !phone) {
        message.textContent = "الرجاء إدخال جميع البيانات";
        message.classList.add('error-message');
        return;
    }

    try {
        const response = await fetch("https://localhost:7113/api/ExamSystem/register", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ name, age, email, password, phone, roleID })
        });

        const result = await response.text();

        if (response.ok) {
            message.innerHTML = '<i class="fas fa-check-circle"></i> تم التسجيل بنجاح، سيتم تحويلك لصفحة الدخول...';
            message.classList.add('success-message');
            setTimeout(() => {
                window.location.href = "index.html";
            }, 2000);
        } else {
            message.textContent = result;
            message.classList.add('error-message');
        }
    } catch (error) {
        console.error(error);
        message.textContent = "حدث خطأ أثناء التسجيل";
        message.classList.add('error-message');
    }
}

document.addEventListener('DOMContentLoaded', function() {
    document.getElementById('password').addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            register();
        }
    });
});