import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetItemsComponent } from './get-items.component';

describe('GetItemsComponent', () => {
  let component: GetItemsComponent;
  let fixture: ComponentFixture<GetItemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetItemsComponent]
    });
    fixture = TestBed.createComponent(GetItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
