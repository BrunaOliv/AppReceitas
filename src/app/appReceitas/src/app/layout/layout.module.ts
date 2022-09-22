import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './Header/Header.component';
import { RouterModule } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
  imports: [
    RouterModule,
    CommonModule,
    MatButtonModule,
    MatIconModule
  ],
  declarations: [HeaderComponent],
  exports:[HeaderComponent]
})
export class LayoutModule { }
