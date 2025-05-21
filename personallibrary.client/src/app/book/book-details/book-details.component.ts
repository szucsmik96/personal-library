import { AfterViewChecked, AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../book.service';
import { Book } from '../book.model';
import { firstValueFrom } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.css'
})
export class BookDetailsComponent implements OnInit, AfterViewInit, AfterViewChecked {
  book: Book = new Book();
  bookId: number = 0;

  bookFormGroup: FormGroup = new FormGroup({
    title: new FormControl<string | null>(null, [Validators.required]),
    author: new FormControl<string | null>(null, [Validators.required]),
    genre: new FormControl<string | null>(null, [Validators.required]),
  });

  constructor(private route: ActivatedRoute, private router: Router, private bookService: BookService, private changeDetector: ChangeDetectorRef,) {}

  ngOnInit(){ }

  async load(id: number){
    if(this.bookId != 0){
      this.book = await firstValueFrom(this.bookService.getBook(id));
      this.bookFormGroup!.patchValue(this.book);
    }
    else{
      this.bookFormGroup!.reset();
    }
  }

  async ngAfterViewInit(): Promise<void>
    {
        this.route.paramMap.subscribe(async paramMap =>
        {
            this.bookId = Number(paramMap.get("id"));
            await this.load(this.bookId);
        });
    }

  ngAfterViewChecked()
  {
      this.changeDetector?.detectChanges();
  }

  save(): void {
    let book: Book = this.bookFormGroup.getRawValue();
    book.id = this.bookId;

    console.log(book);

    if (this.bookId == 0) {
      this.bookService.createBook(book).subscribe(res => {
        console.log('Book created', res);
        this.router.navigate([`../${res}`], { relativeTo: this.route });
      });
    } else {
      this.bookService.updateBook(book).subscribe(res => {
        console.log('Book updated', res);
      });
    }
  }

  async delete()
  {
    if (confirm('Are you sure you want to delete this book?'))
    {
      await firstValueFrom(this.bookService.deleteBook(this.bookId));
      this.router.navigate([`/`]);
    }
  }
}
