import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MarksService {

  private apiUrl = 'https://localhost:7034/api/Marks';

  constructor(private http: HttpClient) {}

  getMarks(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addMarks(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  updateMarks(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  deleteMarks(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
