import { useEffect, useState } from "react";
import { getRelatorioCategoria, getRelatorioPessoa } from "../services/relatorioService";

import ResumoCards from "../components/ResumoCards";
import TabelaRelatorio from "../components/TabelaRelatorio";


export default function ReportPage() {

  const [relatorioCategoria, setRelatorioCategoria] = useState<any>();
  const [relatorioPessoa, setRelatorioPessoa] = useState<any>();

  useEffect(() => {
    carregar();
  }, []);

  async function carregar() {

    const categoria = await getRelatorioCategoria();
    const pessoa = await getRelatorioPessoa();

    setRelatorioCategoria(categoria);
    setRelatorioPessoa(pessoa);
  }

  return (

    <div className="report-container">

      {/* RELATORIO CATEGORIA */}

      <h2 className="report-title">Relatório por Categoria</h2>

      <ResumoCards relatorio={relatorioCategoria} />

      <TabelaRelatorio dados={relatorioCategoria?.categoria} />


      {/* RELATORIO PESSOA */}

      <h2 className="report-title" style={{marginTop:"60px"}}>
        Relatório por Pessoa
      </h2>

      <ResumoCards relatorio={relatorioPessoa} />

      <TabelaRelatorio dados={relatorioPessoa?.pessoa} />

    </div>
  );
}