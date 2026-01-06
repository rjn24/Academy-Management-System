import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private apiUrl = 'https://localhost:7034/api/Courses';

  constructor(private http: HttpClient) {}

  getCourses(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addCourse(course: any): Observable<any> {
    return this.http.post(this.apiUrl, course);
  }

  updateCourse(code: string, course: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${code}`, course);
  }

  deleteCourse(code: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${code}`);
  }
}
