using LibraryManager.Application.Queries.BookQueries.GetAllBooks;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Moq;

namespace LibraryManager.UnitTests.Application.Queries;

public class GetAllBooksQueryHandlerTests
{
    [Fact]
    public async Task ThreeBooksExist_Executed_ReturnThreeBooksViewModels()
    {
        // Arrange
        var books = new List<Book>
        {
            new Book("Book 1", "Book Author", "1234567890", 1900, "Book Image"),
            new Book("Book 2", "Book Author", "1234567890", 1900, "Book Image"),
            new Book("Book 3", "Book Author", "1234567890", 1900, "Book Image"),
        };
        
        var bookRepositoryMock = new Mock<IBookRepository>();
        bookRepositoryMock.Setup(b => b.GetAllAsync().Result).Returns(books);

        var getAllBooksQuery = new GetAllBooksQuery();
        var getAllBooksQueryHandler = new GetAllBooksHandler(bookRepositoryMock.Object);
        
        // Act
        var bookViewModelList  = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

        // Assert
        Assert.NotNull(bookViewModelList);
        Assert.NotEmpty(bookViewModelList.Data!);
        Assert.Equal(books.Count, bookViewModelList.Data!.Count);
        
        bookRepositoryMock.Verify(b => b.GetAllAsync().Result, Times.Once);
    }
}