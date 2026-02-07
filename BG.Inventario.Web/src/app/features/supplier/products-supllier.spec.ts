import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsSupllier } from './products-supllier';

describe('ProductsSupllier', () => {
  let component: ProductsSupllier;
  let fixture: ComponentFixture<ProductsSupllier>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductsSupllier]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductsSupllier);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
