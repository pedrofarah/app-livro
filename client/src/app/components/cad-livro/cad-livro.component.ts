import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { LivroService } from '../../services/livro.service';
import { LivroDto } from '../../dto/livro.dto';

@Component({
  selector: 'app-cad-livro',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './cad-livro.component.html',
  styleUrl: './cad-livro.component.css'

})
export class CadLivroComponent implements OnInit {

  livros: LivroDto[] = [];
  exibirTabela: boolean = true;
  exibirFormulario: boolean = false; 
  formulario: any;

  constructor(private livroService : LivroService) {}

  ngOnInit(): void {
    this.listarRegistros();
  }

  listarRegistros(): void {
    this.livroService.Get().subscribe((resultado) => {
      this.livros = resultado;
    });
  }

  novoRegistro(): void {
     this.exibirTabela = false;
     this.exibirFormulario = true;

    this.formulario = new FormGroup({
      id: new FormControl(null),
      titulo: new FormControl(null),
      autor: new FormControl(null),
      genero: new FormControl(null),
      ano: new FormControl(null),
    });
  }

  editarRegistro(livroObj: LivroDto): void {
    this.exibirTabela = false;
    this.exibirFormulario = true;
    
    this.livroService.GetById(livroObj.id).subscribe({
      next: (result: any) => {
        
        var registro =  result[0];

        this.formulario = new FormGroup({
          id: new FormControl(registro.id),
          titulo: new FormControl(registro.titulo),
          autor: new FormControl(registro.autor),
          genero: new FormControl(registro.genero),
          ano: new FormControl(registro.ano),
        });

      },
      error: (err) => {
        alert(err.mensagem);
      }
    });

  }  

  excluirRegistro(livroObj: LivroDto): void{

    if(confirm("Confirmar exclusão do registro?")) {
      this.livroService.Delete(livroObj.id)
        .subscribe({
          next: () => {
            this.listarRegistros();
          },
          error: (err) => {
            alert(err.mensagem);
          }
        });
    }

  }  

  gravarRegistro(): void {
    const livro: LivroDto = this.formulario.value;

    if (livro.id != null) {

      this.livroService.Put(livro).subscribe({
        next: () => {
          this.exibirTabela = true;
          this.exibirFormulario = false;
          alert("Registro gravado com sucesso.");
          this.listarRegistros();
        },
        error: (err) => {
          alert(err.mensagem);
        }
      });
    } else {

      this.livroService.Post(livro).subscribe({
        next: () => {
          this.exibirTabela = true;
          this.exibirFormulario = false;
          alert("Registro gravado com sucesso.");
          this.listarRegistros();
        },
        error: (err) => {
          alert(err.mensagem);
        }
      });
    }
  }  

  cancelar(): void{

    this.exibirTabela = true;
    this.exibirFormulario = false;            
    this.listarRegistros();

  }    

}
