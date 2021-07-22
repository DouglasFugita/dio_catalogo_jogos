using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required(ErrorMessage = "O nome do jogo eh obrigatorio")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome da produtora eh obrigatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required(ErrorMessage = "O preco do jogo eh obrigatorio")]
        [Range(1, 1000,ErrorMessage = "O preco do jogo deve ser entre R$ 1,00 e R$ 1.000,00")]
        public double Preco { get; set; }
    }
}
