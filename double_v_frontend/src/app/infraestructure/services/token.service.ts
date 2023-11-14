import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';


@Injectable({
  providedIn: 'root',
})
export class TokenService {

  private http:HttpClient = inject(HttpClient);

  public addItemSessionStorage(key: string, value: string): void {
    sessionStorage.setItem(key, value);
  }

  public getItemSessionStorage(key: string): string | null {
    const item = sessionStorage.getItem(key);
    return item ? item : null;
  }

  public removeItemSessionStorage(key: string): void {
    sessionStorage.removeItem(key);
  }

  public removeItemsAllSessionStorage(): void {
    sessionStorage.clear();
  }

  public cerrarSesion(){
    this.removeItemsAllSessionStorage();
  }


  public checkSession(){
    const token = this.getItemSessionStorage("token");
    const headers = new HttpHeaders({
      'Authorization' : `Bearer ${token}`,
      'Content-Type': `application/json`
    })
    return this.http.get<any>(`${environment.api}/auth/checkSession`,{
      headers
    });
  }

}
