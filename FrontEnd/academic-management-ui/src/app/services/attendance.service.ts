import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  private apiUrl = 'https://localhost:7034/api/Attendance';

  constructor(private http: HttpClient) {}

  getAttendance(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addAttendance(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  deleteAttendance(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
