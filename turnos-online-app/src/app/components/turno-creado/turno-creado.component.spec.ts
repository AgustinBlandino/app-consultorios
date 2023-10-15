import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnoCreadoComponent } from './turno-creado.component';

describe('TurnoCreadoComponent', () => {
  let component: TurnoCreadoComponent;
  let fixture: ComponentFixture<TurnoCreadoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TurnoCreadoComponent]
    });
    fixture = TestBed.createComponent(TurnoCreadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
