using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Moq;

namespace LibraryManager.UnitTests.Application.Commands;

public class InsertLoanCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Execute_ReturnLoanId()
    {
        //Arrange
        var book = new Book("Book Title", "Book Author", "1234567890", 1900, "Book Image");
        var user = new User("User Name", "User Email", "User Password", "Client");
        
        var loanRepositoryMock = new Mock<ILoanRepository>();
        var bookRepositoryMock = new Mock<IBookRepository>();
        var userRepositoryMock = new Mock<IUserRepository>();
        
        bookRepositoryMock.Setup(b => b.GetByIdAsync(book.Id).Result).Returns(book);
        userRepositoryMock.Setup(u => u.GetByIdAsync(user.Id).Result).Returns(user);

        var insertLoanCommand = new InsertLoanCommand(user.Id, book.Id);
        var insertLoanCommandHandler = new InsertLoanHandler(loanRepositoryMock.Object, bookRepositoryMock.Object, userRepositoryMock.Object);

        // Act
        var id = await insertLoanCommandHandler.Handle(insertLoanCommand, CancellationToken.None);

        // Assert
        Assert.True(id.Data != Guid.Empty);
        loanRepositoryMock.Verify(l => l.AddAsync(It.IsAny<Loan>()), Times.Once());
    }
}