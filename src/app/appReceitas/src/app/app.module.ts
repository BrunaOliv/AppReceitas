import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReceitasModule } from './modules/receitas/receitas.module';
import { HttpClientModule } from '@angular/common/http';
import { CatalogoDeProdutosModule } from './modules/CatalogoDeProdutos/CatalogoDeProdutos.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    BrowserAnimationsModule,
    ReceitasModule,
    HttpClientModule,
    CatalogoDeProdutosModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
