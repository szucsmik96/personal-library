import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookComponent } from './book/book.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookDetailsComponent } from './book/book-details/book-details.component';
import { FormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';

import Aura from '@primeng/themes/aura';
import { ButtonModule } from 'primeng/button';
import { providePrimeNG } from 'primeng/config';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { PanelModule } from 'primeng/panel';
import { Menubar } from 'primeng/menubar';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    BookListComponent,
    BookDetailsComponent,
    BookComponent,
    BookDetailsComponent,
    BookListComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    JsonPipe,
    ButtonModule,
    TableModule,
    InputTextModule,
    PanelModule,
    Menubar,
    ReactiveFormsModule
  ],
  providers: [
    provideAnimationsAsync(),
    providePrimeNG({ 
      theme: {
          preset: Aura,
          options: {
            darkModeSelector: 'light',
          }
      }
  })
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
