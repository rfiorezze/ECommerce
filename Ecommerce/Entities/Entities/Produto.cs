﻿using Entities.Entities.Enums;
using Entities.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{

    [Table("TB_PRODUTO")]
    public class Produto : Notifies
    {
        [Column("PRD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PRD_NOME")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("PRD_DESCRICAO")]
        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Column("PRD_OBSERVACAO")]
        [Display(Name = "Observação")]
        [MaxLength(20000)]
        public string Observacao { get; set; }

        [Required]
        [Column("PRD_VALOR", TypeName = "decimal(16,2)")]
        [Display(Name = "Valor")]
        public Decimal Valor { get; set; }

        [Column("PRD_QTD_ESTOQUE")]
        [Display(Name = "Quantidade Estoque")]
        public int QtdEstoque { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        [Column("PRD_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Column("PRD_DATA_CADASTRO")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("PRD_DATA_ALTERACAO")]
        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        [NotMapped]
        public int IdProdutoCarrinho { get; set; }

        [NotMapped]
        [Display(Name = "Quantidade")]
        public int QtdCompra { get; set; }

        [NotMapped]
        [Display(Name = "Total")]
        public decimal ValorTotal { get; set; }

        [NotMapped]
        public IFormFile Imagem { get; set; }

        [Column("PDR_URL")]
        public string Url { get; set; }

        [Column("PDR_PROMOCAO")]
        [Display(Name = "Promoção")]
        public int Promocao { get; set; }

        [Display(Name = "Promoção aplicada")]
        [NotMapped]
        public string DescricaoPromocao { get; set; }
    }
}
