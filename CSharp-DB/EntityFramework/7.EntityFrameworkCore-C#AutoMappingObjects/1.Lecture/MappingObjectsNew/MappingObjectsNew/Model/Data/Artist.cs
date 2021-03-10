using AutoMapper;
using MappingObjectsNew.ViewModels;
using System;
using System.Collections.Generic;

#nullable disable

namespace MappingObjectsNew.Model.Data
{
    public partial class Artist : IMapFrom<Artist>, IHaveCustomMapping
    {
        public Artist()
        {
            ArtistMetadata = new HashSet<ArtistMetadatum>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadatum> ArtistMetadata { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }

        public void CreateMapping(IProfileExpression configuration)
        {
            configuration.CreateMap<Artist, ArtistWithCount>();
        }
    }
}
