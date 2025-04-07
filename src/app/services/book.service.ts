import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private baseUrl = 'https://localhost:7160/api/Books';

  constructor(private http: HttpClient) {}

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseUrl}/GetAllBooks`);
  }

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.baseUrl}/GetBookById/${id}`);
  }

  addBook(book: Book): Observable<any> {
    return this.http.post(`${this.baseUrl}/AddBook`, book);
  }

  updateBook(book: Book): Observable<any> {
    return this.http.put(`${this.baseUrl}/${book.id}`, book);
  }

  deleteBook(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
