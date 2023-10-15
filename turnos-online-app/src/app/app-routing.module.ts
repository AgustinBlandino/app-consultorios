import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedirTurnoComponent } from './pages/pedir-turno/pedir-turno.component';
import { MisTurnosComponent } from './pages/mis-turnos/mis-turnos.component';
import { HomeComponent } from './layout/home/home.component';

const routes: Routes = [{
  path: 'pedir-turno', component: PedirTurnoComponent,
},
{
  path: 'mis-turnos', component: MisTurnosComponent
},
{
  path: 'home', component: HomeComponent
}]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
