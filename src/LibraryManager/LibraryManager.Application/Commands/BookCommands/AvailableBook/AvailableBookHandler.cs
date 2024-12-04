using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.AvailableBook;

public class AvailableBookHandler(IBookRepository bookRepository)
    : IRequestHandler<AvailableBookCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(AvailableBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.Id);
        
        if(book == null) return ResultViewModel.Error("Book not found.");
        
        book.ToAvaliable();
        await bookRepository.UpdateAsync(book);
        return ResultViewModel.Success(); 
    }
}