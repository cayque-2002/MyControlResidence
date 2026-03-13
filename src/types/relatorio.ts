export interface TransacaoItem {
  valor: number
  tipo: number
  dataHoraCriacao: string
}

export interface TransacoesResumo {
  chave: string
  totalReceitas: number
  totalDespesas: number
  totalSaldo: number
  itens: TransacaoItem[]
}

export interface ResponseRelatorio {
  itens: TransacoesResumo[]
  totalReceitas: number
  totalDespesas: number
  totalSaldo: number
}