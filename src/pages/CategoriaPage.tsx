import { useEffect, useState } from "react"
import FormModal from "../components/FormModal"
import InputField from "../components/InputField"
import { toast } from "react-toastify"

import {
  FinalidadeCategoria,
  FinalidadeCategoriaTexto
} from "../types/finalidadeCategoria"

import {
  getCategorias,
  createCategoria
} from "../services/categoriaService"

import type { ResponseCategoria, CreateCategoria } from "../types/categoria"

export default function CategoriaPage(){

  const [categorias,setCategorias] = useState<ResponseCategoria[]>([])

  const [modal,setModal] = useState(false)

  const [descricao,setDescricao] = useState("")
  const [finalidade,setFinalidade] = useState<number>(0)

  useEffect(()=>{
    carregar()
  },[])

  async function carregar(){

    const data = await getCategorias()

    setCategorias(data)
  }

  function abrirNovo(){

    setDescricao("")
    setFinalidade(FinalidadeCategoria.Despesa)

    setModal(true)
  }

  async function salvar(){

    const payload:CreateCategoria = {
      descricao,
      finalidade: finalidade
    }

    try{

      await createCategoria(payload)

      toast.success("Categoria criada com sucesso!")

      setModal(false)

      carregar()

    }catch{

      toast.error("Erro ao criar categoria")

    }

  }

  return(

    <div className="crud-container">

      <h2>Categorias</h2>

      <table className="crud-table">

        <thead>

          <tr>

            <th>Descrição</th>
            <th>Finalidade</th>

          </tr>

        </thead>

        <tbody>

          {categorias.map((categoria)=>(

            <tr key={categoria.id}>

              <td>{categoria.descricao}</td>

              <td>
                {FinalidadeCategoriaTexto[categoria.finalidade]}
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
          + Nova Categoria
        </button>

      </div>


      <FormModal
        open={modal}
        onClose={()=>setModal(false)}
        title="Nova Categoria"
      >

        <InputField
          label="Descrição"
          value={descricao}
          onChange={(e)=>setDescricao(e.target.value)}
        />

        <div className="input-field">

          <label>Finalidade</label>

          <select
            value={finalidade}
            onChange={(e)=>setFinalidade(Number(e.target.value))}
          >

            <option value={FinalidadeCategoria.Despesa}>
              Despesa
            </option>

            <option value={FinalidadeCategoria.Receita}>
              Receita
            </option>

            <option value={FinalidadeCategoria.Ambas}>
              Ambas
            </option>

          </select>

        </div>


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
  )
}