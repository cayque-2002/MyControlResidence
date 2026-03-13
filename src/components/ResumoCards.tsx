export default function ResumoCards({ relatorio }:any){

  if(!relatorio) return null;

  return(

    <div className="report-totals">

      <div className="card-total receita">
        <span>Receitas</span>
        <strong>
          {relatorio.totalReceitas?.toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}
        </strong>
      </div>

      <div className="card-total despesa">
        <span>Despesas</span>
        <strong>
          {relatorio.totalDespesas?.toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}
        </strong>
      </div>

      <div className="card-total saldo">
        <span>Saldo</span>
        <strong>
          {relatorio.totalSaldo?.toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}
        </strong>
      </div>

    </div>
  )
}