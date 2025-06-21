using FluentAssertions;
using Moq;
using MotoHub.Application.Resources;
using MotoHub.Application.Services;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Tests;

[TestFixture]
public class RentalServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IRentalRepository> _rentalRepositoryMock;
    private Mock<IRepository<DeliveryMan>> _deliveryManRepositoryGenericMock;
    private Mock<IRepository<Rental>> _rentalRepositoryGenericMock;
    private RentalDTO _rentalDTO;
    private RentalService _service;

    [SetUp]
    public void SetUp()
    {
        _rentalDTO = new RentalDTO("123", "123", "123", DateTime.Today, DateTime.Today.AddDays(7), DateTime.Today.AddDays(7), 7);

        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _rentalRepositoryMock = new Mock<IRentalRepository>();
        _deliveryManRepositoryGenericMock = new Mock<IRepository<DeliveryMan>>();
        _rentalRepositoryGenericMock = new Mock<IRepository<Rental>>();

        _unitOfWorkMock.Setup(u => u.Repository<DeliveryMan>()).Returns(_deliveryManRepositoryGenericMock.Object);
        _unitOfWorkMock.Setup(u => u.Repository<Rental>()).Returns(_rentalRepositoryGenericMock.Object);

        _service = new RentalService(_unitOfWorkMock.Object, _rentalRepositoryMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _rentalRepositoryMock = default!;
        _unitOfWorkMock = default!;
        _deliveryManRepositoryGenericMock = default!;
        _rentalDTO = default!;
        _rentalRepositoryGenericMock = default!;
        _service = default!;
    }

    [Test]
    public async Task CreateAsync_WhenDeliveryManNotFound_ShouldThrowsKeyNotFoundExceptionAndRollback()
    {
        //Arrange
        _deliveryManRepositoryGenericMock.Setup(r => r.GetByIdentifierAsync(_rentalDTO.DeliveryManIdentifier!)).ReturnsAsync((DeliveryMan)null!);

        RentalService rentalService = new(_unitOfWorkMock.Object, _rentalRepositoryMock.Object);

        //Act
        Func<Task> act = async () => await _service.CreateAsync(_rentalDTO);

        //Assert
        await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage(string.Format(BusinessMessage.NotFound_Warning, "entregador"));
        _unitOfWorkMock.Verify(u => u.RollbackAsync(), Times.Once);
    }

    [Test]
    public async Task CreateAsync_WhenLicenseInvalid_ShouldThrowsInvalidOperationExceptionAndRollback()
    {
        // Arrange
        DeliveryMan deliveryMan = new() { Identifier = "123", DriverLicenseType = "B" };

        _deliveryManRepositoryGenericMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(deliveryMan);

        //Act
        Func<Task> act = async () => await _service.CreateAsync(_rentalDTO);

        //Assert
        await act.Should().ThrowAsync<InvalidOperationException>().WithMessage(string.Format(BusinessMessage.Invalid_DeliveryMan_Warning));
        _unitOfWorkMock.Verify(u => u.RollbackAsync(), Times.Once);
    }

    [Test]
    public async Task CreateAsync_WhenExistingActiveRental_ShouldThrowsInvalidOperationExceptionAndRollback()
    {
        //Arrange
        DeliveryMan deliveryMan = new() { Identifier = "123", DriverLicenseType = "A" };
        _deliveryManRepositoryGenericMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(deliveryMan);

        var oldRental = new Rental { ReturnDate = DateTime.Now.AddDays(1) };
        _rentalRepositoryMock.Setup(r => r.GetByMotorcycleIdentifierAsync(It.IsAny<string>())).ReturnsAsync(oldRental);

        //Act
        Func<Task> act = async () => await _service.CreateAsync(_rentalDTO);

        //Assert
        await act.Should().ThrowAsync<InvalidOperationException>().WithMessage(string.Format(BusinessMessage.Invalid_Rental_Warning));
        _unitOfWorkMock.Verify(u => u.RollbackAsync(), Times.Once);
    }

    [Test]
    public async Task CreateAsync_WhenNewRental_ShouldAddAndCommit()
    {
        //Arrange
        DeliveryMan deliveryMan = new() { Identifier = "123", DriverLicenseType = "A" };
        _deliveryManRepositoryGenericMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(deliveryMan);
        _rentalRepositoryMock.Setup(r => r.GetByMotorcycleIdentifierAsync(It.IsAny<string>())).ReturnsAsync((Rental)null!);

        //Act
        await _service.CreateAsync(_rentalDTO);

        //Assert
        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _rentalRepositoryGenericMock.Verify(r => r.AddAsync(It.Is<Rental>(rent => rent.MotorcycleIdentifier == _rentalDTO.MotorcycleIdentifier)), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }

    [Test]
    public async Task GetByIdAsync_WhenRentalNotFound_ShouldThrowsKeyNotFoundException()
    {
        //Arrange
        _rentalRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync((Rental)null!);

        //Act
        Func<Task<RentalResponseDTO>> act = async () => await _service.GetByIdAsync("123");

        //Assert
        await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage(string.Format(BusinessMessage.NotFound_Warning, "locação"));
    }

    [Test]
    public async Task GetByIdAsync_WhenFound_ShouldReturnRentalResponseDTO()
    {
        //Arrange
        var rental = new Rental 
        { 
            Identifier = "123", 
            MotorcycleIdentifier = "123",
            DeliveryManIdentifier = "123",
            StartDate = DateTime.Today, 
            EndDate = DateTime.Today.AddDays(7), 
            ExpectedEndDate = DateTime.Today.AddDays(7), 
            ReturnDate = DateTime.Today.AddDays(7), 
            Plan = 7, 
            Value = 100m 
        };

        _rentalRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(rental);

        //Act
        RentalResponseDTO result = await _service.GetByIdAsync("123");

        //Assert
        RentalResponseDTO expected = new()
        {
            Identifier = "123",
            MotorcycleIdentifier = "123",
            DeliveryManIdentifier = "123",
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(7),
            ExpectedEndDate = DateTime.Today.AddDays(7),
            ReturnDate = DateTime.Today.AddDays(7),
            Plan = 7,
            Value = 100m
        };
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public async Task UpdateAsync_BeforeExpectedEndDate_CalculatesCorrectValue()
    {
        //Arrange
        DateTime start = DateTime.Today;
        DateTime expectedEnd = start.AddDays(7);
        Rental rental = new() { Identifier = "123", StartDate = start, ExpectedEndDate = expectedEnd, Plan = 7 };

        _rentalRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(rental);

        //Act
        DateTime returnDate = start.AddDays(3);
        await _service.UpdateAsync("123", returnDate);

        //Assert
        decimal expectedValue = 30m * 3 + ((7 - 3) * 30m * 0.2m);
        Assert.That(rental.Value, Is.EqualTo(Math.Round(expectedValue, 2)));
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_OnExpectedEndDate_CalculatesFullPlanValue()
    {
        //Arrange
        DateTime start = DateTime.Today;
        DateTime expectedEnd = start.AddDays(7);
        Rental rental = new() { Identifier = "123", StartDate = start, ExpectedEndDate = expectedEnd, Plan = 7 };

        _rentalRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(rental);

        //Act
        await _service.UpdateAsync("123", expectedEnd);

        //Assert
        decimal expectedValue = 30m * 7;
        rental.Value.Should().Be(expectedValue);
    }

    [Test]
    public async Task UpdateAsync_AfterExpectedEndDate_IncludesFineAndExtraDays()
    {
        //Arrange
        DateTime start = DateTime.Today;
        DateTime expectedEnd = start.AddDays(7);
        Rental rental = new() { Identifier = "123", StartDate = start, ExpectedEndDate = expectedEnd, Plan = 7 };

        _rentalRepositoryMock.Setup(r => r.GetByIdentifierAsync(It.IsAny<string>())).ReturnsAsync(rental);

        //Act
        DateTime returnDate = expectedEnd.AddDays(2);
        await _service.UpdateAsync("123", returnDate);

        //Assert
        decimal expectedValue = (30m * 7) + (30m * 2) + (50m * 2);
        rental.Value.Should().Be(expectedValue);
    }
}
