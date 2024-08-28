using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PokemonDBSwagger.Models
{
    //Column for the table
    public class PokemonType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(8)]
        public string? TypeName { get; set; }
        public byte againstNormal { get; set; } = 0;
        public byte againstFire { get; set; } = 0;
        public byte againstWater { get; set; } = 0;
        public byte againstGrass { get; set; } = 0;
        public byte againstElectric { get; set; } = 0;
        public byte againstIce { get; set; } = 0;
        public byte againstFighting { get; set; } = 0;
        public byte againstPoison { get; set; } = 0;
        public byte againstGround { get; set; } = 0;
        public byte againstFlying { get; set; } = 0;
        public byte againstPsychic { get; set; } = 0;
        public byte againstBug { get; set; } = 0;
        public byte againstRock { get; set; } = 0;
        public byte againstGhost { get; set; } = 0;
        public byte againstDark { get; set; } = 0;
        public byte againstDragon { get; set; } = 0;
        public byte againstSteel { get; set; } = 0;
        public byte againstFairy { get; set; } = 0;
    }
}
