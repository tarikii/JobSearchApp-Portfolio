// wwwroot/js/components/loadComponent.js
export const loadComponent = async (url, containerId) => {
    try {
        const response = await fetch(url);
        const html = await response.text();
        document.getElementById(containerId).innerHTML = html;
    } catch (error) {
        console.error('Error loading component:', error);
    }
};
