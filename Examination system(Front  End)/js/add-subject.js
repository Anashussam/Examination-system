
document.addEventListener('DOMContentLoaded', function() {
    const user = JSON.parse(localStorage.getItem('user'));
    if (!user) {
        window.location.href = 'login.html';
        return;
    }

    if (user.role.toLowerCase() !== 'admin') {
        document.getElementById('subjectForm').style.display = 'none';
        showMessage('ليس لديك صلاحية للوصول إلى هذه الصفحة', 'danger');
        return;
    }

    const form = document.getElementById('subjectForm');
    form.addEventListener('submit', async function(e) {
        e.preventDefault();
        await addSubject();
    });
});


async function addSubject() {
    const subjectName = document.getElementById('subjectName').value.trim();
    const subjectCode = document.getElementById('subjectCode').value.trim();
    const createdById = 1; 

    if (!subjectName || !subjectCode) {
        alert('الرجاء إدخال جميع الحقول المطلوبة');
        return;
    }

    try {
        const response = await fetch('https://localhost:7113/api/Subjects/AddSubject', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                SubjectName: subjectName,
                Code: subjectCode,
                Status: true,
                CreatedBy: createdById 
            })
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.detail || 'فشل في إضافة المادة');
        }

        const result = await response.json();
        alert('تمت إضافة المادة بنجاح!');
        console.log('تمت الإضافة:', result);
        
    } catch (error) {
        console.error('Error:', error);
        alert('حدث خطأ: ' + error.message);
    }
}
function showMessage(text, type) {
    const message = document.getElementById('message');
    message.innerHTML = text;
    message.className = `alert alert-${type} mt-3`;
    message.style.display = 'block';
}