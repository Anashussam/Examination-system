document.addEventListener('DOMContentLoaded', function() {
    
    const subjectsTableBody = document.getElementById('subjectsTableBody');
    const searchInput = document.getElementById('searchInput');
    const searchBtn = document.getElementById('searchBtn');
    const subjectCount = document.getElementById('subjectCount');

  
    let allSubjects = [];

    
    loadSubjects();

    
    searchBtn.addEventListener('click', searchSubjectById);
    searchInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') searchSubjectById();
    });

 
    async function loadSubjects() {
        try {
            showLoading(true);
            
            
            const response = await fetch('https://localhost:7113/api/Subjects/GetAllSubjects');
            
            if (!response.ok) {
                throw new Error('فشل في جلب قائمة المواد');
            }
            
            allSubjects = await response.json();
            displaySubjects(allSubjects);
            updateCount(allSubjects.length);
            
        } catch (error) {
            console.error('Error:', error);
            showError('حدث خطأ أثناء جلب قائمة المواد: ' + error.message);
        } finally {
            showLoading(false);
        }
    }

    
    async function searchSubjectById() {
        const subjectId = searchInput.value.trim();
        
        if (!subjectId) {
            displaySubjects(allSubjects);
            updateCount(allSubjects.length);
            return;
        }

        try {
            showLoading(true);
            const response = await fetch(`https://localhost:7113/api/Subjects/GetSubjectById/${subjectId}`);
            
            if (!response.ok) {
                throw new Error('لم يتم العثور على المادة');
            }
            
            const subject = await response.json();
            displaySubjects([subject]);
            updateCount(1);
            
        } catch (error) {
            console.error('Error:', error);
            showError(error.message);
            subjectsTableBody.innerHTML = `
                <tr>
                    <td colspan="6" class="text-center py-5 text-muted">
                        <i class="fas fa-info-circle"></i>
                        <p>${error.message}</p>
                    </td>
                </tr>
            `;
            updateCount(0);
        } finally {
            showLoading(false);
        }
    }

    
    function displaySubjects(subjects) {
        subjectsTableBody.innerHTML = '';

        if (subjects.length === 0) {
            subjectsTableBody.innerHTML = `
                <tr>
                    <td colspan="6" class="text-center py-5 text-muted">
                        <i class="fas fa-info-circle"></i>
                        <p>لا توجد مواد متاحة</p>
                    </td>
                </tr>
            `;
            return;
        }

        subjects.forEach(subject => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${subject.subjectID}</td>
                <td>${subject.subjectName}</td>
                <td>${subject.code}</td>
                <td>${subject.status ? 'نشط' : 'غير نشط'}</td>
                <td>مستخدم #${subject.createdBy}</td>
                
                <td class="action-btns">
                    <a href="edit-subject.html?id=${subject.subjectID}" class="btn btn-sm btn-outline-primary action-btn" title="تعديل">
                        <i class="fas fa-edit"></i> تعديل
                    </a>
                    <a href="delete-subject.html?id=${subject.subjectID}" class="btn btn-sm btn-outline-danger action-btn" title="حذف">
                        <i class="fas fa-trash-alt"></i> حذف
                    </a>
                </td>
            `;
            subjectsTableBody.appendChild(row);
        });
    }

   
    function updateCount(count) {
        subjectCount.textContent = `${count} مادة`;
    }

    function showLoading(show) {
        if (show) {
            subjectsTableBody.innerHTML = `
                <tr>
                    <td colspan="6" class="text-center py-5">
                        <div class="spinner-border text-primary" role="status">
                            <span class="visually-hidden">جاري التحميل...</span>
                        </div>
                        <p class="mt-2">جاري تحميل البيانات...</p>
                    </td>
                </tr>
            `;
        }
    }

    function showError(message) {
        const errorAlert = document.createElement('div');
        errorAlert.className = 'alert alert-danger';
        errorAlert.innerHTML = `
            <i class="fas fa-exclamation-circle"></i>
            ${message}
        `;
        
        const container = document.querySelector('.container');
        container.prepend(errorAlert);
        
        setTimeout(() => errorAlert.remove(), 5000);
    }
});