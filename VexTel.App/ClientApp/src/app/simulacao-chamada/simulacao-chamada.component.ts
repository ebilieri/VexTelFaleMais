import { Component, OnInit } from '@angular/core'
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
  public ativar_spinner;

  ngOnInit(): void {
    this.simulacaoChamada = new SimulacaoChamada();
   
  }

  constructor(private dddService: DDDService,
    private simulacaoService: SimulacaoChamadaService,
    private planoService: PlanoService,
    private toast: ToastrService) {

    this.listSimulacao = [];

    this.CarregarDdds();
    this.CarregarPlanos();
    this.obterSimulacaoSession();
  }

  public CarregarDdds() {
    this.dddService.obterTodos()
      .subscribe(dataResult => {
        this.listDdds = dataResult;
      }, erro => {
          console.log(erro.error);
          this.toast.error(erro.error, "Erro!");
      });
  }

  public CarregarPlanos() {
    this.planoService.obterTodos()
      .subscribe(dataResult => {
        this.listPlanos = dataResult;
      }, erro => {
          console.log(erro.error);
          this.toast.error(erro.error, "Erro!");
      });
  }

  public simular() {
    this.ativarSpinner();
    var listSimulacaoStorage = sessionStorage.getItem("simulacaoStorage");
    this.simulacaoService.simular(this.simulacaoChamada)
      .subscribe(
        data_json => {
          console.log(data_json);
         
          if (this.listSimulacao.filter(x => x.dddOrigemId == this.simulacaoChamada.dddOrigemId &&
            x.dddDestinoId == this.simulacaoChamada.dddDestinoId &&
            x.tempo == this.simulacaoChamada.tempo)[0] == null) {
            if (!listSimulacaoStorage) {
              this.listSimulacao.push(data_json);
            }
            else {
              this.listSimulacao = JSON.parse(listSimulacaoStorage);
              this.listSimulacao.push(data_json);
            }
            
            sessionStorage.setItem("simulacaoStorage", JSON.stringify(this.listSimulacao));
          }
          else
            this.toast.info("Plana já simulado.", "Info!");

          this.desativarSpinner();
        },
        erro => {
          console.log(erro.error);
          this.desativarSpinner();
          this.toast.error(erro.error, "Erro!");
        });
  }

  public obterSimulacaoSession(): SimulacaoChamada[] {
   
    var listSimulacaoStorage = sessionStorage.getItem("simulacaoStorage");

    if (listSimulacaoStorage)
      this.listSimulacao = JSON.parse(listSimulacaoStorage);

    return this.listSimulacao;
  }


  public ativarSpinner() {
    this.ativar_spinner = true;
  }

  public desativarSpinner() {
    this.ativar_spinner = false;
  }
}
