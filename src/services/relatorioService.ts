import { api } from "./api"
import type { ResponseRelatorio } from "../types/relatorio"

export const getRelatorioCategoria = async (): Promise<ResponseRelatorio> => {
  const response = await api.get("/api/relatorio/GetRelatorioPorCategoria")
  return response.data
}

export const getRelatorioPessoa = async (): Promise<ResponseRelatorio> => {
  const response = await api.get("/api/relatorio/GetRelatorioPorPessoa")
  return response.data
}