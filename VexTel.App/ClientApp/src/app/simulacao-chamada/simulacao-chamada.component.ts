import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router';
import { DDD } from '../models/ddd';
import { DDDService } from '../services/dddService';
import { SimulacaoChamada } from '../models/simulacaoChamada';
import { SimulacaoChamadaService } from '../services/simulacaoChamadaService';
import { PlanoService } from '../services/planoService';
import { Plano } from '../models/plano';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-simulacao',
  templateUrl: './simulacao-chamada.component.html',
  styleUrls: ['./simulacao-chamada.component.css']
})

export class SimulacaoChamadaComponent implements OnInit {

  public listDdds: DDD[];
  public listPlanos: Plano[];
  public simulacaoChamada: SimulacaoChamada;
  public listSimulacao: SimulacaoChamada[];

  ngOnInit(): void {
    this.simulacaoChamada = new SimulacaoChamada();
    this.listSimulacao = [];
  }

  constructor(private dddService: DDDService,
    private simulacaoService: SimulacaoChamadaService,
    private planoService: PlanoService,
    private router: Router,
    private toast: ToastrService) {

    this.CarregarDdds();
    this.CarregarPlanos();
  }

  public CarregarDdds() {
    this.dddService.obterTodos()
      .subscribe(dataResult => {
        this.listDdds = dataResult;
      }, erro => {
        console.log(erro.error);
      });
  }

  public CarregarPlanos() {
    this.planoService.obterTodos()
      .subscribe(dataResult => {
        this.listPlanos = dataResult;
      }, erro => {
        console.log(erro.error);
      });
  }

  public simular() {
    this.simulacaoService.simular(this.simulacaoChamada)
      .subscribe(
        data_json => {
          console.log(data_json);
          if (this.listSimulacao.filter(x => x.dddOrigemId == this.simulacaoChamada.dddOrigemId &&
            x.dddDestinoId == this.simulacaoChamada.dddDestinoId &&
            x.tempo == this.simulacaoChamada.tempo)[0] == null)
            this.listSimulacao.push(data_json);
        },
        erro => {
          console.log(erro.error);
          this.toast.error(erro.error, "Erro!");
        });
  }

}
