import { FormPedirTurnoComponent } from './form-pedir-turno/form-pedir-turno.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedMaterialModule } from 'src/app/shared/angular-materials/angular-materials.module';
import { ReactiveFormsModule } from '@angular/forms';
import { TurnoCreadoComponent } from './turno-creado/turno-creado.component';


@NgModule({
  declarations: [FormPedirTurnoComponent,
    TurnoCreadoComponent],
  imports: [
    CommonModule,
    SharedMaterialModule,
    ReactiveFormsModule

  ],
  exports: [
    CommonModule,
    SharedMaterialModule,
    FormPedirTurnoComponent,
    TurnoCreadoComponent
  ]

})
export class FormComponentsModule { }

