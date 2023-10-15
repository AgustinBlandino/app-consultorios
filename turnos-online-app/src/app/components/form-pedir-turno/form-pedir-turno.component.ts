import { Turno } from './../../interfaces/turno/turno.component';
import { Component, OnInit, Output } from '@angular/core';
import { ObraSocial } from 'src/app/interfaces/obra-social/obra-social.component';
import { FormControl } from '@angular/forms';
import { ObraSocialService } from 'src/app/services/obra-social.service';
import { TurnoService } from 'src/app/services/turno.service';
import { HttpClient, HttpResponse } from '@angular/common/http';
import Swal from 'sweetalert';


@Component({
  selector: 'form-pedir-turno',
  templateUrl: './form-pedir-turno.component.html',
  styleUrls: ['./form-pedir-turno.component.css']
})
export class FormPedirTurnoComponent implements OnInit {
  @Output() respuestaHttp: boolean = false;



  public obrasSociales: ObraSocial[] = [];
  public newTurno: Turno = {
    nombreApellido: '',
    email: '',
    dni: 0,
    obraSocial: '',
    nroTelefono: 0,
    fecha: '',
    horario: '',
    disponibilidadSesionVirtual: false
  };
  public selectedObraSocial = new FormControl(null);

  public nombreYApellido: string = ''; // Esta propiedad almacenará el valor del input
  public email: string = ''; // Esta propiedad almacenará el valor del input
  public dni: number = 0; // Esta propiedad almacenará el valor del input
  public obraSocial: ObraSocial = { id: 0, descripcion: "" }; // Esta propiedad almacenará el valor del input
  public nroTelefono: number = 0; // Esta propiedad almacenará el valor del input
  public dia: string = ''; // Esta propiedad almacenará el valor del input
  public hora: string = ''; // Esta propiedad almacenará el valor del input
  public disponibilidadSesionOnline: boolean = false; // Esta propiedad almacenará el valor del input


  constructor(private obrasSocialesService: ObraSocialService, private turnosService: TurnoService) { } // Asegúrate de que el nombre del servicio sea correcto

  ngOnInit(): void {
    this.obrasSocialesService.getObrasSociales().subscribe((data) => {
      this.obrasSociales = data;
    });
    console.log(this.selectedObraSocial)

  }

  enviarTurno() {
    this.newTurno = {
      nombreApellido: this.nombreYApellido,
      email: this.email,
      dni: this.dni,
      obraSocial: this.obraSocial.descripcion,
      nroTelefono: this.nroTelefono,
      fecha: this.dia,
      horario: this.hora,
      disponibilidadSesionVirtual: this.disponibilidadSesionOnline
    }
    console.log(this.newTurno)
    this.turnosService.PostTurno(this.newTurno).subscribe(
      (response: HttpResponse<any>) => {
        if (response.status === 200) {  // Cambiado de 200 a 201
          console.log('Turno creado con éxito');
          Swal("Turno enviado correctamente", "", "success");
          this.respuestaHttp = true;
          // Puedes acceder a la respuesta y a los datos del turno si es necesario.
          console.log(response.body);
        } else {
          console.error(`Error HTTP ${response.status}`);
          this.respuestaHttp = false;

        }
      },
      (error) => {
        console.error('Error en la solicitud HTTP', error);
        this.respuestaHttp = false;

      }
    );
    console.log(this.disponibilidadSesionOnline)
  }
}


