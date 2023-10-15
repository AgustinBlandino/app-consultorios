import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Turno } from '../interfaces/turno/turno.component';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TurnoService {
  private apiUrl = 'https://localhost:7094/turnos'; // Reemplaza esto con la URL de tu API


  constructor(private http: HttpClient) { }

  PostTurno(turno: Turno): Observable<HttpResponse<any>> {
    return this.http.post(this.apiUrl, turno, { observe: 'response' });
  }

  GetTurnoById(dni: number): Observable<HttpResponse<any>> {
    return this.http.get<Turno[]>(`${this.apiUrl}?dni=${dni}`, { observe: 'response' });
  }


}
