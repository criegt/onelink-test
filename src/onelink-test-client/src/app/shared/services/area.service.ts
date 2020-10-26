import { Area } from './../models/area';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

  constructor(private http: HttpClient) { }

  getAreas(): Promise<Area[]> {
    return this.http.get<Area[]>('api/v1/areas').toPromise();
  }
}
