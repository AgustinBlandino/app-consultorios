import { Component, Inject, Input, NgModule, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-pedir-turno',
  templateUrl: './pedir-turno.component.html',
  styleUrls: ['./pedir-turno.component.css']
})
export class PedirTurnoComponent implements OnInit {
  public obrasSociales: ObrasSocial[] = [];
  public selectedObraSocial = new FormControl('');
  @Input() respuestaHttp: boolean = false;


  ngOnInit(): void {
  }

}

interface ObrasSocial {
  descripcion: string;
  id: number;
}
