export interface CreateCategoria {
  descricao: string
  finalidade: number  
}

export interface ResponseCategoria {
  id: number
  descricao: string
  finalidade: number
  dataHoraCriacao: string
}
