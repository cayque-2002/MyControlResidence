export interface CreatePessoa {
  nome: string
  idade: number  
}

export interface UpdatePessoa {
  nome: string
  idade: number  
}

export interface ResponsePessoa {
  id: number
  nome: string
  idade: number
  dataHoraCriacao: string
}
