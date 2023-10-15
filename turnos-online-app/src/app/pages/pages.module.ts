import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedMaterialModule } from 'src/app/shared/angular-materials/angular-materials.module';
import { PedirTurnoComponent } from './pedir-turno/pedir-turno.component';
import { MisTurnosComponent } from './mis-turnos/mis-turnos.component';
import { FormComponentsModule } from '../components/form-components.module';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
  imports: [
    FormsModule, ReactiveFormsModule, SharedMaterialModule, RouterModule,
    FormComponentsModule
  ],
  declarations: [
    PedirTurnoComponent,
    MisTurnosComponent,
  ],
  exports: [

  ]
})
export class PagesModule { }
