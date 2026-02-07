export class CreateProductModel {
    constructor(
        public name: string = '',
        public description: string = '',
        public statusProduct: string = 'Disponible',
        public stock: number = 0,
        public salePrice: number = 0
    ) {}
}