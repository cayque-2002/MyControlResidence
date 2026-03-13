export interface CreateTransacao{
  descricao:string
  valor:string | number
  tipo:number
  categoriaId:number
  pessoaId:number
}

export interface ResponseTransacao{
  id:number
  descricao:string
  valor:number
  tipo:number
  categoriaId:number
  pessoaId:number
  dataHoraCriacao:string
}