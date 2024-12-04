using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.DeleteBook;

public class DeleteBookHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, ResultViewModel>
{
    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.id);
        
        if(book == null) return ResultViewModel.Error("Book not found.");
        
        book.SetAsDeleted();
        await bookRepository.UpdateAsync(book);
        return ResultViewModel.Success();
    }
}