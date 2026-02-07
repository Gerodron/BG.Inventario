import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateProductSupplier } from './create-product-supplier';

describe('CreateProductSupplier', () => {
  let component: CreateProductSupplier;
  let fixture: ComponentFixture<CreateProductSupplier>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateProductSupplier]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateProductSupplier);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
