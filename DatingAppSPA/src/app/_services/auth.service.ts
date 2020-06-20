import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { map } from "rxjs/operators";
@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl = 'http://localhost:49248/api/auth/';
constructor(private http: HttpClient) { }

login(model: any){
  const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };
  return this.http.post(this.baseUrl + 'login', model, httpOptions).pipe(
    map((response: any) => {
      const user = response;
      if (user){
        localStorage.setItem('token', user.token);
      }
    })
  );
}

register(model: any){
  return this.http.post(this.baseUrl+ 'register',model)
}
}
