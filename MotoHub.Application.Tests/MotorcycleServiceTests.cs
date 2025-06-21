using FluentAssertions;
using Moq;
using MotoHub.Application.Resources;
using MotoHub.Application.Services;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Tests
{
    [TestFixture]
    public class MotorcycleServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IMotorcycleRepository> _motorcycleRepositoryMock;
        private MotorcycleDTO _motorcycleDTO;
        private MotorcycleService _service;

        [SetUp]
        public void SetUp()
        {
            _motorcycleDTO = new MotorcycleDTO("123", "ABC123", "bross", 2025);

            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _motorcycleRepositoryMock = new Mock<IMotorcycleRepository>();

            _service = new MotorcycleService(_unitOfWorkMock.Object, _motorcycleRepositoryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _unitOfWorkMock = default!;
            _motorcycleRepositoryMock = default!;
            _motorcycleDTO = default!;
            _service = default!;
        }

        [Test]
        public async Task CreateAsync_WhenMotorcycleExists_ShouldThrowInvalidOperationExceptionAndRollback()
        {
            // Arrange
            Motorcycle motorcycle = new() { Identifier = "123" };

            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(motorcycle);

            // Act
            Func<Task> act = async () => await _service.CreateAsync(_motorcycleDTO);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage(string.Format(BusinessMessage.Invalid_Operation_Warning, "moto"));
            _unitOfWorkMock.Verify(u => u.RollbackAsync(), Times.Once);
        }

        [Test]
        public async Task CreateAsync_WhenNewMotorcycle_ShouldAddAndCommit()
        {
            // Arrange
            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync((Motorcycle)null!);
            _motorcycleRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Motorcycle>())).Returns(Task.CompletedTask);

            // Act
            await _service.CreateAsync(_motorcycleDTO);

            // Assert
            _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
            _motorcycleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Motorcycle>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Test]
        public void GetByIdentifierAsync_WhenMotorcycleNotFound_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync((Motorcycle)null!);

            // Act
            Func<Task> act = async () => await _service.GetByIdentifierAsync("123");

            // Assert
            act.Should().ThrowAsync<KeyNotFoundException>().WithMessage(string.Format(BusinessMessage.NotFound_Warning, "moto"));
        }

        [Test]
        public async Task GetByIdentifierAsync_WhenFound_ShouldReturnMotorcycleResponseDTO()
        {
            // Arrange
            Motorcycle motorcycle = new() { Identifier = "123", LicensePlate = "ABC123", Model = "bross", Year = 2022 };
            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(motorcycle);

            // Act
            MotorcycleResponseDTO result = await _service.GetByIdentifierAsync("123");

            // Assert
            MotorcycleResponseDTO expected = new()
            {
                Identifier = "123",
                LicensePlate = "ABC123",
                Model = "bross",
                Year = 2022
            };
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task UpdateLicensePlateByIdentifierAsync_WhenMotorcycleNotFound_ShouldThrowKeyNotFoundExceptionAndRollback()
        {
            // Arrange
            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync((Motorcycle)null!);

            // Act
            Func<Task> act = async () => await _service.UpdateLicensePlateByIdentifierAsync(_motorcycleDTO);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage(string.Format(BusinessMessage.NotFound_Warning, "moto"));
            _unitOfWorkMock.Verify(u => u.RollbackAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateLicensePlateByIdentifierAsync_WhenMotorcycleFound_ShouldUpdateAndCommit()
        {
            // Arrange
            Motorcycle motorcycle = new() { Identifier = "123", LicensePlate = "ABC123", Model = "bross", Year = 2022 };

            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(motorcycle);

            // Act
            await _service.UpdateLicensePlateByIdentifierAsync(_motorcycleDTO);

            // Assert
            _motorcycleRepositoryMock.Verify(r => r.Update(motorcycle), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteByIdentifierAsync_WhenMotorcycleNotFound_ShouldThrowKeyNotFoundExceptionAndRollback()
        {
            // Arrange
            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync((Motorcycle)null!);

            // Act
            Func<Task> act = async () => await _service.DeleteByIdentifierAsync("123");

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage(string.Format(BusinessMessage.NotFound_Warning, "moto"));
            _unitOfWorkMock.Verify(u => u.RollbackAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteByIdentifierAsync_WhenMotorcycleFound_ShouldRemoveAndCommit()
        {
            // Arrange
            Motorcycle motorcycle = new() { Identifier = "123" };
            
            _motorcycleRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(motorcycle);
            
            // Act
            await _service.DeleteByIdentifierAsync("123");

            // Assert
            _motorcycleRepositoryMock.Verify(r => r.Remove(motorcycle), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }
    }
}