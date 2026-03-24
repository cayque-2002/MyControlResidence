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

      {/* TOTAL GERAL */}
      <h2 className="report-title">Total Geral</h2>

      <ResumoCards relatorio={relatorioPessoa} />

      {/* TABELA CATEGORIA */}
      <h3 style={{ marginTop: "50px" }}>Por Categoria</h3>
      <TabelaRelatorio dados={relatorioCategoria?.itens} />

      {/* TABELA PESSOA */}
      <h3 style={{ marginTop: "50px" }}>Por Pessoa</h3>
      <TabelaRelatorio dados={relatorioPessoa?.itens} />

    </div>
  );
}