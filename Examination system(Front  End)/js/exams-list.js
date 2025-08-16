
document.addEventListener('DOMContentLoaded', function() {
    const examsContainer = document.getElementById('examsContainer');
    const searchInput = document.getElementById('searchInput');
    const searchBtn = document.getElementById('searchBtn');
    const showAllBtn = document.getElementById('showAllBtn');
    const loadingSpinner = document.getElementById('loadingSpinner');
    const noResults = document.getElementById('noResults');

    loadExams();

  
    searchBtn.addEventListener('click', function() {
        const examId = searchInput.value.trim();
        if (examId) {
            loadExamById(examId);
        } else {
            alert('الرجاء إدخال رقم الامتحان');
        }
    });

  
    showAllBtn.addEventListener('click', loadExams);

    async function loadExams() {
        try {
            showLoading(true);
            const response = await fetch('https://localhost:7113/GetAllExams');
            
            if (!response.ok) {
                throw new Error('فشل في جلب البيانات');
            }

            const exams = await response.json();
            displayExams(exams);
        } catch (error) {
            console.error('Error:', error);
            alert('حدث خطأ أثناء جلب البيانات: ' + error.message);
        } finally {
            showLoading(false);
        }
    }

    async function loadExamById(examId) {
        try {
            showLoading(true);
            const response = await fetch(`https://localhost:7113/GetExamById/${examId}`);
            
            if (!response.ok) {
                throw new Error('لم يتم العثور على الامتحان');
            }

            const exam = await response.json();
            displayExams([exam]);
        } catch (error) {
            console.error('Error:', error);
            noResults.style.display = 'block';
            examsContainer.innerHTML = '';
        } finally {
            showLoading(false);
        }
    }

    function displayExams(exams) {
        if (!exams || exams.length === 0) {
            noResults.style.display = 'block';
            examsContainer.innerHTML = '';
            return;
        }

        noResults.style.display = 'none';
        examsContainer.innerHTML = '';

        exams.forEach(exam => {
            const difficultyClass = getDifficultyClass(exam.diffficulty);
            
            const examCard = document.createElement('div');
            examCard.className = `card exam-card ${difficultyClass}`;
            examCard.innerHTML = `
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8">
                            <h5 class="card-title">${exam.title}</h5>
                            <p class="card-text">${exam.description || 'لا يوجد وصف'}</p>
                            <div class="d-flex flex-wrap gap-2">
                                <span class="badge bg-primary">المادة: ${exam.subjectName}</span>
                                <span class="badge bg-secondary">المدة: ${exam.duration} دقيقة</span>
                                <span class="badge ${getDifficultyBadgeClass(exam.diffficulty)}">
                                    الصعوبة: ${exam.diffficulty}
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4 text-start">
                            <div class="d-flex flex-column h-100 justify-content-between">
                                <div>
                                    <p class="text-muted mb-1">رقم الامتحان: ${exam.examID}</p>
                                    <p class="text-muted">أنشأ بواسطة: ${exam.createdByName}</p>
                                </div>
                                <div class="mt-2">
                                    <a href="delete-exam.html?id=${exam.examID}" class="btn btn-danger btn-sm">حذف</a>
                                    <a href="edit-exam.html?id=${exam.examID}" class="btn btn-warning btn-sm">تعديل</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            `;
            
            examsContainer.appendChild(examCard);
        });
    }

    function getDifficultyClass(difficulty) {
        switch(difficulty.toLowerCase()) {
            case 'easy': return 'difficulty-easy';
            case 'medium': return 'difficulty-medium';
            case 'hard': return 'difficulty-hard';
            default: return '';
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

    function showLoading(show) {
        loadingSpinner.style.display = show ? 'block' : 'none';
    }
});