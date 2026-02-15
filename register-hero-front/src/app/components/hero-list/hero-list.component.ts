import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { HeroisService } from '../../services/herois.service';
import { HeroiListDto } from '../../models/heroi-list';

@Component({
  selector: 'app-hero-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css']
})
export class HeroListComponent implements OnInit {

  herois: HeroiListDto[] = [];
  loading = true;
  error: string | null = null;
  showModal = false;
  idParaExcluir: number | null = null;
  nomeParaExcluir: string = '';


  constructor(
    private heroisService: HeroisService,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.loadHerois();
  }

  loadHerois() {
    this.heroisService.getAll().subscribe({
      next: (data) => {
        this.herois = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('ERRO API:', err);
        this.loading = false;
      }
    });
  }

  details(id: number) {
  this.router.navigate(['/herois/detalhes', id]);
}

  edit(id: number) {
    this.router.navigate(['/herois/editar', id]);
  }
  
openDeleteModal(heroi: HeroiListDto) {
  this.showModal = true;
  this.idParaExcluir = heroi.id;
  this.nomeParaExcluir = heroi.nomeHeroi;
}

confirmDelete() {
  if (!this.idParaExcluir) return;

  this.heroisService.delete(this.idParaExcluir).subscribe({
    next: () => {
      this.herois = this.herois.filter(h => h.id !== this.idParaExcluir);
      this.closeModal();
    },
    error: () => {
      alert("Erro ao excluir.");
      this.closeModal();
    }
  });
}

closeModal() {
  this.showModal = false;
  this.idParaExcluir = null;
  this.nomeParaExcluir = '';
}
}
