using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.BookCommands.UpdateBook;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        
        if(book is null) return ResultViewModel.Error("Book not found.");
        
        book.Update(request.Title, request.Author, request.ISBN, request.PublicationYear, request.ImageUrl);
        await _bookRepository.UpdateAsync(book);
        return ResultViewModel.Success();
    }
}