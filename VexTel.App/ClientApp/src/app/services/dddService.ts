import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DDD } from '../models/ddd';

@Injectable({
  providedIn: 'root'
})

export class DDDService implements OnInit {
  private baseURL: string;

  public listDdds: DDD[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    // recuperar o endereço raiz do site
    this.baseURL = baseUrl;
  }

  ngOnInit(): void {
    this.listDdds = [];
  }

  public obterTodos(): Observable<DDD[]> {
    return this.http.get<DDD[]>(this.baseURL + 'api/ddds');
  }
}
