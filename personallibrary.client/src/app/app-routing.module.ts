import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookComponent } from './book/book.component';
import { BookDetailsComponent } from './book/book-details/book-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'book', pathMatch: 'full' },
  {
    path: 'book',
    component: BookComponent,
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'data/:id', component: BookDetailsComponent },
      { path: 'list', component: BookListComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
