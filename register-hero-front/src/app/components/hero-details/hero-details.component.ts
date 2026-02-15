import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { HeroisService } from '../../services/herois.service';

@Component({
  selector: 'app-hero-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero-details.component.html',
  styleUrls: ['./hero-details.component.css']
})
export class HeroDetailsComponent implements OnInit {

  heroi: any = null;
  loading = true;
  error: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private heroisService: HeroisService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.error = 'ID inválido.';
      this.loading = false;
      return;
    }

    this.heroisService.getById(id).subscribe({
      next: (data) => {
        this.heroi = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Erro ao carregar detalhes do herói.';
        this.loading = false;
      }
    });
  }

  voltar() {
    this.router.navigate(['/herois']);
  }

  editar() {
    this.router.navigate(['/herois/editar', this.heroi.id]);
  }
}
