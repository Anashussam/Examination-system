async function loadSubjects() {
    try {
        const response = await fetch('https://localhost:7113/api/Subjects/GetAllSubjects');
        
        if (!response.ok) {
            throw new Error('Failed to load subjects');
        }
        
        const subjects = await response.json();
        const select = document.getElementById('subjectID');
        
    
        while (select.options.length > 1) {
            select.remove(1);
        }
        
        subjects.forEach(subject => {
            const option = document.createElement('option');
            option.value = subject.subjectID;
            option.textContent = subject.subjectName;
            select.appendChild(option);
        });
        
    } catch (error) {
        console.error('Error loading subjects:', error);
        alert('تعذر تحميل قائمة المواد');
    }
}


document.addEventListener('DOMContentLoaded', loadSubjects);