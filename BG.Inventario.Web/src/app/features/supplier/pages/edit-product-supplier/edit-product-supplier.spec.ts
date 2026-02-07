import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProductSupplier } from './edit-product-supplier';

describe('EditProductSupplier', () => {
  let component: EditProductSupplier;
  let fixture: ComponentFixture<EditProductSupplier>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditProductSupplier]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditProductSupplier);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
