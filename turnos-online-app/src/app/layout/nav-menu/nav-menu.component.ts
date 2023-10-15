import { Component, NgModule } from '@angular/core';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})

export class NavMenuComponent {
  selectedObraSocial = new FormControl(); // Crea una instancia de FormControl
  obrasSociales: any[] = [ // Define un array de objetos con propiedad 'descripcion'
    { descripcion: 'Obra Social 1' },
    { descripcion: 'Obra Social 2' },
    // Otros objetos
  ];
}
