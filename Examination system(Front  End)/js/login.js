

const translations = {
    ar: {
        usernamePlaceholder: "اسم المستخدم أو البريد الإلكتروني",
        passwordPlaceholder: "كلمة المرور",
        loginButton: "دخول",
        errorEmpty: "الرجاء إدخال البريد الإلكتروني وكلمة المرور",
        errorCredentials: "بيانات الدخول غير صحيحة",
        errorServer: "حدث خطأ أثناء الاتصال بالخادم",
        loginProgress: "جارٍ تسجيل الدخول...",
        loginSuccess: "تم تسجيل الدخول بنجاح!"
    },
    en: {
        usernamePlaceholder: "Username or Email",
        passwordPlaceholder: "Password",
        loginButton: "Login",
        errorEmpty: "Please enter email and password",
        errorCredentials: "Invalid login credentials",
        errorServer: "An error occurred while connecting to the server",
        loginProgress: "Logging in...",
        loginSuccess: "Logged in successfully!"
    }
};

function setLanguage(lang) {
    document.documentElement.dir = lang === 'ar' ? 'rtl' : 'ltr';
    document.documentElement.lang = lang;

    document.querySelector('h2').textContent = lang === 'ar' ? 'تسجيل الدخول' : 'Login';
    document.getElementById('username').placeholder = translations[lang].usernamePlaceholder;
    document.getElementById('password').placeholder = translations[lang].passwordPlaceholder;
    document.getElementById('btn').value = translations[lang].loginButton;
    document.querySelector('.group a:first-child').innerHTML = lang === 'ar'
        ? '<i class="fas fa-user-plus"></i> إنشاء حساب جديد'
        : '<i class="fas fa-user-plus"></i> Create new account';
    document.querySelector('.group a:last-child').innerHTML = lang === 'ar'
        ? '<i class="far fa-check-circle"></i> تذكرني'
        : '<i class="far fa-check-circle"></i> Remember me';

    document.getElementById('arabic-btn').classList.toggle('active', lang === 'ar');
    document.getElementById('english-btn').classList.toggle('active', lang === 'en');

    localStorage.setItem('selectedLanguage', lang);
}

async function login() {
    const email = document.getElementById("username").value.trim();
    const password = document.getElementById("password").value.trim();
    const errorMessage = document.getElementById("error-message");
    const currentLang = localStorage.getItem('selectedLanguage') || 'ar';

    if (!email || !password) {
        errorMessage.textContent = translations[currentLang].errorEmpty;
        errorMessage.classList.add('error-message');
        return;
    }

    try {
        errorMessage.innerHTML = `<i class="fas fa-spinner fa-spin"></i> ${translations[currentLang].loginProgress}`;
        errorMessage.className = "message";
       
        const response = await fetch("https://localhost:7113/api/ExamSystem/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ Email: email, Password: password })
        });

        if (!response.ok) {
            throw new Error(translations[currentLang].errorCredentials);
        }

        const data = await response.json();
        console.log("API Response Data:", data); 
        const userData = {
            userId: data.userID || data.UserID,
            name: data.name || data.Name,
            email: data.email || data.Email,
            role: data.role || data.Role
        };
        
        localStorage.setItem("user", JSON.stringify(userData));
        
        errorMessage.innerHTML = `<i class="fas fa-check-circle"></i> ${translations[currentLang].loginSuccess}`;
        errorMessage.classList.add('success-message');

        setTimeout(() => {
            const role = (userData.role || "").toString().toLowerCase().trim();
            console.log("Final Role:", role); 
            
            if (role === 'admin') {
                window.location.href = "admin-dashboard.html";
            } else if (role === 'teacher') {
                window.location.href = "teacher-dashboard.html";
            } else if (role === 'student') {
                window.location.href = "student-dashboard.html";
            } else {
                errorMessage.textContent = currentLang === 'ar' 
                    ? "نوع الحساب غير معروف. الرجاء التواصل مع المسؤول" 
                    : "Unknown account type. Please contact administrator";
                errorMessage.classList.add('error-message');
            }
        }, 1500);
    } catch (error) {
        console.error("Login Error:", error);
        errorMessage.textContent = error.message || translations[currentLang].errorServer;
        errorMessage.classList.add('error-message');
    }
}

document.addEventListener('DOMContentLoaded', function () {
    const savedLang = localStorage.getItem('selectedLanguage') || 'ar';
    setLanguage(savedLang);

    document.getElementById('password').addEventListener('keypress', function (e) {
        if (e.key === 'Enter') {
            login();
        }
    });

    document.getElementById('arabic-btn').addEventListener('click', () => setLanguage('ar'));
    document.getElementById('english-btn').addEventListener('click', () => setLanguage('en'));
});