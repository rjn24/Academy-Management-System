import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {

  private apiUrl = 'https://localhost:7034/api/Auth/login';

  constructor(private http: HttpClient) {}

  login(data: any) {
  return this.http.post<any>('https://localhost:7034/api/Auth/login', data)
    .pipe(
      tap(res => localStorage.setItem('token', res.token))
    );
}

isLoggedIn(): boolean {
  return !!localStorage.getItem('token');
}

logout() {
  localStorage.removeItem('token');
}

}
