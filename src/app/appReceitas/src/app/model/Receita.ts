import { Categoria } from "./Categoria"
import { Level } from "./Level"

export class Receita {
    totalItems?: number
    data?: any[]
}

export class data {
    id?: number
    ingredients?: string
    preparationMode?: string
    image?: string
    category?: Categoria
    level?: Level
}