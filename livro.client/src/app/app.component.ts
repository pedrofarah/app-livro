import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CadLivroComponent } from './components/cad-livro/cad-livro.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CadLivroComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Cadastro de Livros';
}
