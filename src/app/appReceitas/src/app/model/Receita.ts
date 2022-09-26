import { Categoria } from "./Categoria"
import { Level } from "./Level"

export class Receita {
    totalItems?: number
    data?: any[]
}

export class data {
    id?: number
    name?: string
    ingredients?: string
    preparationMode?: string
    image?: string
    category?: Categoria
    level?: Level
}