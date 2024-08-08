import { renderQuestionList } from './question/questionList.js';

document.addEventListener('DOMContentLoaded', async () => {
    const app = document.getElementById('app');

    const questionSection = document.createElement('section');
    questionSection.id = 'questions';
    questionSection.innerHTML = '<h2>Preguntas</h2>';
    const questionList = await renderQuestionList();
    questionSection.appendChild(questionList);
    app.appendChild(questionSection);

    const questionDetailSection = document.createElement('section');
    questionDetailSection.id = 'question-details';
    questionDetailSection.innerHTML = '<h2>Detalles de la Pregunta</h2>';
    app.appendChild(questionDetailSection);
});
