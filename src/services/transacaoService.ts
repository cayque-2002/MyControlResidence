import { api } from "./api"
import type { CreateTransacao } from "../types/transacao"

export async function getTransacoes(){
  const response = await api.get("/api/transacao")
  return response.data
}

export async function createTransacao(data:CreateTransacao){
  const response = await api.post("/api/transacao",data)
  return response.data
}