import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { 
  AbstractControl,
  FormBuilder, 
  FormGroup, 
  ReactiveFormsModule, 
  ValidationErrors,
  Validators 
} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HeroisService } from '../../services/herois.service';
import { SuperpoderService, SuperpoderDto } from '../../services/superpoder.service';
import { HeroiCreateDto } from '../../models/heroi-create';
import { HeroiUpdateDto } from '../../models/heroi-update';

@Component({
  selector: 'app-hero-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './hero-form.component.html',
  styleUrls: ['./hero-form.component.css']
})
export class HeroFormComponent implements OnInit {

  form: FormGroup;
  superpoderes: SuperpoderDto[] = [];
  idHeroi: number | null = null;
  apiError: string | null = null;

  constructor(
    private fb: FormBuilder,
    private heroisService: HeroisService,
    private superpoderService: SuperpoderService,
    public router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      nome: ['', Validators.required],
      nomeHeroi: ['', Validators.required],
      dataNascimento: ['', this.dataNaoPodeSerFutura],
      altura: ['', [Validators.required, Validators.min(0)]],
      peso: ['', [Validators.required, Validators.min(0)]],
      superpoderesIds: [[], Validators.required]
    });
  }

  dataNaoPodeSerFutura(control: AbstractControl): ValidationErrors | null {
    if (!control.value) return null;

    const data = new Date(control.value + "T00:00:00");
    const hoje = new Date();
    hoje.setHours(0, 0, 0, 0);

    return data > hoje ? { dataFutura: true } : null;
  }

  ngOnInit(): void {
    this.loadSuperpoderes();

    this.idHeroi = this.route.snapshot.params['id'];

    if (this.idHeroi) {
      this.heroisService.getById(this.idHeroi).subscribe(h => {

        const dataFormatada = h.dataNascimento
          ? new Date(h.dataNascimento).toISOString().split('T')[0]
          : '';

        this.form.patchValue({
          nome: h.nome,
          nomeHeroi: h.nomeHeroi,
          dataNascimento: dataFormatada,
          altura: h.altura,
          peso: h.peso,
          superpoderesIds: h.superpoderes.map(sp => sp.id)
        });
      });
    }
  }

  loadSuperpoderes() {
    this.superpoderService.getAll().subscribe(sp => this.superpoderes = sp);
  }

  onCheck(event: any) {
    const selected: number[] = this.form.value.superpoderesIds || [];
    const value = +event.target.value;

    if (event.target.checked) {
      if (!selected.includes(value)) selected.push(value);
    } else {
      const index = selected.indexOf(value);
      if (index > -1) selected.splice(index, 1);
    }

    this.form.patchValue({ superpoderesIds: selected });
  }

  submit() {
    this.apiError = null;

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const dto: HeroiCreateDto | HeroiUpdateDto = this.form.value;

    if (this.idHeroi) {
      this.heroisService.update(this.idHeroi, dto as HeroiUpdateDto).subscribe({
        next: () => this.router.navigate(['/herois']),
        error: (err) => {
          this.apiError = err.error?.mensagem || "Erro ao atualizar herói.";
          alert(this.apiError);
        }
      });
    } else {
      this.heroisService.create(dto as HeroiCreateDto).subscribe({
        next: () => this.router.navigate(['/herois']),
        error: (err) => {
          this.apiError = err.error?.mensagem || "Erro ao cadastrar herói.";
          alert(this.apiError);
        }
      });
    }
  }
}
