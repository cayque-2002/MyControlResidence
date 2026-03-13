export const FinalidadeCategoria = {
  Despesa: 0,
  Receita: 1,
  Ambas: 2
} as const


export type FinalidadeCategoriaType =
  typeof FinalidadeCategoria[keyof typeof FinalidadeCategoria]


  export const FinalidadeCategoriaTexto: Record<number,string> = {
  0: "Despesa",
  1: "Receita",
  2: "Ambas"
}