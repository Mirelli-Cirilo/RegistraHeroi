import { Routes } from '@angular/router';
import { HeroListComponent } from './components/hero-list/hero-list.component';
import { HeroFormComponent } from './components/hero-form/hero-form.component';
import { HeroDetailsComponent } from './components/hero-details/hero-details.component';

export const routes: Routes = [
  { path: '', redirectTo: 'herois', pathMatch: 'full' },
  { path: 'herois', component: HeroListComponent },
  { path: 'herois/novo', component: HeroFormComponent },
  { path: 'herois/editar/:id', component: HeroFormComponent },
  { path: 'herois/detalhes/:id', component: HeroDetailsComponent },
];