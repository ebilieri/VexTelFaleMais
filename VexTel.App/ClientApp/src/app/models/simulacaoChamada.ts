import { DDD } from "./ddd";
import { Plano } from "./plano";

export class SimulacaoChamada {
  id: number;
  dddOrigemId: number;
  dddDestinoId: number;
  planoId: number;
  tempo: number;
  custoComFaleMais: number;
  custoSemFaleMais: number;
  dddOrigem: DDD;
  dddDestino: DDD;
  plano: Plano;
}
