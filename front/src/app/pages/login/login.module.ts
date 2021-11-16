import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import {InputTextModule} from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import {CardModule} from 'primeng/card';
import { MessageService } from 'primeng/api';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    LoginRoutingModule,
    ReactiveFormsModule,
    PasswordModule,
    FormsModule,
    InputTextModule,
    ButtonModule,
    FormsModule,
    CardModule,
    MessagesModule,
    MessageModule
  ],
  providers:[MessageService]
})

export class LoginModule { }
