

document.addEventListener("DOMContentLoaded", loadDashboard);

async function loadDashboard() {
    const user = JSON.parse(localStorage.getItem("user"));

    if (!user) {
        window.location.href = "index.html";
        return;
    }

    document.getElementById("student-name").textContent = user.name || user.Name;

    try {
        const response = await fetch("https://localhost:7113/api/Subjects/GetAllSubjects", {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        });

        if (!response.ok) {
            throw new Error("خطأ في تحميل المواد");
        }

        const subjects = await response.json();
        renderSubjects(subjects);

    } catch (error) {
        console.error(error);
        const list = document.getElementById("subjects-list");
        list.innerHTML = '<li class="error-message" style="padding: 10px; border-radius: 8px;">تعذر تحميل المواد</li>';
    }
}

function renderSubjects(subjects) {
    const list = document.getElementById("subjects-list");
    list.innerHTML = "";

    subjects.forEach(subject => {
        const li = document.createElement("li");
        li.innerHTML = `
            <h3>${subject.subjectName}</h3>
            <p>${subject.description || 'لا يوجد وصف للمادة'}</p>
        `;
        li.onclick = () => {
            localStorage.setItem("selectedSubject", JSON.stringify(subject));
            window.location.href = "exam.html";
        };
        list.appendChild(li);
    });
}
document.getElementById("logout-btn").addEventListener("click", () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    window.location.href = "index.html";
});


