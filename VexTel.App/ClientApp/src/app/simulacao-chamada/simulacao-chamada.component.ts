import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router';
import { DDD } from '../models/ddd';
import { DDDService } from '../services/dddService';
import { SimulacaoChamada } from '../models/simulacaoChamada';
import { simulacaoChamadaService } from '../services/simulacaoChamadaService';

@Component({
  selector: 'app-simulacao',
  templateUrl: './simulacao-chamada.component.html',
  styleUrls: ['./simulacao-chamada.component.css']
})

export class SimulacaoChamadaComponent implements OnInit {

  public listDdds: DDD[];
  public simulacaoChamada: SimulacaoChamada;

  ngOnInit(): void {

  }

  constructor(private dddService: DDDService, private simulacaoService: simulacaoChamadaService, private router: Router) {
    this.CarregarDdds();
  }

  public CarregarDdds() {
    this.dddService.obterTodos()
      .subscribe(dataResult => {
        this.listDdds = dataResult;
      }, erro => {
        console.log(erro.error);
      });
  }

  public simular() {
    this.simulacaoService.simular(this.simulacaoChamada)
      .subscribe(
        data_json => { },
        erro => { });
  }

}
