import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListProductSupplier } from './list-product-supplier';

describe('ListProductSupplier', () => {
  let component: ListProductSupplier;
  let fixture: ComponentFixture<ListProductSupplier>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListProductSupplier]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListProductSupplier);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
