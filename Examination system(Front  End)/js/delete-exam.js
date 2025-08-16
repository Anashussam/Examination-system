document.addEventListener('DOMContentLoaded', function() {
    const urlParams = new URLSearchParams(window.location.search);
    const examId = urlParams.get('id');
    const examInfo = document.getElementById('examInfo');
    const confirmDeleteBtn = document.getElementById('confirmDeleteBtn');
    const errorAlert = document.getElementById('errorAlert');

    if (!examId) {
        errorAlert.textContent = 'لم يتم تحديد امتحان للحذف';
        errorAlert.style.display = 'block';
        return;
    }

    fetchExamDetails(examId);

    confirmDeleteBtn.addEventListener('click', function() {
        if (confirm('هل أنت متأكد من حذف هذا الامتحان؟ لا يمكن التراجع عن هذه العملية.')) {
            deleteExam(examId);
        }
    });

    async function fetchExamDetails(id) {
        try {
            const response = await fetch(`https://localhost:7113/GetExamById/${id}`);
            
            if (!response.ok) {
                throw new Error('لم يتم العثور على الامتحان');
            }

            const exam = await response.json();
            displayExamInfo(exam);
        } catch (error) {
            console.error('Error:', error);
            errorAlert.textContent = error.message;
            errorAlert.style.display = 'block';
            confirmDeleteBtn.disabled = true;
        }
    }

    function displayExamInfo(exam) {
        examInfo.innerHTML = `
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">${exam.title}</h5>
                    <p class="card-text">${exam.description || 'لا يوجد وصف'}</p>
                    <div class="d-flex flex-wrap gap-2">
                        <span class="badge bg-primary">رقم الامتحان: ${exam.examID}</span>
                        <span class="badge bg-secondary">المادة: ${exam.subjectName}</span>
                        <span class="badge bg-secondary">المدة: ${exam.duration} دقيقة</span>
                        <span class="badge ${getDifficultyBadgeClass(exam.diffficulty)}">
                            الصعوبة: ${exam.diffficulty}
                        </span>
                    </div>
                </div>
            </div>
        `;
    }

    async function deleteExam(id) {
        try {
            const response = await fetch(`https://localhost:7113/DeleteExam/${id}`, {
                method: 'DELETE'
            });

            if (!response.ok) {
                throw new Error('فشل في حذف الامتحان');
            }

            alert('تم حذف الامتحان بنجاح');
            window.location.href = 'exams-list.html';
        } catch (error) {
            console.error('Error:', error);
            errorAlert.textContent = error.message;
            errorAlert.style.display = 'block';
        }
    }

    function getDifficultyBadgeClass(difficulty) {
        switch(difficulty.toLowerCase()) {
            case 'easy': return 'bg-success';
            case 'medium': return 'bg-warning text-dark';
            case 'hard': return 'bg-danger';
            default: return 'bg-secondary';
        }
    }
});