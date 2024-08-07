using AutoMapper;
using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.Domain.Models;
using JobSearchApp.Infrastructure.Interfaces;
using Moq;

namespace JobSearchApp.Tests.Services
{
    public class QuestionServiceTests
    {
        private readonly Mock<IQuestionRepository> _mockQuestionRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly QuestionService _questionService;

        public QuestionServiceTests()
        {
            _mockQuestionRepository = new Mock<IQuestionRepository>();
            _mockMapper = new Mock<IMapper>();
            _questionService = new QuestionService(_mockQuestionRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllQuestionsAsync_ReturnsListOfQuestions()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question { QuestionId = 1, QuestionText = "Question 1" },
                new Question { QuestionId = 2, QuestionText = "Question 2" }
            };
            _mockQuestionRepository.Setup(repo => repo.GetAllQuestionsAsync()).ReturnsAsync(questions);
            var questionDtos = new List<QuestionDto>
            {
                new QuestionDto( new Question(){ QuestionId = 1, QuestionText = "Question 1" }),
                new QuestionDto ( new Question() { QuestionId = 2, QuestionText = "Question 2" })
            };
            _mockMapper.Setup(m => m.Map<IEnumerable<QuestionDto>>(questions)).Returns(questionDtos);

            // Act
            var result = await _questionService.GetAllQuestionsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<QuestionDto>>(result);
        }

        [Fact]
        public async Task GetQuestionByIdAsync_ReturnsQuestionDto()
        {
            // Arrange
            var question = new Question { QuestionId = 1, QuestionText = "Question 1" };
            _mockQuestionRepository.Setup(repo => repo.GetQuestionByIdAsync(1)).ReturnsAsync(question);
            var questionDto = new QuestionDto (new Question(){ QuestionId = 1, QuestionText = "Question 1" });
            _mockMapper.Setup(m => m.Map<QuestionDto>(question)).Returns(questionDto);

            // Act
            var result = await _questionService.GetQuestionByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<QuestionDto>(result);
        }

        [Fact]
        public async Task CreateQuestionAsync_ReturnsCreatedQuestionDto()
        {
            // Arrange
            var createQuestionDto = new CreateQuestionDto { QuestionText = "New Question" };
            var question = new Question { QuestionText = "New Question" };
            _mockMapper.Setup(m => m.Map<Question>(createQuestionDto)).Returns(question);
            var createdQuestion = new Question { QuestionId = 1, QuestionText = "New Question" };
            _mockQuestionRepository.Setup(repo => repo.CreateQuestionAsync(question)).ReturnsAsync(createdQuestion);
            var createdQuestionDto = new QuestionDto (new Question(){ QuestionId = 1, QuestionText = "New Question" });
            _mockMapper.Setup(m => m.Map<QuestionDto>(createdQuestion)).Returns(createdQuestionDto);

            // Act
            var result = await _questionService.CreateQuestionAsync(createQuestionDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<QuestionDto>(result);
            Assert.Equal(1, result.QuestionId);
        }

        [Fact]
        public async Task UpdateQuestionAsync_ReturnsUpdatedQuestionDto()
        {
            // Arrange
            var updateQuestionDto = new UpdateQuestionDto { QuestionId = 1, QuestionText = "Updated Question" };
            var question = new Question { QuestionId = 1, QuestionText = "Updated Question" };
            _mockMapper.Setup(m => m.Map<Question>(updateQuestionDto)).Returns(question);
            var updatedQuestion = new Question { QuestionId = 1, QuestionText = "Updated Question" };
            _mockQuestionRepository.Setup(repo => repo.UpdateQuestionAsync(question)).ReturnsAsync(updatedQuestion);
            var updatedQuestionDto = new QuestionDto (new Question(){ QuestionId = 1, QuestionText = "Updated Question" });
            _mockMapper.Setup(m => m.Map<QuestionDto>(updatedQuestion)).Returns(updatedQuestionDto);

            // Act
            var result = await _questionService.UpdateQuestionAsync(1, updateQuestionDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<QuestionDto>(result);
            Assert.Equal("Updated Question", result.QuestionText);
        }

        [Fact]
        public async Task DeleteQuestionAsync_ReturnsTrue()
        {
            // Arrange
            _mockQuestionRepository.Setup(repo => repo.DeleteQuestionAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _questionService.DeleteQuestionAsync(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteQuestionAsync_ReturnsFalseIfQuestionNotFound()
        {
            // Arrange
            _mockQuestionRepository.Setup(repo => repo.DeleteQuestionAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _questionService.DeleteQuestionAsync(1);

            // Assert
            Assert.False(result);
        }
    }
}
