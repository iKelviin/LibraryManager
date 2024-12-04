using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.ArchiveBook;

public class ArchiveBookHandler(IBookRepository bookRepository) : IRequestHandler<ArchiveBookCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(ArchiveBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.Id);
        
        if(book == null) return  ResultViewModel.Error("Book not found.");
        
        book.ToArchive();
        await bookRepository.UpdateAsync(book);
        return ResultViewModel.Success(); 
    }
}