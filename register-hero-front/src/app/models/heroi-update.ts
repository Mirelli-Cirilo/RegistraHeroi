export interface HeroiUpdateDto {
  nome: string;
  nomeHeroi: string;
  dataNascimento: string | null;
  altura: number;
  peso: number;
  superpoderesIds: number[];
}