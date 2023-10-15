import { NgModule } from '@angular/core';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SharedMaterialModule } from '../shared/angular-materials/angular-materials.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [NavMenuComponent, HomeComponent, FooterComponent,],
  imports: [SharedMaterialModule, FormsModule, ReactiveFormsModule, BrowserAnimationsModule, RouterModule], // Importa el módulo compartido aquí
  exports: [NavMenuComponent, HomeComponent, FooterComponent], // Exporta el componente si es necesario
})
export class LayoutModule { }
