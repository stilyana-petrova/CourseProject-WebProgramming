﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Data.Entities
{
    public class ProductArtist
    {
        [ForeignKey(nameof(Product))]

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(Artist))]

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
