import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviehouseComponent } from './moviehouse.component';

describe('MoviehouseComponent', () => {
  let component: MoviehouseComponent;
  let fixture: ComponentFixture<MoviehouseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoviehouseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
