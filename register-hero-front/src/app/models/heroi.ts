export interface SuperpoderDto {
  id: number;
  superpoder: string;
  descricao: string | null ;
}

export interface HeroiResponseDto {
  id: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento: string | null;
  altura: number;
  peso: number;
  superpoderes: SuperpoderDto[];
}
