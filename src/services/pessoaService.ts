import { api } from "./api"
import type { CreatePessoa, UpdatePessoa, ResponsePessoa } from "../types/pessoa"

export async function getPessoas(): Promise<ResponsePessoa[]> {
  const response = await api.get("/api/pessoa")
  return response.data
}

export async function createPessoa(data: CreatePessoa) {
  const response = await api.post("/api/pessoa", data)
  return response.data
}

export async function updatePessoa(id: number, data: UpdatePessoa) {
  const response = await api.put(`/api/pessoa/${id}`, data)
  return response.data
}

export async function deletePessoa(id: number) {
  await api.delete(`/api/pessoa/${id}`)
}