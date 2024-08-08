export const createQuestionElement = (question) => {
    const container = document.createElement('div');
    container.className = 'question-container';

    const questionTitle = document.createElement('h3');
    questionTitle.innerText = question.title;
    container.appendChild(questionTitle);

    const questionText = document.createElement('p');
    questionText.innerText = question.text;
    container.appendChild(questionText);

    container.addEventListener('click', () => {
        renderQuestionDetails(question.id);
    });

    return container;
};

const renderQuestionDetails = async (id) => {
    const response = await fetch(`https://localhost:5001/api/question/${id}`);
    const question = await response.json();

    const detailContainer = document.getElementById('question-details');
    detailContainer.innerHTML = ''; 

    const questionTitle = document.createElement('h3');
    questionTitle.innerText = question.title;
    detailContainer.appendChild(questionTitle);

    const questionText = document.createElement('p');
    questionText.innerText = question.text;
    detailContainer.appendChild(questionText);

    const answerTextarea = document.createElement('textarea');
    answerTextarea.placeholder = 'Escribe tu respuesta aquí...';
    detailContainer.appendChild(answerTextarea);

    const saveButton = document.createElement('button');
    saveButton.innerText = 'Guardar';
    saveButton.addEventListener('click', async () => {
        await saveAnswer(question.id, answerTextarea.value);
    });
    detailContainer.appendChild(saveButton);
};

const saveAnswer = async (questionId, answerText) => {
    const response = await fetch(`https://localhost:5001/api/question/${questionId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ answer: answerText })
    });

    if (response.ok) {
        alert('Respuesta guardada correctamente');
    } else {
        alert('Error al guardar la respuesta');
    }
};
