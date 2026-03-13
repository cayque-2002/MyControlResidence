import { useEffect, useState } from "react";
import "./PessoaPage.css";
import FormModal from "../components/FormModal";
import InputField from "../components/InputField";
import { getPessoas, createPessoa, updatePessoa, deletePessoa } from "../services/pessoaService";
import type { ResponsePessoa } from "../types/pessoa"

import { toast } from "react-toastify"


export default function PessoaPage(){

  const [pessoas, setPessoas] = useState<ResponsePessoa[]>([])
  const [modal,setModal] = useState(false)

  const [idade,setIdade] = useState<number>(0)

  const [editando,setEditando] = useState(false)
  const [id,setId] = useState(0)

  const [nome,setNome] = useState("")

  useEffect(()=>{
    carregar()
  },[])

  async function carregar(){
    const data = await getPessoas()
    setPessoas(data)
  }

  function abrirNovo(){
    setEditando(false)
    setNome("")
    setIdade(0)
    setModal(true)
  }

  function editarPessoa(pessoa:any){
    setEditando(true)
    setId(pessoa.id)
    setNome(pessoa.nome)
    setIdade(pessoa.idade)
    setModal(true)
  }

  async function salvar(){

    const payload = {
      nome,
      idade
    }

    if(editando){
      await updatePessoa(id,payload)
      toast.success("Pessoa editada com sucesso!")
    }else{
      await createPessoa(payload)
      toast.success("Pessoa criada com sucesso!")
    }

    setModal(false)
    carregar()
  }

  async function excluirPessoa(id:number){

    if(!confirm("Deseja excluir essa pessoa?")) return

    await deletePessoa(id)
    toast.success("Pessoa deletada com sucesso!")

    carregar()
  }

  return(

    <div className="crud-container">

      <h2>Pessoas</h2>

      <table className="crud-table">

        <thead>
          <tr>
            <th>Nome</th>
            <th>Idade</th>
            <th>Data Criação</th>
            <th>Ações</th>
          </tr>
        </thead>

        <tbody>

          {pessoas.map((pessoa) => (

            <tr key={pessoa.id}>

              <td>{pessoa.nome}</td>
              <td>{pessoa.idade}</td>
              <td>{new Date(pessoa.dataHoraCriacao).toLocaleDateString("pt-BR")}</td>

              <td className="acoes">

                <button
                  className="btn-editar"
                  onClick={() => editarPessoa(pessoa)}
                >
                  ✏
                </button>

                <button
                  className="btn-excluir"
                  onClick={() => excluirPessoa(pessoa.id)}
                >
                  🗑
                </button>

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
          + Nova Pessoa
        </button>

      </div>


      <FormModal
        open={modal}
        onClose={()=>setModal(false)}
        title={editando ? "Editar Pessoa" : "Nova Pessoa"}
      >

        <InputField
          label="Nome"
          value={nome}
          onChange={(e)=>setNome(e.target.value)}
        />

        <InputField
          label="Idade"
          type="number"
          value={idade}
          min={0}
          onChange={(e)=>setIdade(Number(e.target.value))}
        />

        <div className="modal-footer">

          <button
            className="btn-salvar"
            onClick={salvar}
          >
            Salvar
          </button>

          <button
            className="btn-cancelar"
            onClick={()=>setModal(false)}
          >
            Cancelar
          </button>

        </div>

      </FormModal>

    </div>
  )
}