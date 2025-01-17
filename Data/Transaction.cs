﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderApp
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Transaction() { }

        public Transaction(int transactionId, int userId, int bookId, decimal amount)
        {
            TransactionId = transactionId;
            UserId = userId;
            BookId = bookId;
            Title = BookService.GetBookTitle(bookId);
            Amount = amount;
            BorrowDate = DateTime.UtcNow;
            ReturnDate = DateTime.UtcNow.AddMonths(1);
        }

        public Transaction(int transactionId, int userId, int bookId, decimal amount, DateTime borrowDate)
        {
            TransactionId = transactionId;
            UserId = userId;
            BookId = bookId;
            Title = BookService.GetBookTitle(bookId);
            Amount = amount;
            BorrowDate = borrowDate;
            ReturnDate = borrowDate.AddMonths(1);
        }

        public Transaction(int transactionId, int userId, int bookId, decimal amount, DateTime borrowDate, DateTime returnDate)
        {
            TransactionId = transactionId;
            UserId = userId;
            BookId = bookId;
            Title = BookService.GetBookTitle(bookId);
            Amount = amount;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }

    }
}
