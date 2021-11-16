import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public formulario: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    public route: ActivatedRoute,
    private service: LoginService,
    private messageService: MessageService
  ) {
  }

  ngOnInit() {
    this.criarFormulario();
    localStorage.clear();
  }

  private criarFormulario(): void {
    this.formulario = this.formBuilder.group({
      login: [null, Validators.required],
      senha: [null, Validators.required]
    });
  }

  public realizarLogin() {
    if (this.formulario.invalid) {
      this.formulario.get('login').markAsTouched();
      this.formulario.get('login').markAsDirty();
      this.formulario.get('senha').markAsTouched();
      this.formulario.get('senha').markAsDirty();
      return;
    }

    this.gerarToken(this.formulario.value);
  }

  private gerarToken(usuario): void {
    this.service.gerarToken(usuario).subscribe(
      (token) => {
        localStorage.setItem('evolucional.access_token', token);
        this.router.navigate(['inicio']);
      }, (errors) => {
        this.addAlerta('error', errors['error'])
      }
    );
  }

  public removerToken(): void {
    localStorage.removeItem('evolucional.access_token');
  }

  addAlerta(tipo: string, mensagem: string) {
    this.messageService.add({ severity: tipo, summary: mensagem });
    setTimeout(() => {
      this.messageService.clear();
    }, 3000);
  }

}
