import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Atoliberacao } from '../../Model/atoLiberacao';


@Injectable({
  providedIn: 'root'
})
export class AtoLiberacaoService {

  private baseUrl = 'http://localhost:56599/api/Employee';

  constructor(private http: HttpClient) { }

  getAtoLiberacao(): Observable<Atoliberacao[]> {
    return this.http.get<Atoliberacao[]>(`${this.baseUrl}`);
  }

  createAtoLiberacao(ato: Atoliberacao): Observable<Atoliberacao> {
    return this.http.post<Atoliberacao>(`${this.baseUrl}`, ato);
  }

  getAtoLiberacaoById(id: string): Observable<Atoliberacao> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Atoliberacao>(url);
  }

  updateAtoLiberacao(id: string, employee: Atoliberacao): Observable<Atoliberacao> {
    return this.http.put<Atoliberacao>(`${this.baseUrl}/${id}`, employee);
  }

  deleteAtoLiberacao(id: string): Promise<any> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete(url).toPromise();
  }

}
