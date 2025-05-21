import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Book } from '../book.model';
import { BookService } from '../book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit
{
  books: Book[] = [];
  booksRowData: any[] = [];

  constructor(private bookService: BookService, private router: Router) { }

  async ngOnInit()
  {
    console.log("loading books")
    await this.loadBooks();
    console.log(this.books);
  }

  async loadBooks()
  {
    this.books = await firstValueFrom(this.bookService.getBooks());
    this.booksRowData = this.books;
  }

  editBook(id: number)
  {
    this.router.navigate(['/books', id]);
  }

  addBook()
  {
    this.router.navigate(['/books/new']);
  }
}
