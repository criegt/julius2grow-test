import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { UserSigned } from '../models/user-signed';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {
  }

  async signIn(userName: string, password: string) {
    let user = { userName, password };

    console.log(user);

    let response = await this.http
      .post<UserSigned>('https://localhost:5001/api/v1/Users/SignIn', user)
      .toPromise();

    this.setSession(response);

    console.log(response);
  }

  async signUp(email: string, userName: string, password: string) {
    let user = { email, userName, password };

    console.log(user);

    let response = await this.http
      .post('https://localhost:5001/api/v1/Users/SignUp', user)
      .toPromise();

    console.log(response);
  }

  private setSession(userSigned: UserSigned) {
    const expiresAt = moment().add(userSigned.expiresIn, 'second');

    localStorage.setItem('id_token', userSigned.token);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
  }

  SignOut() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
  }

  public isSignedIn() {
    return moment().isBefore(this.getExpiration());
  }

  isSignOut() {
    return !this.isSignedIn();
  }

  getExpiration() {
    const expiration = localStorage.getItem("expires_at");
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
  }
}
