import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ObraSocial } from '../interfaces/obra-social/obra-social.component';

@Injectable({
  providedIn: 'root' // Esto lo hace un servicio singleton en toda la app

})
export class ObraSocialService {
  private apiUrl = 'https://localhost:7094/obrasocial'; // Reemplaza esto con la URL de tu API

  constructor(private http: HttpClient) { }

  getObrasSociales(): Observable<ObraSocial[]> {
    return this.http.get<ObraSocial[]>(this.apiUrl);
  }
}
