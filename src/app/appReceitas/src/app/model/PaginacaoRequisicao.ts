export class PaginacaoRequisicao {
    pageSize!: number
    pageIndex!: number
    filter!: Filter
}

export class Filter {
    categoria!: string
    level!: string
    nome!: string
}
