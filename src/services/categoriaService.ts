import { api } from "./api"
import type { CreateCategoria, ResponseCategoria } from "../types/categoria"

export async function getCategorias(): Promise<ResponseCategoria[]> {
  const response = await api.get("/api/categoria")
  return response.data
}

export async function createCategoria(data: CreateCategoria) {
  const response = await api.post("/api/categoria", data)
  return response.data
}
