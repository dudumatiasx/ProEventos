using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         StringLength(50, MinimumLength = 4, ErrorMessage = "O campo {0} deve ter entre 4 e 50 caracteres.")]
        public string Tema { get; set; }

        [Display(Name = "Qtd Pessoas"),
         Range(2, 120000, ErrorMessage = "O campo {0} não pode ter menos de 2 e mais de 120000 pessoas.")]
        public int QtdPessoas { get; set; }

        [Display(Name = "Imagem do Evento"),
         Required(ErrorMessage = "O campo {0} é obrigatório."),
         FileExtensions(Extensions = "jpg,jpeg,png,bmp,gif", ErrorMessage = "Somente imagens são permitidas."),
         RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         Phone(ErrorMessage = "Telefone em formato inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}