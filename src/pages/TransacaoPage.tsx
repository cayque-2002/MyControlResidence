import { useEffect, useState } from "react"
import { toast } from "react-toastify"

import FormModal from "../components/FormModal"
import InputField from "../components/InputField"

import { getTransacoes, createTransacao } from "../services/transacaoService"
import { getPessoas } from "../services/pessoaService"
import { getCategorias } from "../services/categoriaService"

import type { ResponseTransacao, CreateTransacao } from "../types/transacao"
import { TipoTransacao, TipoTransacaoTexto } from "../types/tipoTransacao"

export default function TransacaoPage(){

  const [transacoes,setTransacoes] = useState<ResponseTransacao[]>([])

  const [pessoas,setPessoas] = useState<any[]>([])
  const [categorias,setCategorias] = useState<any[]>([])

  const [modal,setModal] = useState(false)

  const [descricao,setDescricao] = useState("")
  const [valor,setValor] = useState<number | "">("")
  const [tipo,setTipo] = useState(0)
  const [categoriaId,setCategoriaId] = useState(0)
  const [pessoaId,setPessoaId] = useState(0)

  useEffect(()=>{
    carregar()
  },[])

  async function carregar(){

    const transacoesApi = await getTransacoes()
    console.log(transacoesApi)

    const pessoasApi = await getPessoas()
    const categoriasApi = await getCategorias()

    setTransacoes(transacoesApi)
    setPessoas(pessoasApi)
    setCategorias(categoriasApi)

  }

  function abrirNovo(){

    setDescricao("")
    setValor(0)
    setTipo(TipoTransacao.Receita)
    setCategoriaId(0)
    setPessoaId(0)

    setModal(true)

  }

  async function salvar(){

    const payload:CreateTransacao = {
      descricao,
      valor,
      tipo,
      categoriaId,
      pessoaId
    }

    try{

      await createTransacao(payload)

      toast.success("Transação criada!")

      setModal(false)

      carregar()

    }catch{

      toast.error("Erro ao criar transação")

    }

  }

  return(

    <div className="table-container">

      <div className="crud-container">

        <h2>Transações</h2>

        <table className="crud-table">

          <thead>

            <tr>

              <th>Descrição</th>
              <th>Tipo</th>
              <th>Categoria</th>
              <th>Pessoa</th>
              <th>Valor</th>

            </tr>

          </thead>

          <tbody>

            {transacoes.map((t)=>(

              <tr key={t.id}>

                <td>{t.descricao}</td>

                <td>
                  {TipoTransacaoTexto[t.tipo]}
                </td>

                <td>
                  {categorias.find(c => c.id === t.categoriaId)?.descricao}
                </td>

                <td>
                  {pessoas.find(p => p.id === t.pessoaId)?.nome}
                </td>

                <td>
                  {t.valor?.toLocaleString("pt-BR",{
                    style:"currency",
                    currency:"BRL"
                  })}
                </td>

              </tr>

            ))}

          </tbody>

        </table>


        <div className="crud-footer">

          <button
            className="btn-novo"
            onClick={abrirNovo}
          >
            + Nova Transação
          </button>

        </div>


        <FormModal
          open={modal}
          onClose={()=>setModal(false)}
          title="Nova Transação"
        >

          <InputField
            label="Descrição"
            value={descricao}
            onChange={(e)=>setDescricao(e.target.value)}
          />


          <div className="input-field">

            <label>Tipo</label>

            <select
              value={tipo}
              onChange={(e)=>setTipo(Number(e.target.value))}
            >

              <option value={TipoTransacao.Receita}>
                Receita
              </option>

              <option value={TipoTransacao.Despesa}>
                Despesa
              </option>

            </select>

          </div>


          <div className="input-field">

            <label>Categoria</label>

            <select
              value={categoriaId}
              onChange={(e)=>setCategoriaId(Number(e.target.value))}
            >

              <option value={0}>Selecione</option>

              {categorias.map((c)=>(
                <option key={c.id} value={c.id}>
                  {c.descricao}
                </option>
              ))}

            </select>

          </div>


          <div className="input-field">

            <label>Pessoa</label>

            <select
              value={pessoaId}
              onChange={(e)=>setPessoaId(Number(e.target.value))}
            >

              <option value={0}>Selecione</option>

              {pessoas.map((p)=>(
                <option key={p.id} value={p.id}>
                  {p.nome}
                </option>
              ))}

            </select>

          </div>


          <InputField
            label="Valor"
            type="number"
            value={valor}
            onChange={(e)=>{
              const v = e.target.value
              setValor(v === "" ? "" : Number(v))
            }}
          />


          <div className="modal-footer">

            <button
              className="btn-cancelar"
              onClick={()=>setModal(false)}
            >
              Cancelar
            </button>

            <button
              className="btn-salvar"
              onClick={salvar}
            >
              Salvar
            </button>

          </div>

        </FormModal>

      </div>
    </div>

  )
}