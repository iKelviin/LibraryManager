namespace LibraryManager.Core.Enums;

public enum BookStatus
{
    Available, // Livro disponível para empréstimo
    Archived, // Livro arquivado, não disponível para empréstimo
    Borrowed, // Livro emprestado
    Reserved // Livro reservado por um usuário
}