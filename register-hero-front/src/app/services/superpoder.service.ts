import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface SuperpoderDto {
  id: number;
  superpoder: string;
  descricao: string;
}

@Injectable({
  providedIn: 'root'
})
export class SuperpoderService {

  private apiUrl = 'http://localhost:5159/api/Superpoderes';

  constructor(private http: HttpClient) { }

  getAll(): Observable<SuperpoderDto[]> {
    return this.http.get<SuperpoderDto[]>(this.apiUrl);
  }
}
