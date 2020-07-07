import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { NouisliderModule } from 'ng2-nouislider';
import { JwBootstrapSwitchNg2Module } from 'jw-bootstrap-switch-ng2';
import { RouterModule } from '@angular/router';
import { BasicelementsComponent } from './basicelements/basicelements.component';
import { NavigationComponent } from './navigation/navigation.component';
import { TypographyComponent } from './typography/typography.component';
import { NucleoiconsComponent } from './nucleoicons/nucleoicons.component';
import { ComponentsComponent } from './components.component';
import { NotificationComponent } from './notification/notification.component';
import { NgbdModalBasic } from './modal/modal.component';
import { MoviehouseComponent } from './moviehouse/moviehouse.component';
import { PanelModule } from 'primeng/panel';
import { InputTextModule } from 'primeng/inputtext';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import {CalendarModule} from 'primeng/calendar';
import {DropdownModule} from 'primeng/dropdown';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {CarouselModule} from 'primeng/carousel';
import { CnmConfirmDialogComponent } from './cinema-components/cnm-confirm-dialog/cnm-confirm-dialog.component';
import { CnmModalComponent } from './cinema-components/cnm-modal/cnm-modal.component';
import { MovieComponent } from './movie/movie.component';
import { SessionComponent } from './session/session.component';
import { VisionMovieComponent } from './vision-movie/vision-movie.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        NgbModule,
        NouisliderModule,
        RouterModule,
        JwBootstrapSwitchNg2Module,
        PanelModule,
        InputTextModule,
        DialogModule,
        TableModule,
        ButtonModule,
        CalendarModule,
        DropdownModule,
        InputTextareaModule,
        CarouselModule
    ],
    declarations: [
        ComponentsComponent,
        BasicelementsComponent,
        NavigationComponent,
        TypographyComponent,
        NucleoiconsComponent,
        NotificationComponent,
        NgbdModalBasic,
        MoviehouseComponent,
        CnmConfirmDialogComponent,
        CnmModalComponent,
        MovieComponent,
        SessionComponent,
        VisionMovieComponent
    ],
    exports: [ComponentsComponent]
})
export class ComponentsModule { }
