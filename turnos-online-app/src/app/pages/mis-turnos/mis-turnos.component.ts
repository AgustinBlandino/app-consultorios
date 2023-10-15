import { Component, Output } from '@angular/core';
import { TurnoService } from 'src/app/services/turno.service';
import { Turno } from 'src/app/interfaces/turno/turno.component';
@Component({
  selector: 'app-mis-turnos',
  templateUrl: './mis-turnos.component.html',
  styleUrls: ['./mis-turnos.component.css']
})
export class MisTurnosComponent {

  listaTurnos: Turno[] = [];

  public mostrarDiv: boolean = false;
  public dni: number = 0; // Esta propiedad almacenará el valor del input
  constructor(private turnosService: TurnoService) { } // Asegúrate de que el nombre del servicio sea correcto

  verTurnos() {
    this.mostrarDiv = true;
    this.hacerPeticionAServicio();
  }

  hacerPeticionAServicio() {
    this.turnosService.GetTurnoById(this.dni).subscribe(
      (data) => {
        this.listaTurnos = data.body as unknown as Turno[];
        console.log(this.listaTurnos)// Asigna la lista de turnos
      },
      (error) => {
        console.error('Error en la solicitud HTTP', error);
        // Maneja el error aquí
      }
    );
  }

}
function output(target: MisTurnosComponent, propertyKey: 'mostrarDiv'): void {
  throw new Error('Function not implemented.');
}

