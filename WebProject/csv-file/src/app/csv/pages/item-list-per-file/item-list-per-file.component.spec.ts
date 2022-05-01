import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemListPerFileComponent } from './item-list-per-file.component';

describe('ItemListPerFileComponent', () => {
  let component: ItemListPerFileComponent;
  let fixture: ComponentFixture<ItemListPerFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemListPerFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemListPerFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
