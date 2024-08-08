document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('add-question-form');
    const questionsList = document.getElementById('questions-list');
    const apiBaseUrl = 'https://localhost:7056/api/question'; 

    form.addEventListener('submit', async (event) => {
        event.preventDefault();
        const questionText = document.getElementById('question-title').value; 
        await addQuestion({ questionText }); 
        form.reset();
        await fetchQuestions();
    });

    const addQuestion = async (question) => {
        try {
            const response = await fetch(apiBaseUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(question)
            });

            if (!response.ok) {
                const errorMessage = await response.text();
                console.log('Error:', errorMessage);
                alert('Error al agregar la pregunta');
            }
        } catch (error) {
            console.error('Fetch error:', error);
            alert('Error de red al agregar la pregunta');
        }
    };


    const fetchQuestions = async () => {
        const response = await fetch(apiBaseUrl);
        const questions = await response.json();
        renderQuestions(questions);
    };

    const renderQuestions = (questions) => {
        questionsList.innerHTML = '';
        questions.forEach(question => {
            const questionElement = createQuestionElement(question);
            questionsList.appendChild(questionElement);
        });
    };

    const createQuestionElement = (question) => {
        const container = document.createElement('div');
        container.className = 'question-container';

        const questionTitle = document.createElement('h3');
        questionTitle.innerText = question.questionText; // Asegúrate de usar questionText aquí
        container.appendChild(questionTitle);

        container.addEventListener('click', () => {
            renderQuestionDetails(question.questionId);
        });

        return container;
    };

    const renderQuestionDetails = async (id) => {
        const response = await fetch(`${apiBaseUrl}/${id}`);
        const question = await response.json();

        const detailContainer = document.createElement('div');
        detailContainer.className = 'question-details';

        const questionTitle = document.createElement('h3');
        questionTitle.innerText = question.questionText; // Asegúrate de usar questionText aquí
        detailContainer.appendChild(questionTitle);

        questionsList.innerHTML = '';
        questionsList.appendChild(detailContainer);
    };

    fetchQuestions();
});
