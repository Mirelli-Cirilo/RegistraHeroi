import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HeroiCreateDto } from '../models/heroi-create';
import { HeroiUpdateDto } from '../models/heroi-update';
import { HeroiResponseDto } from '../models/heroi';
import { HeroiListDto } from '../models/heroi-list';

@Injectable({
  providedIn: 'root'
})
export class HeroisService {

  private apiUrl = "http://localhost:5159/api/Herois";

  constructor(private http: HttpClient) {}

  getAll(): Observable<HeroiListDto[]> {
    return this.http.get<HeroiListDto[]>(this.apiUrl);
  }

  getById(id: number): Observable<HeroiResponseDto> {
    return this.http.get<HeroiResponseDto>(`${this.apiUrl}/${id}`);
  }

  create(dto: HeroiCreateDto): Observable<HeroiResponseDto> {
    return this.http.post<HeroiResponseDto>(this.apiUrl, dto);
  }

  update(id: number, dto: HeroiUpdateDto): Observable<HeroiResponseDto> {
    return this.http.put<HeroiResponseDto>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
  return this.http.delete<void>(`${this.apiUrl}/${id}`);
}
}