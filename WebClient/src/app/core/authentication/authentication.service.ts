import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {LoginResponse} from "./models/login-response";
import {ApiPaths, environment} from "../../../environments/environment";
import {LoginRequest} from "./models/login-request";
import {shareReplay, tap} from "rxjs/operators";
import {RegisterRequest} from "./models/register-request";
import {RegisterResponse} from "./models/register-response";

@Injectable()
export class AuthenticationService {

  constructor(private httpClient: HttpClient) {

  }

  public login(username: string, password: string): Observable<LoginResponse> {
    let loginRequest: LoginRequest = {
      userName: username,
      password: password
    }

    console.log(environment.baseUrl)
    return this.httpClient
      .post<LoginResponse>(environment.baseUrl + ApiPaths.loginService,
        loginRequest)
      .pipe(tap(res => AuthenticationService.setSession(res)),
        shareReplay());
  }

  public register(registerRequest : RegisterRequest) {
    return this.httpClient
      .post<RegisterResponse>(environment.baseUrl + ApiPaths.registerService,
        registerRequest)
      .pipe(
        shareReplay());
  }

  private static setSession(loginResponse: LoginResponse) {
    const expiresAt = loginResponse.expires

    localStorage.setItem('id_token', loginResponse.jwtToken);
    localStorage.setItem("expires_at", expiresAt.toString());
  }

  public isLoggedIn() {
    const today = new Date();

    return this.getExpiration() >= today
  }

  getExpiration() : Date {
    const expiration = localStorage.getItem("expires_at") ?? "";

    return new Date(expiration);
  }

  logout() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
  }
}
