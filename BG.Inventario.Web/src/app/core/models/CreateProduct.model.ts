export class CreateProductModel {
    constructor(
        public name: string = '',
        public description: string = '',
        public status: string = 'disponible',
        public stock: number = 0,
        public salePrice: number = 0
    ) {}
}