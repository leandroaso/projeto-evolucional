import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { InicioService } from './inicio.service';
import { Router } from '@angular/router';

@Component({
  selector: 'inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.scss']
})
export class InicioComponent implements OnInit {

  public formulario: FormGroup;
  public relarioBlob: Blob;
  constructor(
    private service: InicioService,
    private messageService: MessageService,
    private router: Router,
  ) { }

  ngOnInit() {
  }

  public botao1(): void {
    this.service.botao1().subscribe(() => {
      this.addAlerta('success', 'Processo concluído');
    })
  }

  public botao2(): void {
    this.service.botao2().subscribe((dados) => {
      this.relarioBlob = new Blob([dados]);
      this.addAlerta('success', 'Processo concluído');
    })
  }

  public logout(): void {
    this.router.navigate(['login']);
  }

  public download(): void {
    const fileName: string = `alunos-planilha.xlsx`;
    const objectUrl: string = URL.createObjectURL(this.relarioBlob);
    const a: HTMLAnchorElement = document.createElement('a') as HTMLAnchorElement;
    a.href = objectUrl;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(objectUrl);
  }

  addAlerta(tipo: string, mensagem: string) {
    this.messageService.add({ severity: tipo, summary: mensagem });
    setTimeout(() => {
      this.messageService.clear();
    }, 5000);
  }
}
