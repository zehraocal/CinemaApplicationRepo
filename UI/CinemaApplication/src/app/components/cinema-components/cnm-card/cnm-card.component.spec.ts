import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CnmCardComponent } from './cnm-card.component';

describe('CnmCardComponent', () => {
  let component: CnmCardComponent;
  let fixture: ComponentFixture<CnmCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CnmCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CnmCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
