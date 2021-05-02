import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { ComponentsComponent } from './components/components.component';
import { LandingComponent } from './examples/landing/landing.component';
import { ProfileComponent } from './examples/profile/profile.component';
import { NucleoiconsComponent } from './components/nucleoicons/nucleoicons.component';
import { MoviehouseComponent } from './components/moviehouse/moviehouse.component';
import { MovieComponent } from './components/movie/movie.component';
import { SessionComponent } from './components/session/session.component';
import { VisionMovieComponent } from './components/vision-movie/vision-movie.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { MovieDetailComponent } from './components/movie-detail/movie-detail.component';
import { MovieTicketComponent } from './components/movie-ticket/movie-ticket.component';
import { LoginComponent } from './components/login/login.component';
import { AuthorizeGuard } from './guard/authorize.guard';
import { RecordComponent } from './components/record/record.component';


const routes: Routes =[
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'index',                component: ComponentsComponent },
    { path: 'login',                component: LoginComponent },
    { path: 'record',               component: RecordComponent },
    { path: 'moviehouse',           component: MoviehouseComponent},
    { path: 'movie',                component: MovieComponent },
    { path: 'session',              component: SessionComponent },
    { path: 'visionmovie',          component: VisionMovieComponent },
    { path: 'movie-list',           component: MovieListComponent },
    { path: 'movie-detail/:movieId',component: MovieDetailComponent },
    { path: 'movie-ticket/:movieId',component: MovieTicketComponent },
    { path: 'nucleoicons',          component: NucleoiconsComponent },
    { path: 'examples/landing',     component: LandingComponent },
    { path: 'examples/profile',     component: ProfileComponent }
];

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        RouterModule.forRoot(routes)
    ],
    exports: [
    ],
})
export class AppRoutingModule { }
