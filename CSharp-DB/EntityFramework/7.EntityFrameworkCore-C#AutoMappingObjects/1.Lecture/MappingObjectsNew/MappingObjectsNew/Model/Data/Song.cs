using AutoMapper;
using MappingObjectsNew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace MappingObjectsNew.Model.Data
{
    public partial class Song : IMapFrom<Song>, IHaveCustomMapping
    {
        public Song()
        {
            SongArtists = new HashSet<SongArtist>();
            SongMetadata = new HashSet<SongMetadatum>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }
        public string SearchTerms { get; set; }

        public virtual Source Source { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongMetadatum> SongMetadata { get; set; }

        public void CreateMapping(IProfileExpression configuration)
        {
            configuration.CreateMap<Song, SongViewModel>()
                      .ForMember(x => x.Artists,
                                 opt => opt.MapFrom(x => string.Join(", ", x.SongArtists.Select(y => y.Artist.Name))))
                      //Explanation -> for LastModified on use ModifiedOn if is null use CreatedOn
                      .ForMember(x => x.LastModified, opt => opt.MapFrom(x => x.ModifiedOn ?? x.CreatedOn));
        }
    }
}
