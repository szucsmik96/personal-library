import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from './book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService
{
  actionUrl: string = "/api/book";
  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]>
  {
    return this.http.get<Book[]>('/api/book');
  }

  getBook(id: number): Observable<Book>
  {
    return this.http.get<Book>(`${this.actionUrl}/${id}`)
  }

  createBook(newBook: Book): Observable<number>
  {
    return this.http.post<number>(this.actionUrl, newBook);
  }

  updateBook(book: Book): Observable<void>
  {
    return this.http.put<void>(`${this.actionUrl}/${book.id}`, book);
  }

  deleteBook(id: number): Observable<void>
  {
    return this.http.delete<void>(`${this.actionUrl}/${id}`);
  }
}
