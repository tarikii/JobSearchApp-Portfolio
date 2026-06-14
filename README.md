# Swipe4Work

Swipe4Work is a job-matching web application inspired by Tinder and LinkedIn, designed to connect candidates and recruiters through a swipe-based recruitment experience.

Candidates can discover job offers, filter opportunities, like or dislike positions, save offers, and apply to jobs. Recruiters can create and manage job offers, review candidates, and track matches.

---

## Key Features

### Candidate
- Browse job offers using a card-based interface.
- Like, dislike, save, and apply to job offers.
- Filter offers based on preferences and interests.
- Manage applied jobs and matches.
- Create and update professional profile information.
- Add education and professional experience.

### Recruiter / Business
- Register and manage business accounts.
- Create, update, and delete job offers.
- View candidates linked to each job offer.
- Manage recruitment workflow through matches.

### Platform
- User authentication and registration.
- Role-based flows for candidates and recruiters.
- Hard skills, soft skills, interests, and preferences management.
- Feedback system.
- Questions and answers module.
- MVC-based application structure.

---

## Tech Stack

- ASP.NET MVC
- C#
- SQL Server
- Entity Framework
- HTML
- CSS
- Bootstrap
- JavaScript
- Git / GitHub

---

## Architecture Overview

The application is organized using the MVC pattern, separating business logic, views, and data management.

Main areas:

- Authentication
- Candidate flow
- Recruiter/business flow
- Job offers
- Matching system
- User profiles
- Skills, interests, and preferences
- Education and experience management
- Feedback and Q&A

---

## Main Controllers

### HomeController
Handles public and role-specific landing pages.

### AuthController
Manages login, registration, authentication, password recovery, and entity selection.

### Candidate Flow
Handles job offer cards, filtering, likes, dislikes, saved offers, applications, and matches.

### Recruiter Business Flow
Handles job offer creation, modification, deletion, administration, and candidate review.

### ProfileController
Manages user profile visualization and personal data editing.

### ExperienceController
Manages professional experience creation, update, and deletion.

### EducationController
Manages education creation, update, and deletion.

### Skills, Interests and Preferences
Includes management of hard skills, soft skills, interests, and user preferences.

### Feedback and Q&A
Includes feedback creation and question-answer interaction.

---

## What I Learned

- Building a complete ASP.NET MVC web application.
- Designing role-based user flows.
- Managing authentication and registration workflows.
- Structuring a project using controllers, views, and models.
- Implementing CRUD operations across multiple entities.
- Designing candidate-recruiter interaction logic.
- Working with relational data and application state.
- Improving maintainability through separation of concerns.

---

## Future Improvements

- Real-time chat between candidates and recruiters.
- Advanced matching algorithm.
- Email notifications.
- Public recruiter/company pages.
- Azure deployment.
- Dashboard with recruitment analytics.
- API version of the application.

---

## Authors

Tarik Aabouch  
GitHub: https://github.com/tarikii

Cath Cardenas
Github: https://github.com/CathCM

Jay Marc
Github: https://github.com/JmarcXD
