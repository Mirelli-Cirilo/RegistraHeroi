using RegisterHeroApi.DTOs.Heroi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterHeroApi.Services
{
    public interface IRegisterHeroService
    {
        Task<List<HeroiListDto>> GetAllAsync();
        Task<HeroiResponseDto> GetByIdAsync(int id);
        Task<HeroiResponseDto> CreateAsync(HeroiCreateDto dto);
        Task<HeroiResponseDto> UpdateAsync(int id, HeroiUpdateDto dto);
        Task DeleteAsync(int id);
    }
}