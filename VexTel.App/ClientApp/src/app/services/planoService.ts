import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Plano } from '../models/plano';

@Injectable({
  providedIn: 'root'
})

export class PlanoService implements OnInit {
  private baseURL: string;

  public listPlanos: Plano[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    // recuperar o endereço raiz do site
    this.baseURL = baseUrl;
  }

  ngOnInit(): void {
    this.listPlanos = [];
  }

  public obterTodos(): Observable<Plano[]> {
    return this.http.get<Plano[]>(this.baseURL + 'api/planos');
  }
}
