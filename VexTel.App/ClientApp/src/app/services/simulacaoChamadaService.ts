import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SimulacaoChamada } from '../models/simulacaoChamada';

@Injectable({
  providedIn: 'root'
})

export class SimulacaoChamadaService implements OnInit {
  private baseURL: string;

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    // recuperar o endereço raiz do site
    this.baseURL = baseUrl;
  }

  ngOnInit(): void {
    
  }

  public simular(simulacaoChamada: SimulacaoChamada): Observable<SimulacaoChamada> {
    return this.http.post<SimulacaoChamada>(this.baseURL + 'api/simulacoes/simular', JSON.stringify(simulacaoChamada), { headers: this.headers });
  }
}
