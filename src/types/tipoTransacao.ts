export const TipoTransacao = {
  Despesa: 0,
  Receita: 1
} as const

export const TipoTransacaoTexto: Record<number,string> = {
  0: "Despesa",
  1: "Receita"
}