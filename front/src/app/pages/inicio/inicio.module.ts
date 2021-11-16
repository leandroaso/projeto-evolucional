import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { InicioRoutingModule } from './inicio-routing.module';
import { InicioComponent } from './inicio.component';
import {ButtonModule} from 'primeng/button';
import { CardModule } from 'primeng/card';
import {MessagesModule} from 'primeng/messages';
import {MessageModule} from 'primeng/message';
import { MessageService } from 'primeng/api';
import {MenubarModule} from 'primeng/menubar';

@NgModule({
  declarations: [InicioComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InicioRoutingModule,
    ButtonModule,
    CardModule,
    MessagesModule,
    MessageModule,
    MenubarModule
  ],
  exports: [InicioComponent],
  providers:[MessageService]
})

export class InicioModule { }
