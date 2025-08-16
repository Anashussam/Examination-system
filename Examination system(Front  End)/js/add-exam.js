document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('examForm');
    const user = JSON.parse(localStorage.getItem('user')); 
    
    form.addEventListener('submit', async function(e) {
        e.preventDefault();
        
        if (!form.checkValidity()) {
            e.stopPropagation();
            form.classList.add('was-validated');
            return;
        }
        
        const examData = {
            subjectID: parseInt(document.getElementById('subjectID').value),
            createdBy: user.userId, 
            title: document.getElementById('examTitle').value,
            description: document.getElementById('examDescription').value,
            duration: parseInt(document.getElementById('examDuration').value),
            diffficulty: document.getElementById('examDifficulty').value,
            subjectName: document.getElementById('subjectID').selectedOptions[0].text,
            createdByName: user.name 
        };
        
        try {
            const response = await fetch('https://localhost:7113/AddExam', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(examData)
            });
            
            if (!response.ok) {
                const errorData = await response.json();
                throw new Error(errorData.message || 'فشل في إضافة الامتحان');
            }
            
            alert('تم إضافة الامتحان بنجاح');
            form.reset();
            form.classList.remove('was-validated');
            
        } catch (error) {
            console.error('Error:', error);
            alert('حدث خطأ: ' + error.message);
        }
    });
});