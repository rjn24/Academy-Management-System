import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

  private apiUrl = 'https://localhost:7034/api/Professors';

  constructor(private http: HttpClient) {}

  getProfessors(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addProfessor(prof: any): Observable<any> {
    return this.http.post(this.apiUrl, prof);
  }

  updateProfessor(id: number, prof: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, prof);
  }

  deleteProfessor(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
