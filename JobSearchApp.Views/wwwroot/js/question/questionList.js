import { createQuestionElement } from './questionDetails.js';

export const renderQuestionList = async () => {
    const response = await fetch('https://localhost:5001/api/question');
    const questions = await response.json();
    const questionListContainer = document.createElement('div');
    questionListContainer.className = 'question-list';

    questions.forEach(question => {
        const questionElement = createQuestionElement(question);
        questionListContainer.appendChild(questionElement);
    });

    return questionListContainer;
};
