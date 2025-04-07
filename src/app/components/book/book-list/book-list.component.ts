import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../../models/book.model';
import { BookService } from '../../../services/book.service';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.fetchBooks();
  }

  fetchBooks(): void {
    this.bookService.getAllBooks().subscribe(data => {
      this.books = data;
    });
  }
}
