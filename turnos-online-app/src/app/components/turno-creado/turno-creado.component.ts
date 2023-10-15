import { Component, Input } from '@angular/core';
import { Turno } from 'src/app/interfaces/turno/turno.component';

@Component({
  selector: 'app-turno-creado',
  templateUrl: './turno-creado.component.html',
  styleUrls: ['./turno-creado.component.css']
})
export class TurnoCreadoComponent {
  @Input() turnoCreado: Turno = {
    nombreApellido: '',
    email: '',
    dni: 0,
    obraSocial: '',
    nroTelefono: 0,
    fecha: '',
    horario: '',
    disponibilidadSesionVirtual: false
  }
}
