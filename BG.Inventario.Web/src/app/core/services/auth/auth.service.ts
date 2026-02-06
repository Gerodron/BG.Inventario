import { inject, Injectable } from '@angular/core';
import { BaseResponseApi, IAuthRequest, IAuthResponse } from '../../interfaces/auth.interface';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private _http: HttpClient = inject(HttpClient);
  private url: string = 'http://localhost:5092'

  public loginUser(data: IAuthRequest): Observable<BaseResponseApi> {
    return this._http.post<BaseResponseApi>(`${this.url}/api/Auth/Login`, data)
  }

  public saveAuthDetails(data : IAuthResponse){
    sessionStorage.setItem("AUTH_USR", JSON.stringify(data));
  }

  public clearAuthDetails(){
    sessionStorage.removeItem("AUTH_USR");
  }

  public getAuthDetails() : string{
    return sessionStorage.getItem("AUTH_USR") ?? "{}";
  }

  public isAuthenticated(){
    const data = sessionStorage.getItem("AUTH_USR");
    return !!data;
  }

  public getTokenUser(){
    const authDetailsString = this.getAuthDetails();
    const {token} : IAuthResponse = JSON.parse(authDetailsString) as IAuthResponse;
    return token ?? "";
  }
}