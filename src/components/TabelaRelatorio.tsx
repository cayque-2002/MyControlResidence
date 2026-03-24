export default function TabelaRelatorio({ dados }:any){

  if(!dados) return null;

  return(

    <table className="tabela-relatorio">

      <thead>
        <tr>
          <th>Descrição</th>
          <th>Receita</th>
          <th>Despesa</th>
          <th>Saldo</th>
        </tr>
      </thead>

      <tbody>

        {dados.map((item:any,index:number)=>(
          <tr key={index}>

            <td>{item.chave}</td>

            <td className="valor-receita">
              {item.receita.toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}
            </td>

            <td className="valor-despesa">
              {item.despesas.toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}
            </td>

            <td className={item.saldo < 0 ? "saldo-negativo" : "saldo-positivo"}>
              {item.saldo.toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}
            </td>

          </tr>
        ))}

      </tbody>

    </table>

  )
}