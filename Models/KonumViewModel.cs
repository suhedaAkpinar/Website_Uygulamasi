using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UygulamaWebSıte.Models
{
    public class KonumViewModel
    {

       
            public int Id { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            [Display(Name = "Kategori  Seç")]
            public int KategoriId { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            [Display(Name = "Marka Seç")]
            public int MarkaId { get; set; }
        }
    }
