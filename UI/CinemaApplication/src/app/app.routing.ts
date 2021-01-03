import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { ComponentsComponent } from './components/components.component';
import { LandingComponent } from './examples/landing/landing.component';
import { LoginComponent } from './examples/login/login.component';
import { ProfileComponent } from './examples/profile/profile.component';
import { NucleoiconsComponent } from './components/nucleoicons/nucleoicons.component';
import { MoviehouseComponent } from './components/moviehouse/moviehouse.component';
import { MovieComponent } from './components/movie/movie.component';
import { SessionComponent } from './components/session/session.component';
import { VisionMovieComponent } from './components/vision-movie/vision-movie.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { MovieDetailComponent } from './components/movie-detail/movie-detail.component';
import { MovieTicketComponent } from './components/movie-ticket/movie-ticket.component';


const routes: Routes =[
    { path: '', redirectTo: 'index', pathMatch: 'full' },
    { path: 'index',                component: ComponentsComponent },
    { path: 'moviehouse',           component: MoviehouseComponent },
    { path: 'movie',                component: MovieComponent },
    { path: 'session',              component: SessionComponent },
    { path: 'visionmovie',          component: VisionMovieComponent },
    { path: 'movie-list',           component: MovieListComponent },
    { path: 'movie-detail/:movieId',component: MovieDetailComponent },
    { path: 'movie-ticket/:movieId',component: MovieTicketComponent },
    { path: 'nucleoicons',          component: NucleoiconsComponent },
    { path: 'examples/landing',     component: LandingComponent },
    { path: 'examples/login',       component: LoginComponent },
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
