import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadLivroComponent } from './cad-livro.component';

describe('CadLivroComponent', () => {
  let component: CadLivroComponent;
  let fixture: ComponentFixture<CadLivroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CadLivroComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadLivroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
