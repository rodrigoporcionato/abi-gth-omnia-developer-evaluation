using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the User entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class UserTests
{

    /// <summary>
    /// coverate test sales command
    /// </summary>
    [Fact]
    public void SaleCommand_ShouldInitializeCorrectly()
    {
        // Arrange
        var command = new SaleCommand
        {
            Customer = "rodrigo porcionato",
            Branch = "Main Branch",
            Items = new List<SaleItem> { 
                new SaleItem { Product = new Product 
                { Title="test title" }, 
                    Quantity = 2, 
                    UnitPrice = 3} 
            }
        };

        // Assert
        command.Customer.Should().Be("rodrigo porcionato");
        command.Branch.Should().Be("Main Branch");
        command.Items.Should().HaveCount(1);
        command.Items[0].Product.Title.Should().Be("test title");
        command.Items[0].Quantity.Should().Be(2);
        command.Items[0].UnitPrice.Should().Be(3);
    }


    /// <summary>
    /// test coverage Sales result
    /// </summary>
    [Fact]
    public void SaleResult_ShouldInitializeCorrectly()
    {
        // Arrange
        var saleResult = new SaleResult
        {
            SaleNumber = 123,
            Date = new DateTime(2024, 02, 26),
            Customer = "rodrigo porcionato",
            Branch = "Main Branch",
            Items = new List<SaleItem>(),
            TotalAmount = 150.50m
        };

        // Assert
        saleResult.SaleNumber.Should().Be(123);
        saleResult.Date.Should().Be(new DateTime(2024, 02, 26));
        saleResult.Customer.Should().Be("rodrigo porcionato");
        saleResult.Branch.Should().Be("Main Branch");
        saleResult.Items.Should().BeEmpty();
        saleResult.TotalAmount.Should().Be(150.50m);
    }





    /// <summary>
    /// Tests that when a suspended user is activated, their status changes to Active.
    /// </summary>
    [Fact(DisplayName = "User status should change to Active when activated")]
    public void Given_SuspendedUser_When_Activated_Then_StatusShouldBeActive()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Status = UserStatus.Suspended;

        // Act
        user.Activate();

        // Assert
        Assert.Equal(UserStatus.Active, user.Status);
    }

    /// <summary>
    /// Tests that when an active user is suspended, their status changes to Suspended.
    /// </summary>
    [Fact(DisplayName = "User status should change to Suspended when suspended")]
    public void Given_ActiveUser_When_Suspended_Then_StatusShouldBeSuspended()
    {
        var user = UserTestData.GenerateValidUser();
        user.Status = UserStatus.Active;

        user.Suspend();

        Assert.Equal(UserStatus.Suspended, user.Status);
    }

    /// <summary>
    /// Tests that validation passes when all user properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid user data")]
    public void Given_ValidUserData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();

        // Act
        var result = user.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when user properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid user data")]
    public void Given_InvalidUserData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var user = new User
        {
            Username = "", // Invalid: empty
            Password = UserTestData.GenerateInvalidPassword(), // Invalid: doesn't meet password requirements
            Email = UserTestData.GenerateInvalidEmail(), // Invalid: not a valid email
            Phone = UserTestData.GenerateInvalidPhone(), // Invalid: doesn't match pattern
            Status = UserStatus.Unknown, // Invalid: cannot be Unknown
            Role = UserRole.None // Invalid: cannot be None
        };

        // Act
        var result = user.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
