using LibraryManager.Core.Entities;
using LibraryManager.Core.Enums;

namespace LibraryManager.UnitTests.Core.Entities;

public class BookTests
{
    [Fact]
    public void ToArchiveBook()
    {
        // Arrange
        var book = new Book("Test Book", "Test Author","1234567890",1900,"Test Image");
        
        // Act
        book.ToArchive();
        
        // Assert
        Assert.Equal(BookStatus.Archived, book.Status);
    }
    
    [Fact]
    public void ToAvailableBook()
    {
        // Arrange
        var book = new Book("Test Book", "Test Author","1234567890",1900,"Test Image");
        
        // Act
        book.ToArchive();
        
        // Assert
        Assert.Equal(BookStatus.Archived, book.Status);
        
        // Act
        book.ToAvailable();
        
        // Assert
        Assert.Equal(BookStatus.Available, book.Status);
    }
    
}